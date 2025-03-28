using UnityEngine;

public class AttractorBullet : MonoBehaviour
{
	private float aliveTime = 0;
	public float dragForce;
	public float instaForce;
	// Start is called before the first frame update
	void Awake()
	{
		
	}
	
	void Attract()
	{
		aliveTime += Time.deltaTime;
		GameObject[] dynamicList = GameObject.FindGameObjectsWithTag("dynamic");
		GameObject[] keyList = GameObject.FindGameObjectsWithTag("key");
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (aliveTime < 2f)
		{
			foreach (GameObject obj in dynamicList)
			{
				obj.GetComponent<Rigidbody2D>().
				AddForce((transform.position - obj.transform.position).normalized * dragForce, ForceMode2D.Force);
			}
			foreach (GameObject key in keyList)
			{
				key.GetComponent<Rigidbody2D>().
				AddForce((transform.position - key.transform.position).normalized * dragForce, ForceMode2D.Force);
			}
			player.GetComponent<Rigidbody2D>().
			AddForce((transform.position - player.transform.position).normalized * dragForce, ForceMode2D.Force);
		}
		else
		{
			foreach (GameObject obj in dynamicList)
			{
				obj.GetComponent<Rigidbody2D>().
				AddForce((transform.position - obj.transform.position).normalized * instaForce, ForceMode2D.Force);
			}
			foreach (GameObject key in keyList)
			{
				key.GetComponent<Rigidbody2D>().
				AddForce((transform.position - key.transform.position).normalized * instaForce, ForceMode2D.Force);
			}
			player.GetComponent<Rigidbody2D>().
			AddForce((transform.position - player.transform.position).normalized * instaForce, ForceMode2D.Force);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.forward);
		
		Attract();
	}
}
