using System;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
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

	public static readonly Dictionary<Class, float[]> classWeights = new Dictionary<Class, float[]>
	{
        // endurance strength dexterity agility spirit
        { Class.Warrior, new float[] { 0.35f, 0.3f, 0.2f, 0.1f, 0.05f} },
		{ Class.Archer, new float[] { 0.3f, 0.05f, 0.35f, 0.25f, 0.05f} },
		{ Class.Rogue, new float[] { 0.2f, 0.1f, 0.3f, 0.35f, 0.05f} },
		{ Class.Mage, new float[] { 0.2f, 0.0f, 0.2f, 0.1f, 0.5f} },

		{ Class.All_Rounder, new float[] { 0.2375f, 0.175f, 0.2f, 0.2125f, 0.0875f} },

		{ Class.Warrior_Archer, new float[] { 0.3333333333f, 0.2666666667f, 0.2666666667f, 0.1333333333f, 0.0f} },
		{ Class.Warrior_Rogue, new float[] { 0.3333333333f, 0.2666666667f, 0.2f, 0.2f, 0.0f} },
		{ Class.Warrior_Mage, new float[] { 0.3166666667f, 0.2f, 0.1333333333f, 0.1166666667f, 0.1166666667f} },

		{ Class.Archer_Warrior, new float[] { 0.2666666667f, 0.2333333333f, 0.3333333333f, 0.1666666667f, 0.0f} },
		{ Class.Archer_Rogue, new float[] { 0.2f, 0.2f, 0.3333333333f, 0.2666666667f, 0.0f} },
		{ Class.Archer_Mage, new float[] { 0.1833333333f, 0.1333333333f, 0.2666666667f, 0.1833333333f, 0.1166666667f} },

		{ Class.Rogue_Warrior, new float[] { 0.2666666667f, 0.2333333333f, 0.2f, 0.3f, 0.0f} },
		{ Class.Rogue_Archer, new float[] { 0.2f, 0.2f, 0.2666666667f, 0.3333333333f, 0.0f} },
		{ Class.Rogue_Mage, new float[] { 0.1833333333f, 0.1333333333f, 0.1333333333f, 0.3166666667f, 0.1166666667f} },

		{ Class.Mage_Warrior, new float[] { 0.2333333333f, 0.1f, 0.06666666667f, 0.1333333333f, 0.2333333333f} },
		{ Class.Mage_Archer, new float[] { 0.1666666667f, 0.06666666667f, 0.1333333333f, 0.1666666667f, 0.2333333333f} },
		{ Class.Mage_Rogue, new float[] { 0.1666666667f, 0.06666666667f, 0.06666666667f, 0.2333333333f, 0.2333333333f} },

		{ Class.Warrior_Archer_Rogue, new float[] { 0.3f, 0.25f, 0.2666666667f, 0.1833333333f, 0.0f} },
		{ Class.Warrior_Archer_Mage, new float[] { 0.2916666667f, 0.2166666667f, 0.2333333333f, 0.1416666667f, 0.05833333333f} },
		{ Class.Warrior_Rogue_Archer, new float[] { 0.3f, 0.25f, 0.2333333333f, 0.2166666667f, 0.0f} },
		{ Class.Warrior_Rogue_Mage, new float[] { 0.2916666667f, 0.2166666667f, 0.1666666667f, 0.2083333333f, 0.05833333333f} },
		{ Class.Warrior_Mage_Archer, new float[] { 0.2833333333f, 0.1833333333f, 0.1666666667f, 0.1333333333f, 0.1166666667f} },
		{ Class.Warrior_Mage_Rogue, new float[] { 0.2833333333f, 0.1833333333f, 0.1333333333f, 0.1666666667f, 0.1166666667f} },

		{ Class.Archer_Warrior_Rogue, new float[] { 0.2666666667f, 0.2333333333f, 0.3f, 0.2f, 0.0f} },
		{ Class.Archer_Warrior_Mage, new float[] { 0.2583333333f, 0.2f, 0.2666666667f, 0.1583333333f, 0.05833333333f} },
		{ Class.Archer_Rogue_Warrior, new float[] { 0.2333333333f, 0.2166666667f, 0.3f, 0.25f, 0.0f} },
		{ Class.Archer_Rogue_Mage, new float[] { 0.1916666667f, 0.1666666667f, 0.2666666667f, 0.2583333333f, 0.05833333333f} },
		{ Class.Archer_Mage_Warrior, new float[] { 0.2166666667f, 0.15f, 0.2333333333f, 0.1666666667f, 0.1166666667f} },
		{ Class.Archer_Mage_Rogue, new float[] { 0.1833333333f, 0.1333333333f, 0.2333333333f, 0.2166666667f, 0.1166666667f} },

		{ Class.Rogue_Warrior_Archer, new float[] { 0.2666666667f, 0.2333333333f, 0.2333333333f, 0.2666666667f, 0.0f} },
		{ Class.Rogue_Warrior_Mage, new float[] { 0.2583333333f, 0.2f, 0.1666666667f, 0.2583333333f, 0.05833333333f} },
		{ Class.Rogue_Archer_Warrior, new float[] { 0.2333333333f, 0.2166666667f, 0.2666666667f, 0.2833333333f, 0.0f} },
		{ Class.Rogue_Archer_Mage, new float[] { 0.1916666667f, 0.1666666667f, 0.2333333333f, 0.2916666667f, 0.05833333333f} },
		{ Class.Rogue_Mage_Warrior, new float[] { 0.2166666667f, 0.15f, 0.1333333333f, 0.2666666667f, 0.1166666667f} },
		{ Class.Rogue_Mage_Archer, new float[] { 0.1833333333f, 0.1333333333f, 0.1666666667f, 0.2833333333f, 0.1166666667f} },

		{ Class.Mage_Warrior_Archer, new float[] { 0.2416666667f, 0.1333333333f, 0.1333333333f, 0.1416666667f, 0.175f} },
		{ Class.Mage_Warrior_Rogue, new float[] { 0.2416666667f, 0.1333333333f, 0.1f, 0.175f, 0.175f} },
		{ Class.Mage_Archer_Warrior, new float[] { 0.2083333333f, 0.1166666667f, 0.1666666667f, 0.1583333333f, 0.175f} },
		{ Class.Mage_Archer_Rogue, new float[] { 0.175f, 0.1f, 0.1666666667f, 0.2083333333f, 0.175f} },
		{ Class.Mage_Rogue_Warrior, new float[] { 0.2083333333f, 0.1166666667f, 0.1f, 0.225f, 0.175f} },
		{ Class.Mage_Rogue_Archer, new float[] { 0.175f, 0.1f, 0.1333333333f, 0.2416666667f, 0.175f} }
	};

	public enum ElementTier
	{
		Single,
		Double,
		Triple
	}

	public static readonly Dictionary<string, string[]> singleElementsList = new Dictionary<string, string[]>
	{
		{ "Fire",   new[] { "Blazing Dash", "Flame Burst", "Flame Grasp", "Phoenix Fire", "Flame Manipulation", "Cinderstorm" } },
		{ "Water",  new[] { "Tidal Surge", "Water Manipulation", "Mist Veil", "Healing Waters", "Rejuvenating Liquid", "Erosion" } },
		{ "Earth",  new[] { "Stone Grasp", "Quake Burst", "Terra Ward", "Granite Skin", "Seismic Sense", "Earth Manipulation" } },
		{ "Air",    new[] { "Tempest Step", "Cyclone", "Air Shroud", "Air Manipulation", "Gale Blade", "Vacuum" } },
		{ "Light",  new[] { "Flare", "Light Manipulation", "Halo Ward", "Dawnstep", "Beacon Pulse", "Aegis of the Sun" } },
		{ "Dark",   new[] { "Dark Grasp", "Dark Pulse", "Dark Shroud", "Dark Rend", "Dark Step", "Dark Manipulation" } },
	};

	public static readonly Dictionary<string, string[]> dualElementsList = new Dictionary<string, string[]>
	{
		{ "Hellfire",  new[] { "Infernal Brand", "Damnation Burst", "Soul Scorch", "Hellfire Manipulation", "Devil's Grasp", "Pillar of Torment" } },
		{ "Lightning",  new[] { "Charged Weapon", "Thunder Dash", "Arc Sphere", "Volt Chain", "Lightning Manipulation", "Lightning Aura" } },
		{ "Metal",  new[] { "Steel Skin", "Forgemaster's Bulwark", "Mercurial Shift", "Iron Rend", "Metal Manipulation", "Magnet Lash" } },
		{ "Steam",   new[] { "Steam Manipulation", "Mist Cloak", "Pressure Vent", "Condense", "Steam Jet", "Superheat" } },
		{ "Necrotic",   new[] { "Necrotic Manipulation", "Ashen Grasp", "Scorchbone", "Funeral Pyre", "Necrotic Furnace", "Necrowake" } },
		{ "Solar",  new[] { "Solar Manipulation", "Flare Nova", "Solar Ascension", "Radiant Renewal", "Corona Shield", "Daybreak" } },
	};

	public static readonly Dictionary<string, string[]> triElementsList = new Dictionary<string, string[]>
	{
		{ "Inferno",    new[] { "Hellfire Wave", "Meteor Crash", "Dragon’s Breath", "Volcanic Roar", "Ember Nova", "Infernal Spiral" } },
		{ "Tsunami",    new[] { "Abyssal Surge", "Leviathan Call", "Riptide Rend", "Aqua Maelstrom", "Stormfront", "Drown" } },
		{ "Gaia",       new[] { "Worldbreaker", "Nature’s Wrath", "Primeval Crush", "Living Mountain", "Verdant Pulse", "Cataclysm" } },
		{ "Hurricane",  new[] { "Skyfall", "Thunderstorm", "Supercell", "Typhoon Crash", "Storm Barrier", "Jetstream Blade" } },
		{ "Creation",   new[] { "Genesis Beam", "Ordershift", "Reality Stitch", "Axiom Burst", "Starforge", "Emanation" } },
		{ "Void",       new[] { "Null Sphere", "Entropy Lash", "Black Star", "Erase", "Void Step", "Oblivion Surge" } }
	};

	public static readonly string[] warriorWeapons = new string[]
	{
		"Greatsword",
		"Greataxe",
		"GreatHammer",
		"GreatSpear",
		"Polearm",
		"Longsword",
		"Waraxe",
		"Battleaxe",
		"Mace",
		"Maul",
		"Shortspear",
		"Spear",
	};


	public static readonly string[] rogueWeapons = new string[]
	{
		"Thrown Weapon",
		"Shortsword",
		"Dagger",
	};


	public static readonly string[] archerWeapons = new string[]
	{
		"GreatBow",
		"Ballista",
		"Longbow",
		"Shortbow",
		"Crossbow",
	};


	public static readonly string[] mageWeapons = new string[]
	{
		"Staff",
	};

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
		Heavenly_Soldier,
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
		{ Type.Aethereal_Golem, new float[] { .300f, .050f, .050f, .000f, .000f, .000f, .400f, .200f } },
		{ Type.Aethereal_Ghost, new float[] { .000f, .125f, .000f, .200f, .375f, .050f, .125f, .125f } },
		{ Type.Aethereal_Wisp, new float[] { .000f, .100f, .125f, .300f, .300f, .000f, .200f, .100f } },
		{ Type.Aethereal_ManaVampire, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Aethereal_Catoblepas, new float[] { .250f, .100f, .050f, .000f, .000f, .000f, .300f, .300f } },
		{ Type.Aethereal_Beholder, new float[] { .000f, .125f, .100f, .225f, .125f, .125f, .100f, .200f } },
		{ Type.Natural_Treant, new float[] { .300f, .100f, .000f, .000f, .100f, .000f, .300f, .200f } },
		{ Type.Natural_Druid, new float[] { .050f, .150f, .150f, .250f, .200f, .050f, .100f, .050f } },
		{ Type.Natural_Dryad, new float[] { .000f, .250f, .150f, .150f, .150f, .100f, .100f, .100f } },
		{ Type.Natural_Nymph, new float[] { .150f, .200f, .100f, .100f, .100f, .300f, .050f, .000f } },
		{ Type.Natural_CreepingVine, new float[] { .250f, .250f, .000f, .000f, .000f, .000f, .250f, .250f } },
		{ Type.Natural_PoisonBulb, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Natural_VenusPersonTrap, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Heavenly_Messenger, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Heavenly_Soldier, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Heavenly_Scribe, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Heavenly_Angel, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Heavenly_Watcher, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Heavenly_Virtue, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Misc_Dragon, new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f } },
		{ Type.Misc_Wyvern, new float[] { .250f, .125f, .250f, .000f, .000f, .000f, .225f, .150f } },
		{ Type.Misc_Ogre, new float[] { .300f, .000f, .000f, .000f, .000f, .000f, .300f, .400f } },
		{ Type.Misc_Goblin, new float[] { .125f, .125f, .275f, .125f, .125f, .000f, .100f, .125f } },
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
	[Tooltip("This is how far above a character's current rating their highest stat can be.")]
	public int statCeilingAboveCurrentRating = 2;

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