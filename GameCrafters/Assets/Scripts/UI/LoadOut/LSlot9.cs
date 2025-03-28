using UnityEngine;
using UnityEngine.UI;

public class LSlot9 : MonoBehaviour
{
	public GameObject skillHandler;
	public SpriteHolder holder;
	private Image img;
	private SkillHandler.SkillName[] loadout;

	void Start()
	{
		img = GetComponent<Image>();
		loadout = SkillHandler.loadOut;

	}
	// Update is called once per frame
	void Update()
	{
		if (loadout[8] == SkillHandler.SkillName.DosTeleport)
			img.sprite = holder.dosTeleport;
		if (loadout[8] == SkillHandler.SkillName.TheTree)
			img.sprite = holder.theTree;
		if (loadout[8] == SkillHandler.SkillName.TemporalInvisible)
			img.sprite = holder.temporalInvisible;
		if (loadout[8] == SkillHandler.SkillName.Attractor)
			img.sprite = holder.attractor;
		if (loadout[8] == SkillHandler.SkillName.StickyGrenade)
			img.sprite = holder.stickyGrenade;
		if (loadout[8] == SkillHandler.SkillName.Capturer)
			img.sprite = holder.capturer;
		if (loadout[8] == SkillHandler.SkillName.ZoeHole)
			img.sprite = holder.zoeHole;
		if (loadout[8] == SkillHandler.SkillName.AirGun)
			img.sprite = holder.airGun;
		if (loadout[8] == SkillHandler.SkillName.TheUmbrella)
			img.sprite = holder.theUmbrella;
		if (loadout[8] == SkillHandler.SkillName.TheBox)
			img.sprite = holder.theBox;
		if (loadout[8] == SkillHandler.SkillName.GummyGuy)
			img.sprite = holder.gummyGuy;
		if (loadout[8] == SkillHandler.SkillName.AstronautZone)
			img.sprite = holder.astronautZone;
		if (loadout[8] == SkillHandler.SkillName.Crossbow)
			img.sprite = holder.crossbow;
		if (loadout[8] == SkillHandler.SkillName.Blower)
			img.sprite = holder.blower;
		if (loadout[8] == SkillHandler.SkillName.Balloon)
			img.sprite = holder.balloon;
		if (loadout[8] == SkillHandler.SkillName.Floater)
			img.sprite = holder.floater;
		if (loadout[8] == SkillHandler.SkillName.Glasserizer)
			img.sprite = holder.glasserizer;
		if (loadout[8] == SkillHandler.SkillName.Snake)
			img.sprite = holder.snake;
		if (loadout[8] == SkillHandler.SkillName.WormAndBird)
			img.sprite = holder.wormAndBird;
		if (loadout[8] == SkillHandler.SkillName.GrapplingHooks)
			img.sprite = holder.grapplingHook;
	}
}
