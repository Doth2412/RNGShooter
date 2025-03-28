using Assets.Scripts.TerrainComponents;
using UnityEngine;

public class TheBoxBullet : MovingObject
{
	public GameObject theBox;
	private bool created = false;
	public AudioSource audioCreateBox;
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!created)
		{
			created = true;
			Instantiate(theBox, transform.position, Quaternion.identity);
            audioCreateBox.Play();

            Destroy(gameObject);
		}
		
	}
}
