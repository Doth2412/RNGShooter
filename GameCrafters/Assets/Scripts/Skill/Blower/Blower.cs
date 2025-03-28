using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : ASkill
{
	public GameObject theBlowerBullet;
	public Transform initShootingPosition;
	public Transform player;
	// Start is called before the first frame update
	public AudioSource audioBlower;
	void Awake()
	{
		AmmoMax = 2;
		AmmoCurrent = AmmoMax;
	}

	public override void Shoot(Vector3 shootingPosition)
	{
		if(AmmoCurrent > 0)
		{
			AmmoCurrent--;
			GameObject bullet = Instantiate(theBlowerBullet, shootingPosition, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().AddForce((shootingPosition - player.position).normalized * 3, ForceMode2D.Impulse);
			audioBlower.Play();
		}
		else Debug.Log("OutOfAmmo");
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
