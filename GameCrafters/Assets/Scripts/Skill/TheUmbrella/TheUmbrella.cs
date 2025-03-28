
using UnityEngine;

public class TheUmbrella : ASkill
{
    
    public GameObject theUmbrella;

    public AudioSource audioCreateUmbrella;
    // Start is called before the first frame update

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
            Instantiate(theUmbrella, shootingPosition, Quaternion.identity);
            audioCreateUmbrella.Play();
        }
        else Debug.Log("OutOfAmmo");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
