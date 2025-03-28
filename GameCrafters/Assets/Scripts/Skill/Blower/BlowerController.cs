using Assets.Scripts.TerrainComponents;
using UnityEngine;

public class BlowerController : MovingObject
{
	public float fanForce;
	private new BoxCollider2D collider;
	
	void Awake() 
	{
		collider = GetComponent<BoxCollider2D>();
	}

    new void Update()
	{
		RaycastHit2D[] listCast = Physics2D.BoxCastAll(new Vector2(collider.bounds.center.x, collider.bounds.min.y), collider.bounds.size,
		0f, Vector2.up, 2f);
		foreach (RaycastHit2D cast in listCast)
		{
			try
			{
				cast.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fanForce, ForceMode2D.Force);
			}
			catch{}
		}
	}
}
