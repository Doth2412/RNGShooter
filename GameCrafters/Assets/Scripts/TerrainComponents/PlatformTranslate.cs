using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTranslate : MovingObject
{
    // Start is called before the first frame update
    public float timeStranlate = 3f;
    public bool isVertical = false;

    private float currentTime = 0f;
    private float direction = 1;

    void Start()
    {
        this.rootSpeed = 1.5f;
        this.speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Movement();
    }

    private void Movement()
    {
        currentTime += Time.deltaTime;

        if (currentTime > timeStranlate)
        {
            direction *= -1;
            currentTime = 0f;
        }

        if(isVertical)
        {
            transform.Translate(Vector2.up * direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        }
        
    }


}