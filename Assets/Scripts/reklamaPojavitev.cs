using UnityEngine;
using System.Collections;

public class reklamaPojavitev : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(Random.Range(60,120));        
        reklam.playAD();
        StartCoroutine(wait());
    }

}
