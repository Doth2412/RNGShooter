using Assets.Scripts.TerrainComponents;
using UnityEngine;

public class CapturerBullet : MonoBehaviour
{

	// Start is called before the first frame update
	private float currentTime = 0;
	void Awake()
	{

	}

	private void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > 0.5)
		{
			Destroy(gameObject);
		}
	}
	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider != null)
		{
			try
			{
				if (!collider.gameObject.CompareTag("Player"))
				{
					MovingObject movingObject = collider.gameObject.GetComponent<MovingObject>();
					movingObject.SetCapturer();
					movingObject.GetComponent<Rigidbody2D>().isKinematic = true;
					movingObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
					collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
					collider.gameObject.tag = "static";
				}
			}
			catch { }

		}
	}
}

