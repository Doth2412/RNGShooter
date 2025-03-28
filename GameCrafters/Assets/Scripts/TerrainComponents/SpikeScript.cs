using Assets.Scripts.TerrainComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MovingObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerDie>().CallDead();

        }
    }
}
