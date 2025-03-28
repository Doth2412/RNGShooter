
using System.Net;
using UnityEngine;

public class GummyGuy : ASkill
{
	
	public Transform player;
	public PhysicsMaterial2D bouncyMaterial;
	public AudioSource audiohighJump;
	// Start is called before the first frame update
	void Awake()
	{
		AmmoMax = 2;
		AmmoCurrent = AmmoMax;
	}

	public int MaxAmmo()
	{
		return AmmoMax;
	}

	public override void Shoot(Vector3 shootingPosition)
	{
		if (AmmoCurrent > 0)
		{
			AmmoCurrent--;
			player.GetComponent<PlayerCollisionHandler>().isGummyGuy = true;
			player.GetComponent<PlayerCollisionHandler>().audioHighJump = audiohighJump;
			player.GetComponent<Collider2D>().sharedMaterial = bouncyMaterial;
			player.GetComponent<SpriteRenderer>().color = Color.magenta;
		}
		else Debug.Log("OutOfAmmo");
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
