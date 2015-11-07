public class BasicAttack : baseSkill {
	public override void cast ()
	{
		skillName = "Basic Attack;
		skillDesciption = "Deals 100% of player's attack;
		public SkillCategory	skillCategory;	
		public int				skillLevel;
		public int				skillExperience;
		public int				skillCoolDown;
		public int				skillPower;
		
		public abstract void 	cast();
		public abstract void 	GetObjectData(SerializationInfo info, StreamingContext context);
	}
}
