using UnityEngine;

public class Variables : MonoBehaviour
{
    public int startingStatPoints = 2;
    public int statPointsPerLevelUp = 2;
    public float percentChanceOfBonusPointOnRatingUp = 2f;
    public int numberOfStartingSkills = 2;

    [Header("Modifiers")]
    public int F = 0;
    public int E = 3;
    public int D = 6;
    public int C = 9;
    public int B = 12;
    public int A = 15;
    public int S = 18;
    public int SS = 21;
}