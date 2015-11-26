using UnityEngine.EventSystems;
public class RubyOnRails : baseEnemy {
	public RubyOnRails() {
		name = "Ruby On Rails";
		maxHP = 150;
		currentHP = maxHP;
		attack = 20;
		defense = 0;
		basicAttack = new BasicAttack();
        effected = false;
        duration = 0;
        effect = Status.NONE;
        effective_skill = new NoSkill();
	}
}
