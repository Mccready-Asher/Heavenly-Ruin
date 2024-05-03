using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerPortal : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.isActiveAndEnabled)
        {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(destination);
            }
        }
    }
}
