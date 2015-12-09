using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skillPanel : MonoBehaviour {
    Image _background;
    Text _skillStats;
    Text _skillName;
    void Awake()
    {
        _skillName = GetComponentsInChildren<Text>()[0];
        _skillName.color = Color.white;
        _skillStats = GetComponentsInChildren<Text>()[1];
        _background = GetComponent<Image>();
    }
    // Use this for initialization
    void Start()
    {
        hidePanel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setSkillPanel(baseSkill skill)
    {
        _skillName.text = skill.skillName;
        _skillStats.text = skill.skillDescription + "\n\n" +
            "Skill Level: " + skill.skillLevel + "\n" +
            "Effect : " + skill.additionalEffect.status.ToString() + "\n" +
            "Effect Duration : " + skill.additionalEffect.duration + "\n" +
            "Cooldown :" + skill.skillCoolDown;
    }

    public void updateSkillPanel(baseSkill skill)
    {
        _skillName.text = skill.skillName;
        _skillStats.text = skill.skillDescription + "\n\n" +
            "Effect : " + skill.additionalEffect.ToString() + "\n" +
            "Effect Duration : " + skill.additionalEffect.duration +"Turns "+ "\n" +
            "Cooldown :" + skill.skillCoolDown + "Turns" ;
    }
    public void hidePanel()
    {
        _background.enabled = false;
        _skillStats.enabled = false;
        _skillName.enabled = false;
    }
    public void showPanel()
    {
        _background.enabled = true;
        _skillStats.enabled = true;
        _skillName.enabled = true;
    }
}
