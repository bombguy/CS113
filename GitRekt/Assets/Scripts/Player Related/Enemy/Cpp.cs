public class Cpp : baseEnemy {
	public Cpp() {
		name = "C++";
		maxHP = 300;
		currentHP = maxHP;
		attack = 30;
		defense = 0;
		basicAttack = new BasicAttack();
	}
}
