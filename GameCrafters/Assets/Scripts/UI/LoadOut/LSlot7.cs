using UnityEngine;
using UnityEngine.UI;

public class LSlot7 : MonoBehaviour
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
		if (loadout[6] == SkillHandler.SkillName.DosTeleport)
			img.sprite = holder.dosTeleport;
		if (loadout[6] == SkillHandler.SkillName.TheTree)
			img.sprite = holder.theTree;
		if (loadout[6] == SkillHandler.SkillName.TemporalInvisible)
			img.sprite = holder.temporalInvisible;
		if (loadout[6] == SkillHandler.SkillName.Attractor)
			img.sprite = holder.attractor;
		if (loadout[6] == SkillHandler.SkillName.StickyGrenade)
			img.sprite = holder.stickyGrenade;
		if (loadout[6] == SkillHandler.SkillName.Capturer)
			img.sprite = holder.capturer;
		if (loadout[6] == SkillHandler.SkillName.ZoeHole)
			img.sprite = holder.zoeHole;
		if (loadout[6] == SkillHandler.SkillName.AirGun)
			img.sprite = holder.airGun;
		if (loadout[6] == SkillHandler.SkillName.TheUmbrella)
			img.sprite = holder.theUmbrella;
		if (loadout[6] == SkillHandler.SkillName.TheBox)
			img.sprite = holder.theBox;
		if (loadout[6] == SkillHandler.SkillName.GummyGuy)
			img.sprite = holder.gummyGuy;
		if (loadout[6] == SkillHandler.SkillName.AstronautZone)
			img.sprite = holder.astronautZone;
		if (loadout[6] == SkillHandler.SkillName.Crossbow)
			img.sprite = holder.crossbow;
		if (loadout[6] == SkillHandler.SkillName.Blower)
			img.sprite = holder.blower;
		if (loadout[6] == SkillHandler.SkillName.Balloon)
			img.sprite = holder.balloon;
		if (loadout[6] == SkillHandler.SkillName.Floater)
			img.sprite = holder.floater;
		if (loadout[6] == SkillHandler.SkillName.Glasserizer)
			img.sprite = holder.glasserizer;
		if (loadout[6] == SkillHandler.SkillName.Snake)
			img.sprite = holder.snake;
		if (loadout[6] == SkillHandler.SkillName.WormAndBird)
			img.sprite = holder.wormAndBird;
		if (loadout[6] == SkillHandler.SkillName.GrapplingHooks)
			img.sprite = holder.grapplingHook;
	}
}
