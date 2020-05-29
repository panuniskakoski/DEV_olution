using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float walkSpeed = 40f;
    public Animator animator;

    float horizontalMove = 0f;
    bool interaction = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Interact"))
        {
            interaction = true;
        }
    }

    
    void FixedUpdate() {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        interaction = false;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit detected!");
        //  && interaction == true

        
        if (other.tag == "Player")
        {
            Debug.Log("Hit detected!");
            // other.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            // other.GetComponent<Renderer>().enabled = true;
        }
    }
}
