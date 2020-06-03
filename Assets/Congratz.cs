using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Congratz : MonoBehaviour
{
    public Button quitButton;

    public void Start()
    {
        // Koska UI on koodattu typerästi
        int width = 844; // or something else
        int height = 475; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);

        quitButton = GameObject.Find("Ok_Button").GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
