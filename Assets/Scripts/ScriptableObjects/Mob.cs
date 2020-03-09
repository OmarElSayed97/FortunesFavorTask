using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMob", menuName = "Mob", order = 2)]
public class Mob : Unit
{
    public enum EnemyType
    {
        LEVEL1,
        LEVEL2,
        LEVEL3
    }
    [SerializeField]
    public EnemyType MobType;
}
