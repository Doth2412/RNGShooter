using Assets.Scripts.TerrainComponents;
using UnityEngine;

public class Balloon : ASkill
{
    public GameObject balloon;
    public Transform initShootingPosition;

    public AudioSource audioBalloon;
    void Awake()
    {
        AmmoMax = 3;
        AmmoCurrent = AmmoMax;
    }

    public override void Shoot(Vector3 shootingPosition)
    {
        if (AmmoCurrent > 0)
        {
            AmmoCurrent--;
            Instantiate(balloon, shootingPosition, Quaternion.identity);
            audioBalloon.Play();
        }
        else Debug.Log("OutOfAmmo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
