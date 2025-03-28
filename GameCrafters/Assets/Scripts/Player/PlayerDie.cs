using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour
{
	private bool isDead = false;
	public GameObject xMark;
	public AudioSource audioDie;
	void Start()
	{

	}
	public void PlayerDestroy()
	{
		isDead = true;
	}
	
	public void CallDead()
	{
		StartCoroutine(Die());
	}
	IEnumerator Die()
	{
        audioDie.Play();

        Instantiate(xMark, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
		
		if(SceneManager.GetActiveScene().name == "MenuScene")
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		else SceneManager.LoadScene(2);
		yield return new WaitForSeconds(1);
		gameObject.SetActive(true);
		isDead = false;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			isDead = true;
		}
		if(isDead)
		{
			CallDead();
		}
	}
}


