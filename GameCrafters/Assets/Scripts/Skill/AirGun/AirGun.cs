using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UI;
using UnityEngine;

public class AirGun : ASkill
{
	public GameObject player;
	[SerializeField] private LayerMask ground;
	private Vector3 force;
	Vector3 effectSize;

	// Start is called before the first frame update
	void Awake()
	{
		AmmoMax = 3;
		AmmoCurrent = AmmoMax;
		SkillName = "AirGun";
		try{effectSize = player.GetComponent<Collider2D>().bounds.size;}
		catch{};
	}
	
	
	public override void Shoot(Vector3 shootingPosition)
	{
		if (AmmoCurrent > 0)
		{
			AmmoCurrent--;
			ForceCalculation(shootingPosition);
			player.GetComponent<Rigidbody2D>().velocity = force;
			//audioShoot.Play();
		}
		else Debug.Log("OutOfAmmo");
	}
	
	void ForceCalculation(Vector3 shootingPosition)
	{
		Vector3 direction = (shootingPosition - player.transform.position).normalized;
		RaycastHit2D checkStable = Physics2D.BoxCast(shootingPosition, effectSize, 0f, direction,
		direction.magnitude * 2, ground);
		try
		{
			if(checkStable.transform.CompareTag("static"))
				force = -direction * 10;
			else if(checkStable.transform.CompareTag("dynamic"))
			{
				force = -direction * 5;
				Debug.Log(checkStable.transform.gameObject);
				checkStable.transform.gameObject.GetComponent<Rigidbody2D>().velocity = -force;
			}
		}
		catch
		{
			force = -direction * 10;
		}
	}

	void Update()
	{
	}
	
}
