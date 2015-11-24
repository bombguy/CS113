using UnityEngine.EventSystems;
public class RubyOnRails : baseEnemy, IPointerClickHandler {
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
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.attackTarget = this;
    }
}
