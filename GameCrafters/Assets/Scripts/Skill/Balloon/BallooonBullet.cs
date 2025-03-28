using Assets.Scripts.TerrainComponents;
using UnityEngine;

public class BallooonBullet : MovingObject
{
	public float rotateSpeed;

	private Rigidbody2D rb;
	private float rotateValue;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = -0.2f;
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
