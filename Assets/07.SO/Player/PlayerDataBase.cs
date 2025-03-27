using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataBase", menuName = "NewPlayer")]
public class PlayerDataBase : ScriptableObject
{
    public int atkLevel = 1;
    public int critLevel = 1;
    public int critDamageLevel = 1;
    public int gainGoldLevel = 1;
}
