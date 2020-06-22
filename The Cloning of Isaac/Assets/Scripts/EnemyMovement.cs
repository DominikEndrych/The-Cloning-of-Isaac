using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1;

    [SerializeField] bool followPlayer = true;
    [SerializeField] Transform player = null;


    private Vector3 direction;

    private void FixedUpdate()
    {
        if (followPlayer)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //gameObject.transform.position = transform.position + direction * speed * Time.deltaTime;
            this.FlipModel(player.position.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void FlipModel(float horizontal)
    {
        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
