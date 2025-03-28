using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour 
{
	private string skillName;
	public string SkillName
	{
		get { return skillName; }
		set { skillName = value; }
	}
	private int ammoMax;
	public int AmmoMax
	{
		get { return ammoMax; }
		set { ammoMax = value; }
	}


	private int ammoCurrent;
	public int AmmoCurrent
	{
		get { return ammoCurrent; }
		set { ammoCurrent = value; }
	}

	private int coolDown;
	public int CoolDown
	{
		get{ return coolDown; }
		set { coolDown = value; }
	}
	//public AudioSource audioShoot;
	//public GameObject bullet;

	public virtual void Shoot(Vector3 shootingPosition)
	{
		
	}
	
	
}
