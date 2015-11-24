using UnityEngine.EventSystems;
public class Python : baseEnemy, IPointerClickHandler {
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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.attackTarget = this;
    }
}
