using System.Runtime.Serialization;

public class BasicAttack : baseSkill {
	public BasicAttack () {
		skillName = "Basic Attack";
		skillDesciption = "Deals 100% of player's attack";
	}
//		public SkillCategory	skillCategory;	
//		public int				skillLevel;
//		public int				skillExperience;
//		public int				skillCoolDown;
//		public int				skillPower;
//		
	public override void 	cast() {
		return;
	}

	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		return;
	}
}
