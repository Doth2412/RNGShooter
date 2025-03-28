using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautZoneBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentTime = 0;
    public float noGravityForce = 0.0f;

    void Awake()
    {

    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 0.0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 1.5f;
            }
        }
    }
}
