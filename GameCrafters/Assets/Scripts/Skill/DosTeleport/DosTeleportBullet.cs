using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DosTeleportBullet : MonoBehaviour
{
	private int countToTeleport = 0;
	private Transform player;
	// Start is called before the first frame update
	public AudioSource audioTeleport;
	void Awake()
	{
	}

	public void SetPlayer(Transform reference)
	{	
		player = reference;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!collision.collider.gameObject.CompareTag("Player"))
		{
			countToTeleport++;
			if (countToTeleport == 2)
			{
				player.position = transform.position;
				audioTeleport.Play();

                Destroy(gameObject);
			}
		}
			
	}
}
