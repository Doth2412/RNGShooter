using Assets.Scripts.TerrainComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MovingObject
{
    // Start is called before the first frame update
    public float timeBeforeReturn = 4f;
    public float timeWaitReturn = 2f;
    public float timeBetweenShot = 2f;
    private float currentTime = 0f;

    public GameObject bulletPrefab;
    private float direction = 1;
    bool isReturning = false;
    private float currentTimeWaitReturn = 0f;
    private float currentTimeShot = 0f;
    void Start()
    {

        this.rootSpeed = 3f;
        this.speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (!isReturning)
        {
            // Time Return
            currentTime += Time.deltaTime;
            if (currentTime >= timeBeforeReturn)
            {
                currentTime = 0f;
                direction *= -1;
                isReturning = true;
            }

            // Time Shot
            currentTimeShot += Time.deltaTime;
            if(currentTimeShot >= timeBetweenShot)
            {
                currentTimeShot = 0f;
                GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.SetDirectionShot(new Vector2((float)0.25 * direction, (float)-0.5));
            }

            Movement();
        }
        else
        {
            currentTimeWaitReturn += Time.deltaTime;
            if (currentTimeWaitReturn >= timeWaitReturn)
            {
                currentTimeWaitReturn = 0f;
                isReturning = false;
            }
        }

        
    }

    private void Movement()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }



}
