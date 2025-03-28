using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MovingObject
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
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement p = collision.gameObject.GetComponent<PlayerMovement>();
                p.SetReduceSpeed(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement p = collision.gameObject.GetComponent<PlayerMovement>();
                p.SetReduceSpeed(false);
            }
        }
    }


}
