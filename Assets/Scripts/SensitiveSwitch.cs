using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SensitiveSwitch : MonoBehaviour
{
    public int channel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(channel== 0) { gameController.redSwitch = !gameController.redSwitch; }
        else if (channel==1) { gameController.yelSwitch = !gameController.yelSwitch; }
        else { gameController.bluSwitch = !gameController.bluSwitch; }

        this.gameObject.transform.RotateAround(transform.position, transform.up, 180f);
    }
}
