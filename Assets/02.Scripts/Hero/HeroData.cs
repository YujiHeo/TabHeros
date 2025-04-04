using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "Hero System/Hero Data")]
public class HeroData : ScriptableObject
{
    public int id;
    public string heroName;
    public Sprite heroIcon;
    public int baseDamage;
    public int unlockPrice;
    public GameObject heroPrefab;
    public float attackInterval;
    public bool isFlipped; //�¿������ �����

   
    [HideInInspector] public bool isUnlocked;
    [HideInInspector] public int level = 1;
}
