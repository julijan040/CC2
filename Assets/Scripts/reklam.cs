using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class reklam : MonoBehaviour
{

    // Use this for initialization
    Dictionary<string, object> values;

    public static bool pogledalDoKonca;
    public static bool kliknil;

    void Start()
    {
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
        values.Add("large", true);

    }

    private void Vungle_onAdFinishedEvent(global::AdFinishedEventArgs obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (kliknil)
        {
            kliknil = false;
            zgodilKlik();
        }
        if (pogledalDoKonca)
        {
            pogledalDoKonca = false;
            zgodilPogled();
        }

      
    }


    public static void zgodilKlik()
    {

    }

    public static void zgodilPogled()
    {

    }


    public static void playAD()
    {
        //Short and simple!
        Dictionary<string, object> options = new Dictionary<string, object>();
        //options["incentivized"] = true;
        Vungle.playAdWithOptions(options);
    }



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
