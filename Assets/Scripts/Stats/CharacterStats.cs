using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public float maxRest = 100.0f;
    public float currentRest = 100.0f;
    public const float drain_speed = 1.0f;
    public const float rest_speed = 6.0f;

    public bool resting = false;

    public Slider restBar;


    public GameObject player;

    public Stat rest;
    public Stat xp;
    public Stat gold;
    public Stat attack;
    public Stat mining;
    public Stat woodcut;
    public Stat fun;

    private void Start()
    {
        player = GameObject.Find("Player");
        restBar = GameObject.Find("RestBar").GetComponent<Slider>();
    }


    private void Update()
    {
        if (resting)
        {
            if (currentRest < 100)
            {
                currentRest += rest_speed * Time.deltaTime;
                rest.baseValue = currentRest;
                restBar.value = currentRest;
                restBar.value = (currentRest / 100);
            }
        }
        else
        {
            currentRest -= drain_speed * Time.deltaTime;
            rest.baseValue = currentRest;
            restBar.value = (currentRest/100);
            if (currentRest < 0)
            {
                Debug.Log("Energia loppui");
                Destroy(player);
            }
        }


    }

}
