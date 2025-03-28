using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	private float mute = -40f;
	public AudioMixer mixer;
	public static AudioManager instance;
	// Start is called before the first frame update
	void Awake()
	{
		if(instance==null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	public void MuteSound()
	{
		mixer.SetFloat("music", mute);
	}

	public void UnMuteSound()
	{
		mixer.SetFloat("music", 0f);
	}

	public void MuteSFX()
	{
		mixer.SetFloat("sfx", mute);
	}

	public void UnMuteSFX()
	{
		mixer.SetFloat("sfx", 0f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
