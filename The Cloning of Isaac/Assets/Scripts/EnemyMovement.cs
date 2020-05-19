using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1;

    [SerializeField] bool followPlayer = true;
    [SerializeField] Transform player;


    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            direction = (player.position - transform.position).normalized;
        } 
    }

    private void FixedUpdate()
    {
        if (followPlayer)
        {
            gameObject.transform.position = transform.position + direction * speed * Time.deltaTime;
        }
    }
}
