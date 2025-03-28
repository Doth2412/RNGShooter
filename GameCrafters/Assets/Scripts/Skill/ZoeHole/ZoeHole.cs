using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoeHole : ASkill
{
	// Start is called before the first frame update

	
	public GameObject returnPrefab;
	public Transform initShootingPosition;
	public Transform player;
	public GameObject targetPrefab;

	public AudioSource audioTeleport;

	private GameObject targetPoint = null;
	private GameObject returnObj = null;
	private Vector3 targetPosition;

	private Vector3 rootPosition;
	// Start is called before the first frame update
	private float timeReturn = 2f;
	private float currentTime = 0f;
	private bool isTeleport = false;
	void Awake()
	{
		AmmoMax = 2;
		AmmoCurrent = AmmoMax;
		
	}

	public override void Shoot(Vector3 shootingPosition)
	{
		if (AmmoCurrent > 0)
		{
			// if has any barrier between ShootingPosition and targetPosition, player can teleport
			if(returnObj == null)
			{
				RaycastHit2D hit = Physics2D.Raycast(player.position, shootingPosition, 2f);

				if (hit.collider != null)
				{
					AmmoCurrent--;
					// Store and create returnObj

					rootPosition = player.position;
					this.returnObj = Instantiate(returnPrefab, rootPosition, Quaternion.identity);

					isTeleport = true;
					audioTeleport.Play();

					// teleport to target position
					player.position = shootingPosition;
					Debug.Log("ZoeHole");   
				}
				Debug.Log(player.position.ToString());
				Debug.Log(shootingPosition.ToString());
			}
		}
		else Debug.Log("OutOfAmmo");
	}

	public void TargetPoint(Vector3 shootingPosition)
	{

		targetPosition = shootingPosition;

		if (targetPoint == null)
		{
			targetPoint = Instantiate(targetPrefab, targetPosition, Quaternion.identity);
		}
		else
		{
			targetPoint.transform.position = targetPosition;
		}
		
	}

	public void RemoveTargetPrefab() {
		if(targetPrefab != null)
		{
			Destroy(targetPoint);
		}
		
	}

	private void ReturnRootLocation()
	{
		player.position = rootPosition;
		Destroy(returnObj);
	}

	// Update is called once per frame
	void Update()
	{
		if (isTeleport)
		{
			currentTime += Time.deltaTime;
			if (currentTime >= timeReturn)
			{
				isTeleport = false;
				ReturnRootLocation();
				currentTime = 0f;
			}
		}
	}
}
