using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatformScript : MovingObject
{
    // Start is called before the first frame update

    public int timeBeforeFall = 2;

    private float posY;
    private bool isFalling = false;

    void Start()
    {
        this.rootSpeed = 3f;
        this.speed = 3f;
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if ( isFalling )
        {
            Invoke("Falling", 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isFalling = true;
            }
        }   
    }

    void Falling()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }



}
