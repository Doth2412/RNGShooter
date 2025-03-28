using Assets.Scripts.TerrainComponents;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Skill.Floater
{
	public class FloaterBullet : MovingObject
	{
		//public AudioSource audioHit;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if(collision != null)
			{
				if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("zone"))
				{
					collision.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
					collision.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.3f;
					if(!collision.collider.CompareTag("key"))
						collision.collider.gameObject.tag = "dynamic";
					//audioHit.Play();

					Destroy(gameObject);
				}
			}
		}
	}
}