using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [System.Serializable]
    public class Pool
    {
        public string tag; //오브젝트 구분용 키
        public GameObject prefab; //생성할 프리펩 ex)이펙트
        public int size; //미리 만들어둘 개수
    }

    public List<Pool> pools; 
    private Dictionary<string, Queue<GameObject>> poolDictionary; //태그별로 저장하는 딕셔너리

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, float disableTime = 1f)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"태그가 {tag}인풀이 없습니다.");
            return null;
        }

        var poolQueue = poolDictionary[tag];

        GameObject obj;

        if (poolQueue.Count == 0)
        {
            Pool poolConfig = pools.Find(p => p.tag == tag);
            if (poolConfig == null)
            {
                Debug.LogWarning($"{tag}에 풀이 없습니다.");
                return null;
            }

            obj = Instantiate(poolConfig.prefab);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }

        obj = poolQueue.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        StartCoroutine(DisableAfterTime(obj, tag, disableTime));
        return obj;
    }

    private System.Collections.IEnumerator DisableAfterTime(GameObject obj, string tag, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }
}

