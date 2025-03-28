using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyGrenadeBomb : MovingObject
{
    // Start is called before the first frame update
    
    public float timeExplode = 1.5f;
    public float explosionRadius = 2f;

    public AudioSource audioExplode;
    public AudioSource audioBombTimer;
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("ground");
    }


    void Explode()
    {
        // Handle with player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.GetMask("Player", "ground"));

        foreach (Collider2D collider in colliders)
        {

            // Handle with player
            Vector2 forceDirection = (collider.transform.position - transform.position).normalized;
            //Debug.Log(forceDirection.ToString());
            //if (collider.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
            //{

            //    PlayerMovement player = collider.GetComponent<PlayerMovement>();
            //    player.GetComponent<Rigidbody2D>().AddForce(forceDirection * 300, ForceMode2D.Force);
            //}
            //// Handle with else
            //else
            //{
            //    //    if (collider.CompareTag("Fence"))
            //    //    {

            //    //        Fence fence = collider.GetComponent<Fence>();
            //    //        fence.DestroyFence();
            //    //    }
            if (collider.GetComponent<Rigidbody2D>() != null)
                {
                    if (collider.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
                    {
                        collider.GetComponent<Rigidbody2D>().AddForce(forceDirection * 300, ForceMode2D.Force);
                    }
                }
                
                
            //}
        }

        audioExplode.Play();
        Destroy(gameObject);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                audioBombTimer.Play();
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                Invoke("Explode", timeExplode);
            }
        }
    }
}
