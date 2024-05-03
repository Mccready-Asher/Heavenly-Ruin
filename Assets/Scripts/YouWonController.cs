using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWonController : MonoBehaviour
{
    public string destination;
    void Start()
    {
        SceneManager.LoadScene(destination);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
