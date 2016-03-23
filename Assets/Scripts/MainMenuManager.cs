using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public GameObject scrollTab;

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

    public void LoadScene3()
    {
        SceneManager.LoadScene("level2");

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

    public void playAnimation()
    {
        scrollTab.GetComponent<Animator>().Play("sidescrollerAnim");
    }

    public void playReverseAnimation()
    {
        scrollTab.GetComponent<Animator>().Play("sidescrollerAnimReverse");
    }

}
