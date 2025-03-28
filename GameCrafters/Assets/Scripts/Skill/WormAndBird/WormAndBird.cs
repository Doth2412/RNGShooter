using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Skill.WormAndBird
{
    public class WormAndBird : ASkill
    {
        
        public GameObject floaterBullet;
        public Transform initShootingPosition;
        public Transform player;

        public AudioSource audioShootWorm;
        public AudioSource audioBird;

        public Camera mainCamera;
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
                GameObject bullet = Instantiate(floaterBullet, shootingPosition, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce((shootingPosition - player.position).normalized * 2, ForceMode2D.Impulse);
                Worm worm = bullet.GetComponent<Worm>();
                worm.mainCamera = mainCamera;
                worm.audioBird = audioBird;
                audioShootWorm.Play();
                worm.player = player;
            }
            else Debug.Log("OutOfAmmo");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}