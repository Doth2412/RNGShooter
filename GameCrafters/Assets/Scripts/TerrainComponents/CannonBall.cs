using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MovingObject
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerDie player = collision.gameObject.GetComponent<PlayerDie>();
            player.CallDead();
        }
        else if (!collision.gameObject.CompareTag("turret"))
        {
            Destroy(gameObject);
        }
    }

    

}
