using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interact_1 : MonoBehaviour
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
        CharacterStats characterStats_1 = player.GetComponent<CharacterStats>();

        if (Input.GetButtonDown("Interact") && currentInterObject)
        {
            // Execute activity
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = false;

            // Aktiviteettien efektit menee päälle
            if (currentInterObject.name == "1_bed")
            {
                characterStats_1.resting = true;
            }

            if (currentInterObject.name == "1_tv")
            {
                characterStats_1.having_fun = true;
            }

            if (currentInterObject.name == "1_rock")
            {
                characterStats_1.mining_rock = true;
            }

            if (currentInterObject.name == "1_tree")
            {
                characterStats_1.cutting_wood = true;
            }

            if (currentInterObject.name == "1_blobs")
            {
                characterStats_1.attacking_blobs = true;
            }

        }

        if (Input.GetButtonUp("Interact") && currentInterObject)
        {
            currentInterObject.SendMessage("ToggleAnimation");
            this.GetComponent<Renderer>().enabled = true;

            // Aktiviteettien efektit menee pois
            if (currentInterObject.name == "1_bed")
            {
                characterStats_1.resting = false;
            }

            if (currentInterObject.name == "1_tv")
            {
                characterStats_1.having_fun = false;
            }

            if (currentInterObject.name == "1_rock")
            {
                characterStats_1.mining_rock = false;
            }

            if (currentInterObject.name == "1_tree")
            {
                characterStats_1.cutting_wood = false;
            }

            if (currentInterObject.name == "1_blobs")
            {
                characterStats_1.attacking_blobs = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hot_spots"))
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
