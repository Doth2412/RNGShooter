using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Bullet : MovingObject
{
    // Start is called before the first frame update
    private Vector2 directionShot;
    void Start()
    {
        this.rootSpeed = 10f;
        this.speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Shot();
           
    }

    public void SetDirectionShot(Vector2 v)
    {
        this.directionShot = v;
    }

    private void Shot()
    {
        transform.Translate(directionShot * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement p = collision.gameObject.GetComponent<PlayerMovement>();
            }
            else if (collision.gameObject.CompareTag("drone"))
            {

            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
            {
                Destroy(gameObject);
            }

        }
    }


}
