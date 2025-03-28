using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadOutLoad : MonoBehaviour
{
	public SkillHandler skillhandler;
	public GameObject[] onScreenSkill;
	private SkillHandler.SkillName[] loadOut;
	
	// Start is called before the first frame update
	void Start()
	{
		skillhandler = GetComponent<SkillHandler>();
		Reroll();
	}
	
	public void Reroll()
	{
		SkillHandler.CreateLoadOut();
		SkillHandler.GenerateMapSet();
		loadOut = SkillHandler.loadOut;
		StartCoroutine(ShowLoadOut());
		
	}
	
	void ShowSkill(GameObject obj)
	{
		var temp = obj.GetComponent<Image>().color;
		temp = Color.white;
		temp = new Color(temp.r, temp.g, temp.b, 1f);
		obj.GetComponent<Image>().color = temp;
	}
	
	void MapSkillToScreen(SkillHandler.SkillName skill)
	{
		if (skill == SkillHandler.SkillName.DosTeleport) // 1
			ShowSkill(onScreenSkill[0]);
		if (skill == SkillHandler.SkillName.TheBox) // 2
			ShowSkill(onScreenSkill[16]);
		if (skill == SkillHandler.SkillName.TheUmbrella) // 3
			ShowSkill(onScreenSkill[19]);
		if (skill == SkillHandler.SkillName.Balloon) // 4
			ShowSkill(onScreenSkill[2]);
		if (skill == SkillHandler.SkillName.Capturer) // 5
			ShowSkill(onScreenSkill[4]);
		if (skill == SkillHandler.SkillName.ZoeHole) // 6
			ShowSkill(onScreenSkill[9]);
		if (skill == SkillHandler.SkillName.GummyGuy) // 7
			ShowSkill(onScreenSkill[15]);
		if (skill == SkillHandler.SkillName.Crossbow) // 8
			ShowSkill(onScreenSkill[12]);
		if (skill == SkillHandler.SkillName.AirGun) // 9
			ShowSkill(onScreenSkill[8]);
		if (skill == SkillHandler.SkillName.TemporalInvisible) // 10
			ShowSkill(onScreenSkill[11]);
		if (skill == SkillHandler.SkillName.StickyGrenade) // 11
			ShowSkill(onScreenSkill[7]);
		if (skill == SkillHandler.SkillName.Floater) // 12
			ShowSkill(onScreenSkill[14]);
		if (skill == SkillHandler.SkillName.Attractor) // 13
			ShowSkill(onScreenSkill[6]);
		if (skill == SkillHandler.SkillName.TheTree) // 14
			ShowSkill(onScreenSkill[1]);
		if (skill == SkillHandler.SkillName.AstronautZone) // 15
			ShowSkill(onScreenSkill[10]);
		if (skill == SkillHandler.SkillName.Blower) // 16
			ShowSkill(onScreenSkill[5]);
		if (skill == SkillHandler.SkillName.Glasserizer) // 17
			ShowSkill(onScreenSkill[3]);
		if (skill == SkillHandler.SkillName.WormAndBird) // 18
			ShowSkill(onScreenSkill[18]);
		if (skill == SkillHandler.SkillName.GrapplingHooks) // 19
			ShowSkill(onScreenSkill[13]);
		if (skill == SkillHandler.SkillName.Snake) // 20
			ShowSkill(onScreenSkill[17]);
	}
	IEnumerator ShowLoadOut()
	{
		foreach (SkillHandler.SkillName skill in loadOut)
		{
			MapSkillToScreen(skill);
			yield return new WaitForSeconds(0.25f);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			SceneManager.LoadScene(2);
		}
	}
}
