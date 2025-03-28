using UnityEngine;
using UnityEngine.UI;

public class InventoryIndicator : MonoBehaviour
{
	public GameObject skillhandler; 
	private int currentSkill;
	public GameObject[] inventoryUI;
	
	void Start()
	{
		currentSkill = skillhandler.GetComponent<SkillHandler>().currentSkillIndex;
	}

	// Update is called once per frame
	void Update()
	{
		currentSkill = skillhandler.GetComponent<SkillHandler>().currentSkillIndex;
		for (int i = 0; i < inventoryUI.Length; i++)
		{
			if(i == currentSkill)
			{
				var temp = inventoryUI[i].GetComponent<Image>();
				temp.color = new Color(temp.color.r, temp.color.g, temp.color.b, 1f);
			}
			else
			{
				var temp = inventoryUI[i].GetComponent<Image>();
				temp.color = new Color(temp.color.r, temp.color.g, temp.color.b, 0.3f);
			}
		}
	}
}
