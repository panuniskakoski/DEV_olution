using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats_3 : MonoBehaviour
{
    [SerializeField]
    public float delayBeforeSceneLoad = 3f;
    public float timeElapsed;

    // Max valuet
    public const float maxRest = 75.0f;
    public float currentRest = 100.0f;

    public const float maxMining = 1;
    public float currentMining = 0;

    public const float maxWoodcut = 1;
    public float currentWoodcut = 0;

    public const float maxAttack = 1;
    public float currentAttack = 0;


    public const float maxFun = 1;
    public float currentFun = 0;

    public float maxXp = 1;
    public float currentXp = 0;

    // Nopeudet gainiin/drainiin liittyen
    public const float drain_speed = 2.0f;
    public const float rest_speed = 10.0f;

    public float mining_xp_gain = 0.02f;
    public float mining_multiplier = 10;

    public float attack_xp_gain = 0.02f;
    public float attack_multiplier = 10;

    public float woodcut_xp_gain = 0.02f;
    public float woodcut_multiplier = 10;

    public float fun_xp_gain = 0.02f;
    public float fun_multiplier = 10;

    public bool resting = false;

    public bool having_fun = false;
    public bool fun_maxed = false;

    public bool mining_rock = false;
    public bool mining_maxed = false;

    public bool cutting_wood = false;
    public bool woodcut_maxed = false;

    public bool attacking_blobs = false;
    public bool attacking_maxed = false;

    public bool gaining_xp = false;

    public bool lvl_up_1_engaged = false;
    public bool lvl_up_2_engaged = false;
    public bool lvl_up_3_engaged = false;

    public bool defeat = false;

    // Skillien sliderit
    public Slider restBar;
    public Slider funBar;
    public Slider attackBar;
    public Slider miningBar;
    public Slider woodcutBar;
    public Slider xpBar;

    public GameObject player;

    private GameObject lvl_up;

    public GameObject fun_maxed_text;
    public GameObject mining_maxed_text;
    public GameObject woodcut_maxed_text;
    public GameObject attack_maxed_text;
    public GameObject peace_sign;
    public GameObject flag;
    public GameObject lvlUp_icon;

    public Stat rest;
    public Stat xp;
    public Stat gold;
    public Stat attack;
    public Stat mining;
    public Stat woodcut;
    public Stat fun;

    Text text;
    public float goldCounter;
    public float currentGold = 0;

    private void Start()
    {
        // Koska UI on koodattu typerästi
        int width = 844; // or something else
        int height = 475; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);


        // Haetaan slider komponentit pelaaja_objektista
        player = GameObject.Find("Player");

        fun_maxed_text = GameObject.Find("maxed_text_fun");
        mining_maxed_text = GameObject.Find("maxed_text_mining");
        attack_maxed_text = GameObject.Find("maxed_text_attack");
        woodcut_maxed_text = GameObject.Find("maxed_text_woodcut");

        lvl_up = GameObject.Find("LVLup_icon");

        restBar = GameObject.Find("RestBar").GetComponent<Slider>();
        funBar = GameObject.Find("FunBar").GetComponent<Slider>();
        miningBar = GameObject.Find("MiningBar").GetComponent<Slider>();
        woodcutBar = GameObject.Find("WoodcutBar").GetComponent<Slider>();

        attackBar = GameObject.Find("AttackBar").GetComponent<Slider>();
        peace_sign = GameObject.Find("1_sign_sprite");
        flag = GameObject.Find("3x_flag_1");

        xpBar = GameObject.Find("XpBar").GetComponent<Slider>();

        text = GameObject.Find("GoldCounter").GetComponent<Text>();
    }


    private void Update()
    {
        checkIfResting();
        checkIfMining();
        checkIfAttacking();
        checkIfHavingFun();
        checkIfWoodcut();

        checkLvlUp();

        // Delay before next scene
        if (timeElapsed > delayBeforeSceneLoad)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void checkLvlUp()
    {
        if (xpBar.value >= maxXp)
        {
            timeElapsed += Time.deltaTime;

            if (!lvl_up_3_engaged)
            {
                lvl_up_3_engaged = true;
                lvl_up.GetComponent<Renderer>().enabled = true;
                Debug.Log("Sälli on nyt tyytyväinen elämäänsä! Onnittelut!");
            }
        }
    }

    public void checkIfResting()
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
            restBar.value = (currentRest / 100);
            if (currentRest <= 0)
            {
                this.GetComponent<Renderer>().enabled = false;
                Debug.Log("Energia loppui");
                player.GetComponent<CharacterStats_3>();
                CharacterStats_3 characterStats_3 = player.GetComponent<CharacterStats_3>();
                characterStats_3.defeat = true;
                // Tänne animaatio. Heiluttaa käsiä + teksti "ei jaksa enää"
            }
        }
    }

    public void checkIfMining()
    {
        if (mining_rock)
        {
            // Gold gain
            gold.baseValue = currentGold;
            currentGold += 10 * Time.deltaTime;
            text.text = (System.Math.Round(currentGold, 2)).ToString();

            mining.baseValue = currentMining;

            if (miningBar.value < maxMining)
            {
                currentMining += mining_xp_gain * Time.deltaTime;
                miningBar.value = currentMining / mining_multiplier;
            }
            else
            {
                // Jos eka kierros, niin saa xp
                if (!mining_maxed)
                {
                    currentXp += 0.25f;
                    xpBar.value = currentXp;
                }

                mining_maxed = true;
                mining_maxed_text.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    public void checkIfWoodcut()
    {
        if (cutting_wood)
        {
            // Gold gain
            gold.baseValue = currentGold;
            currentGold += 10 * Time.deltaTime;
            text.text = (System.Math.Round(currentGold, 2)).ToString();

            woodcut.baseValue = currentWoodcut;

            if (woodcutBar.value < maxWoodcut)
            {
                currentWoodcut += woodcut_xp_gain * Time.deltaTime;
                woodcutBar.value = currentWoodcut / woodcut_multiplier;
            }
            else
            {
                // Jos eka kierros, niin saa xp
                if (!woodcut_maxed)
                {
                    currentXp += 0.25f;
                    xpBar.value = currentXp;
                }

                woodcut_maxed = true;
                woodcut_maxed_text.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    public void checkIfHavingFun()
    {
        if (having_fun)
        {
            // Gold gain
            gold.baseValue = currentGold;
            currentGold += 10 * Time.deltaTime;
            text.text = (System.Math.Round(currentGold, 2)).ToString();

            fun.baseValue = currentFun;

            if (funBar.value < maxFun)
            {
                currentFun += fun_xp_gain * Time.deltaTime;
                funBar.value = currentFun / fun_multiplier;
            }
            else
            {
                // Jos eka kierros, niin saa xp
                if (!fun_maxed)
                {
                    currentXp += 0.25f;
                    xpBar.value = currentXp;
                }

                fun_maxed = true;
                fun_maxed_text.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    public void checkIfAttacking()
    {
        if (attacking_blobs)
        {
            // Gold gain
            gold.baseValue = currentGold;
            currentGold += 10 * Time.deltaTime;
            text.text = (System.Math.Round(currentGold, 2)).ToString();

            attack.baseValue = currentAttack;

            if (attackBar.value < maxAttack)
            {
                currentAttack += attack_xp_gain * Time.deltaTime;
                attackBar.value = currentAttack / attack_multiplier;
            }
            else
            {
                // Jos eka kierros, niin saa xp
                if (!attacking_maxed)
                {
                    currentXp += 0.25f;
                    xpBar.value = currentXp;
                }

                attacking_maxed = true;
                attack_maxed_text.GetComponent<Renderer>().enabled = true;
                peace_sign.GetComponent<Renderer>().enabled = true;
                flag.GetComponent<Renderer>().enabled = true;
            }
        }
    }

}
