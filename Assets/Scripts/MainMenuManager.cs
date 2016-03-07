using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    
	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void LoadScene()
    {
        SceneManager.LoadScene("level1");
        
    }

    public void exit()
    {
        Application.Quit();
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("infinity");
    }

    public void OpenFacebookPage()
    {
        float startTime;
        startTime = Time.timeSinceLevelLoad;

        //open the facebook app
        Application.OpenURL("https://www.facebook.com/mordenkul/?fref=ts");

        if (Time.timeSinceLevelLoad - startTime <= 1f)
        {
            //fail. Open safari.
            Application.OpenURL("https://www.facebook.com/mordenkul/?fref=ts");
        }
    }

}
