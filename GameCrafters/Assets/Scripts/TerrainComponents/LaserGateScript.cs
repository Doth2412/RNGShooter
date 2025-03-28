using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateScript : MovingObject
{
    // Start is called before the first frame update
 
    public float timeBreak = 5f;
    private float currentTime = 0f;
    private bool isActive = true;

    private new Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        currentTime += Time.deltaTime;
        if (currentTime < timeBreak)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
            if (currentTime >= 10f)
            {
                currentTime = 0f;
            }
        }

        display();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if laser active then check player touches
        if(isActive == true)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player touches laser");
                PlayerDie player = other.gameObject.GetComponent<PlayerDie>();
                player.CallDead();
            }
        }
        
    }

    private void display()
    {
        if (isActive)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }

}
