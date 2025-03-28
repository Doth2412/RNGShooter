using UnityEngine;

public class Crossbow : ASkill
{
	
	private Quaternion initRotation;
	public GameObject crossbowBullet;
	public Transform player;

	public AudioSource audioShoot;
	//public AudioSource audioHit;

	// Start is called before the first frame update
	void Awake()
	{
		AmmoMax = 5;
		AmmoCurrent = AmmoMax;
	}

	public override void Shoot(Vector3 shootingPosition)
	{
		if (AmmoCurrent > 0)
		{
			AmmoCurrent--;
			SetInitRotation(shootingPosition);
			GameObject bullet = Instantiate(crossbowBullet, shootingPosition, initRotation);
			bullet.GetComponent<CrossbowBullet>().SetVelocity((shootingPosition - player.position).normalized * 10);
            audioShoot.Play();
			//bullet.GetComponent<CrossbowBullet>().audioHit = audioHit;

        } 
		else Debug.Log("OutOfAmmo");
	}
	
	private void SetInitRotation(Vector3 shootingPosition)
	{
		Quaternion totalRotation = Quaternion.Euler(Vector3.zero);
		Vector2 direction = shootingPosition - player.position;
		Debug.Log(direction);
		if (direction.x > 0)
		{
			totalRotation *= Quaternion.Euler(Vector3.up);
		}
        if (direction.x < 0)
        {
            totalRotation *= Quaternion.Euler(Vector3.up*180);
        }
        if (direction.y > 0)
		{
			totalRotation *= Quaternion.Euler(Vector3.forward * 70f);
		}
		else if (direction.y < 0)
		{
			totalRotation *= Quaternion.Euler(Vector3.forward * -70f);
		}
		initRotation = totalRotation;
	}

	void Update()
	{
	}
}
