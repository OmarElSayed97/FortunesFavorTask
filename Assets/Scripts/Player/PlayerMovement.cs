using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    private Rigidbody rb_PlayerRigidBody;
    #endregion

    #endregion

    #region Main Methods
    // Start is called before the first frame update


    void Awake()
    {
        rb_PlayerRigidBody = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
       
        Turning();
    }
    #endregion

    #region Methods

  


    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, 100, 1))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb_PlayerRigidBody.MoveRotation(newRotation);
        }
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
