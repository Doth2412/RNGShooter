using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautZone : ASkill
{
	public GameObject astronautzoneBullet;
	public Transform player;

	public AudioSource audioAstronautZone;
	// Start is called before the first frame update
	void Awake()
	{
		AmmoMax = 1;
		AmmoCurrent = AmmoMax;
		SkillName = "AstronautZone";
	}


	public override void Shoot(Vector3 shootingPosition)
		{	
			if(AmmoCurrent > 0)
			{
				AmmoCurrent--;
				GameObject bullet = Instantiate(astronautzoneBullet, shootingPosition, Quaternion.identity);
				audioAstronautZone.Play();
			}
			else Debug.Log("OutOfAmmo");
		}

	// Update is called once per frame
	void Update()
	{
		
	}
}
