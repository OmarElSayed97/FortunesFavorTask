using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Unit : ScriptableObject
{
    [SerializeField]
    public int HP;
    [SerializeField]
    public int Attack;
    [SerializeField]
    public float Lifetime;
    [SerializeField]
    public int Speed;
}
