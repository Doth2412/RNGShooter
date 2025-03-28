using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
	public GameObject pauseSignal;
	public GameObject[] uiComponent;
	public GameObject skillHandler;
	public GameObject pauseMenu;
	private GameObject audioSetting;
	private static bool isMusicOn;
	private static bool isSFXOn;
	private int current = 0;
	private bool firstTime = true;
	void Awake()
	{
		DontDestroyOnLoad(this);
		if(firstTime)
		{
			isMusicOn = true;
			isSFXOn = true;
		}
	}
	
	void Start()
	{
		audioSetting = GameObject.Find("AudioManager");
	}
	
	void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.None)) return;
		if(Input.GetKeyDown(KeyCode.K))
		{
			if(current == 0)
			{
				pauseMenu.SetActive(false);
				Time.timeScale = 1f;
			}
			if (current == 1)
			{
				if(SceneManager.GetActiveScene().buildIndex != 0)
				{
					pauseMenu.SetActive(false);
					Time.timeScale = 1f;
					SceneManager.LoadScene(1);
				}
				

			}
			if (current == 2)
			{
				if(isMusicOn)
					audioSetting.GetComponent<AudioManager>().MuteSound();
				else audioSetting.GetComponent<AudioManager>().UnMuteSound();
				isMusicOn = !isMusicOn;
			}
			if (current == 3)
			{
				if (isSFXOn)
					audioSetting.GetComponent<AudioManager>().MuteSFX();
				else audioSetting.GetComponent<AudioManager>().UnMuteSFX();
				isSFXOn = !isSFXOn;
			}
			if (current == 4)
			{

			}
			if(current == 5)
			{
				Application.Quit();
			}
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			uiComponent[current].GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;
			uiComponent[current].GetComponent<TMP_Text>().fontSize = 100;
			if (current < uiComponent.Length - 1) current++;
			else current = 0;
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			uiComponent[current].GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;
			uiComponent[current].GetComponent<TMP_Text>().fontSize = 100;
			if (current > 0) current--;
			else current = uiComponent.Length - 1;
		}
		uiComponent[current].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
		uiComponent[current].GetComponent<TMP_Text>().fontSize = 120;
	}
	
	void UnPause()
	{
		Time.timeScale = 0f;
		GameObject.Find("PauseMenu").SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		HandleInput();
	}
}
