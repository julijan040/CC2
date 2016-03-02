using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventListener : MonoBehaviour
{
    GameManagerScript GameManagerScript;

    void Start()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (this.gameObject.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
        {
            GameManagerScript.canScroll = true;
        }
        else
        {
            GameManagerScript.canScroll = false;
        }
    }
    
    

}
