using UnityEngine.EventSystems;
public class Python : baseEnemy {
	public Python() {
		name = "Python";
		maxHP = 140;
		currentHP = maxHP;
		attack = 10;
		defense = 0;
		basicAttack = new BasicAttack();
        effected = false;
        duration = 0;
        effect = Status.NONE;
        effective_skill = new NoSkill();
    }
}
