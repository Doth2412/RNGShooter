using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalInvisibleBullet : MonoBehaviour
{
	// Start is called before the first frame update
	// Start is called before the first frame update

	private Renderer objRenderer;
	private Collider2D objCollider;
	private float currentTime = 0;
	void Awake()
	{

	}

	private void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > 0.5f)
		{
			Destroy(gameObject);
		}
	}

	
	private void OnTriggerStay2D (Collider2D collision)
	{
		if (collision != null)
		{
			if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("worldBorder"))
			{
				
					collision.gameObject.GetComponent<MovingObject>().SetInvisible();
				
			}
		}
	}

}
