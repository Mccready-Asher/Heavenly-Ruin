using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubcontroller : MonoBehaviour
{
    public GameObject redfloor;
    public GameObject blufloor;
    public GameObject yelfloor;
    public GameObject whtfloor;
    public GameObject reddoor;
    public GameObject bludoor;
    public GameObject yeldoor;
    public GameObject whtdoor;
    // Start is called before the first frame update
    void Start()
    {
        print(gameController.bluSwitch);
        int numlights = 0;
        if (gameController.redSwitch)
        {
            redfloor.SetActive(true);
            reddoor.GetComponent<HardPlayerPortal>().enabled = false;
            numlights++;
        }
        if (gameController.bluSwitch)
        {
            blufloor.SetActive(true);
            bludoor.GetComponent<HardPlayerPortal>().enabled = false;
            numlights++;
        }
        if (gameController.yelSwitch)
        {
            yelfloor.SetActive(true);
            yeldoor.GetComponent<HardPlayerPortal>().enabled = false;
            numlights++;
        }
        if(numlights>2) 
        {
            whtfloor.SetActive(true);
            whtdoor.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
