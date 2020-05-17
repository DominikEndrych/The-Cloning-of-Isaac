using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject bullet;     // bullet placeholder

    [SerializeField] Transform origin;

    private float timeBetweenShots = 0.333f;    // 3 shots per second

    private float timestamp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp && Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, origin.position, transform.rotation);
            timestamp = Time.time + timeBetweenShots;
        }
    }
}
