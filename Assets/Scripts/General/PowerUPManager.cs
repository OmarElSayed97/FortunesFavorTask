using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPManager : MonoBehaviour
{
    #region Singleton
    Player PlayerInstance;
    #endregion

    #region Variables

    #region Booleans
    private bool IsPowerUpEnabled;
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
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyPowerUp", 3f);
        PlayerInstance = ThirdPersonCharacterController.Instance.Player;
    }

   
   
    #endregion

    #region Methods
    void DestroyPowerUp()
    {
        if(!IsPowerUpEnabled)
            Destroy(gameObject);
    }
    #endregion

    #region Collisons And Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (gameObject.CompareTag("Speed"))
                StartCoroutine(SpeedPowerUp());
            if (gameObject.CompareTag("Health"))
            { 
                PlayerInstance.Health += 5;
                if (PlayerInstance.Health > PlayerInstance.HP)
                    PlayerInstance.Health = PlayerInstance.HP;
                Destroy(gameObject);
            }
                


            ;
        }
    }
    #endregion

    #region Coroutines
    IEnumerator SpeedPowerUp()
    {
        IsPowerUpEnabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        PlayerInstance.CurrentSpeed = PlayerInstance.Speed * 2;
        ThirdPersonCharacterController.Instance.trail.enabled = true;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        ThirdPersonCharacterController.Instance.trail.enabled = false;
        PlayerInstance.CurrentSpeed = PlayerInstance.Speed;
        
    }
    #endregion
}
