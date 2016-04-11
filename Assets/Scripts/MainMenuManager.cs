using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public GameObject scrollTab;

    public Toggle sound;
    void Start ()
    {
        
        if (PlayerPrefs.HasKey("soundListener"))
        {
            if (PlayerPrefs.GetInt("soundListener") == 0)
            {

                sound.isOn = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("soundListener", 1);
        }
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


    public void toggleSound()
    {
        if (sound.isOn)
        {
            PlayerPrefs.SetInt("soundListener", 0);

        }else
        {
            PlayerPrefs.SetInt("soundListener", 1);
        }
        AudioListener.pause = sound.isOn;
    }

}
