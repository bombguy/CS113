public class Python : baseEnemy {
	public Python() {
		name = "Python";
		maxHP = 140;
		currentHP = maxHP;
		attack = 10;
		defense = 0;
		basicAttack = new BasicAttack();
	}
}
