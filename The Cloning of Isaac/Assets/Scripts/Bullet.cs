using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    public float speed = 1.0f;
    public float timeToLive = 2.0f;

    private Vector2 direction;
    private Rigidbody2D rb;
    private float startTimestamp;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startTimestamp = Time.time;

        damage *= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().damageMultiplier; //additional damage from player

        float dirVertical = Input.GetAxis("ShootingVertical");
        float dirHorizontal = Input.GetAxis("ShootingHorizontal");

        direction = new Vector2(dirHorizontal, dirVertical).normalized;

        rb.AddForce(direction * speed, ForceMode2D.Impulse);     
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTimestamp >= timeToLive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {

            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyController>().Hit(damage);
                Destroy(gameObject);
            } 
        }
    }
}
