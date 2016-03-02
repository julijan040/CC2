using UnityEngine;
using System.Collections;

public class MakeTransparent : MonoBehaviour {

    
    public bool Fade;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Fade) GetComponent<CanvasGroup>().alpha -= 0.18f * Time.deltaTime;
    }
}
