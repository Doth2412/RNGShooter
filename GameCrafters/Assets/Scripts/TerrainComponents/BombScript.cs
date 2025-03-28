using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompScript : MovingObject
{
    // Start is called before the first frame update
    public float delayBeforeExlosion = 1f;
    public float explosionRadius = 1.5f;
    void Start()
    {
        Physics2D.autoSyncTransforms = true;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // if the player touchs the bomb, it will explode
        // ( other object such as: object from gun... )
        if (other.CompareTag("Player"))
        {
            Invoke("Explode", delayBeforeExlosion);
        }
    }

    void Explode()
    {

        // Handle with player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.GetMask("Player", "Fence"));

        foreach (Collider2D collider in colliders) {

            // Handle with player
            if (collider.CompareTag("Player"))
            {

                PlayerMovement player = collider.GetComponent<PlayerMovement>();
                player.Die();
            }
            // Handle with Fence
            if (collider.CompareTag("Fence"))
            {

                Fence fence = collider.GetComponent<Fence>();
                fence.DestroyFence();
            }
        }


        Destroy(gameObject);


    }
}
