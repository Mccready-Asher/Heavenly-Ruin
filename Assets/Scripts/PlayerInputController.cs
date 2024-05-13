using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;
    public GameObject menu;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeInHierarchy == false)
            {
                menu.SetActive(true);
                menu.GetComponent<Menu>().pauseGame();
            }


            else
            {
                menu.GetComponent<Menu>().unPauseGame();
            }
        }
        /*
        if (Input.GetKeyDown("l"))
        {
            menu.SetActive(false);
        }
        if (Input.GetKeyDown("p"))
        {
            print(gameController.paused);
        }*/
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
