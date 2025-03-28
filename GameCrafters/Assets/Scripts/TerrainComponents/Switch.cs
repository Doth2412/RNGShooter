using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MovingObject
{
    // Start is called before the first frame update
    bool transOnToOff = false;
    public PlatformWithSwitch pws;

    public float timeDelayBeforeReturn = 3f;
    private float currentTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (transOnToOff)
        {
            currentTime += Time.deltaTime;
            if(currentTime > timeDelayBeforeReturn ) { 
                transOnToOff=false;
                pws.SetIsReturing(true);
                currentTime = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                pws.SetIsReturing(false);
                pws.SetIsSwitch(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                pws.SetIsSwitch(false);
                transOnToOff = true;
            }
        }
    }


}
