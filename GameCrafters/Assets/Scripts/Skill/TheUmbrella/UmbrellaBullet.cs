using Assets.Scripts.TerrainComponents;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UmbrellaBullet : MovingObject
{
	public float rotateSpeed;
	
	private float rotateValue;
	private Rigidbody2D body;

	void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		body.gravityScale = 0.3f;
	}

	void Update()
	{
		rotateValue = -rotateSpeed * Time.deltaTime * transform.rotation.z;

		Quaternion rota = transform.rotation;
		rota.z += rotateValue;
		transform.rotation = rota;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject hit = collision.collider.gameObject;
		if (hit.CompareTag("Player"))
			hit.GetComponent<Rigidbody2D>().gravityScale = hit.GetComponent<PlayerMovement>().playerBaseGravity / 2;
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		GameObject hit = collision.collider.gameObject;
		if (hit.CompareTag("Player"))
			hit.GetComponent<Rigidbody2D>().gravityScale = hit.GetComponent<PlayerMovement>().playerBaseGravity;
	}

}

