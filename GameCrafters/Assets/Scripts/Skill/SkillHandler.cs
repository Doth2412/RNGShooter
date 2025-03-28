using UnityEngine;
using System;
using System.Linq;
using Assets.Scripts.Skill.Floater;
using Assets.Scripts.Skill.Glasserizer;
using Assets.Scripts.Skill.WormAndBird;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(AirGun))]
[RequireComponent(typeof(Attractor))]
[RequireComponent(typeof(Balloon))]
[RequireComponent(typeof(Capturer))]
[RequireComponent(typeof(Crossbow))]
[RequireComponent(typeof(DosTeleport))]
[RequireComponent(typeof(Floater))]
[RequireComponent(typeof(GummyGuy))]
[RequireComponent(typeof(StickyGrenade))]
[RequireComponent(typeof(TemporalInvisible))]
[RequireComponent(typeof(TheBox))]
[RequireComponent(typeof(TheUmbrella))]
[RequireComponent(typeof(ZoeHole))]
[RequireComponent(typeof(AstronautZone))]
[RequireComponent(typeof(Blower))]
[RequireComponent(typeof(Glasserizer))]
[RequireComponent(typeof(WormAndBird))]
[RequireComponent(typeof(GrapplingHooks))]
[RequireComponent(typeof(Snake))]

public class SkillHandler : MonoBehaviour
{
	public enum SkillName
	{
		//temp,
		DosTeleport,
		GrapplingHooks,
		TheTree,
		Snake,
		TemporalInvisible,
		Attractor,
		StickyGrenade,
		Capturer,
		ZoeHole,
		AirGun,
		TheUmbrella,
		TheBox,
		WormAndBird,
		GummyGuy,
		AstronautZone,
		Crossbow,
		Blower,
		Balloon,
		Floater,
		Glasserizer,
	}
	
	private Dictionary<SkillName, ASkill> skills = new Dictionary<SkillName, ASkill>();
	public static SkillName[] loadOut;
	public static SkillName[] inventory;
	//
	public static int[] mapIndex;
	public static bool[] levelDone;
	// public GameObject rerollCaller;
	public int currentSkillIndex;
	public SkillName currentSkill;
	public readonly int inventorySize = 3;
	public Transform initShootingPosition;
	public Transform player;
	public GameObject shootingIndicator;
	public int currentSkillAmmo;
	public LayerMask ground;
	private static bool firstTime = true;
	// Start is called before the first frame update
	
	

	SkillName[] shootingSkill = {SkillName.GrapplingHooks, SkillName.DosTeleport, SkillName.TheTree, SkillName.Snake,
	SkillName.StickyGrenade, SkillName.AirGun, SkillName.TheBox, SkillName.Crossbow, SkillName.Blower,
	SkillName.Floater, SkillName.Glasserizer, SkillName.WormAndBird};
	
	SkillName[] onPointSkill = {SkillName.TemporalInvisible, SkillName.Attractor, SkillName.Capturer,
	SkillName.TheUmbrella, SkillName.Balloon, SkillName.AstronautZone, SkillName.ZoeHole};
	
	SkillName[] affectSkill = {SkillName.GummyGuy};

	Vector3 shootingPosition;
	

	void Awake()
	{		
		skills[SkillName.DosTeleport] = GetComponent<DosTeleport>();
		skills[SkillName.TheBox] = GetComponent<TheBox>();
		skills[SkillName.TheUmbrella] = GetComponent<TheUmbrella>();
		skills[SkillName.Capturer] = GetComponent<Capturer>();
		skills[SkillName.ZoeHole] = GetComponent<ZoeHole>();
		skills[SkillName.GummyGuy] = GetComponent<GummyGuy>();
		skills[SkillName.Crossbow] = GetComponent<Crossbow>();
		skills[SkillName.Balloon] = GetComponent<Balloon>();
		skills[SkillName.AirGun] = GetComponent<AirGun>();
		skills[SkillName.TemporalInvisible] = GetComponent<TemporalInvisible>();
		skills[SkillName.StickyGrenade] = GetComponent<StickyGrenade>();
		skills[SkillName.Floater] = GetComponent<Floater>();
		skills[SkillName.Attractor] = GetComponent<Attractor>();
		skills[SkillName.TheTree] = GetComponent<TheTree>();
		skills[SkillName.AstronautZone] = GetComponent<AstronautZone>();
		skills[SkillName.Blower] = GetComponent<Blower>();
		skills[SkillName.Glasserizer] = GetComponent<Glasserizer>();
		skills[SkillName.WormAndBird] = GetComponent<WormAndBird>();
		skills[SkillName.GrapplingHooks] = GetComponent<GrapplingHooks>();
		skills[SkillName.Snake] = GetComponent<Snake>();
		

		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			inventory = new SkillName[3];
			inventory[0] = SkillName.TheBox;
			inventory[1] = SkillName.AirGun;
			inventory[2] = SkillName.Floater;
		}
		else if (firstTime)
		{
			CreateLoadOut();
			CreateInventory();
			GenerateMapSet();
			firstTime = !firstTime;
		}

