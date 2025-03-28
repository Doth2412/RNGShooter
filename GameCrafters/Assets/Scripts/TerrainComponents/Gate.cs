using System;
using System.Linq;
using Assets.Scripts.TerrainComponents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MovingObject
{
	public int keyRequire;
	public bool isOpened = false;
	public AudioSource audioOpenGate;
	
	private Renderer render;
	// Start is called before the first frame update
	void Awake()
	{
		keyRequire = GameObject.FindGameObjectsWithTag("key").Length;
		render = GetComponent<Renderer>();
	}
	
	void Start()
	{
		render.material.color = Color.grey;
	}

	// Update is called once per frame
	void Update()
	{
		base.Update();
		if (keyRequire == 0)
		{
			if(isOpened == false)
			{
				audioOpenGate.Play();

			}
			isOpened = true;
			render.material.color = Color.white;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(isOpened && collider.gameObject.CompareTag("Player"))
		{
			if(SceneManager.GetActiveScene().buildIndex == 0)
			{
				SceneManager.LoadScene(1);
			}
			else
			{
				SkillHandler.levelDone[Array.IndexOf(SkillHandler.mapIndex, SceneManager.GetActiveScene().buildIndex)] = true;
				if(!SkillHandler.levelDone.Contains(false))
				{
					SceneManager.LoadScene(3);
				}
				else SceneManager.LoadScene(2);
			}
		}
	}
}
