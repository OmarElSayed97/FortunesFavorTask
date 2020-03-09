using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    Player PlayerInstance;
    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats
    public static int i_MobsSpawned = 0;
    private float TimeLasted;
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
    TextMeshProUGUI TimeText;
    [SerializeField]
    GameObject GameOverPanel;
    [SerializeField]
    TextMeshProUGUI Score;
    [SerializeField]
    TextMeshProUGUI HighScore;
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        i_MobsSpawned = 0;
        TimeLasted = 0;
        PlayerInstance = ThirdPersonCharacterController.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
        GameOver();
        
    }
    #endregion

    #region Methods
    void CountScore()
    {
        TimeLasted += Time.deltaTime;
        TimeText.text = "Time: " + (int)TimeLasted;
    }
    void GameOver()
    {
        if (PlayerInstance.Health <= 0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            Score.text = "YOUR SCORE: " + (int)TimeLasted;
            if(PlayerPrefs.GetInt("Highscore",0) < (int)TimeLasted)
            {
                PlayerPrefs.SetInt("Highscore", (int)TimeLasted);
                HighScore.text = "HIGHSCORE IS: " + (int)TimeLasted;
            }
            else
            {
                HighScore.text = "HIGHSCORE IS: " + PlayerPrefs.GetInt("Highscore",0);
            }
               
        }
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
