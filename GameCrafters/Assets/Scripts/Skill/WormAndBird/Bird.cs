using Assets.Scripts.TerrainComponents;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Skill.WormAndBird
{
	public class Bird : MovingObject
	{

		// Use this for initialization
		private Vector3 wormPos;
		private Vector3 playerPos;
		private bool startFly = false;
		private bool attackPlayer = false;
		private bool isVertical = false;
		private float direction = 1;

		public Camera mainCamera;
		Vector3 topLeft;
		Vector3 bottomRight;

		void Start()
		{
			speed = 4f;
			topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
			bottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
		}


		// Update is called once per frame
		void Update()
		{
			if (gameObject.transform.position.x  < topLeft.x 
				|| gameObject.transform.position.x > bottomRight.x
				|| gameObject.transform.position.y > topLeft.y
				|| gameObject.transform.position.y < bottomRight.y) {
				Destroy(gameObject);
			}
			if (startFly)
			{
				if(!attackPlayer)
				{
					Fly();
				}
				else
				{
					Attack();
				}
				
			}
		}


		public void SetWormPosition(Vector3 worm, float direction, bool isVertical)
		{
			this.wormPos = worm;
			this.startFly = true;
			this.direction = direction;
			this.isVertical = isVertical;
		}

		public void SetPlayerPosition(Vector3 playerPos)
		{
			this.playerPos = playerPos;
			this.startFly = true;
			this.attackPlayer = true;
		}

		private void Fly()
		{
			if(isVertical)
			{
				transform.Translate(Vector2.up * direction * speed * Time.deltaTime);
			}
			else
			{
				transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
			}
			
		}

		private void Attack()
		{
			transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			try
			{
				collision.collider.gameObject.GetComponent<Key>().PlayerTakeKey();
			}
			catch
			{
				if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Player"))
				{
					gameObject.GetComponent<Collider2D>().isTrigger = true;
				}
			}
			
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(attackPlayer)
			{
				if (collision.gameObject.CompareTag("Player"))
				{
					PlayerDie playerDie = collision.gameObject.GetComponent<PlayerDie>();
					playerDie.PlayerDestroy();
				}
			}
		}
	}
}