using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	public static float time;
	private TextMeshProUGUI timer;
	private float minute;
	private float second;
	private static bool firstTime = false;
	// Start is called before the first frame update
	void Start()
	{
		if(firstTime)
			{time = 0f; firstTime = true;}
		timer = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		if(GameObject.Find("PauseMenu")==null)
		{
			time += Time.deltaTime;
			minute = Mathf.FloorToInt(time / 60);
			second = Mathf.FloorToInt(time % 60);
			timer.text = (minute < 10 ? "0" + minute.ToString() : minute.ToString())
			+ ":" + (second < 10 ? "0" + second.ToString() : second.ToString());
		}
		
	}
}
