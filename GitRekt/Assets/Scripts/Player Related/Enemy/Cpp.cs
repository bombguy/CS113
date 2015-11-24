using UnityEngine.EventSystems;
public class Cpp : baseEnemy, IPointerClickHandler {
	public Cpp() {
		name = "C++";
		maxHP = 300;
		currentHP = maxHP;
		attack = 30;
		defense = 0;
		basicAttack = new BasicAttack();
        effected = false;
        duration = 0;
        effect = Status.NONE;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.attackTarget = this;
    }
}
