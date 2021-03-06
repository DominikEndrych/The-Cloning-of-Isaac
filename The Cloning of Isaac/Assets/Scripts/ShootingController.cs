﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    [SerializeField] GameObject bullet = null;     // bullet placeholder

    public float timeBetweenShots = 0.333f; // 3 shots per second

    [SerializeField] Transform origin = null;

    private float timestamp;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp && (Input.GetAxis("ShootingVertical") != 0 || Input.GetAxis("ShootingHorizontal") != 0))
        {
            Instantiate(bullet, origin.position, transform.rotation);
            timestamp = Time.time + timeBetweenShots;
        }

    }
}
