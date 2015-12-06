using UnityEngine;
using System.Collections;

public class PacketSniffing : baseSkill {
	public GameInformation gameInformation;
	
	public PacketSniffing () {
		skillID = 14;
		skillName = "Packet Sniffing";
		skillDescription = "Damages enemy " + (10 + skillLevel * 5) + "and heals for " + (2 + skillLevel * 5);
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;

		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.HEAL;
		additionalEffect.power = 2 + skillLevel * 5;
		additionalEffect.duration = 1;

		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int attack = 10 + (skillLevel * 5);

		//skill experience gain
		skillExperience++;

		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			caster.networkMastery++;
		}
		return attack;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }

	public PacketSniffing(string load)
	{
		skillID = 14;
		skillName = "Packet Sniffing";
		skillDescription = "Damages enemy " + (10 + skillLevel * 5) + "and heals for " + (2 + skillLevel * 5);
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;

		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.HEAL;
		additionalEffect.power = 2 + skillLevel * 5;
		additionalEffect.duration = 1;

		skillLevel = PlayerPrefs.GetInt("PACKETSNIFFING_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("PACKETSNIFFING_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("PACKETSNIFFING_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("PACKETSNIFFING_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("PACKETSNIFFING_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("PACKETSNIFFING_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("PACKETSNIFFING_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("PACKETSNIFFING_POWERL", (float)skillPower);

		
	}
	
}

