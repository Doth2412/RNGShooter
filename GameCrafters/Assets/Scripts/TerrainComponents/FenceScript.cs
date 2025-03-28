using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MovingObject
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    // Function destroy wall when impact with explosion
    public void DestroyFence()
    {
        Destroy(gameObject);
    }
}
