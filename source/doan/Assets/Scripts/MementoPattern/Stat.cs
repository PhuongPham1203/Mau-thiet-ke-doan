using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPlayer", menuName = "ScriptableObjects/StatPlayer", order = 1)]

public class Stat : ScriptableObject  
{
    
    public float hp;
    public int money;
    public int score;
}
