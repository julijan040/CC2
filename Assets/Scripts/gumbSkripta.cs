using UnityEngine;
using System.Collections;

public class gumbSkripta : MonoBehaviour {

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

	public void changeBool()
    {
        if (anim.GetBool("goDown") == false)
        {
            anim.Play("Pressed");
            anim.SetBool("goDown", true);
        } 
        else
        {
            anim.SetBool("goDown", false);
            anim.Play("New Animation");
        } 
    }
}
