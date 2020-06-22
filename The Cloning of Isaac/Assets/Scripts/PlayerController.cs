using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int health = 3;
    public int money = 0;

    public float damageMultiplier = 1;

    public bool canBeHit = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void applyPickupEffect(Pickup pickup)
    {
        gameObject.GetComponent<PlayerMovement>().speed += pickup.speed;
        this.damageMultiplier += pickup.damage;
    }

    private IEnumerator CanBeHit()
    {
        this.canBeHit = false;
        yield return new WaitForSeconds(2.0f);
        this.canBeHit = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && this.canBeHit)
        {

            if (--health <= 0)
            {
                Debug.Log("Player is dead");
                return;
            }
            StartCoroutine(this.CanBeHit());
            Debug.Log("Hit by enemy");
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            this.money++;
            Debug.Log(this.money);
        }
        else if (collision.gameObject.CompareTag("Pickup_basic"))
        {
            this.applyPickupEffect(collision.gameObject.GetComponent<Pickup>());    //apply pikcup effect
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && this.canBeHit)
        {
            StartCoroutine(this.CanBeHit());
            Debug.Log("Player still hit");
        }
    }
}
