using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillName : MonoBehaviour
{
	public GameObject skillHandler;

	private SkillHandler.SkillName[] inventory;
	private int skillIndex;
	private TextMeshProUGUI skillName;
	void Start()
	{
		skillName = GetComponent<TextMeshProUGUI>();
		inventory = SkillHandler.inventory;
		skillIndex = skillHandler.GetComponent<SkillHandler>().currentSkillIndex;
	}
	
	// Update is called once per frame
	void Update()
	{
		skillIndex = skillHandler.GetComponent<SkillHandler>().currentSkillIndex;
		skillName.text = inventory[skillIndex].ToString();
	}
}
