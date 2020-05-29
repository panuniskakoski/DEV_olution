using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interact : MonoBehaviour
{
    public GameObject currentInterObject = null;


    private void Update()
    {
        if(Input.GetButtonDown("Interact") && currentInterObject)
        {
            // Execute activity
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetButtonUp("Interact") && currentInterObject)
        {
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Hot_spots"))
        {
            Debug.Log(other.name);
            currentInterObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hot_spots"))
        {
            if (other.gameObject == currentInterObject)
            {
                currentInterObject = null;
            }

        }
    }
}
