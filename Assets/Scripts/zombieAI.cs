using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zombieAI : MonoBehaviour
{
    Rigidbody2D body;
    private bool hunting;
    private bool aggro;
    public GameObject player;
    public float moveSpeed = 20.0f;
    private int curGoal;
    public int tcLimit;
    private int tickCounter = 0;
    public int positionepsilon;
    public Transform[] waypoints;
    

    void Start()
    {
        hunting = false;
        aggro = false;
        body = GetComponent<Rigidbody2D>();
        curGoal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.paused)
        {
            Vector3 targetPos;
            if (hunting) targetPos = player.transform.position;
            else
            {
                targetPos = waypoints[curGoal].position;
            }


            var heading = targetPos - transform.position;
            var dist = heading.magnitude;
            var dir = heading / dist;

            if (dist > 5.02f)
            {
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                var newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                if (Quaternion.Angle(newRotation, transform.rotation) > 3f)
                    transform.rotation = newRotation;
            }
            body.velocity = new Vector2(heading.x, heading.y).normalized * moveSpeed;
            if (Vector3.Distance(transform.position, waypoints[curGoal].position) < positionepsilon)
            {
                curGoal++;
                if (curGoal >= waypoints.Length) { curGoal = 0; }
                //print(curGoal);
            }
        }
        else
        {
            body.velocity = new Vector3(0,0,0);
        }
    }
    private void FixedUpdate()
    {
        if (!gameObject.GetComponent<DamageHandler>().amAlive())
        {

            gameObject.GetComponent<zombieAI>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().kill();
        }
        if (other.gameObject.tag == "GunProjectile")
        {
            aggro = true;
            hunting = true;
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            if (tickCounter == 0)
            {
                curGoal++;
                if (curGoal >= waypoints.Length) { curGoal = 0; }
                //print(curGoal);
            }
            tickCounter++;
            if(tickCounter > tcLimit)tickCounter = 0; 
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.isActiveAndEnabled)
        {
            if (other.gameObject.tag == "Player")
            {
                hunting = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (this.isActiveAndEnabled && !aggro)
        {
            if (other.gameObject.tag == "Player")
            {
                hunting = false;
            }
        }
    }
}
