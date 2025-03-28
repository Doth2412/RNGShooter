using UnityEngine;

public class GetPauseSignal : MonoBehaviour
{
	public static bool pause = false;
	public GameObject pauseMenu;
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && !pause){
			pauseMenu.SetActive(true);
			pause=!pause;
			Time.timeScale = 0f;
		}

		else if (Input.GetKeyDown(KeyCode.Escape) && pause)
		{
			pauseMenu.SetActive(false);
			pause = !pause;
			Time.timeScale = 1f;
		}
	}
	
}
