
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunEndText : MonoBehaviour
{
	public TextMeshProUGUI text;
	
	// Start is called before the first frame update
	void Start()
	{
		float time = Timer.time;
		int minute = Mathf.FloorToInt(time / 60);
		int second = Mathf.FloorToInt(time % 60);
		text.text = "Nice run!\nYour run time is: " + (minute < 10 ? "0" + minute.ToString() : minute.ToString())
		+ ":" + (second < 10 ? "0" + second.ToString() : second.ToString()) + "\n Press k if you can do better.";
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
			SceneManager.LoadScene(1);
	}
}
