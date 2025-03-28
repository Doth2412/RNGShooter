using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyGrenade : ASkill
{
    
    public GameObject stickyGrenadeBomb;
    public Transform player;
    public AudioSource audioBombTimer;
    public AudioSource audioExplode;
    // Start is called before the first frame update

    void Awake()
    {
        AmmoMax = 6;
        AmmoCurrent = AmmoMax;
    }

    public override void Shoot(Vector3 shootingPosition)
    {
        if (AmmoCurrent > 0)
        {
            AmmoCurrent--;
            GameObject bullet = Instantiate(stickyGrenadeBomb, shootingPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce((shootingPosition - player.position).normalized * 2, ForceMode2D.Impulse);
            bullet.GetComponent<StickyGrenadeBomb>().audioExplode = audioExplode;
            bullet.GetComponent<StickyGrenadeBomb>().audioBombTimer = audioBombTimer;
        }
        else Debug.Log("OutOfAmmo");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
