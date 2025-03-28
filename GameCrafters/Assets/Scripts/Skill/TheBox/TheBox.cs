using UnityEngine;

public class TheBox : ASkill
{
	
	public GameObject theBoxBullet;
	public Transform initShootingPosition;
	public Transform player;
	// Start is called before the first frame update
	public AudioSource audioShoot;
	public AudioSource audioCreateBox;
	void Awake()
	{
		AmmoMax = 6;
		AmmoCurrent = AmmoMax;
	}

	public override void Shoot(Vector3 shootingPosition)
	{
		if(AmmoCurrent > 0)
		{
			AmmoCurrent--;
			GameObject bullet = Instantiate(theBoxBullet, shootingPosition, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().AddForce((shootingPosition - player.position).normalized * 2, ForceMode2D.Impulse);
			bullet.GetComponent<TheBoxBullet>().audioCreateBox = audioCreateBox;
			audioShoot.Play();

        }
		else Debug.Log("OutOfAmmo");
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
