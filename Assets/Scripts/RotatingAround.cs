using UnityEngine;
using System.Collections;

public class RotatingAround : MonoBehaviour {

    public Vector3 crytal;
	// Use this for initialization
	void Start () {
        crytal = GameObject.FindGameObjectWithTag("Crystal").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(crytal, new Vector3(0f,0f,1f), 20 * Time.deltaTime);
    }
}
