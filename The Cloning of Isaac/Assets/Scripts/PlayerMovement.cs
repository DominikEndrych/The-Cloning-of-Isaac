using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] Rigidbody2D player = null;

    private Vector2 movement;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        this.FlipModel(Input.GetAxis("ShootingHorizontal"));

        movement = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
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
