using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public GameObject deathThing;
    private bool alive;
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tick(int dmg)
    {
        if (alive)
        {
            hp -= dmg;
            if (hp < 0) kill();
        }
    }
    public void kill()
    {

        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        deathThing.SetActive(true);
        alive = false;

    }
    public bool amAlive()
    {
        return alive;
    }
}
