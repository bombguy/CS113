using UnityEngine;
using System.Collections;

//A Static class where we abstract away some of the math stuff
//Also a class where we can store random tools potentially needed
//By various classes.
public static class Utilities{
    public static void calculateStat() { }


    public static int combat(int targetHealth, int friendlyDamage) { return targetHealth - friendlyDamage; }
    public static int combat(baseSkill ability, basePlayer target) {return target.Health - CalculateSpellDamage(ability, 0);}
    public static int heal(int targetHealth, int friendlyHeal) { return targetHealth + friendlyHeal; }
    public static int heal(baseSkill ability, basePlayer target) { return target.Health + CalculateSpellDamage(ability, 0); }


    public static int CalculateSpellDamage(baseSkill usedAbility, int scalarModifier ) {return ((usedAbility.Power * scalarModifier) + usedAbility.Power);}


    public static int generateStat(int value, float modifier) {
        return (int)Random.Range(value - (value * modifier), value + (value * modifier));
    }
}
