using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Boolean fireButtonPressed; //is the button being held down 
    private Boolean fireButtonReleased; //has the button been released since the last time it was pressed
    private int timeSinceLastShot; //# of fixed updates since last shot
    public int rOFCap = 10; //min # of fixed updates between shots
    public Boolean isFullAuto = false; //does te firing button need to be released between shots
    public GameObject bullet;
    public Transform muzzle;
    // Start is called before the first frame
    private void Start()
    {
        fireButtonPressed = false;
        fireButtonReleased = true;
        timeSinceLastShot = rOFCap;
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameController.paused)
        {
            fireButtonPressed = Input.GetButtonDown("Fire1"); // is the fire button pressed?

            if (!fireButtonPressed && !fireButtonReleased) fireButtonReleased = true; //if the fire button is released and the variable has not been updated, update it.

            if (fireButtonPressed && timeSinceLastShot >= rOFCap) //if the fire button is pressed and sufficient time has elapsed
            {
                if (isFullAuto) //fire if you're full auto
                {
                    fire();
                }
                else if (fireButtonReleased) // if you're semi auto and the button's been released.
                {
                    fire(); //fire
                    fireButtonReleased = false; //and reset the button.
                }

            }
        }
    }
    private void FixedUpdate()
    {
        if (timeSinceLastShot <= rOFCap) timeSinceLastShot++; //if the ROF timer has not been passed,increment it
    }
    private void fire()
    {
        Vector3 pos;
        Quaternion rot;
        muzzle.GetPositionAndRotation(out pos, out rot);

        Instantiate(bullet,pos,rot);
        timeSinceLastShot= 0; //reset last shot timer
    }
}
