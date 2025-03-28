using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTree : ASkill
{
    
    public GameObject theTree;
    public Transform initShootingPosition;
    // Start is called before the first frame update
    public AudioSource audioTree;

    void Awake()
    {
        AmmoMax = 1;
        AmmoCurrent = AmmoMax;
    }

    public override void Shoot(Vector3 shootingPosition)
    {
        if (AmmoCurrent > 0)
        {
            AmmoCurrent--;
            Instantiate(theTree, shootingPosition, Quaternion.identity);
            audioTree.Play();
        }
        else Debug.Log("OutOfAmmo");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
