using System.Collections.Generic;
using UnityEngine;

public class Variables : ScriptableObject
{
	[Header("Leveling Up")]
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
}