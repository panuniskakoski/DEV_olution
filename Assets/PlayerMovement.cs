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
        interaction = false;

        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    
    void FixedUpdate() {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        interaction = false;

    }

    /*
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit detected (player)");

        if (Input.GetButtonDown("Interact"))
        {
            interaction = true;
            Debug.Log("true");
            this.GetComponent<Renderer>().enabled = false;
        }
        

        if (Input.GetButtonUp("Interact")) {
            interaction = false;
            Debug.Log("false");
            this.GetComponent<Renderer>().enabled = true;
        }
    }
    */

}
