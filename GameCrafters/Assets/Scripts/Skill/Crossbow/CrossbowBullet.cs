using Assets.Scripts.TerrainComponents;
using UnityEngine;

public class CrossbowBullet : MovingObject
{
	private bool firstContact = true;
	private Rigidbody2D body;
	private Vector2 constantVelocity;
	//public AudioSource audioHit;
	
	void Awake()
	{
		body = GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(firstContact && !collision.collider.gameObject.CompareTag("Player"))
		{
			firstContact = false;
			transform.tag = "static";
			Transform hit = collision.collider.transform;
			if(hit.name == "CrossbowBulletPrefabs(Clone)"){
				hit = hit.parent.parent.transform;
			}	
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
			Destroy(body);
            //audioHit.Play();

        }
	}
	
	public void SetVelocity(Vector2 velo)
	{
		constantVelocity = velo;
	}
	
	new void Update()
	{
		try
		{
			body.velocity = constantVelocity;
		}
		catch{}
	}
}
