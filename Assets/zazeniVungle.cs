using UnityEngine;
using System.Collections;

public class zazeniVungle : MonoBehaviour {

    // Use this for initialization
    public GameObject vungleReklam;
    GameObject vungleInstant;
	void Start () {
        if(vungleInstant == null)
        {
            vungleInstant = Instantiate(vungleReklam) as GameObject;
            DontDestroyOnLoad(vungleInstant);
        }
        
        
	}
	
}
