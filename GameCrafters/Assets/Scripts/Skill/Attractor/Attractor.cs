using UnityEngine;

public class Attractor : ASkill
{
	public GameObject attractor;
	public Transform initShootingPosition;

	public AudioSource audioSuck;

	void Awake()
	{
		AmmoMax= 1;
		AmmoCurrent = AmmoMax;
	}

	public override void Shoot(Vector3 shootingPosition)
	{
		if (AmmoCurrent > 0)
		{
			AmmoCurrent--;
			Instantiate(attractor, shootingPosition, Quaternion.identity);
			audioSuck.Play();
		}
		else Debug.Log("OutOfAmmo");
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
