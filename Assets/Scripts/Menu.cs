using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Menu : MonoBehaviour
{
    
    public GameObject player;
    float playerspeed = 0;
    public void pauseGame()
    {
        //print("pausing");
        gameController.paused = true;
        playerspeed = player.GetComponent<PlayerInputController>().runSpeed;
        player.GetComponent<PlayerInputController>().runSpeed= 0;
    }
    public void unPauseGame()
    {
        //print("unpausing");
        gameController.paused = false;
        player.GetComponent<PlayerInputController>().runSpeed = playerspeed;
        gameObject.SetActive(false);
    }
}
