using UnityEngine;
using System.Collections;

public class LimitingScroll : MonoBehaviour
{

    float UpperScrollLimit = 470f;
    float LowerScrollLimit;

    void Start()
    {
        LowerScrollLimit = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
    }

    void Update()
    {
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y > UpperScrollLimit - Mathf.Epsilon)
        {
            gameObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, UpperScrollLimit - Mathf.Epsilon);
        }
        else if(gameObject.GetComponent<RectTransform>().anchoredPosition.y < LowerScrollLimit + Mathf.Epsilon)
        {
            gameObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, LowerScrollLimit + Mathf.Epsilon);
        }
    }

}
