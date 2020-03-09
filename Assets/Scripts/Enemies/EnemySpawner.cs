using UnityEngine.AI;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats
    #endregion

    #region Strings And Enums

    #endregion

    #region Lists
    #endregion

    #region Public GameObjects
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    #endregion

    #region Others
    private Mob SpawnerMob;
    #endregion

    #region Inspector Variables
    [SerializeField]
    GameObject[] l_go_EnemyPrefabs;


    [Header("Spawn Location On Zaxis & Xaxis")]

    [SerializeField]
    [Range(-20, 20)]
    float f_min;

    [SerializeField]
    [Range(-20, 20)]
    float f_max;

    [Header("SpawnTiming")]
    [SerializeField]
    [Range(0, 20)]
    float f_Tmin;

    [SerializeField]
    [Range(1, 20)]
    float f_Tmax;

    [SerializeField]
    Transform t_EnemyTarget;

    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        GameManager.i_MobsSpawned = 0;
        Invoke("OrganizeEnemies", Random.Range(f_Tmin, f_Tmax));
        SpawnerMob = l_go_EnemyPrefabs[0].GetComponent<EnemyController>().mob;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Methods
    void OrganizeEnemies()
    {
        
        if(SpawnerMob.MobType == Mob.EnemyType.LEVEL1)
        {
          
            if(GameManager.i_MobsSpawned < 5)
            {
                SpawnEnemy();
            }
            float Delay = Random.Range(f_Tmin, f_Tmax);
            Invoke("OrganizeEnemies", Delay);
        }

        if (SpawnerMob.MobType == Mob.EnemyType.LEVEL2)
        {

            if (GameManager.i_MobsSpawned < 10 && GameManager.i_MobsSpawned >= 5)
            {
                SpawnEnemy();
            }
            float Delay = Random.Range(f_Tmin, f_Tmax);
            Invoke("OrganizeEnemies", Delay);
        }

        if (SpawnerMob.MobType == Mob.EnemyType.LEVEL3)
        {
           
            if (GameManager.i_MobsSpawned >= 10)
            {
                SpawnEnemy();
            }
            float Delay = Random.Range(f_Tmin, f_Tmax);
            Invoke("OrganizeEnemies", Delay);
        }
        

    }

    void SpawnEnemy()
    {
        float RandomZ = Random.Range(f_min, f_max);
        int RandomEnemy = Random.Range(0, l_go_EnemyPrefabs.Length);
        Vector3 EnemyPos = new Vector3(transform.position.x + RandomZ, transform.position.y, transform.position.z + RandomZ);
        GameObject NewEnemy = Instantiate(l_go_EnemyPrefabs[RandomEnemy], EnemyPos, new Quaternion(0, 0, 0, 0));
        NewEnemy.transform.SetParent(transform);
        NewEnemy.GetComponent<NavMeshAgent>().SetDestination(t_EnemyTarget.position);
        NewEnemy.GetComponent<EnemyController>().t_Target = t_EnemyTarget;
        GameManager.i_MobsSpawned++;
        
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
