using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

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
            Debug.LogWarning($"Pool with tag {tag} doesn't exist!");
            return null;
        }

        var poolQueue = poolDictionary[tag];

        GameObject obj;

        if (poolQueue.Count == 0)
        {
            Pool poolConfig = pools.Find(p => p.tag == tag);
            if (poolConfig == null)
            {
                Debug.LogWarning($"No pool config found for tag {tag}");
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

