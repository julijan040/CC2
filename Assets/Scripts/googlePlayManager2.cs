using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class googlePlayManager2 : MonoBehaviour
{

    GameManagerScript GameManager;
    public bool ACH100;
    public bool ACH200;
    public bool ACH500;
    public bool ACH1000;
    public bool ACH5000;
    public bool SCORE;
    public bool mainMenu;

    void Start()
    {
        if (!mainMenu) GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        //login
        Social.localUser.Authenticate((bool success) => {

        });

    }

    

    void Update()
    {
        if (!mainMenu)
        {
            if (GameManager.score >= 100 && !ACH100)
            {
                ACH100 = true;
                Social.ReportProgress("CgkImp-w7uYcEAIQAQ", 100.0f, (bool success) =>
                {
                    //succes
                });

            }

            if (GameManager.score >= 200 && !ACH500)
            {
                ACH200 = true;
                Social.ReportProgress("CgkImp-w7uYcEAIQAg", 100.0f, (bool success) =>
                {
                    //succes
                });

            }

            if (GameManager.score >= 500 && !ACH500)
            {
                ACH500 = true;
                Social.ReportProgress("CgkImp-w7uYcEAIQAw", 100.0f, (bool success) =>
                {
                    //succes
                });

            }

            if (GameManager.score >= 1000 && !ACH1000)
            {
                ACH1000 = true;
                Social.ReportProgress("CgkImp-w7uYcEAIQBA", 100.0f, (bool success) =>
                {
                    //succes
                });

            }

            if (GameManager.score >= 5000 && !ACH5000)
            {
                ACH5000 = true;
                Social.ReportProgress("CgkImp-w7uYcEAIQBQ", 100.0f, (bool success) =>
                {
                    //succes
                });

            }


            if (GameManager.timeTillEnd <= 0 && !SCORE && !mainMenu)
            {

                SCORE = true;
                Social.ReportScore(GameManager.score, "CgkImp-w7uYcEAIQCg", (bool success) => {
                    // handle success or failure
                });

                ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkImp-w7uYcEAIQCg");

                SceneManager.LoadScene("mainMenu");




            }
        }


    }
}
