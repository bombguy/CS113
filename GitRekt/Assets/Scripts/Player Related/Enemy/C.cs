using UnityEngine.EventSystems;

public class C : baseEnemy, IPointerClickHandler {
	public C() {
		name = "C";
		maxHP = 100;
		currentHP = maxHP;
		attack = 3;
		defense = 0;
		basicAttack = new BasicAttack();
	}


    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.attackTarget = this;
    }
}
