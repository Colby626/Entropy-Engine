using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class GenerateStats : MonoBehaviour
{
    public enum Rarity
    {
        Low_Common, 
        Mid_Common,
        High_Common,
        Low_Uncommon,
        Mid_Uncommon,
        High_Uncommon,
        Low_Rare,
        Mid_Rare,
        High_Rare,
        Low_Epic,
        Mid_Epic,
        High_Epic,
        Low_Legendary,
        Mid_Legendary,
        High_Legendary,
        Low_Cataclysmic,
        Mid_Cataclysmic,
        High_Cataclysmic
    }

    public enum Class
    {
        Warrior,
        Archer,
        Rogue,
        Mage,
        All_Rounder,
        Warrior_Archer,
        Warrior_Rogue,
        Warrior_Mage,
        Archer_Warrior,
        Archer_Rogue,
        Archer_Mage,
        Rogue_Warrior,
        Rogue_Archer,
        Rogue_Mage,
        Mage_Warrior,
        Mage_Archer,
        Mage_Rogue,
        Warrior_Archer_Rogue,
        Warrior_Archer_Mage,
        Warrior_Rogue_Archer,
        Warrior_Rogue_Mage,
        Warrior_Mage_Archer,
        Warrior_Mage_Rogue,
        Archer_Warrior_Rogue,
        Archer_Warrior_Mage,
        Archer_Rogue_Warrior,
        Archer_Rogue_Mage,
        Archer_Mage_Warrior,
        Archer_Mage_Rogue,
        Rogue_Warrior_Archer,
		Rogue_Warrior_Mage,
		Rogue_Archer_Warrior,
		Rogue_Archer_Mage,
        Rogue_Mage_Warrior,
		Rogue_Mage_Archer,
		Mage_Warrior_Archer,
		Mage_Warrior_Rogue,
		Mage_Archer_Warrior,
		Mage_Archer_Rogue,
        Mage_Rogue_Warrior,
        Mage_Rogue_Archer
	}

	public enum Rating
	{
		F,
		E,
		D,
		C,
		B,
		A,
		S,
		SS,
		SSS,
		X
	}

	public enum Type
	{
        Humanoid_Civilian,
        Humanoid_Soldier,
        Humanoid_Champion,
		Humanoid_Commander,
		Humanoid_Mage,
		Humanoid_Battlemage,
        Undead_Skeleton,
		Undead_Lich,
		Undead_Wight,
		Undead_Zombie,
		Undead_CorpseLord,
		Undead_Vampire,
        Undead_Ghoul,
		Undead_DeathKnight,
        Demonic_Devil,
        Demonic_Imp,
		Demonic_Demon,
		Demonic_Azklat,
		Demonic_Hellhound,
		Demonic_MurderCat,
		Demonic_Sin,
        Abyssal_Mimic,
		Abyssal_Remnant,
        Abyssal_EldritchHorror,
		Abyssal_Sludge,
		Abyssal_WakingNightmare,
		Abyssal_Aspect,
        Aethereal_Golem,
        Aethereal_Ghost,
		Aethereal_Wisp,
		Aethereal_ManaVampire,
		Aethereal_Catoblepas,
		Aethereal_Beholder,
        Natural_Treant,
        Natural_Druid,
		Natural_Dryad,
		Natural_Nymph,
		Natural_CreepingVine,
		Natural_PoisonBulb,
		Natural_VenusPersonTrap,
        Heavenly_Messenger,
		Heavenly_Solider,
        Heavenly_Scribe,
		Heavenly_Angel,
		Heavenly_Watcher,
		Heavenly_Virtue,
		Misc_Dragon,
        Misc_Wyvern,
		Misc_Ogre,
		Misc_Goblin,
		Misc_Bunyip,
		Misc_Giant
	}

	private static readonly Dictionary<Class, float[]> classWeights = new Dictionary<Class, float[]>
	{
		{ Class.Warrior, new float[] { 0.4f, 0.3f, 0.2f, 0.1f, 0f, 0f } },
		{ Class.Archer, new float[] { 0.2f, 0.2f, 0.4f, 0.2f, 0f, 0f } },
		{ Class.Rogue, new float[] { 0.2f, 0.2f, 0.2f, 0.4f, 0f, 0f } },
		{ Class.Mage, new float[] { 0.15f, 0.0f, 0.0f, 0.15f, 0.35f, 0.35f } },
		{ Class.All_Rounder, new float[] { 0.2375f, 0.175f, 0.2f, 0.2125f, 0.0875f, 0.0875f } },

		{ Class.Warrior_Archer, new float[] { 0.3333333333f, 0.2666666667f, 0.2666666667f, 0.1333333333f, 0.0f, 0.0f } },
		{ Class.Warrior_Rogue, new float[] { 0.3333333333f, 0.2666666667f, 0.2f, 0.2f, 0.0f, 0.0f } },
		{ Class.Warrior_Mage, new float[] { 0.3166666667f, 0.2f, 0.1333333333f, 0.1166666667f, 0.1166666667f, 0.1166666667f } },

		{ Class.Archer_Warrior, new float[] { 0.2666666667f, 0.2333333333f, 0.3333333333f, 0.1666666667f, 0.0f, 0.0f } },
		{ Class.Archer_Rogue, new float[] { 0.2f, 0.2f, 0.3333333333f, 0.2666666667f, 0.0f, 0.0f } },
		{ Class.Archer_Mage, new float[] { 0.1833333333f, 0.1333333333f, 0.2666666667f, 0.1833333333f, 0.1166666667f, 0.1166666667f } },

		{ Class.Rogue_Warrior, new float[] { 0.2666666667f, 0.2333333333f, 0.2f, 0.3f, 0.0f, 0.0f } },
		{ Class.Rogue_Archer, new float[] { 0.2f, 0.2f, 0.2666666667f, 0.3333333333f, 0.0f, 0.0f } },
		{ Class.Rogue_Mage, new float[] { 0.1833333333f, 0.1333333333f, 0.1333333333f, 0.3166666667f, 0.1166666667f, 0.1166666667f } },

		{ Class.Mage_Warrior, new float[] { 0.2333333333f, 0.1f, 0.06666666667f, 0.1333333333f, 0.2333333333f, 0.2333333333f } },
		{ Class.Mage_Archer, new float[] { 0.1666666667f, 0.06666666667f, 0.1333333333f, 0.1666666667f, 0.2333333333f, 0.2333333333f } },
		{ Class.Mage_Rogue, new float[] { 0.1666666667f, 0.06666666667f, 0.06666666667f, 0.2333333333f, 0.2333333333f, 0.2333333333f } },

		{ Class.Warrior_Archer_Rogue, new float[] { 0.3f, 0.25f, 0.2666666667f, 0.1833333333f, 0.0f, 0.0f } },
		{ Class.Warrior_Archer_Mage, new float[] { 0.2916666667f, 0.2166666667f, 0.2333333333f, 0.1416666667f, 0.05833333333f, 0.05833333333f } },
		{ Class.Warrior_Rogue_Archer, new float[] { 0.3f, 0.25f, 0.2333333333f, 0.2166666667f, 0.0f, 0.0f } },
		{ Class.Warrior_Rogue_Mage, new float[] { 0.2916666667f, 0.2166666667f, 0.1666666667f, 0.2083333333f, 0.05833333333f, 0.05833333333f } },
		{ Class.Warrior_Mage_Archer, new float[] { 0.2833333333f, 0.1833333333f, 0.1666666667f, 0.1333333333f, 0.1166666667f, 0.1166666667f } },
		{ Class.Warrior_Mage_Rogue, new float[] { 0.2833333333f, 0.1833333333f, 0.1333333333f, 0.1666666667f, 0.1166666667f, 0.1166666667f } },

		{ Class.Archer_Warrior_Rogue, new float[] { 0.2666666667f, 0.2333333333f, 0.3f, 0.2f, 0.0f, 0.0f } },
		{ Class.Archer_Warrior_Mage, new float[] { 0.2583333333f, 0.2f, 0.2666666667f, 0.1583333333f, 0.05833333333f, 0.05833333333f } },
		{ Class.Archer_Rogue_Warrior, new float[] { 0.2333333333f, 0.2166666667f, 0.3f, 0.25f, 0.0f, 0.0f } },
		{ Class.Archer_Rogue_Mage, new float[] { 0.1916666667f, 0.1666666667f, 0.2666666667f, 0.2583333333f, 0.05833333333f, 0.05833333333f } },
		{ Class.Archer_Mage_Warrior, new float[] { 0.2166666667f, 0.15f, 0.2333333333f, 0.1666666667f, 0.1166666667f, 0.1166666667f } },
		{ Class.Archer_Mage_Rogue, new float[] { 0.1833333333f, 0.1333333333f, 0.2333333333f, 0.2166666667f, 0.1166666667f, 0.1166666667f } },

		{ Class.Rogue_Warrior_Archer, new float[] { 0.2666666667f, 0.2333333333f, 0.2333333333f, 0.2666666667f, 0.0f, 0.0f } },
		{ Class.Rogue_Warrior_Mage, new float[] { 0.2583333333f, 0.2f, 0.1666666667f, 0.2583333333f, 0.05833333333f, 0.05833333333f } },
		{ Class.Rogue_Archer_Warrior, new float[] { 0.2333333333f, 0.2166666667f, 0.2666666667f, 0.2833333333f, 0.0f, 0.0f } },
		{ Class.Rogue_Archer_Mage, new float[] { 0.1916666667f, 0.1666666667f, 0.2333333333f, 0.2916666667f, 0.05833333333f, 0.05833333333f } },
		{ Class.Rogue_Mage_Warrior, new float[] { 0.2166666667f, 0.15f, 0.1333333333f, 0.2666666667f, 0.1166666667f, 0.1166666667f } },
		{ Class.Rogue_Mage_Archer, new float[] { 0.1833333333f, 0.1333333333f, 0.1666666667f, 0.2833333333f, 0.1166666667f, 0.1166666667f } },

		{ Class.Mage_Warrior_Archer, new float[] { 0.2416666667f, 0.1333333333f, 0.1333333333f, 0.1416666667f, 0.175f, 0.175f } },
		{ Class.Mage_Warrior_Rogue, new float[] { 0.2416666667f, 0.1333333333f, 0.1f, 0.175f, 0.175f, 0.175f } },
		{ Class.Mage_Archer_Warrior, new float[] { 0.2083333333f, 0.1166666667f, 0.1666666667f, 0.1583333333f, 0.175f, 0.175f } },
		{ Class.Mage_Archer_Rogue, new float[] { 0.175f, 0.1f, 0.1666666667f, 0.2083333333f, 0.175f, 0.175f } },
		{ Class.Mage_Rogue_Warrior, new float[] { 0.2083333333f, 0.1166666667f, 0.1f, 0.225f, 0.175f, 0.175f } },
		{ Class.Mage_Rogue_Archer, new float[] { 0.175f, 0.1f, 0.1333333333f, 0.2416666667f, 0.175f, 0.175f } }
	};

	private static readonly Dictionary<Type, float[]> typeWeights = new Dictionary<Type, float[]>
	{
		// Strength, Dexterity, Agility, Intelligence, Spirit, Charisma, Vitality, Fortitude
		{ Type.Humanoid_Civilian, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Humanoid_Soldier, new float[] { .225f, .225f, .025f, .025f, .025f, .025f, .225f, .225f } },
        { Type.Humanoid_Champion, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Humanoid_Commander, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Humanoid_Mage, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Humanoid_Battlemage, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_Skeleton, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_Lich, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_Wight, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_Zombie, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_CorpseLord, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_Vampire, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_Ghoul, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Undead_DeathKnight, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_Devil, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_Imp, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_Demon, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_Azklat, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_Hellhound, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_MurderCat, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Demonic_Sin, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Abyssal_Mimic, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Abyssal_Remnant, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Abyssal_EldritchHorror, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Abyssal_Sludge, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Abyssal_WakingNightmare, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Abyssal_Aspect, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Aethereal_Golem, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Aethereal_Ghost, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Aethereal_Wisp, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Aethereal_ManaVampire, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Aethereal_Catoblepas, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Aethereal_Beholder, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_Treant, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_Druid, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_Dryad, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_Nymph, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_CreepingVine, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_PoisonBulb, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Natural_VenusPersonTrap, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Heavenly_Messenger, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Heavenly_Solider, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Heavenly_Scribe, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Heavenly_Angel, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Heavenly_Watcher, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Heavenly_Virtue, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Misc_Dragon, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Misc_Wyvern, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Misc_Ogre, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Misc_Goblin, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Misc_Bunyip, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
        { Type.Misc_Gian, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
    };

	private int modFromRating(Rating rating)
	{
		if (rating == Rating.F)
			return variables.F;
		else if (rating == Rating.E)
			return variables.E;
		else if (rating == Rating.D)
			return variables.D;
		else if (rating == Rating.C)
			return variables.C;
		else if (rating == Rating.B)
			return variables.B;
		else if (rating == Rating.A)
			return variables.A;
		else if (rating == Rating.S)
			return variables.S;
		else if (rating == Rating.SS)
			return variables.SS;
		else
			return 0;
    }

    string[] adventurerAdjectives = new string[]
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

	public TMP_Dropdown rarityDropdown;
    public TMP_Dropdown classDropdown;

	public TMP_Dropdown lordshipRatingDropdown;
	public TMP_Dropdown lordshipTypeDropdown;

    private Rarity currentRarity;
    private Class currentClass;
	private Rating currentRating;
	private Type currentType;

    private int enduranceStat = 1;
    private int strengthStat = 0;
    private int dexterityStat = 0;
    private int agilityStat = 0;
    private int intelligenceStat = 0;
    private int spiritStat = 0;

    private Rating strengthRating = Rating.F;
    private Rating dexterityRating = Rating.F;
    private Rating agilityRating = Rating.F;
    private Rating intelligenceRating = Rating.F;
    private Rating spiritRating = Rating.F;
	private Rating charismaRating = Rating.F;
    private Rating vitalityRating = Rating.F;
    private Rating fortitudeRating = Rating.F;

    public CharacterList characterList;
	public Variables variables;

	// Called by the Generate button
    public void GenerateClassStatPoints()
    {
		int level = CalculateLevelBasedOnRarity(currentRarity);
        Debug.Log("Level calculated: " + level);
        int statPoints = CalculateStatPointsBasedOnLevel(level);
        Debug.Log("Total stat points: " +  statPoints);

		enduranceStat = 1;
		strengthStat = 0;
		dexterityStat = 0;
		agilityStat = 0;
		intelligenceStat = 0;
		spiritStat = 0;
		DistributeStatPoints(statPoints - 1); // Minus 1 for the forced 1 endurance

		int randomIndex = Random.Range(0, adventurerAdjectives.Length);
		string randomAdjective = adventurerAdjectives[randomIndex];

		characterList.GenerateCharacter(new CharacterList.Character()
		{
			Name = randomAdjective + " " + currentClass.ToString(),

			Endurance = enduranceStat,
			Strength = strengthStat,
			Dexterity = dexterityStat,
			Agility = agilityStat,
			Intelligence = intelligenceStat,
			Spirit = spiritStat,

			MaxHealth = enduranceStat * 3,
			CurrentHealth = enduranceStat * 3,
			MaxMana = spiritStat * 2,
			CurrentMana = spiritStat * 2,
			PhysicalResistance = enduranceStat / 10,
			MagicResistance = spiritStat / 10,
			PlusToHit = dexterityStat / 5,
			AgilityClass = (agilityStat / 5) + 8,
			InitiativeBonus = agilityStat / 5,
			MovementSpeed = (agilityStat / 10) + 3,

			Initiative = 0
		});
	}

	// Called by the Generate button
	public void GenerateLordshipStatPoints()
	{
        strengthRating = Rating.F;
		dexterityRating = Rating.F;
		agilityRating = Rating.F;
		intelligenceRating = Rating.F;
		spiritRating = Rating.F;
		charismaRating = Rating.F;
		vitalityRating = Rating.F;
		fortitudeRating = Rating.F;

		DistributeRatingPoints();

        int randomIndex = Random.Range(0, adventurerAdjectives.Length);
        string randomAdjective = adventurerAdjectives[randomIndex];

        characterList.GenerateNPC(new CharacterList.NPC()
		{
			Name = randomAdjective + " " + currentType.ToString(),

			Strength = strengthRating,
			Dexterity = dexterityRating,
			Agility = agilityRating,
			Intelligence = intelligenceRating,
			Spirit = spiritRating,
			Charisma = charismaRating,
			Vitality = vitalityRating,
			Fortitude = fortitudeRating,

			MaxHealth = (modFromRating(fortitudeRating) * 5) + 10,
			CurrentHealth = (modFromRating(fortitudeRating) * 5) + 10,
            MaxMana = (modFromRating(spiritRating) * 5) + 10,
            CurrentMana = (modFromRating(spiritRating) * 5) + 10,
            PhysicalResistance = modFromRating(fortitudeRating),
            MagicResistance = modFromRating(fortitudeRating),
            PlusToHit = (int)dexterityRating,
			PhysicalDamageBonus = modFromRating(strengthRating),
            MagicDamageBonus = modFromRating(intelligenceRating),
            AgilityBonus = (int)agilityRating,
			MovementSpeed = (int)agilityRating + 3,

			Initiative = 0
		});
	}

	private void DistributeStatPoints(int statPoints)
	{
		for (int i = 0; i < statPoints; i++) // For every stat point to distribute
		{
			float random = Random.Range(0f, 1f); // Calculate a random number between 0 and 1
			float cumulativeWeight = 0f;

			// Go through each stat and check which range the random number falls into
			for (int statWeight = 0; statWeight < 6; statWeight++)
			{
				// Increase the cumulative weight by the amount specified in the current classes' weight map
				cumulativeWeight += classWeights[currentClass][statWeight]; 

				if (random < cumulativeWeight)
				{
					// Increment the corresponding stat based on the random number falling within this weight range
					switch (statWeight)
					{
						case 0: enduranceStat++; break;
						case 1: strengthStat++; break;
						case 2: dexterityStat++; break;
						case 3: agilityStat++; break;
						case 4: intelligenceStat++; break;
						case 5: spiritStat++; break;
					}
					break;
				}
			}
		}
	}

	private void DistributeRatingPoints()
	{
		int pointsToDistribute = (int)currentRating * 2;
		int bonusPoints = 0;
		float chanceOfBonus = variables.chanceOfBonusPointOnRatingUp;

		for (int i = 0; i < pointsToDistribute / 2; i++)
		{
			int randomNumber = Random.Range(0, 100);
			if (randomNumber < chanceOfBonus)
				bonusPoints++;
			chanceOfBonus += 2;
		}

		Debug.Log("Bonus points awarded: " + bonusPoints);
		pointsToDistribute += bonusPoints;

		for (int i = 0; i < pointsToDistribute; i++)
		{
            float random = Random.Range(0f, 1f); // Calculate a random number between 0 and 1
            float cumulativeWeight = 0f;

            // Go through each stat rating and check which range the random number falls into
            for (int statWeight = 0; statWeight < 8; statWeight++)
            {
                // Increase the cumulative weight by the amount specified in the current classes' weight map
                cumulativeWeight += typeWeights[currentType][statWeight];

                if (random < cumulativeWeight)
                {
                    // Increment the corresponding stat based on the random number falling within this weight range
                    switch (statWeight)
                    {
                        case 0: strengthRating++; break;
                        case 1: dexterityRating++; break;
                        case 2: agilityRating++; break;
                        case 3: intelligenceRating++; break;
                        case 4: spiritRating++; break;
                        case 5: charismaRating++; break;
                        case 6: vitalityRating++; break;
                        case 7: fortitudeRating++; break;
                    }
                    break;
                }
            }
        }
	}

	private int CalculateLevelBasedOnRarity(Rarity rarity)
    {
		return rarity switch
		{
			Rarity.Low_Common => Random.Range(1, 10),
			Rarity.Mid_Common => Random.Range(11, 20),
			Rarity.High_Common => Random.Range(21, 30),
			Rarity.Low_Uncommon => Random.Range(31, 40),
			Rarity.Mid_Uncommon => Random.Range(41, 50),
			Rarity.High_Uncommon => Random.Range(51, 60),
			Rarity.Low_Rare => Random.Range(61, 70),
			Rarity.Mid_Rare => Random.Range(71, 80),
			Rarity.High_Rare => Random.Range(81, 90),
			Rarity.Low_Epic => Random.Range(91, 100),
			Rarity.Mid_Epic => Random.Range(101, 110),
			Rarity.High_Epic => Random.Range(111, 120),
			Rarity.Low_Legendary => Random.Range(121, 130),
			Rarity.Mid_Legendary => Random.Range(131, 140),
			Rarity.High_Legendary => Random.Range(141, 150),
			Rarity.Low_Cataclysmic => Random.Range(151, 160),
			Rarity.Mid_Cataclysmic => Random.Range(161, 170),
			Rarity.High_Cataclysmic => Random.Range(171, 180),
			_ => 0,
		};
	}

    private int CalculateStatPointsBasedOnLevel(int level)
    {
        int sum = 0;
        for (int i = 0; i < level; i++)
        {
            if (i <= 30) // For commons, they get 3 stat points per level
            {
                sum += 3;
            }
            else if (i <= 60) // Uncommons get 5 stat points per level
            {
                sum += 5;
            }
            else if (i <= 90)
			{
				sum += 7;
			}
			else if (i <= 120)
			{
				sum += 9;
			}
			else if (i <= 150)
			{
				sum += 11;
			}
			else if (i <= 180)
			{
				sum += 13;
			}
		}
        return sum;
    }

	public void Start()
	{
		// Sets the dropdown menus' to have the correct enum to choose from
		rarityDropdown.options.Clear();
		foreach (string rarityName in Enum.GetNames(typeof(Rarity)))
		{
			rarityDropdown.options.Add(new TMP_Dropdown.OptionData(rarityName));
		}
		classDropdown.options.Clear();
		foreach (string className in Enum.GetNames(typeof(Class)))
		{
			classDropdown.options.Add(new TMP_Dropdown.OptionData(className));
		}

        lordshipRatingDropdown.options.Clear();
        foreach (string ratingName in Enum.GetNames(typeof(Rating)))
        {
            lordshipRatingDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
        }
        lordshipTypeDropdown.options.Clear();
        foreach (string typeName in Enum.GetNames(typeof(Type)))
        {
            lordshipTypeDropdown.options.Add(new TMP_Dropdown.OptionData(typeName));
        }

        lordshipRatingDropdown.onValueChanged.AddListener(OnRatingDropdownValueChanged);
        lordshipTypeDropdown.onValueChanged.AddListener(OnTypeDropdownValueChanged);

        lordshipRatingDropdown.RefreshShownValue();
        lordshipTypeDropdown.RefreshShownValue();

        rarityDropdown.onValueChanged.AddListener(OnRarityDropdownValueChanged);
        classDropdown.onValueChanged.AddListener(OnClassDropdownValueChanged);

		rarityDropdown.RefreshShownValue();
        classDropdown.RefreshShownValue();
	}

	public void OnRarityDropdownValueChanged(int index)
	{
		currentRarity = (Rarity)index;
        Debug.Log("Rarity changed to: " + currentRarity);
	}

	public void OnClassDropdownValueChanged(int index)
	{
		currentClass = (Class)index;
		Debug.Log("Class changed to: " + currentClass);
	}

    public void OnRatingDropdownValueChanged(int index)
    {
        currentRating = (Rating)index;
        Debug.Log("Rating changed to: " + currentRating);
    }

    public void OnTypeDropdownValueChanged(int index)
    {
        currentType = (Type)index;
        Debug.Log("Type changed to: " + currentType);
    }
}