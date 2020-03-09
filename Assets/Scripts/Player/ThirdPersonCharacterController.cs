using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField]
    float Speed;

    [SerializeField]
    float JumpForce;

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
    private Rigidbody rb;
    [SerializeField]
    public Player Player;
    [SerializeField]
    public TrailRenderer trail;
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
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (IsGrounded)
            {
                rb.AddForce(new Vector3(0, 2, 0) * JumpForce, ForceMode.Impulse);
                IsGrounded = false;
            }
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
