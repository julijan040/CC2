using UnityEngine;
using System.Collections;

public class changingColliderOnResize : MonoBehaviour {

    BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(Screen.width * 100, boxCollider.size.y);
    }

	
}
