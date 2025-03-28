using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class TurretScript : MovingObject
{
    // Start is called before the first frame update
    public GameObject cannonballPrefab;

    public float speedUp = 10f;
    public float directionUp = 1;
    public float speedForward = 5f;
    public float directionForward = -1;

    public float timePerFire = 3;

    private float currentTime = 0f;

    private bool isFired = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        currentTime += Time.deltaTime;
        if(currentTime > timePerFire )
        {
            currentTime = 0f;
            isFired = false;
        }
        if(!isFired )
        {
            Fire();
        }
        
    }

    void Fire()
    {
        GameObject cannon = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = cannon.GetComponent<Rigidbody2D>();
        Vector2 moveFire = new Vector2(directionForward * speedForward, directionUp * speedUp);
        rb.AddForce(moveFire, ForceMode2D.Impulse);

        isFired = true;
    }
}
