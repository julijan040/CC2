using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Advertisements;


public class reklam : MonoBehaviour
{

    // Use this for initialization
    //Dictionary<string, object> values;

    //public static bool pogledalDoKonca;
    //public static bool kliknil;
    [SerializeField]
    string iosGameId;
    [SerializeField]
    string androidGameId;
    [SerializeField]
    bool enableTestMode;

    void Start()
    {
        /*
        //Your App IDs can be found in the Vungle Dashboard on your apps' pages
        Vungle.init("56f454ab7c4a036e69000018", "Test_iOS", "56db21cda81e752f63000013");


        Vungle.adPlayableEvent += (isAdAvailable) => {
            if (isAdAvailable)
            {
                Debug.Log("An ad is ready to show!");
            }
            else {
                Debug.Log("No ad is available at this moment.");
            }
        };

        Vungle.onAdFinishedEvent += (clas) =>
        {

            Debug.Log("noter sem");
            if (clas.WasCallToActionClicked)
            {
                kliknil = true;
                Debug.Log("kliknil");
            }
            else if (clas.IsCompletedView)
            {
                pogledalDoKonca = true;
                Debug.Log("pogledal sem vse");
            }
        };



        Vungle.onAdStartedEvent += () =>
        {
            Debug.Log("startalo reklamo");
        };




        //onAdFinishedEvent = OnPogledalReklamo;


        values = new Dictionary<string, object>();
        values.Add("large", true);*/
        string gameId = null;

#if UNITY_IOS // If build platform is set to iOS...
        gameId = iosGameId;
#elif UNITY_ANDROID // Else if build platform is set to Android...
        gameId = androidGameId;
#endif

        if (string.IsNullOrEmpty(gameId))
        { // Make sure the Game ID is set.
            Debug.LogError("Failed to initialize Unity Ads. Game ID is null or empty.");
        }
        else if (!Advertisement.isSupported)
        {
            Debug.LogWarning("Unable to initialize Unity Ads. Platform not supported.");
        }
        else if (Advertisement.isInitialized)
        {
            Debug.Log("Unity Ads is already initialized.");
        }
        else {
            Debug.Log(string.Format("Initialize Unity Ads using Game ID {0} with Test Mode {1}.",
                gameId, enableTestMode ? "enabled" : "disabled"));
            Advertisement.Initialize(gameId, enableTestMode);
        }

    }

    private void Vungle_onAdFinishedEvent(global::AdFinishedEventArgs obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (kliknil)
        {
            kliknil = false;
            //zgodilKlik();
        }
        if (pogledalDoKonca)
        {
            pogledalDoKonca = false;
            //zgodilPogled();
        }

      */
    }


    public static void zgodilKlik()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().money += 100;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().score += 100;
    }

    public static void zgodilPogled()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().money += 50;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().score += 50;
    }

    
    public static void playAD()
    {
        //Short and simple!
        //Dictionary<string, object> options = new Dictionary<string, object>();
        //options["incentivized"] = true;
        //Vungle.playAdWithOptions(options);
        ShowRewardedAd();
    }

    public static void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private static void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                zgodilPogled();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
            
        }
    }


    /*
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Vungle.onPause();
        }
        else {
            Vungle.onResume();
        }
    }




    /* // Fired when a Vungle ad is ready to be displayed
     public static event Action<bool> adPlayableEvent;

     // Fired when a Vungle ad starts
     public static event Action onAdStartedEvent;

     //Fired when a Vungle ad finishes and provides the entire information about this event
     public static event Action<AdFinishedEventArgs> onAdFinishedEvent;


     static void ReklamaNared(bool t)
     {
         klik.text = "reklamNared";
     }*/




    /* public class AdFinishedEventArgs : EventArgs
     {
         // true if a user tapped Download button to go store
         public bool WasCallToActionClicked;

         // true if at least 80% of the video was watched
         public bool IsCompletedView;

         // duration a Vungle ad watched
         public double TimeWatched;

         // total duration of a Vungle ad
         public double TotalDuration;
     }*/

    // Encapsulated functionality called asynchronously each time event is triggered



}
