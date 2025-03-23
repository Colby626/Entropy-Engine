using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Text;

public class GenerateStats : MonoBehaviour
{
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

	private static readonly Dictionary<Type, float[]> typeWeights = new ()
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

	public TMP_Dropdown lordshipRatingDropdown;
	public TMP_Dropdown lordshipTypeDropdown;

	private Rating currentRating;
	private Type currentType;

    private Rating strengthRating = Rating.F;
    private Rating dexterityRating = Rating.F;
    private Rating agilityRating = Rating.F;
    private Rating intelligenceRating = Rating.F;
    private Rating spiritRating = Rating.F;
	private Rating charismaRating = Rating.F;
    private Rating vitalityRating = Rating.F;
    private Rating fortitudeRating = Rating.F;

    public CharacterList characterList;
	private Variables variables;

	// Called by the Generate button
	public void GenerateLordshipStatPoints()
	{
		variables = FindObjectOfType<OptionsMenu>().settings;
        strengthRating = Rating.F;
		dexterityRating = Rating.F;
		agilityRating = Rating.F;
		intelligenceRating = Rating.F;
		spiritRating = Rating.F;
		charismaRating = Rating.F;
		vitalityRating = Rating.F;
		fortitudeRating = Rating.F;

		DistributeRatingPoints();

		int upgradePoints = variables.upgradePointsPerLevel * (int)currentRating;

        int randomIndex = Random.Range(0, Variables.adventurerAdjectives.Length);
        string randomAdjective = Variables.adventurerAdjectives[randomIndex];

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

			MaxHealth = ((int)vitalityRating * 50) == 0 ? 10 : (int)vitalityRating * 50, // This means if the vitalityRating * 50 equals 0, MaxHealth is set to 10
			CurrentHealth = ((int)vitalityRating * 50) == 0 ? 10 : (int)vitalityRating * 50, // Otherwise, it is set to vitalityRating * 50
			MaxMana = (int)spiritRating * 50,
			CurrentMana = (int)spiritRating * 50,
			PlusToHit = (int)dexterityRating,
			PhysicalDamageMultiplier = MultiplierFromRating(strengthRating),
            MagicDamageMultiplier = MultiplierFromRating(intelligenceRating),
			DodgeBonus = ModFromRating(agilityRating),
			MovementSpeed = (int)agilityRating * 2 + 3,

			Initiative = 0,
			Abilities = GenerateAbilities(upgradePoints, SkillsPoolFromType(), FeatsPoolFromType()),
			Notes = "",
        },
		currentRating);
    }

    private string GenerateAbilities(int upgradePoints, string[] skillsPool, string[] featsPool)
	{
		string[] selectedSkills;
		Dictionary<string, int> skillLevels = new ();
		Dictionary<string, int> featLevels = new ();

		selectedSkills = new string[variables.numberOfStartingSkills];
		List<string> availableSkills = new (skillsPool);
		List<string> availableFeats = new (featsPool);
		int numberOfStartingSkills = variables.numberOfStartingSkills;

		// Pick unique starting skills
		// Humanoids must have at least one martial skill or magic skill
		if (currentType == Type.Humanoid_Champion ||
			currentType == Type.Humanoid_Civilian ||
			currentType == Type.Humanoid_Commander ||
			currentType == Type.Humanoid_Soldier)
		{
			int index = Random.Range(0, Abilities.martialSkills.Length);
			skillLevels[Abilities.martialSkills[index]] = 1;
			numberOfStartingSkills--;
		}
		if (currentType == Type.Humanoid_Battlemage ||
			currentType == Type.Humanoid_Mage)
		{
			int index = Random.Range(0, Abilities.arcaneSkills.Length);
			skillLevels[Abilities.arcaneSkills[index]] = 1;
			numberOfStartingSkills--;
		}

		if (numberOfStartingSkills >= 1)
		{
            // Humanoids must have at least one armor skill
            if (currentType == Type.Humanoid_Champion ||
                currentType == Type.Humanoid_Civilian)
            {
                int index = Random.Range(0, Abilities.armorSkills.Length);
                skillLevels[Abilities.armorSkills[index]] = 1;
            }
            else if (currentType == Type.Humanoid_Mage)
            {
                skillLevels["Light Armor"] = 1;
            }
			else if (currentType == Type.Humanoid_Soldier)
			{
                int index = Random.Range(0, 2);
				if (index == 0)
					skillLevels["Medium Armor"] = 1;
				else
					skillLevels["Heavy Armor"] = 1;
            }
			else if (currentType == Type.Humanoid_Commander ||
					 currentType == Type.Humanoid_Battlemage)
			{
                skillLevels["Heavy Armor"] = 1;
            }
            numberOfStartingSkills--;
        }

		for (int i = 0; i < numberOfStartingSkills; i++)
		{
			if (availableSkills.Count == 0) break; // Safety check
			int index = Random.Range(0, availableSkills.Count);
			string skill = availableSkills[index];
			availableSkills.RemoveAt(index);
			selectedSkills[i] = skill;
			skillLevels[skill] = 1; // Start at level 1
		}

		// Pick one random feat
		if (availableFeats.Count > 0)
		{
			int index = Random.Range(0, availableFeats.Count);
			string feat = availableFeats[index];
			availableFeats.RemoveAt(index);
			featLevels[feat] = 1; // Feats start at level 1
		}

		// Spend upgrade points
		while (upgradePoints > 0)
		{
			bool validUpgradeFound = false;  // Track if any valid upgrade is found

			// Randomly decide whether to upgrade a skill, upgrade a feat, or pick a new one
			int choice = Random.Range(0, 3); // 0 = skill upgrade, 1 = feat upgrade, 2 = new pick

			if (choice == 0 && skillLevels.Count > 0)
			{
				// Upgrade an existing skill
				List<string> upgradableSkills = new ();
				foreach (var skill in skillLevels)
				{
					if (skill.Value < 5 && upgradePoints >= skill.Value + 1) // Ensure enough points
						upgradableSkills.Add(skill.Key);
				}

				if (upgradableSkills.Count > 0)
				{
					string skillToUpgrade = upgradableSkills[Random.Range(0, upgradableSkills.Count)];
					int cost = skillLevels[skillToUpgrade] + 1;
					skillLevels[skillToUpgrade]++;
					upgradePoints -= cost;
					validUpgradeFound = true;
				}
			}
			else if (choice == 1 && featLevels.Count > 0)
			{
				// Upgrade an existing feat
				List<string> upgradableFeats = new ();
				foreach (var feat in featLevels)
				{
					if (feat.Value < 3 && upgradePoints >= (feat.Value + 1) * 2) // Ensure enough points
						upgradableFeats.Add(feat.Key);
				}

				if (upgradableFeats.Count > 0)
				{
					string featToUpgrade = upgradableFeats[Random.Range(0, upgradableFeats.Count)];
					int cost = (featLevels[featToUpgrade] + 1) * 2;
					featLevels[featToUpgrade]++;
					upgradePoints -= cost;
					validUpgradeFound = true;
				}
			}
			else if (choice == 2 && availableSkills.Count > 0 && skillLevels.Count < variables.maximumSkills)
			{
				// Pick a new skill
				int index = Random.Range(0, availableSkills.Count);
				string newSkill = availableSkills[index];
				availableSkills.RemoveAt(index);
				skillLevels[newSkill] = 1;
				upgradePoints -= 1;
				validUpgradeFound = true;
			}
			else if (choice == 2 && availableFeats.Count > 0 && featLevels.Count < variables.maximumFeats && upgradePoints >= 2)
			{
				// Pick a new feat
				int index = Random.Range(0, availableFeats.Count);
				string newFeat = availableFeats[index];
				availableFeats.RemoveAt(index);
				featLevels[newFeat] = 1;
				upgradePoints -= 2;
				validUpgradeFound = true;
			}

			// If no valid upgrade was found, check for the next valid action instead of exiting
			if (!validUpgradeFound && upgradePoints < 6) // Go through the loop again if you can purchase the most expensive upgrade
			{
				// If no valid upgrades are available, break the loop to avoid infinite loops
				break;
			}
		}

		StringBuilder result = new ();

		foreach (var skill in skillLevels)
		{
			result.AppendLine($"{skill.Key}: {skill.Value}");
		}

		foreach (var feat in featLevels)
		{
			result.AppendLine($"{feat.Key}: {feat.Value}");
		}

		return result.ToString();
	}

	private string[] SkillsPoolFromType()
	{
		return currentType switch
		{
			// Humanoids
			Type.Humanoid_Civilian => Abilities.humanoidCivilianSkills,
			Type.Humanoid_Soldier => Abilities.humanoidSoldierSkills,
			Type.Humanoid_Champion => Abilities.humanoidChampionSkills,
			Type.Humanoid_Commander => Abilities.humanoidCommanderSkills,
			Type.Humanoid_Mage => Abilities.humanoidMageSkills,
			Type.Humanoid_Battlemage => Abilities.humanoidBattlemageSkills,

			// Undead
			Type.Undead_Skeleton => Abilities.undeadSkeletonSkills,
			Type.Undead_Lich => Abilities.undeadLichSkills,
			Type.Undead_Wight => Abilities.undeadWightSkills,
			Type.Undead_Zombie => Abilities.undeadZombieSkills,
			Type.Undead_CorpseLord => Abilities.undeadCorpseLordSkills,
			Type.Undead_Vampire => Abilities.undeadVampireSkills,
			Type.Undead_Ghoul => Abilities.undeadGhoulSkills,
			Type.Undead_DeathKnight => Abilities.undeadDeathKnightSkills,

			// Demonic
			Type.Demonic_Devil => Abilities.demonicDevilSkills,
			Type.Demonic_Imp => Abilities.demonicImpSkills,
			Type.Demonic_Demon => Abilities.demonicDemonSkills,
			Type.Demonic_Azklat => Abilities.demonicAzklatSkills,
			Type.Demonic_Hellhound => Abilities.demonicHellhoundSkills,
			Type.Demonic_MurderCat => Abilities.demonicMurderCatSkills,
			Type.Demonic_Sin => Abilities.demonicSinSkills,

			// Abyssal
			Type.Abyssal_Mimic => Abilities.abyssalMimicSkills,
			Type.Abyssal_Remnant => Abilities.abyssalRemnantSkills,
			Type.Abyssal_EldritchHorror => Abilities.abyssalEldritchHorrorSkills,
			Type.Abyssal_Sludge => Abilities.abyssalSludgeSkills,
			Type.Abyssal_WakingNightmare => Abilities.abyssalWakingNightmareSkills,
			Type.Abyssal_Aspect => Abilities.abyssalAspectSkills,

			// Aethereal
			Type.Aethereal_Golem => Abilities.aetherealGolemSkills,
			Type.Aethereal_Ghost => Abilities.aetherealGhostSkills,
			Type.Aethereal_Wisp => Abilities.aetherealWispSkills,
			Type.Aethereal_ManaVampire => Abilities.aetherealManaVampireSkills,
			Type.Aethereal_Catoblepas => Abilities.aetherealCatoblepasSkills,
			Type.Aethereal_Beholder => Abilities.aetherealBeholderSkills,

			// Natural
			Type.Natural_Treant => Abilities.naturalTreantSkills,
			Type.Natural_Druid => Abilities.naturalDruidSkills,
			Type.Natural_Dryad => Abilities.naturalDryadSkills,
			Type.Natural_Nymph => Abilities.naturalNymphSkills,
			Type.Natural_CreepingVine => Abilities.naturalCreepingVineSkills,
			Type.Natural_PoisonBulb => Abilities.naturalPoisonBulbSkills,
			Type.Natural_VenusPersonTrap => Abilities.naturalVenusPersonTrapSkills,

			// Heavenly
			Type.Heavenly_Messenger => Abilities.heavenlyMessengerSkills,
			Type.Heavenly_Solider => Abilities.heavenlySoldierSkills,
			Type.Heavenly_Scribe => Abilities.heavenlyScribeSkills,
			Type.Heavenly_Angel => Abilities.heavenlyAngelSkills,
			Type.Heavenly_Watcher => Abilities.heavenlyWatcherSkills,
			Type.Heavenly_Virtue => Abilities.heavenlyVirtueSkills,

			// Miscellaneous
			Type.Misc_Dragon => Abilities.miscDragonSkills,
			Type.Misc_Wyvern => Abilities.miscWyvernSkills,
			Type.Misc_Ogre => Abilities.miscOgreSkills,
			Type.Misc_Goblin => Abilities.miscGoblinSkills,
			Type.Misc_Bunyip => Abilities.miscBunyipSkills,
			Type.Misc_Giant => Abilities.miscGiantSkills,

			// Default Case (Failsafe)
			_ => new string[] { "Unknown Skill" }
		};
	}

	private string[] FeatsPoolFromType()
	{
		return currentType switch
		{
			// Humanoids
			Type.Humanoid_Civilian => Abilities.humanoidCivilianAbilities,
			Type.Humanoid_Soldier => Abilities.humanoidSoldierAbilities,
			Type.Humanoid_Champion => Abilities.humanoidChampionAbilities,
			Type.Humanoid_Commander => Abilities.humanoidCommanderAbilities,
			Type.Humanoid_Mage => Abilities.humanoidMageAbilities,
			Type.Humanoid_Battlemage => Abilities.humanoidBattlemageAbilities,

			// Undead
			Type.Undead_Skeleton => Abilities.undeadSkeletonAbilities,
			Type.Undead_Lich => Abilities.undeadLichAbilities,
			Type.Undead_Wight => Abilities.undeadWightAbilities,
			Type.Undead_Zombie => Abilities.undeadZombieAbilities,
			Type.Undead_CorpseLord => Abilities.undeadCorpseLordAbilities,
			Type.Undead_Vampire => Abilities.undeadVampireAbilities,
			Type.Undead_Ghoul => Abilities.undeadGhoulAbilities,
			Type.Undead_DeathKnight => Abilities.undeadDeathKnightAbilities,

			// Demonic
			Type.Demonic_Devil => Abilities.demonicDevilAbilities,
			Type.Demonic_Imp => Abilities.demonicImpAbilities,
			Type.Demonic_Demon => Abilities.demonicDemonAbilities,
			Type.Demonic_Azklat => Abilities.demonicAzklatAbilities,
			Type.Demonic_Hellhound => Abilities.demonicHellhoundAbilities,
			Type.Demonic_MurderCat => Abilities.demonicMurderCatAbilities,
			Type.Demonic_Sin => Abilities.demonicSinAbilities,

			// Abyssal
			Type.Abyssal_Mimic => Abilities.abyssalMimicAbilities,
			Type.Abyssal_Remnant => Abilities.abyssalRemnantAbilities,
			Type.Abyssal_EldritchHorror => Abilities.abyssalEldritchHorrorAbilities,
			Type.Abyssal_Sludge => Abilities.abyssalSludgeAbilities,
			Type.Abyssal_WakingNightmare => Abilities.abyssalWakingNightmareAbilities,
			Type.Abyssal_Aspect => Abilities.abyssalAspectAbilities,

			// Aethereal
			Type.Aethereal_Golem => Abilities.aetherealGolemAbilities,
			Type.Aethereal_Ghost => Abilities.aetherealGhostAbilities,
			Type.Aethereal_Wisp => Abilities.aetherealWispAbilities,
			Type.Aethereal_ManaVampire => Abilities.aetherealManaVampireAbilities,
			Type.Aethereal_Catoblepas => Abilities.aetherealCatoblepasAbilities,
			Type.Aethereal_Beholder => Abilities.aetherealBeholderAbilities,

			// Natural
			Type.Natural_Treant => Abilities.naturalTreantAbilities,
			Type.Natural_Druid => Abilities.naturalDruidAbilities,
			Type.Natural_Dryad => Abilities.naturalDryadAbilities,
			Type.Natural_Nymph => Abilities.naturalNymphAbilities,
			Type.Natural_CreepingVine => Abilities.naturalCreepingVineAbilities,
			Type.Natural_PoisonBulb => Abilities.naturalPoisonBulbAbilities,
			Type.Natural_VenusPersonTrap => Abilities.naturalVenusPersonTrapAbilities,

			// Heavenly
			Type.Heavenly_Messenger => Abilities.heavenlyMessengerAbilities,
			Type.Heavenly_Solider => Abilities.heavenlySoldierAbilities,
			Type.Heavenly_Scribe => Abilities.heavenlyScribeAbilities,
			Type.Heavenly_Angel => Abilities.heavenlyAngelAbilities,
			Type.Heavenly_Watcher => Abilities.heavenlyWatcherAbilities,
			Type.Heavenly_Virtue => Abilities.heavenlyVirtueAbilities,

			// Miscellaneous
			Type.Misc_Dragon => Abilities.miscDragonAbilities,
			Type.Misc_Wyvern => Abilities.miscWyvernAbilities,
			Type.Misc_Ogre => Abilities.miscOgreAbilities,
			Type.Misc_Goblin => Abilities.miscGoblinAbilities,
			Type.Misc_Bunyip => Abilities.miscBunyipAbilities,
			Type.Misc_Giant => Abilities.miscGiantAbilities,

			// Default Case (Failsafe)
			_ => new string[] { "Unknown Ability" }
		};
	}

	private void DistributeRatingPoints()
	{
		int pointsToDistribute = ((int)currentRating * variables.statPointsPerLevelUp) + variables.startingStatPoints;
		int bonusPoints = 0;
		float chanceOfBonus = variables.percentChanceOfBonusPointOnRatingUp;

		for (int i = 0; i < pointsToDistribute / 2; i++)
		{
			int randomNumber = Random.Range(0, 100);
			if (randomNumber < chanceOfBonus)
				bonusPoints++;
			chanceOfBonus += 2;
		}

		Debug.Log("Bonus points awarded: " + bonusPoints);
		pointsToDistribute += bonusPoints;

		// Random Stat Groupings per level
		for (int i = 0; i < (int)currentRating - 1; i++)
		{
            var index = Random.Range(0, 4);
            if (index == 0) // Body
            {
                if (strengthRating == Rating.SS)
					pointsToDistribute++;
				else
					strengthRating++;

                if (agilityRating == Rating.SS)
                    pointsToDistribute++;
                else
                    agilityRating++;
            }
            else if (index == 1) // Control
            {
                if (vitalityRating == Rating.SS)
                    pointsToDistribute++;
                else
                    vitalityRating++;

                if (dexterityRating == Rating.SS)
                    pointsToDistribute++;
                else
                    dexterityRating++;
            }
            else if (index == 2) // Presence
            {
                if (intelligenceRating == Rating.SS)
                    pointsToDistribute++;
                else
                    intelligenceRating++;

                if (charismaRating == Rating.SS)
                    pointsToDistribute++;
                else
                    charismaRating++;
            }
            else if (index == 3) // Willpower
            {
                if (spiritRating == Rating.SS)
                    pointsToDistribute++;
                else
                    spiritRating++;

                if (fortitudeRating == Rating.SS)
                    pointsToDistribute++;
                else
                    fortitudeRating++;
            }
        }

		if (pointsToDistribute >= (int)Rating.SS * 8) // The number of stats
		{
            strengthRating = Rating.SS;
            dexterityRating = Rating.SS;
            agilityRating = Rating.SS;
            intelligenceRating = Rating.SS;
            spiritRating = Rating.SS;
            charismaRating = Rating.SS;
            vitalityRating = Rating.SS;
            fortitudeRating = Rating.SS;

            Debug.LogWarning($"Too many points to distribute ({pointsToDistribute}), maxing out");
			return;
		}

		for (int i = 0; i < pointsToDistribute; i++)
		{
            float random = Random.Range(0f, 1f); // Calculate a random number between 0 and 1
            float cumulativeWeight = 0f;

            // Go through each stat rating and check which range the random number falls into
            for (int statWeight = 0; statWeight < 8; statWeight++)
            {
				// Increase the cumulative weight by the amount specified in the current classes' weight map
				// Bonus points are randomly distributed
				if (i < bonusPoints)
					cumulativeWeight += .125f;
				else
					cumulativeWeight += typeWeights[currentType][statWeight];

                if (random < cumulativeWeight)
                {
                    // Increment the corresponding stat based on the random number falling within this weight range
                    switch (statWeight)
                    {
                        case 0:
							if (strengthRating == Rating.SS)
							{
								i -= 1;
								break;
							}
							strengthRating++;
							break;
                        case 1:
                            if (dexterityRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            dexterityRating++; 
							break;
                        case 2:
                            if (agilityRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            agilityRating++; 
							break;
                        case 3:
                            if (intelligenceRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            intelligenceRating++; 
							break;
                        case 4:
                            if (spiritRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            spiritRating++; 
							break;
                        case 5:
                            if (charismaRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            charismaRating++; 
							break;
                        case 6:
                            if (vitalityRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            vitalityRating++; 
							break;
                        case 7:
                            if (fortitudeRating == Rating.SS)
                            {
                                i -= 1;
                                break;
                            }
                            fortitudeRating++; 
							break;
                    }
                    break;
                }
            }
        }
	}

	private int ModFromRating(Rating rating)
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

	private string MultiplierFromRating(Rating rating)
	{
        if (rating == Rating.F)
            return "1";
        else if (rating == Rating.E)
            return "1d2";
        else if (rating == Rating.D)
            return "1d4";
        else if (rating == Rating.C)
            return "1d6";
        else if (rating == Rating.B)
            return "1d8";
        else if (rating == Rating.A)
            return "2d4";
        else if (rating == Rating.S)
            return "2d6";
        else if (rating == Rating.SS)
            return "3d4";
        else
            return "0";
    }

	public void Start()
	{
		// Sets the dropdown menus' to have the correct enum to choose from
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
	}

    public void OnRatingDropdownValueChanged(int index)
    {
        currentRating = (Rating)index;
    }

    public void OnTypeDropdownValueChanged(int index)
    {
        currentType = (Type)index;
    }
}