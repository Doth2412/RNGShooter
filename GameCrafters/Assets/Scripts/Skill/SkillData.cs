using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "new Skill", menuName = "Skill")]

public class SkillData : ScriptableObject
{
	public int maxAmmo;
	public int coolDown;
	public AudioSource audioShoot;
	public GameObject bullet;
}

