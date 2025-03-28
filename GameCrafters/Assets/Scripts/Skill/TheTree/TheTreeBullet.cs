using Assets.Scripts.TerrainComponents;
using System.Collections;
using UnityEngine;

public class TheTreeBullet : MovingObject
{
    public float growthTime = 2.0f;
    public float maxSizeMultiplier = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Grow());

    }

    IEnumerator Grow()
    {
        float elapsedTime = 0f;

        // Grow
        while (elapsedTime < growthTime)
        {
            float newSize = Mathf.Lerp(1.0f, maxSizeMultiplier, elapsedTime / growthTime);
            transform.localScale = new Vector3(newSize, newSize, 1.0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
