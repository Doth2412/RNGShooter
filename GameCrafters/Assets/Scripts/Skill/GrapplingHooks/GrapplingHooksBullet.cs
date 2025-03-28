using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHooksBullet : MonoBehaviour
{
    public float maxLifetime = 0f;
    public float grapplingHookMaxDistance = 10f;

    private bool isAttached = false;
    private Transform attachedSurface;
    private bool firstContact = true;
	private Rigidbody2D body;
	private Vector2 constantVelocity;

    public DistanceJoint2D joint;
    public LineRenderer _lineRenderer;
    public bool isGrappling;
    private Transform player;
    private Transform hit;

    public AudioSource audioHit;

    void Awake()
    {
        Invoke("DestroyBullet", maxLifetime);
		body = GetComponent<Rigidbody2D>();

        isGrappling = true;
        joint.autoConfigureDistance =false;
        joint.enabled = false;
        _lineRenderer.enabled = true;

    }
    public void SetPlayer(Transform reference)
    {	
        player = reference;
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if(firstContact && !collision.collider.gameObject.CompareTag("Player"))
		{
            audioHit.Play();
			firstContact = false;
			transform.tag = "static";
			hit = collision.collider.transform;
				
			try
			{ 
				Transform container = hit.GetChild(0);
				transform.SetParent(container);
			}
			catch
			{
				GameObject container = new GameObject("container");
				Vector3 myScale = hit.localScale;
				container.transform.localScale = new Vector3(1f / myScale.x, 1f / myScale.y,
						1f / myScale.z);
				container.transform.SetParent(hit, false);
				transform.SetParent(container.transform);
			}
			body.velocity = Vector2.zero;
            if (joint != null)
            {
                Destroy(joint);
            }
			Destroy(body);
		}

        if(collision.collider.gameObject.CompareTag("Player"))
        {
            // try
        // {
            if (joint != null)
            {
                Destroy(joint);
            }
            // else
            // {
                Destroy(gameObject);
            // }
        // }
        // catch (System.Exception e)
        // {

        // }
                 
        }


	}
    void DestroyBullet()
    {
        // try
        // {
            if (joint != null)
            {
                Destroy(joint);
            }
            // else
            // {
                Destroy(gameObject);
            // }
        // }
        // catch (System.Exception e)
        // {

        // }
    }
    public void SetVelocity(Vector2 velo)
	{
		constantVelocity = velo;
	}
    void Update()
    {
        _lineRenderer.SetPosition(0, player.position);
        _lineRenderer.SetPosition(1, transform.position);

        try
		{
			body.velocity = constantVelocity;
		}
		catch{}

        if (!firstContact)
        {
            Vector3 Direction = hit.position - player.position;
            if (Direction.magnitude > 0.2f)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction.x * 1.5f, Direction.y * 1.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
            {
                CutRope();
            }
    }



    void CutRope()
    {
        // Destroy the joint to cut the rope
        if (joint != null)
        {
            Destroy(joint);
            Invoke("DestroyBullet", 0.1f); 
        }
    }
}
