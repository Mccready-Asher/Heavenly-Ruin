using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float gunpower;
    public int lifetime = 50;
    private int age;
    public int damage;
    private Vector2 spd;
    private bool lastpaused;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * gunpower;
        spd = rb.velocity;
        age = 0;
        lastpaused= false;

        float rot = Mathf.Atan2(-direction.y, -direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot-90);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject otherThing = coll.collider.gameObject;
        if (otherThing.tag =="breakable")
        {
            otherThing.GetComponent<Breakable>().tick(damage);
            StartCoroutine("waitDestroyBullet");
        }
        if (otherThing.tag == "enemy")
        {
            otherThing.GetComponent<DamageHandler>().tick(damage);
            StartCoroutine("waitDestroyBullet");
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if (gameController.paused){
            if (!lastpaused)
            {
                rb.velocity = new Vector2(0, 0);
                lastpaused = true;
            }
        }
   
        else if (lastpaused)
        {
            rb.velocity = spd;
            lastpaused = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameController.paused)
        {
            if (age >= lifetime) Destroy(gameObject);
            else age++;
        }
    }
    IEnumerator waitDestroyBullet()
    {
        yield return new WaitForSeconds((float)0.21);
        Destroy(gameObject);
    }
}
