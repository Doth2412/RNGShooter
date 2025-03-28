using Assets.Scripts.TerrainComponents;
using UnityEngine;

// [RequireComponent(typeof(CircleCollider2D))]
// [RequireComponent(typeof(Rigidbody2D))]
public class Key : MovingObject
{
	private Rigidbody2D body;
	private Renderer render;
	public Gate gate;
	public AudioSource audioTakeKey;
	public void PlayerTakeKey()
	{
		body = GetComponent<Rigidbody2D>();
		render = GetComponent<Renderer>();

		body.mass = 2f;
		body.gravityScale = 0.4f;
		render.material.color = Color.gray;
		tag = "Untagged";
		
		gate.keyRequire--;
        audioTakeKey.Play();

    }
	
	public void KeyOutOfBound()
	{
		gate.keyRequire--;
		Destroy(gameObject);
	}
}
