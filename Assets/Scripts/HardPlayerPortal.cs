using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class HardPlayerPortal : MonoBehaviour
{
    public string destination;
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
        if (this.isActiveAndEnabled)
        {
            GameObject otherThing = coll.collider.gameObject;
            if (otherThing.tag == "Player")
            {
                SceneManager.LoadScene(destination);
            }
        }
    }
}
