using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
	public bool isGummyGuy = false;
	public PhysicsMaterial2D baseMaterial;
	// Start is called before the first frame update
	public AudioSource audioHighJump;
	void Awake()
	{
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(isGummyGuy)
		{
			isGummyGuy = false;
			gameObject.GetComponent<Collider2D>().sharedMaterial = baseMaterial;
			gameObject.GetComponent<SpriteRenderer>().color = Color.white	;
			audioHighJump.Play();
		}
		if (collision.collider.gameObject.CompareTag("key"))
		{
			collision.collider.gameObject.GetComponent<Key>().PlayerTakeKey();
		}
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
