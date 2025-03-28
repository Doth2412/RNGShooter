using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoeHoleBullet : MonoBehaviour
{
    private float speed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
