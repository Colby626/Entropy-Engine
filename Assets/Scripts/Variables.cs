using UnityEngine;

public class Variables : MonoBehaviour
{
    public int startingStatPoints = 2;
    public int statPointsPerLevelUp = 2;
    public float percentChanceOfBonusPointOnRatingUp = 2f;
    public int numberOfStartingSkills = 2;
    public int upgradePointsPerLevel = 4;
    public int maximumSkills = 5;
    public int maximumFeats = 5;

    [Header("Modifiers")]
    public int F = 0;
    public int E = 3;
    public int D = 6;
    public int C = 9;
    public int B = 12;
    public int A = 15;
    public int S = 18;
    public int SS = 21;

    public static string[] adventurerAdjectives =
    {
		"Brash",
		"Greedy",
		"Rash",
		"Fierce",
		"Bold",
		"Vain",
		"Cruel",
		"Proud",
		"Stoic",
		"Noble",
		"Cunning",
		"Feeble",
		"Coward",
		"Shifty",
		"Brave",
		"Savage",
		"Lucky",
		"Fickle",
		"Sturdy",
		"Jovial",
		"Sullen",
		"Rogue",
		"Gloomy",
		"Timid",
		"Reckless",
		"Vile",
		"Heroic",
		"Arrogant",
		"Skilled",
		"Daring",
		"Fearful",
		"Loyal",
		"Hearty",
		"Shrewd",
		"Meek",
		"Grim",
		"Kind",
		"Calm",
		"Quiet",
		"Tense",
		"Harsh",
		"Sneaky",
		"Rough",
		"Witty",
		"Angry",
		"Eager",
		"Crafty",
		"Mighty",
		"Sly",
		"Weary",
		"Dire",
		"Keen",
		"Wary",
		"Humble",
		"Wise",
		"Naive",
		"Stern",
		"Zany",
		"Swift",
		"Gentle",
		"Tough",
		"Hasty",
		"Grumpy",
		"Cheery",
		"Savvy",
		"Austere",
		"Valiant",
		"Spunky",
		"Gracious",
		"Frantic",
		"Devious",
		"Brutal",
		"Wicked",
		"Gallant"
	};
}