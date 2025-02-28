using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
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

	public static Dictionary<string, int> treasureList = new()
	{
		{ "Diamond-Encrusted Crystal Chalice", 1_000_000_000 },
		{ "Gold and Obsidian Box with Jade Lining", 750_000_000 },
		{ "Tsavorite Garnet-Encrusted Goblet", 500_000_000 },
		{ "Fire Opal and Ruby Lined Box", 250_000_000 },
		{ "Platinum and Diamond Utensil Set", 200_000_000 },
		{ "Benitoite-Encrusted Chalice with Neon Blue Sapphire", 175_000_000 },
		{ "Star Sapphire Box with Moldavite Stones", 150_000_000 },
		{ "Sapphire and Ruby Inlaid Goblet", 125_000_000 },
		{ "Obsidian Box with Fire Opal and Diamond", 100_000_000 },
		{ "Burmese Ruby-Studded Box of Sapphire Gems", 75_000_000 },
		{ "Platinum-Embellished Utensil Set with Malachite", 50_000_000 },
		{ "Golden Goblet with Benitoite and Alexandrite", 40_000_000 },
		{ "Emerald Box with Tsavorite Garnet and Topaz Stones", 30_000_000 },
		{ "Opal-Studded Chalice with Blue Garnet Rim", 20_000_000 },
		{ "Moldavite Lined Box of Ruby and Sapphire", 15_000_000 },
		{ "Voidsteel Goblet with Star Sapphire", 10_000_000 },
		{ "Mythic Sunstone", 10_000_000 },
		{ "Titan’s Eye Gem", 9_500_000 },
		{ "Ancient Lich's Soulstone", 9_000_000 },
		{ "The Unbreakable Adamant Orb", 8_500_000 },
		{ "Primordial Emerald Statue", 8_000_000 },
		{ "Sunstone-Encrusted Utensil Set", 7_500_000 },
		{ "Evershimmering Diamond Crown", 7_500_000 },
		{ "Phantom Jewel of the Elders", 7_000_000 },
		{ "Celestial Gold Compass", 6_500_000 },
		{ "Shadow Pearl of the Abyss", 6_000_000 },
		{ "Moonstone Box with Fire Opal Stones", 5_000_000 },
		{ "Frostbound Sapphire Idol", 5_000_000 },
		{ "Heart of the Mountain Ruby", 4_500_000 },
		{ "Platinum and Jade Encrusted Chalice", 4_000_000 },
		{ "Runestone of Forgotten Kings", 3_500_000 },
		{ "Gold-Plated Box with Pink Sapphire Lining", 3_000_000 },
		{ "Dragonlord's Gemmed Crown", 3_000_000 },
		{ "Crystal Goblet with Alexandrite and Fire Opal", 2_500_000 },
		{ "Ethereal Glass Tiara", 2_500_000 },
		{ "Dragonbone Box with Emerald and Sapphire Decorations", 2_000_000 },
		{ "Titanium-Embellished Utensil Set with Topaz Stones", 1_500_000 },
		{ "Scepter of the Moon Queen", 1_400_000 },
		{ "Platinum Goblet with Lapis Lazuli Base", 1_250_000 },
		{ "Obsidian Box with Ruby and Peridot Lining", 1_000_000 },
		{ "Imperial War Banner (Gold-Threaded)", 1_000_000 },
		{ "Gleaming Ruby Crown", 800_000 },
		{ "Golden Dragon Figurine", 750_000 },
		{ "Wooden Box with Amethyst-Studded Lining", 500_000 },
		{ "Ivory and Platinum Chalice with Garnet Stone", 400_000 },
		{ "Jeweled Music Box", 400_000 },
		{ "Phoenix Feather Quill", 350_000 },
		{ "Silver Encrusted Box with Emerald and Sapphire", 300_000 },
		{ "Dragonfang Necklace", 300_000 },
		{ "Diamond-Inlaid Goblet with Pink Star Diamond", 250_000 },
		{ "Silver Crown of a Forgotten King", 200_000 },
		{ "Platinum Necklace with Sapphire", 150_000 },
		{ "Royal Signet Ring", 120_000 },
		{ "Runed Gold Circlet", 100_000 },
		{ "Benitoite and Obsidian Box", 75_000 },
		{ "Crystal-Topped Scepter", 60_000 },
		{ "Bronze Gemstone Box with Red Beryl Lining", 52_500 },
		{ "Diamond Ring", 50_000 },
		{ "Emerald-Encrusted Chalice with Imperial Topaz", 35_000 },
		{ "Silver Encrusted Box with Paraiba Tourmaline", 30_000 },
		{ "Platinum Utensil Set with Moldavite Details", 25_000 },
		{ "Ancient Gold Coin Collection", 25_000 },
		{ "Gold-Plated Goblet with Tanzanite Stones", 20_000 },
		{ "Jewel-Encrusted Goblet", 20_000 },
		{ "Sunstone Encrusted Box of Blue Sapphire Gems", 15_000 },
		{ "Golden Chalice", 15_000 },
		{ "Voidsteel Chalice with Fire Opal Stones", 12_000 },
		{ "Moonstone-Encrusted Box with Alexandrite Lid", 11_000 },
		{ "Sapphire Pendant", 10_000 },
		{ "Jeweled Anklet", 9_000 },
		{ "Platinum Bracelet", 8_000 },
		{ "Opal-Encrusted Brooch", 7_500 },
		{ "Gilded Candle Holder", 6_000 },
		{ "Ruby Ring", 5_000 },
		{ "Antique Silver Mirror", 4_000 },
		{ "Emerald Stud Earring", 2_500 },
		{ "Gem-Set Belt Buckle", 2_000 },
		{ "Miniature Golden Idol", 1_750 },
		{ "Engraved Silver Locket", 1_500 },
		{ "Small Pearl Earring", 1_250 },
		{ "Decorated Clay Chalice", 1_000 },
		{ "Gold-Plated Spoon", 800 },
		{ "Silver Goblet", 650 },
		{ "Ornate Copper Hairpin", 400 },
		{ "Ivory Dice Set", 300 },
		{ "Small Silver Pendant", 200 },
		{ "Bronze Bracelet", 150 },
		{ "Simple Silver Ring", 100 },
		{ "Iron Chalice", 100 },
		{ "Wooden Goblet", 75 },
		{ "Wooden Figurine", 75 },
		{ "Tin Brooch", 50 },
		{ "Copper Band", 25 },
	};
}