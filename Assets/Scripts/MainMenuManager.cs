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
    
}
