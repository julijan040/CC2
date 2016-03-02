using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour {

    GameManagerScript gameManager;
    int beforeScore;
    Text text;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        text = GetComponent<Text>();
        StartCoroutine(DetectScorePerSecond());
	}
	
	IEnumerator DetectScorePerSecond()
    {
        yield return new WaitForSeconds(1);
        int difference = gameManager.score - beforeScore;
        beforeScore = gameManager.score;
        text.text = difference.ToString();
        StartCoroutine(DetectScorePerSecond());
    }
}
