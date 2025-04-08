using System;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
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

	private static List<Treasure> treasureList = new()
	{
		new Treasure ("Legendary Enchanting Dust", 250_000_000),
		new Treasure ("Cateclysmic Alchemy Ingredient", 200_000_000, new string[] 
		{
			"Seraphim Flower",
			"Demonic Flower",
			"Nelsiim Flower",
			"Elemental Flower"
		}),
		new Treasure ("Legendary Material", 100_000_000, new string[]
		{
			"Demonic Essence",
			"Divine Essence"
		}),
		new Treasure ("Ancient Sage's Wisdom", 50_000_000),
		new Treasure ("Gem-Encrusted Platinum Crown", 25_000_000),
		new Treasure ("Shard of Emperor Helgard's Sword", 10_000_000),
		new Treasure ("Dragon Horde Gemstone", 5_000_000),
		new Treasure ("Epic Enchanting Dust", 2_500_000),
		new Treasure ("Epic Material", 1_000_000, new string[]
		{
			"Draconic Remnants",
			"Mythril Ingot",
			"Jade Silk"
		}),
		new Treasure ("Gem-Encrusted Golden Chalice", 750_000),
		new Treasure ("Legendary Alchemy Ingredient", 500_000, new string[] 
		{
			"Malkley's Shade Flower",
			"Primordial Dew Drop"
		}),
		new Treasure ("Diamond Ring", 250_000),
		new Treasure ("Ruby Brooch", 100_000),
		new Treasure ("Rare Enchanting Dust", 50_000),
		new Treasure ("Rare Material", 20_000, new string[] 
		{
			"Dlaren Ingot",
			"Shade Leather",
			"Mana Silk"
		}),
		new Treasure ("Precious Gemstone", 15_000, new string[] 
		{
			"Diamond",
			"Emerald",
			"Sapphire"
		}),
		new Treasure ("Music Box", 10_000),
		new Treasure ("Gemstone", 6_000, new string[] 
		{
			"Ruby",
			"Amethest"
		}),
		new Treasure ("Uncommon Enchanting Dust", 4_000),
		new Treasure ("Epic Alchemy Ingredients", 3_000, new string[] 
		{
			"Ent Root",
			"Black Spotted Sponge Moss",
			"Mandrake Root",
			"Ocean Anise",
			"Salty Buxox",
			"Sapphire Aclloa",
			"Balme Leaves",
			"Gapruche Bloom",
			"Olusveritis",
			"Angelic Bloom Leaves",
			"Chasgruond Roots",
			"Damater",
			"Marmallow",
			"Pattran",
			"Culkcas Leaves",
			"Melland"
		}),
		new Treasure ("Engraved Silver Goblet", 2_500),
		new Treasure ("Silver Goblet", 2_000),
		new Treasure ("Uncommon Material", 1_500, new string[] 
		{
			"Steel Ingot",
			"Scaled Leather",
			"Threaded Silk"
		}),
		new Treasure ("Encyclopedia", 1_000),
		new Treasure ("Common Enchanting Dust", 500),
		new Treasure ("Common Material", 200, new string[] 
		{
			"Iron Ingot",
			"Leather Piece",
			"Mana Cloth"
		}),
		new Treasure ("Rare Alchemy Ingredients", 150, new string[] 
		{
			"Dream Berry",
			"Gorgon Tongue",
			"Rhododendron",
			"Chrysanthemum",
			"Asptongue",
			"Crypt Shrooms",
			"Ember Flower",
			"Draffe",
			"Killmatur",
			"Gylvaria",
			"Fetrefe",
			"Lunort",
			"Golcorone",
			"Iron Split Roots",
			"Vilerge"
		}),
		new Treasure ("Semi-Precious Stone", 75, new string[]
		{
			"Garnet",
			"Topaz"
		}),
		new Treasure ("Wooden Figurine", 40),
		new Treasure ("Uncommon Alchemy Ingredients", 30, new string[] 
		{
			"Rash Avens",
			"Grey Mold",
			"Strixcap",
			"Royal Barb",
			"Glowing Nettle",
			"Confrey Root",
			"Bonemeal",
			"Biset",
			"Darkroot",
			"Navouh Bush Roots",
			"Wodero Leaves",
			"Anserke Roots"
		}),
		new Treasure ("Copper Band", 15),
		new Treasure ("Common Alchemy Ingredients", 10, new string[] 
		{
			"Wyrmgrass",
			"Honeybell",
			"Toadstool",
			"Holly",
			"Desert Sage",
			"Cacti Bloom",
			"Withered Sand Harrier",
			"Amran",
			"Laumpor",
			"Macerate",
			"Olvar",
			"Five-Leaves",
			"Beer Spore"
		}),
	};

	public struct Treasure
	{
		public string name;
		public long value;
		public string[] breakdown;

		public Treasure(string name, long value, string[] breakdown = null)
		{
			this.name = name;
			this.value = value;
			this.breakdown = breakdown ?? new string[0];
		}
	}

	public static Dictionary<string, Treasure> treasureDictionary = new();

	public void Start()
	{
		foreach (var treasure in treasureList)
		{
			if (!treasureDictionary.ContainsKey(treasure.name))
			{
				treasureDictionary[treasure.name] = treasure;
			}
		}
	}

	public static Treasure GetTreasure(string name)
	{
		if (treasureDictionary.TryGetValue(name, out Treasure treasure))
		{
			return treasure;
		}
		throw new KeyNotFoundException($"Treasure '{name}' not found.");
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

	public static readonly Dictionary<Type, float[]> typeWeights = new()
	{
		// Strength, Dexterity, Agility, Intelligence, Spirit, Charisma, Vitality, Fortitude
		{ Type.Humanoid_Civilian, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Humanoid_Soldier, new float[] { .225f, .225f, .100f, .000f, .000f, .000f, .225f, .225f } },
		{ Type.Humanoid_Champion, new float[] { .250f, .100f, .050f, .000f, .000f, .100f, .250f, .250f } },
		{ Type.Humanoid_Commander, new float[] { .125f, .125f, .100f, .100f, .000f, .200f, .225f, .125f } },
		{ Type.Humanoid_Mage, new float[] { .025f, .125f, .100f, .300f, .300f, .025f, .100f, .025f } },
		{ Type.Humanoid_Battlemage, new float[] { .150f, .125f, .100f, .150f, .150f, .000f, .175f, .150f } },
		{ Type.Undead_Skeleton, new float[] { .250f, .300f, .075f, .000f, .000f, .000f, .150f, .225f } },
		{ Type.Undead_Lich, new float[] { .000f, .200f, .000f, .300f, .300f, .000f, .100f, .100f } },
		{ Type.Undead_Wight, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Undead_Zombie, new float[] { .400f, .000f, .000f, .000f, .000f, .000f, .300f, .300f } },
		{ Type.Undead_CorpseLord, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Undead_Vampire, new float[] { .100f, .175f, .125f, .125f, .125f, .075f, .150f, .125f } },
		{ Type.Undead_Ghoul, new float[] { .075f, .125f, .400f, .000f, .000f, .000f, .200f, .200f } },
		{ Type.Undead_DeathKnight, new float[] { .250f, .125f, .075f, .000f, .000f, .125f, .225f, .200f } },
		{ Type.Demonic_Devil, new float[] { .150f, .175f, .300f, .000f, .000f, .125f, .100f, .150f } },
		{ Type.Demonic_Imp, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Demonic_Demon, new float[] { .275f, .050f, .050f, .000f, .000f, .075f, .300f, .250f } },
		{ Type.Demonic_Azklat, new float[] { .000f, .125f, .125f, .250f, .250f, .000f, .125f, .125f } },
		{ Type.Demonic_Hellhound, new float[] { .400f, .100f, .250f, .000f, .000f, .000f, .250f, .000f } },
		{ Type.Demonic_MurderCat, new float[] { .300f, .125f, .450f, .000f, .000f, .000f, .125f, .000f } },
		{ Type.Demonic_Sin, new float[] { .150f, .125f, .125f, .150f, .150f, .000f, .150f, .150f } },
		{ Type.Abyssal_Mimic, new float[] { .250f, .250f, .000f, .000f, .000f, .000f, .250f, .250f } },
		{ Type.Abyssal_Remnant, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Abyssal_EldritchHorror, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Abyssal_Sludge, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Abyssal_WakingNightmare, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Abyssal_Aspect, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Aethereal_Golem, new float[] { .300f, .000f, .050f, .000f, .000f, .000f, .400f, .250f } },
		{ Type.Aethereal_Ghost, new float[] { .000f, .125f, .000f, .200f, .375f, .050f, .125f, .125f } },
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
		{ Type.Misc_Wyvern, new float[] { .250f, .125f, .250f, .000f, .000f, .000f, .225f, .150f } },
		{ Type.Misc_Ogre, new float[] { .300f, .000f, .000f, .000f, .000f, .000f, .300f, .400f } },
		{ Type.Misc_Goblin, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Misc_Bunyip, new float[] { .300f, .125f, .325f, .000f, .000f, .000f, .125f, .125f } },
		{ Type.Misc_Giant, new float[] { .425f, .050f, .050f, .000f, .000f, .100f, .200f, .175f } },
	};
}

