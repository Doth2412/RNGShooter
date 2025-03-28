using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : ASkill
{
	
	public GameObject snakeBullet;
	public Transform player;
    public AudioSource audioShootSnake;
    public AudioSource audioSnakeHissing;

	// Start is called before the first frame update
	void Awake()
	{
		AmmoMax = 2;
		AmmoCurrent = AmmoMax;
	}

    public override void Shoot(Vector3 shootingPosition)
    {
        if (AmmoCurrent > 0)
        {
            AmmoCurrent--;
            GameObject bullet = Instantiate(snakeBullet, shootingPosition, Quaternion.identity);
            bullet.GetComponent<SnakeBullet>().audioSnakeHissing = audioSnakeHissing;
            bullet.GetComponent<Rigidbody2D>().AddForce((shootingPosition - player.position).normalized * 2, ForceMode2D.Impulse);
            audioShootSnake.Play();


        }
        else Debug.Log("OutOfAmmo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
