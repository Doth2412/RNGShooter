using UnityEngine;

public class WorldBorder : MonoBehaviour
{
	void OnTriggerExit2D(Collider2D collider)
	{
		try
		{
			if (collider.CompareTag("Player"))
			{
				collider.gameObject.GetComponent<PlayerDie>().PlayerDestroy();
			}
			if (collider.CompareTag("key"))
			{
				collider.gameObject.GetComponent<Key>().KeyOutOfBound();
			}
		}
		catch{}
		
	}
}
