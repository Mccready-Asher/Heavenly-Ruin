using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static bool redSwitch;
    public static bool bluSwitch;
    public static bool yelSwitch;
    public static bool paused;
    // Start is called before the first frame update
    void Start()
    {
        redSwitch= false;
        bluSwitch= false;   
        yelSwitch= false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
