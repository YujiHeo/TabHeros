using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroManager : Singleton<HeroManager>
{
    public List<HeroData> heroList; 
    public List<HeroSlot> heroSlots; 
    public List<Transform> heroSpawnPositions; 

    private Player player;

    private void Awake()
    {
        // StartScene에서는 HeroManager가 비활성화되도록 설정
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Debug.Log("[HeroManager] StartScene에서는 활성화되지 않습니다.");
            gameObject.SetActive(false);
            return;
        }

        // 기존 초기화 코드 유지
        InitializeHeroList();
    }

    private void InitializeHeroList()
    {
        if (heroList == null)
        {
            heroList = new List<HeroData>(); // heroList가 null이면 초기화
        }

        // 기본 영웅 데이터 추가
        heroList.Add(new HeroData { isUnlocked = true, level = 1 });
        heroList.Add(new HeroData { isUnlocked = false, level = 1 });
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();

        HeroSaveData save = SaveLoadManager.instance.heroData;
        if (save != null)
        {
            LoadHeroSaveData(save); 
        }
        else
        {
           
            foreach (var hero in heroList)
            {
                hero.level = 0;
                hero.isUnlocked = false;
            }
        }

        RefreshAllSlots();

       
        foreach (var hero in heroList)
        {
            if (hero.isUnlocked)
            {
                SpawnHero(hero);
            }
        }
    }


    public void OnHeroUnlocked(int heroId)
    {
        HeroData hero = heroList.Find(h => h.id == heroId);
        if (hero != null)
        {
            SpawnHero(hero);

            SaveLoadManager.instance.SaveAllData();
        }
    }

    public void RefreshAllSlots()
    {
        for (int i = 0; i < heroSlots.Count; i++)
        {
            bool isLocked = (i > 0 && !heroList[i - 1].isUnlocked); 
            heroSlots[i].SetData(heroList[i], isLocked, player);
        }
    }

    public void SpawnHero(HeroData data)
    {
        int index = heroList.IndexOf(data);
        if (index < 0 || index >= heroSpawnPositions.Count)
        {
            Debug.LogWarning($"[HeroManager] ��ȿ���� ���� ���� ���� ��ġ - id:{data.id}");
            return;
        }

        Transform spawnPoint = heroSpawnPositions[index];
        GameObject go = Instantiate(data.heroPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        HeroAttack attack = go.GetComponent<HeroAttack>();
        if (attack != null)
        {
            attack.Init(data);
        }

        Debug.Log($"[HeroManager] {data.heroName} ���� �Ϸ�");
    }
    public HeroSaveData GetHeroSaveData()
    {
        if (heroList == null || heroList.Count == 0)
        {
            Debug.LogError("[HeroManager] heroList가 null이거나 비어 있습니다. 저장 데이터를 반환할 수 없습니다.");
            return null;
        }

        HeroSaveData saveData = new HeroSaveData();

        for (int i = 0; i < heroList.Count; i++)
        {
            saveData.isUnlocked[i] = heroList[i].isUnlocked;
            saveData.heroLevel[i] = heroList[i].level;
        }

        return saveData;
    }
    public void LoadHeroSaveData(HeroSaveData saveData)
    {
        for (int i = 0; i < heroList.Count; i++)
        {
            heroList[i].isUnlocked = saveData.isUnlocked[i];
            heroList[i].level = saveData.heroLevel[i];
        }

        RefreshAllSlots();
    }
    public void SaveHeroData()
    {
        SaveLoadManager.instance.heroData = GetHeroSaveData();
    }

}





