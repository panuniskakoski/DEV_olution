using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interact : MonoBehaviour
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
        player.GetComponent<CharacterStats>();
        CharacterStats characterStats = player.GetComponent<CharacterStats>();

        if (Input.GetButtonDown("Interact") && currentInterObject)
        {
            // Execute activity
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = false;

            // Aktiviteettien efektit menee päälle
            if (currentInterObject.name == "1_bed")
            {
                characterStats.resting = true;
            }

            if (currentInterObject.name == "1_tv")
            {
                characterStats.having_fun = true;
            }

            if (currentInterObject.name == "1_rock")
            {
                characterStats.mining_rock = true;
            }

            if (currentInterObject.name == "1_tree")
            {
                characterStats.cutting_wood = true;
            }

            if (currentInterObject.name == "1_blobs")
            {
                characterStats.attacking_blobs = true;
            }

        }

        if (Input.GetButtonUp("Interact") && currentInterObject)
        {
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = true;

            // Aktiviteettien efektit menee pois
            if (currentInterObject.name == "1_bed")
            {
                characterStats.resting = false;
            }

            if (currentInterObject.name == "1_tv")
            {
                characterStats.having_fun = false;
            }

            if (currentInterObject.name == "1_rock")
            {
                characterStats.mining_rock = false;
            }

            if (currentInterObject.name == "1_tree")
            {
                characterStats.cutting_wood = false;
            }

            if (currentInterObject.name == "1_blobs")
            {
                characterStats.attacking_blobs = false;
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
