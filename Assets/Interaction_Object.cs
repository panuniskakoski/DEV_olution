using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Object : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleAnimation()
    {
        if(anim.GetBool("Interact") == false) {
            anim.SetBool("Interact", true);
        }
        else
        {
            anim.SetBool("Interact", false);
        }

    }

}