[Serializable]
public class SaveData
{
	[Header("Leveling Up")]
	public int startingStatPoints = 2;
	public int statPointsPerLevelUp = 2;
	public int percentChanceOfBonusPointOnRatingUp = 2;
	public int increaseInBonusChancePerLevel = 2;
	public int numberOfStartingSkills = 2;
	public int upgradePointsPerLevel = 4;
	public int maximumSkills = 5;
	public int maximumFeats = 5;
	public int maximumSkillLevel = 3;
	public int maximumFeatLevel = 3;

	[Header("Modifiers")]
	public int F = 0;
	public int E = 3;
	public int D = 6;
	public int C = 9;
	public int B = 12;
	public int A = 15;
	public int S = 18;
	public int SS = 21;

	[Header("Miscellaneous")]
	public float percentOfCoinpurseAsTreasure = 0f;
	public float percentOfStashAsTreasure = .25f;
	public float percentOfLockboxAsTreasure = .4f;
	public float percentOfSafeAsTreasure = .6f;
	public float percentOfTreasuryAsTreasure = .75f;
	public float percentOfHordeAsTreasure = .8f;
	[Tooltip("Lower values make treasure trend towards more expensive while higher values makes treasure more random.")]
	public int treasureVariance = 3;
	[Tooltip("Generate Treasure will always generate at least 1 item, and this is the chance that no more items will be generated after any given item is generated.")]
	public float exitTreasureGenerationEarlyChance = .25f;
}