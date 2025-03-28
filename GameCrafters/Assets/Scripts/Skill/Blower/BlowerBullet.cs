using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowerBullet : MovingObject
{
    public GameObject theBlower;
    private bool created = false;
	
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (!created)
        {
            created = true;

            // Instantiate the blower at the collision point
            theBlower = Instantiate(theBlower, transform.position, Quaternion.identity);

            // Attach the blower to the surface
            if (!collision.collider.gameObject.CompareTag("Player"))
            {
                Transform hit = collision.collider.transform;
                if (hit.name == "CrossbowBulletPrefabs(Clone)")
                {
                    hit = hit.parent.parent.transform;
                }
                try
                {
                    Transform container = hit.GetChild(0);
                    theBlower.transform.SetParent(container);
                }
                catch
                {
                    GameObject container = new GameObject("container");
                    Vector3 myScale = hit.localScale;
                    container.transform.localScale = new Vector3(1f / myScale.x, 1f / myScale.y,
                            1f / myScale.z);
                    container.transform.SetParent(hit, false);
                    theBlower.transform.SetParent(container.transform);
                }
            }
            Rigidbody2D rb = theBlower.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            
            Destroy(gameObject);
        }
    }
}
