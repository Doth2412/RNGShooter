using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MovingObject
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("ground");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
                player.SetReduceSpeed(true);
                player.SetCanJump(false);

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
                player.SetReduceSpeed(false);
                player.SetCanJump(true);

            }
        }
    }
}
