using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBullet : MonoBehaviour
{
	public float moveSpeed = 5f;
	private Rigidbody2D rb;
	private Vector3 surfaceNormal;
	private bool colli=false;
	private Vector3 leftmostPoint;
	private Vector3 rightmostPoint;
	private Vector3 topmostPoint;
	private Vector3 botmostPoint;
	private float direction = 1;
	private bool firstContact = true;
	private bool verticalColli = false;
	public AudioSource audioSnakeHissing;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (firstContact && !collision.collider.gameObject.CompareTag("Player"))
		{
			try{collision.collider.gameObject.GetComponent<Key>().PlayerTakeKey();}
			catch{} 
			firstContact = false;
			rb.velocity = Vector2.zero;
			rb.gravityScale = 0f;
			// Kiểm tra hướng va chạm
			Vector3 collisionNormal = collision.contacts[0].normal;
			if (collisionNormal.y !=0)
			{
				verticalColli = true;
			}

			// Lấy collider của đối tượng va chạm
			Collider2D collidingCollider = collision.collider;

			// Lấy hộp giới hạn xung quanh collider
			Bounds colliderBounds = collidingCollider.bounds;

			// Lấy tọa độ điểm xa nhất bên trái và bên phải
			leftmostPoint = new Vector3(colliderBounds.min.x, colliderBounds.center.y, colliderBounds.center.z);
			rightmostPoint = new Vector3(colliderBounds.max.x, colliderBounds.center.y, colliderBounds.center.z);
			botmostPoint = new Vector3(colliderBounds.center.x, colliderBounds.min.y, colliderBounds.center.z);
			topmostPoint = new Vector3(colliderBounds.center.x, colliderBounds.max.y, colliderBounds.center.z);
			

			//gắn làm con
			Transform hit = collision.collider.transform;
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
			Destroy(rb);
		}
	}

	void Update()
	{
		if (!firstContact)
		{
			
			Vector3 position = transform.position;

			// kiểm tra xem sắp tới rìa chưa để quay đầu
			if ((position.x > rightmostPoint.x - 0.4f || position.x < leftmostPoint.x + 0.4f) && verticalColli)
			{
				direction *= -1;
				audioSnakeHissing.Play();
			}
			if ((position.y > topmostPoint.y - 0.4f || position.y < botmostPoint.y + 0.4f) && !verticalColli)
			{
				direction *= -1;
				audioSnakeHissing.Play();
			}

			// Kiểm tra xem nó va chạm chiều nào để di chuyển theo chiều vuông góc
			if (!verticalColli)
			{
				position.y += direction * Time.deltaTime * 1f;
				transform.position = position;
				Debug.Log("position.y");
			} else
			{
				position.x += direction * Time.deltaTime * 1f;
				transform.position = position;
				Debug.Log("position.x");
			}
			 
		}
	}
}
