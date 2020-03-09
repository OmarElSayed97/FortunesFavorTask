using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player", order = 1)]
public class Player : Unit
{
    [HideInInspector]
    public int Health;

    [HideInInspector]
    public int CurrentSpeed;
    private void Awake()
    {
        Lifetime = Mathf.Infinity;
        
    }
}


