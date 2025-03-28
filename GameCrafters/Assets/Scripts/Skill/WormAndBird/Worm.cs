using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Skill.WormAndBird
{
    public class Worm : MonoBehaviour
    {
        public AudioSource audioBird;
        public Camera mainCamera;

        private bool isCreateBird = false;
        class Direction
        {
            public float distance;
            public Vector3 pos;
            public float direction;
            public bool isVertical;

            public Direction(float distance, Vector3 pos, float direction, bool isVertical)
            {
                this.pos = pos;
                this.distance = distance;
                this.direction = direction;
                this.isVertical = isVertical;
            }
        }

        public GameObject birdPrefab;
        public Transform player;
        // Use this for initialization
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision != null)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
                {
                    //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    gameObject.GetComponent<Collider2D>().isTrigger = true;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

                    // Tính toán tọa độ của góc trên bên trái
                    Vector3 topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));

                    // Tính toán tọa độ của góc dưới bên phải
                    Vector3 bottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));


                    List<Direction> list = new List<Direction>();
                    Direction d = new Direction(
                        Vector3.Distance(new Vector3(topLeft.x, gameObject.transform.position.y), gameObject.transform.position),
                        new Vector3(topLeft.x, gameObject.transform.position.y),
                        1, 
                        false);
                    
                    list.Add(d);

                    d = new Direction(
                        Vector3.Distance(new Vector3(bottomRight.x, gameObject.transform.position.y), gameObject.transform.position),
                        new Vector3(bottomRight.x, gameObject.transform.position.y),
                        -1,
                        false);
                    list.Add(d);

                    d = new Direction(
                        Vector3.Distance(new Vector3(gameObject.transform.position.x, topLeft.y, 0), gameObject.transform.position),
                        new Vector3(gameObject.transform.position.x, topLeft.y, 0),
                        -1,
                        true);
                    list.Add(d);

                    d = new Direction(
                        Vector3.Distance(new Vector3(gameObject.transform.position.x, bottomRight.y, 0), gameObject.transform.position),
                        new Vector3(gameObject.transform.position.x, bottomRight.y, 0),
                        1,
                        true);
                    list.Add(d);
                    list.Add(d);
                    list.Sort((x, y) => x.distance.CompareTo(y.distance));


                    bool isCanFly = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!CheckDirectionIsBlock(list[i].pos, gameObject.transform.position) && !isCreateBird)
                        {
                            GameObject birdObj = Instantiate(birdPrefab, list[i].pos, Quaternion.identity);
                            Bird bird = birdObj.GetComponent<Bird>();
                            bird.SetWormPosition(gameObject.transform.position, list[i].direction, list[i].isVertical);
                            bird.mainCamera = mainCamera;
                            isCanFly = true;
                            audioBird.Play();
                            isCreateBird = true;
                            break;
                        }
                    }
                    if (!isCanFly && !isCreateBird)
                    {
                        GameObject birdObj = Instantiate(birdPrefab, topLeft, Quaternion.identity);
                        Bird bird = birdObj.GetComponent<Bird>();
                        bird.GetComponent<Collider2D>().isTrigger = true;
                        bird.SetPlayerPosition(player.position);
                        bird.mainCamera = mainCamera;
                        audioBird.Play();
                        isCreateBird = true;
                    }
                    //GameObject birdObj = Instantiate(birdPrefab, new Vector3(topLeft.x, gameObject.transform.position.y), Quaternion.identity);
                    //Bird bird = birdObj.GetComponent<Bird>();
                    //bird.SetWormPosition(gameObject.transform.position);
                }

                if (collision.gameObject.CompareTag("bird"))
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.CompareTag("bird"))
            {
                Destroy(gameObject);
            }
        }

        private bool CheckDirectionIsBlock(Vector3 start, Vector3 des)
        {
            RaycastHit2D hit = Physics2D.Linecast(start, des, LayerMask.GetMask("ground"));
            if(hit.collider != null)
            {
                Debug.Log(hit.ToString());
                return true;
            }

            return false;
            
        }

        
    }
}