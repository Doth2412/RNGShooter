using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadInventory : MonoBehaviour
{
	public GameObject skillHandler;
	public GameObject[] onScreenSkill;
	public GameObject spriteHolder;
	private SkillHandler.SkillName[] inventory;
	// Start is called before the first frame update
	void Start()
	{
		SkillHandler.CreateInventory();
		inventory = SkillHandler.inventory;
		ShowSkill();
	}
	
	
	
	void MapSkillToScreen(GameObject onScreen, SkillHandler.SkillName skill)
	{
		if (skill == SkillHandler.SkillName.DosTeleport)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().dosTeleport;
		if (skill == SkillHandler.SkillName.TheTree)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().theTree;
		if (skill == SkillHandler.SkillName.TemporalInvisible)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().temporalInvisible;
		if (skill == SkillHandler.SkillName.Attractor)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().attractor;
		if (skill == SkillHandler.SkillName.StickyGrenade)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().stickyGrenade;
		if (skill == SkillHandler.SkillName.Capturer)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().capturer;
		if (skill == SkillHandler.SkillName.ZoeHole)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().zoeHole;
		if (skill == SkillHandler.SkillName.AirGun)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().airGun;
		if (skill == SkillHandler.SkillName.TheUmbrella)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().theUmbrella;
		if (skill == SkillHandler.SkillName.TheBox)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().theBox;
		if (skill == SkillHandler.SkillName.GummyGuy)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().gummyGuy;
		if (skill == SkillHandler.SkillName.AstronautZone)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().astronautZone;
		if (skill == SkillHandler.SkillName.Crossbow)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().crossbow;
		if (skill == SkillHandler.SkillName.Blower)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().blower;
		if (skill == SkillHandler.SkillName.Balloon)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().balloon;
		if (skill == SkillHandler.SkillName.Floater)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().floater;
		if (skill == SkillHandler.SkillName.Glasserizer)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().glasserizer;
		if (skill == SkillHandler.SkillName.Snake)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().snake;
		if (skill == SkillHandler.SkillName.WormAndBird)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().wormAndBird;
		if (skill == SkillHandler.SkillName.GrapplingHooks)
			onScreen.GetComponent<Image>().sprite = spriteHolder.GetComponent<SpriteHolder>().grapplingHook;
	}
	void ShowSkill()	
	{
		for(int i = 0; i < 3; i++)
		{
			MapSkillToScreen(onScreenSkill[i], inventory[i]);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			int temp = Random.Range(0, 9);
			while (SkillHandler.levelDone[temp])
			{
				temp = Random.Range(0, 9);
			}
			SceneManager.LoadScene(SkillHandler.mapIndex[temp]);
		}
	}
}
