using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GooglePlayManager : MonoBehaviour {

    GameManagerScript GameManager;
    public bool ACH100;
    public bool ACH200;
    public bool ACH500;
    public bool ACH1000;
    public bool ACH5000;
    public bool SCORE;
    public bool mainMenu;

    void Start ()
    {
        if (!mainMenu) GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        
        //login
        Social.localUser.Authenticate((bool success) => {
            
        });
        
    }

    public void postInfinityScore()
    {
        Social.ReportScore(GameManager.score, "CgkImp-w7uYcEAIQCQ", (bool success) => {
            // handle success or failure
        });

        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkImp-w7uYcEAIQCQ");
        
    }

    public void showAchivments()
    {
        Social.ShowAchievementsUI();
    }

    public void showLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }


    void Update ()
    {
        if(!mainMenu)
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


            if (GameManager.timeTillEnd <= 0 && !SCORE)
            {
                SCORE = true;
                Social.ReportScore(GameManager.score, "CgkImp-w7uYcEAIQBg", (bool success) => {
                    // handle success or failure
                });

                ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkImp-w7uYcEAIQBg");

                SceneManager.LoadScene("mainMenu");


            }
        }

	    
    }
}
