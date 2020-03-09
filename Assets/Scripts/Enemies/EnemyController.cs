using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    #region Singleton
    Player PlayerInstance;
    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms
    [HideInInspector]
    public Transform t_Target;
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
    [SerializeField]
    Image LifeBar;
    #endregion

    #region Others
    NavMeshAgent agt_CurrentAgent;
    [SerializeField]
    public Mob mob;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        agt_CurrentAgent = GetComponent<NavMeshAgent>();
        agt_CurrentAgent.speed = mob.Speed;

        StartCoroutine(FillWithTime(LifeBar, mob.Lifetime));

        PlayerInstance = ThirdPersonCharacterController.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (agt_CurrentAgent.enabled)
        {
            agt_CurrentAgent.SetDestination(t_Target.position);
        }
       
    }
    #endregion

    #region Methods
    #endregion

    #region Collisons And Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInstance.Health -= mob.Attack;
        }
    }
    #endregion

    #region Coroutines

    IEnumerator FillWithTime(Image img, float sec)
    {
        float counter = sec;

        while (counter >= 0)
        {
            
            counter -= Time.deltaTime;
            img.fillAmount = counter / sec;
            yield return null;
        }

        Destroy(gameObject);
    }

        #endregion
}
