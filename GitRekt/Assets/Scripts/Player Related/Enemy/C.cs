using UnityEngine.EventSystems;

public class C : baseEnemy, IPointerClickHandler {
	public C() {
		name = "C";
		maxHP = 100;
		currentHP = maxHP;
		attack = 3;
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
