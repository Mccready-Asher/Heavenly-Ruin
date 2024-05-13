using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Breakable : MonoBehaviour
{
    public ParticleSystem ps;
    public AudioSource breakSound;
    public int hp;

    private void Start()
    {
        ps.Pause();
        ps.GetComponent<Renderer>().enabled = false;
    }

    public void kill()
    {
        
        breakSound.Play();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        ps.GetComponent<Renderer>().enabled = true;
        ps.Play();

    }
    
    public void tick( int dmg)
    {
        hp -= dmg;
        if (hp < 0) kill();
    }
}
