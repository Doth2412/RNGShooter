using Assets.Scripts.TerrainComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGate : MonoBehaviour
{
    // Start is called before the first frame update

    public TeleportGate destination;
    public Transform player;

    private float currentTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // Lấy thông tin Transform của đối tượng
        Transform objectTransform = GetComponent<Transform>();

        // Xoay đối tượng theo trục Y
        objectTransform.Rotate(Vector3.up, 1 * Time.deltaTime);

    }

    public Vector2 Position()
    {
        return transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentTime > 0.5f)
        {
            if (collision != null)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
                    if (!player.GetJustTeleport())
                    {
                        player.Teleport(destination.Position());
                        player.SetJustTeleport(true);
                        currentTime = 0f;
                    }
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentTime > 0.5f)
        {
            if (collision != null)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
                    if (player.GetJustTeleport())
                    {
                        player.SetJustTeleport(false);
                        currentTime = 0f;
                    }
                }
            }
        }
    }
}
