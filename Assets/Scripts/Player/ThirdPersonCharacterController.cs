using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ThirdPersonCharacterController : MonoBehaviour
{

    #region Singleton
    public static ThirdPersonCharacterController Instance;
    
    #endregion

    #region Variables

    #region Booleans

    private bool IsGrounded = true;

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
    [SerializeField]
    Image LifeBar;
    #endregion

    #region Others
    private Rigidbody rb_PlayerRigidBody;
    [SerializeField]
    public Player Player;
    [SerializeField]
    public TrailRenderer trail;
    [SerializeField]
    Plane TargetPlane;
    NavMeshAgent PlayerAgent;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Player.Health = Player.HP;
        Player.CurrentSpeed = Player.Speed;
    }
    void Start()
    {
        PlayerAgent = GetComponent<NavMeshAgent>();
        rb_PlayerRigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAgent.speed = Player.CurrentSpeed;
        ClickMove();
        Turning();
        FillBar(LifeBar, Player.Health, Player.HP);
    }
    #endregion

    #region Methods
    void Move()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 playerMovement = new Vector3(horizontal, 0, vertical).normalized * Player.CurrentSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    void ClickMove()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(ray, out floorHit, 100, 1))
            {
                PlayerAgent.SetDestination(floorHit.point);
            }
            
        }
    }

    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(ray, out floorHit, 100, 1))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb_PlayerRigidBody.MoveRotation(newRotation);
        }
    }


    void FillBar(Image img, int value, int originalValue)
    {
        float newValue = (float)value / originalValue;
        img.fillAmount = newValue;
    }
    #endregion

    #region Collisons And Triggers
    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }
    #endregion

    #region Coroutines
    #endregion

   
   
    // Update is called once per frame


  

   

   

   
}
