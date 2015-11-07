public class C : baseEnemy {
	public C() {
		name = "C";
		maxHP = 100;
		currentHP = maxHP;
		attack = 3;
		defense = 0;
		basicAttack = new BasicAttack();
	}
}
