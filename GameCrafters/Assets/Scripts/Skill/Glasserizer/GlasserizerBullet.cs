using Assets.Scripts.TerrainComponents;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Skill.Glasserizer
{
    public class GlasserizerBullet : MovingObject
    {

        // Use this for initialization
        //public AudioSource audioHit;
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision != null)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
                {
                    MovingObject movingObject = collision.gameObject.GetComponent<MovingObject>();
                    //movingObject.SetIsGlasses(audioHit);
                    Renderer renderer = movingObject.GetComponent<Renderer>();
                    Color originalColor = renderer.material.color;
                    float newAlpha = 0.5f;
                    Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                    renderer.material.color = newColor;
                    
                    Destroy(gameObject);
                }
            }
        }
    }
}