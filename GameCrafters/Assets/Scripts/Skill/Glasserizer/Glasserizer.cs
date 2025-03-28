using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Skill.Glasserizer
{
    public class Glasserizer : ASkill
    {
        
        public GameObject floaterBullet;
        public Transform player;
        public AudioSource audioShoot;
        //public AudioSource audioHit;

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
                //bullet.GetComponent<GlasserizerBullet>().audioHit = audioHit;
                audioShoot.Play();
            }
            else Debug.Log("OutOfAmmo");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}