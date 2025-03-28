using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TerrainComponents
{
    public class MovingObject : MonoBehaviour
    {

        // Use this for initialization
        public float rootSpeed = 0f;
        public float speed = 0f;
        protected bool isInvisible = false;
        protected bool isFly = false;
        protected bool isGlasses = false;

        private AudioSource audioHit;
        public void OnTriggerExit2D(Collider2D collision)
        {
            if(isInvisible)
            {
                if(!collision.gameObject.CompareTag("zone"))
                {
                    isInvisible = false;
                    Renderer renderer = GetComponent<Renderer>();
                    renderer.enabled = true;
                    Collider2D collider2D = GetComponent<Collider2D>();
                    collider2D.isTrigger = false;
                }
            }
        }

        protected void OnCollisionStay2D(Collision2D collision)
        {
            if(isGlasses)
            {
                if(!collision.collider.CompareTag("zone") && !collision.collider.CompareTag("glasserizerBullet"))
                {
                    audioHit.Play();
                    Destroy(gameObject, 0.5f);
                }
            }
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (isGlasses)
            {
                if (!collision.collider.CompareTag("zone") && !collision.collider.CompareTag("glasserizerBullet"))
                {
                    audioHit.Play();
                    Destroy(gameObject, 0.5f);
                }
            }
        }

        public void SetInvisible()
        {
            isInvisible = true;
            Renderer renderer = GetComponent<Renderer>();
            renderer.enabled = false;
            Collider2D collider2D = GetComponent<Collider2D>();
            collider2D.isTrigger = true;
        }

        public void FlyUp()
        {
            transform.Translate(Vector2.up * 2 * Time.deltaTime);
        }

        public void SetFly(bool value)
        {
            if(speed == 0)
            {
                isFly = value;
            }            
        }

        protected void Update()
        {
            if(isFly)
            {
                FlyUp();
            }
        }

        public void SetCapturer()
        {
            speed = 0f;
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.Sleep();
        }

        public void SetIsGlasses(AudioSource audio)
        {
            this.audioHit = audio;
            isGlasses = true;
        }
    }
}