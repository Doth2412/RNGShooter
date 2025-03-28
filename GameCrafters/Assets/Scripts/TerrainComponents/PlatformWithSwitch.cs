using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithSwitch : MovingObject
{
    // Start is called before the first frame update


    public float positionTargetX = 0;
    public float positionTargetY = 0;

    private Vector2 initializationPosition;
    private Vector2 targetPosition;

    private bool isSwitch = false;
    private bool isReturing = false;

    void Start()
    {
        this.rootSpeed = 3f;
        this.speed = 3f;
        initializationPosition = transform.position;
        targetPosition = new Vector2(positionTargetX,positionTargetY);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (isSwitch)
        {
            Movement();
        }

        if (isReturing)
        {
            MoveReturn();
            if ((Vector2)transform.position == initializationPosition)
            {
                isReturing = false;
            }
        }
        
        
        
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void SetIsSwitch(bool value)
    {
        isSwitch = value;
    }

    private void MoveReturn()
    {
        transform.position = Vector2.MoveTowards(transform.position, initializationPosition, speed * Time.deltaTime);
    }
    
    public void SetIsReturing(bool value)
    {
        isReturing = value;
    }

}
