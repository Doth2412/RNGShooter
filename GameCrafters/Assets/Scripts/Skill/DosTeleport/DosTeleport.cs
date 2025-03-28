using UnityEngine;

public class DosTeleport : ASkill
{
	
	public GameObject dosTeleportBullet;
	public Transform player;
	public AudioSource audioTeleport;
	public AudioSource audioShoot;

	// Start is called before the first frame update
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
			GameObject bullet = Instantiate(dosTeleportBullet, shootingPosition, Quaternion.identity);
			bullet.GetComponent<DosTeleportBullet>().SetPlayer(player);
            bullet.GetComponent<DosTeleportBullet>().audioTeleport = audioTeleport;
            bullet.GetComponent<Rigidbody2D>().AddForce((shootingPosition - player.position).normalized * 2, ForceMode2D.Impulse);
            audioShoot.Play();


        }
		else Debug.Log("OutOfAmmo");
	}
	
	void Update()
	{
	}
}
