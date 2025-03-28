using TMPro;
using UnityEngine;

public class Capturer : ASkill
{
    // Start is called before the first frame update
    public GameObject capturerBullet;
    public Transform player;
    private Vector3 targetPosition;
    public GameObject targetPrefab;

    private GameObject targetPoint = null;
    public AudioSource audioCapture;

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
            GameObject bullet = Instantiate(capturerBullet, shootingPosition, Quaternion.identity);
            audioCapture.Play();

        }
        else Debug.Log("OutOfAmmo");
    }

    public void TargetPoint(Vector3 shootingPoint)
    {

        targetPosition = shootingPoint;

        if (targetPoint == null)
        {
            targetPoint = Instantiate(targetPrefab, targetPosition, Quaternion.identity);
        }
        else
        {
            targetPoint.transform.position = targetPosition;
        }

    }

    public void RemoveTargetPrefab()
    {
        if (targetPrefab != null)
        {
            Destroy(targetPoint);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
