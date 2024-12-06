using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Camera cam1;
    public Camera cam2;
    private bool isPlayer1Active = true;

    void Start()
    {
        // Enable player1 by default
        ActivatePlayer1();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isPlayer1Active)
            {
                ActivatePlayer2();
            }
            else
            {
                ActivatePlayer1();
            }
        }
    }

    void ActivatePlayer1()
    {
        // Activate player1 and deactivate player2
        player1.GetComponent<CharacterControllerCustom>().enabled = true;
        player2.GetComponent<CharacterControllerCustom>().enabled = false;

        cam1.enabled = true;
        cam2.enabled = false;

        isPlayer1Active = true;
    }

    void ActivatePlayer2()
    {
        // Activate player2 and deactivate player1
        player1.GetComponent<CharacterControllerCustom>().enabled = false;
        player2.GetComponent<CharacterControllerCustom>().enabled = true;

        cam1.enabled = false;
        cam2.enabled = true;

        isPlayer1Active = false;
    }
}
