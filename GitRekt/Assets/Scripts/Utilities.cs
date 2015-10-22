using UnityEngine;
using System.Collections;

//A Static class where we abstract away some of the math stuff
//Also a class where we can store random tools potentially needed
//By various classes.
public static class Utilities{
    public static void calculateStat() { }
    public static void calculateDamage() { }
    public static int generateStat(int value, float modifier) {
        return (int)Random.Range(value - (value * modifier), value + (value * modifier));
    }
}
