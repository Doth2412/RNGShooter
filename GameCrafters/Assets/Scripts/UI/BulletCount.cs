using UnityEngine;
using TMPro;

public class BulletCount : MonoBehaviour
{
	public GameObject skillHandler;
	private int ammoCount;
	private TextMeshProUGUI textFill;

	void Start()
	{
		textFill = GetComponent<TextMeshProUGUI>();
		ammoCount = skillHandler.GetComponent<SkillHandler>().currentSkillAmmo;
	}

	// Update is called once per frame
	void Update()
	{
		ammoCount = skillHandler.GetComponent<SkillHandler>().currentSkillAmmo;
		textFill.text = "Ammo: " + ammoCount.ToString();
	}
}
