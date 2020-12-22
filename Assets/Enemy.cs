using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] float speed = 10f;
    [SerializeField] bool invincible = false;
    [SerializeField] public bool notMoving = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!notMoving) {
            MoveShip();
        }
    }

    private void MoveShip()
    {
        float yPos = transform.localPosition.y;
        yPos = yPos - speed * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }

    void OnParticleCollision(GameObject other)
    {
        if(!invincible)
        {
            TakeDamage();
        }

    }

    private void TakeDamage()
    {
        health = health - 5;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("hit player");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
