using UnityEngine;
using UnityEngine.UI;

public class Slot2 : MonoBehaviour
{
	public GameObject skillHandler;
	public SpriteHolder holder;
	private Image img;
	private SkillHandler.SkillName[] inventory;

	void Start()
	{
		img = GetComponent<Image>();
		inventory = SkillHandler.inventory;

	}
	// Update is called once per frame
	void Update()
	{
		if (inventory[1] == SkillHandler.SkillName.DosTeleport)
			img.sprite = holder.dosTeleport;
		if (inventory[1] == SkillHandler.SkillName.TheTree)
			img.sprite = holder.theTree;
		if (inventory[1] == SkillHandler.SkillName.TemporalInvisible)
			img.sprite = holder.temporalInvisible;
		if (inventory[1] == SkillHandler.SkillName.Attractor)
			img.sprite = holder.attractor;
		if (inventory[1] == SkillHandler.SkillName.StickyGrenade)
			img.sprite = holder.stickyGrenade;
		if (inventory[1] == SkillHandler.SkillName.Capturer)
			img.sprite = holder.capturer;
		if (inventory[1] == SkillHandler.SkillName.ZoeHole)
			img.sprite = holder.zoeHole;
		if (inventory[1] == SkillHandler.SkillName.AirGun)
			img.sprite = holder.airGun;
		if (inventory[1] == SkillHandler.SkillName.TheUmbrella)
			img.sprite = holder.theUmbrella;
		if (inventory[1] == SkillHandler.SkillName.TheBox)
			img.sprite = holder.theBox;
		if (inventory[1] == SkillHandler.SkillName.GummyGuy)
			img.sprite = holder.gummyGuy;
		if (inventory[1] == SkillHandler.SkillName.AstronautZone)
			img.sprite = holder.astronautZone;
		if (inventory[1] == SkillHandler.SkillName.Crossbow)
			img.sprite = holder.crossbow;
		if (inventory[1] == SkillHandler.SkillName.Blower)
			img.sprite = holder.blower;
		if (inventory[1] == SkillHandler.SkillName.Balloon)
			img.sprite = holder.balloon;
		if (inventory[1] == SkillHandler.SkillName.Floater)
			img.sprite = holder.floater;
		if (inventory[1] == SkillHandler.SkillName.Glasserizer)
			img.sprite = holder.glasserizer;
		if (inventory[1] == SkillHandler.SkillName.Snake)
			img.sprite = holder.snake;
		if (inventory[1] == SkillHandler.SkillName.WormAndBird)
			img.sprite = holder.wormAndBird;
		if (inventory[1] == SkillHandler.SkillName.GrapplingHooks)
			img.sprite = holder.grapplingHook;
	}
}
