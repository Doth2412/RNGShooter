using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class LevelChecker : MonoBehaviour
{
	public GameObject[] level;
	public Sprite finished;
	

	// Update is called once per frame
	void Update()
	{
		for (int i = 0;  i < 9; i++)
		{
			if(SkillHandler.levelDone[i])
			{
				level[i].GetComponent<Image>().sprite = finished;
			}
		}
		level[Array.IndexOf(SkillHandler.mapIndex, SceneManager.GetActiveScene().buildIndex)].GetComponent<Image>().color = Color.red;
	}
}