		currentSkillIndex = 0;
		currentSkill = inventory[currentSkillIndex];
	}
	
	void Start()
	{
		GetCurrentSkillAmmo();
	}

	public static void GenerateMapSet()
	{
		mapIndex = new int[9];
		levelDone = new bool[9];
		for (int i = 0; i < 9; i++)
		{
			int tempIndex = UnityEngine.Random.Range(4, 30);
			while(mapIndex.Contains(tempIndex))
				tempIndex = UnityEngine.Random.Range(4, 30);
			mapIndex[i] = tempIndex;
			levelDone[i]= false;
		}
	}
	
	
	private void GetCurrentSkillAmmo()
	{
		currentSkillAmmo = skills[currentSkill].AmmoCurrent;
	}

	public static void CreateLoadOut()
	{
		SkillName[] skillNameArray = new SkillName[9];
		System.Random random = new System.Random();
		for (int i = 0; i < skillNameArray.Length; i++)
		{
			SkillName randomSkillName = (SkillName)random.Next(Enum.GetValues(typeof(SkillName)).Length);
			while(skillNameArray.Contains(randomSkillName))
			{
				randomSkillName = (SkillName)random.Next(Enum.GetValues(typeof(SkillName)).Length);
			}
			skillNameArray[i] = randomSkillName;
		}
		loadOut = skillNameArray;
	}

	public static void CreateInventory()
	{
		SkillName[] inven = new SkillName[3];
		System.Random random = new System.Random();
		for (int i = 0; i < inven.Length; i++)
		{
			int randomIndex = random.Next(0, loadOut.Length);
			while(inven.Contains(loadOut[randomIndex]))
				randomIndex = random.Next(0, loadOut.Length);
			inven[i] = loadOut[randomIndex];
		}
		inventory = inven;
	}

	void IteratingSkill()
	{
		if(currentSkillIndex == inventorySize - 1)
			currentSkillIndex = 0;
		else currentSkillIndex++;
		if(onPointSkill.Contains(inventory[currentSkillIndex]))
			shootingIndicator.SetActive(true);
		else shootingIndicator.SetActive(false);
		currentSkill = inventory[currentSkillIndex];
		GetCurrentSkillAmmo();
	}

	void DeclareShootingPosition(Transform initShootingPosition)
	{
		if(affectSkill.Contains(currentSkill) || shootingSkill.Contains(currentSkill))
		{
			shootingPosition = initShootingPosition.position;
		}
		else if (onPointSkill.Contains(currentSkill))
		{
			
			RaycastHit2D aimLaser = Physics2D.Raycast(initShootingPosition.position, 
			(initShootingPosition.position - player.position).normalized, 2f);
			if (aimLaser.collider == null || currentSkill == SkillName.ZoeHole)
			{
				shootingPosition = player.position + 
				(initShootingPosition.position - player.position).normalized * 2;
			}
			else
			{
				shootingPosition = aimLaser.point;
			}
		}
		shootingIndicator.transform.position = shootingPosition;
	}

	void Shoot(Vector3 shootingPosition)
	{
		skills[currentSkill].Shoot(shootingPosition);
	}
	

	// Update is called once per frame
	void Update()
	{
		if(GameObject.Find("PauseMenu") == null) 
		{
			try{
			DeclareShootingPosition(initShootingPosition);
			if (Input.GetKeyDown(KeyCode.L))
			{
				Debug.Log("change skill");
				IteratingSkill();
			}
			if (Input.GetKeyDown(KeyCode.K) && currentSkillAmmo > 0)
			{
				Shoot(shootingPosition);
				currentSkillAmmo--;
			}}
			catch{}
		}
		
	}
}