using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interact_2 : MonoBehaviour
{
    public GameObject currentInterObject = null;
    public GameObject player;

    public Stat playerRest;


    public void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        player.GetComponent<CharacterStats_2>();
        CharacterStats_2 characterStats_2 = player.GetComponent<CharacterStats_2>();

        if (Input.GetButtonDown("Interact") && currentInterObject)
        {
            // Execute activity
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = false;

            // Aktiviteettien efektit menee päälle
            if (currentInterObject.name == "1_bed")
            {
                characterStats_2.resting = true;
            }

            if (currentInterObject.name == "1_tv")
            {
                characterStats_2.having_fun = true;
            }

            if (currentInterObject.name == "1_rock")
            {
                characterStats_2.mining_rock = true;
            }

            if (currentInterObject.name == "1_tree")
            {
                characterStats_2.cutting_wood = true;
            }

            if (currentInterObject.name == "1_blobs")
            {
                characterStats_2.attacking_blobs = true;
            }

        }

        if (Input.GetButtonUp("Interact") && currentInterObject)
        {
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = true;

            // Aktiviteettien efektit menee pois
            if (currentInterObject.name == "1_bed")
            {
                characterStats_2.resting = false;
            }

            if (currentInterObject.name == "1_tv")
            {
                characterStats_2.having_fun = false;
            }

            if (currentInterObject.name == "1_rock")
            {
                characterStats_2.mining_rock = false;
            }

            if (currentInterObject.name == "1_tree")
            {
                characterStats_2.cutting_wood = false;
            }

            if (currentInterObject.name == "1_blobs")
            {
                characterStats_2.attacking_blobs = false;
            }
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
