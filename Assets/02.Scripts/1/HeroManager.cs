using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : Singleton<HeroManager>
{
    public List<HeroData> heroList; 
    public List<HeroSlot> heroSlots; 
    public List<Transform> heroSpawnPositions; 

    private Player player;

    //private void Start()
    //{
    //    player = FindObjectOfType<Player>();
    //    RefreshAllSlots();

    //}
    private void Start()
    {
        player = FindObjectOfType<Player>();

        foreach (var hero in heroList)
        {
            hero.level = 0;
            hero.isUnlocked = false;
        }

        RefreshAllSlots();
    }

    public void OnHeroUnlocked(int heroId)
    {
        HeroData hero = heroList.Find(h => h.id == heroId);
        if (hero != null)
        {
            SpawnHero(hero);
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
            Debug.LogWarning($"[HeroManager] 유효하지 않은 영웅 스폰 위치 - id:{data.id}");
            return;
        }

        Transform spawnPoint = heroSpawnPositions[index];
        GameObject go = Instantiate(data.heroPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        HeroAttack attack = go.GetComponent<HeroAttack>();
        if (attack != null)
        {
            attack.Init(data);
        }

        Debug.Log($"[HeroManager] {data.heroName} 스폰 완료");
    }
}





