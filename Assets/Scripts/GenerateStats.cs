using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Text;
using static Variables;
using System.Linq;

public class GenerateStats : MonoBehaviour
{
	public TMP_Dropdown rarityDropdown;
    public TMP_Dropdown classDropdown;
    public TMP_Dropdown elementTierDropdown;

    private Rarity currentRarity;
    private Class currentClass;
    private ElementTier currentElementTier;

    private int enduranceStat = 1;
    private int strengthStat = 0;
    private int dexterityStat = 0;
    private int agilityStat = 0;
    private int spiritStat = 0;

    public CharacterList characterList;

    // Called by the Generate button
    public void GenerateStatPoints()
    {
        int level = CalculateLevelBasedOnRarity(currentRarity);
        Debug.Log("Level calculated: " + level);
        int statPoints = CalculateStatPointsBasedOnLevel(level);
        Debug.Log("Total stat points: " + statPoints);

        enduranceStat = 1;
        strengthStat = 0;
        dexterityStat = 0;
        agilityStat = 0;
        spiritStat = 0;
        DistributeStatPoints(statPoints - 1); // Minus 1 for the forced 1 endurance
        string currentElement = ChooseElement();

		int randomIndex = Random.Range(0, adventurerAdjectives.Length);
        string randomAdjective = adventurerAdjectives[randomIndex];

        characterList.GenerateNPC(new CharacterList.NPC()
        {
            Name = randomAdjective + " " + currentClass.ToString(),

            Endurance = enduranceStat,
            Strength = strengthStat,
            Dexterity = dexterityStat,
            Agility = agilityStat,
            Spirit = spiritStat,

            MaxHealth = CalculateHealth(),
            CurrentHealth = CalculateHealth(),
            MaxMana = CalculateMana(),
            CurrentMana = CalculateMana(),
            DR = enduranceStat / 5,
            PlusToHit = dexterityStat / 10 >= 15 ? 15 : dexterityStat / 10,
            InitiativeBonus = CalculateInitiativeBonus(),
            CriticalBonus = CalculateCriticalBonus(),
            MovementSpeed = 3 + (agilityStat / 10),
            StrengthDamageBonus = CalculateStatBonus(strengthStat),
            DexterityDamageBonus = CalculateStatBonus(dexterityStat),
            SpiritDamageBonus = CalculateStatBonus(spiritStat),

            Element = currentElement,
            Abilities = GenerateAbilities(currentElement),

            Initiative = 0
        }, 
        currentRarity);
    }

    private int CalculateHealth()
    {
        switch (currentRarity)
        {
            case Rarity.Low_Common:
            case Rarity.Mid_Common:
            case Rarity.High_Common:
                return enduranceStat;
            case Rarity.Low_Uncommon:
            case Rarity.Mid_Uncommon:
            case Rarity.High_Uncommon:
                return enduranceStat * 2;
            case Rarity.Low_Rare:
            case Rarity.Mid_Rare:
            case Rarity.High_Rare:
                return enduranceStat * 3;
            case Rarity.Low_Epic:
            case Rarity.Mid_Epic:
            case Rarity.High_Epic:
                return enduranceStat * 4;
            case Rarity.Low_Legendary:
            case Rarity.Mid_Legendary:
            case Rarity.High_Legendary:
                return enduranceStat * 5;
            case Rarity.Low_Cataclysmic:
            case Rarity.Mid_Cataclysmic:
            case Rarity.High_Cataclysmic:
                return enduranceStat * 6;
            default:
                return 0;
        }
    }

    private int CalculateMana()
    {
        switch (currentRarity)
        {
            case Rarity.Low_Common:
            case Rarity.Mid_Common:
            case Rarity.High_Common:
                return spiritStat;
            case Rarity.Low_Uncommon:
            case Rarity.Mid_Uncommon:
            case Rarity.High_Uncommon:
                return spiritStat * 2;
            case Rarity.Low_Rare:
            case Rarity.Mid_Rare:
            case Rarity.High_Rare:
                return spiritStat * 3;
            case Rarity.Low_Epic:
            case Rarity.Mid_Epic:
            case Rarity.High_Epic:
                return spiritStat * 4;
            case Rarity.Low_Legendary:
            case Rarity.Mid_Legendary:
            case Rarity.High_Legendary:
                return spiritStat * 5;
            case Rarity.Low_Cataclysmic:
            case Rarity.Mid_Cataclysmic:
            case Rarity.High_Cataclysmic:
                return spiritStat * 6;
            default:
                return 0;
        }
    }

    private int CalculateCriticalBonus()
    {
        switch (currentRarity)
        {
            case Rarity.Low_Common:
            case Rarity.Mid_Common:
            case Rarity.High_Common:
                return dexterityStat / 6;
            case Rarity.Low_Uncommon:
            case Rarity.Mid_Uncommon:
            case Rarity.High_Uncommon:
                return dexterityStat / 5;
            case Rarity.Low_Rare:
            case Rarity.Mid_Rare:
            case Rarity.High_Rare:
                return dexterityStat / 4;
            case Rarity.Low_Epic:
            case Rarity.Mid_Epic:
            case Rarity.High_Epic:
                return dexterityStat / 3;
            case Rarity.Low_Legendary:
            case Rarity.Mid_Legendary:
            case Rarity.High_Legendary:
                return dexterityStat / 2;
            case Rarity.Low_Cataclysmic:
            case Rarity.Mid_Cataclysmic:
            case Rarity.High_Cataclysmic:
                return dexterityStat;
            default:
                return 0;
        }
    }

    private int CalculateStatBonus(int stat)
    {
        switch (currentRarity)
        {
            case Rarity.Low_Common:
            case Rarity.Mid_Common:
            case Rarity.High_Common:
                return stat / 6;
            case Rarity.Low_Uncommon:
            case Rarity.Mid_Uncommon:
            case Rarity.High_Uncommon:
                return stat / 5;
            case Rarity.Low_Rare:
            case Rarity.Mid_Rare:
            case Rarity.High_Rare:
                return stat / 4;
            case Rarity.Low_Epic:
            case Rarity.Mid_Epic:
            case Rarity.High_Epic:
                return stat / 3;
            case Rarity.Low_Legendary:
            case Rarity.Mid_Legendary:
            case Rarity.High_Legendary:
                return stat / 2;
            case Rarity.Low_Cataclysmic:
            case Rarity.Mid_Cataclysmic:
            case Rarity.High_Cataclysmic:
                return stat;
            default:
                return 0;
        }
    }

    private int CalculateInitiativeBonus()
    {
        switch (currentRarity)
        {
            case Rarity.Low_Common:
            case Rarity.Mid_Common:
            case Rarity.High_Common:
                return agilityStat / 10;
            case Rarity.Low_Uncommon:
            case Rarity.Mid_Uncommon:
            case Rarity.High_Uncommon:
                return (agilityStat / 10) * 2;
            case Rarity.Low_Rare:
            case Rarity.Mid_Rare:
            case Rarity.High_Rare:
                return (agilityStat / 10) * 3;
            case Rarity.Low_Epic:
            case Rarity.Mid_Epic:
            case Rarity.High_Epic:
                return (agilityStat / 10) * 4;
            case Rarity.Low_Legendary:
            case Rarity.Mid_Legendary:
            case Rarity.High_Legendary:
                return (agilityStat / 10) * 5;
            case Rarity.Low_Cataclysmic:
            case Rarity.Mid_Cataclysmic:
            case Rarity.High_Cataclysmic:
                return (agilityStat / 10) * 6;
            default:
                return 0;
        }
    }

    private void DistributeStatPoints(int statPoints)
    {
        for (int i = 0; i < statPoints; i++) // For every stat point to distribute
        {
            float random = Random.Range(0f, 1f); // Calculate a random number between 0 and 1
            float cumulativeWeight = 0f;

            // Go through each stat and check which range the random number falls into
            for (int statWeight = 0; statWeight < 5; statWeight++)
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
                        case 4: spiritStat++; break;
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
            if (i <= 30) // For commons, they get 2 stat points per level
            {
                sum += 2;
            }
            else if (i <= 60) // Uncommons get 4 stat points per level
            {
                sum += 4;
            }
            else if (i <= 90)
            {
                sum += 6;
            }
            else if (i <= 120)
            {
                sum += 8;
            }
            else if (i <= 150)
            {
                sum += 10;
            }
            else if (i <= 180)
            {
                sum += 12;
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
		elementTierDropdown.options.Clear();
		foreach (string elementTier in Enum.GetNames(typeof(ElementTier)))
		{
			elementTierDropdown.options.Add(new TMP_Dropdown.OptionData(elementTier));
		}

		rarityDropdown.onValueChanged.AddListener(OnRarityDropdownValueChanged);
        classDropdown.onValueChanged.AddListener(OnClassDropdownValueChanged);
		elementTierDropdown.onValueChanged.AddListener(OnElementTierDropdownValueChanged);

		rarityDropdown.RefreshShownValue();
        classDropdown.RefreshShownValue();
		elementTierDropdown.RefreshShownValue();
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

	public void OnElementTierDropdownValueChanged(int index)
	{
		currentElementTier = (ElementTier)index;
		Debug.Log("Element Tier changed to: " + currentElementTier);
	}

	private SaveData settings;

    /*private string GenerateAbilities(int upgradePoints, string[] skillsPool, string[] featsPool)
	{
		string[] selectedSkills;
		Dictionary<string, int> skillLevels = new ();
		Dictionary<string, int> featLevels = new ();

		selectedSkills = new string[settings.numberOfStartingSkills];
		List<string> availableSkills = new (skillsPool);
		List<string> availableFeats = new (featsPool);
		int numberOfStartingSkills = settings.numberOfStartingSkills;

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
            // These must have at least one armor skill
            if (currentType == Type.Humanoid_Champion ||
                currentType == Type.Humanoid_Civilian)
            {
                int index = Random.Range(0, Abilities.armorSkills.Length);
                skillLevels[Abilities.armorSkills[index]] = 1;
            }
            else if (currentType == Type.Humanoid_Mage ||
                     currentType == Type.Undead_Lich ||
                     currentType == Type.Undead_CorpseLord ||
                     currentType == Type.Demonic_Azklat ||
                     currentType == Type.Abyssal_EldritchHorror ||
                     currentType == Type.Aethereal_Beholder ||
                     currentType == Type.Natural_Druid ||
                     currentType == Type.Natural_Nymph ||
                     currentType == Type.Natural_CreepingVine ||
                     currentType == Type.Natural_PoisonBulb ||
                     currentType == Type.Heavenly_Scribe)
            {
                skillLevels["Light Armor"] = 1;
            }
            else if (currentType == Type.Undead_Vampire ||
                     currentType == Type.Undead_Ghoul ||
                     currentType == Type.Demonic_Devil ||
                     currentType == Type.Demonic_Hellhound ||
                     currentType == Type.Demonic_MurderCat ||
                     currentType == Type.Abyssal_Remnant ||
                     currentType == Type.Abyssal_Sludge ||
                     currentType == Type.Abyssal_Aspect ||
                     currentType == Type.Aethereal_ManaVampire ||
                     currentType == Type.Aethereal_Catoblepas ||
                     currentType == Type.Heavenly_Messenger ||
                     currentType == Type.Heavenly_Watcher ||
                     currentType == Type.Misc_Ogre ||
                     currentType == Type.Misc_Goblin ||
                     currentType == Type.Misc_Bunyip ||
                     currentType == Type.Misc_Giant)
            {
                skillLevels["Medium Armor"] = 1;
            }
            else if (currentType == Type.Humanoid_Soldier ||
                     currentType == Type.Undead_Skeleton ||
                     currentType == Type.Demonic_Imp ||
                     currentType == Type.Demonic_Sin ||
                     currentType == Type.Natural_Dryad ||
                     currentType == Type.Heavenly_Soldier ||
                     currentType == Type.Heavenly_Virtue)
			{
                int index = Random.Range(0, 2);
				if (index == 0)
					skillLevels["Medium Armor"] = 1;
				else
					skillLevels["Heavy Armor"] = 1;
            }
			else if (currentType == Type.Humanoid_Commander ||
					 currentType == Type.Humanoid_Battlemage ||
                     currentType == Type.Undead_Wight ||
                     currentType == Type.Undead_DeathKnight ||
                     currentType == Type.Demonic_Demon ||
                     currentType == Type.Abyssal_Mimic ||
                     currentType == Type.Abyssal_WakingNightmare ||
                     currentType == Type.Aethereal_Golem ||
                     currentType == Type.Natural_Treant ||
                     currentType == Type.Natural_VenusPersonTrap ||
                     currentType == Type.Heavenly_Angel ||
                     currentType == Type.Misc_Dragon ||
                     currentType == Type.Misc_Wyvern)
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
			else if (choice == 2 && availableSkills.Count > 0 && skillLevels.Count < settings.maximumSkills)
			{
				// Pick a new skill
				int index = Random.Range(0, availableSkills.Count);
				string newSkill = availableSkills[index];
				availableSkills.RemoveAt(index);
				skillLevels[newSkill] = 1;
				upgradePoints -= 1;
				validUpgradeFound = true;
			}
			else if (choice == 2 && availableFeats.Count > 0 && featLevels.Count < settings.maximumFeats && upgradePoints >= 2)
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
	}*/

    private string GenerateAbilities(string currentElement)
    {
        // This version is just for armor 
        // Assign armor type based on class pattern
        Dictionary<string, int> skillLevels = new();
        string className = currentClass.ToString();
        string weaponChoice = "Sword";

        if (className.StartsWith("Warrior") || currentClass == Class.All_Rounder)
        {
            skillLevels["Heavy Armor"] = 1;
            weaponChoice = warriorWeapons[Random.Range(0, warriorWeapons.Length)];
        }
        else if (className.StartsWith("Archer"))
        {
            skillLevels["Medium Armor"] = 1;
            weaponChoice = archerWeapons[Random.Range(0, archerWeapons.Length)];
        }
        else if (className.StartsWith("Rogue"))
        {
            skillLevels["Medium Armor"] = 1;
            weaponChoice = rogueWeapons[Random.Range(0, rogueWeapons.Length)];
        }
        else if (className.StartsWith("Mage"))
        {
            skillLevels["Light Armor"] = 1;
            weaponChoice = mageWeapons[Random.Range(0, mageWeapons.Length)];
        }
        skillLevels[weaponChoice] = 1;

        StringBuilder result = new();

        foreach (var skill in skillLevels)
        {
            result.AppendLine($"{skill.Key}: {skill.Value}");
        }

        string[] elementalAbilities = new string[6] { "", "", "", "", "", ""};
		switch (currentElementTier)
		{
			case ElementTier.Single:
                elementalAbilities = singleElementsList[currentElement];
				break;
			case ElementTier.Double:
				elementalAbilities = dualElementsList[currentElement];
				break;
			case ElementTier.Triple:
				elementalAbilities = triElementsList[currentElement];
				break;
			default:
				break;
		}

		foreach (var ability in elementalAbilities)
		{
			result.AppendLine($"{ability}");
		}

		return result.ToString();
    }

    private string ChooseElement()
    {
        List<string> keys = new List<string>();
		switch (currentElementTier)
		{
			case ElementTier.Single:
				keys = singleElementsList.Keys.ToList();
				break;

			case ElementTier.Double:
				keys = dualElementsList.Keys.ToList();
				break;

			case ElementTier.Triple:
				keys = triElementsList.Keys.ToList();
				break;
		}
		return keys[Random.Range(0, keys.Count)];
	}

	/*private string[] SkillsPoolFromType()
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
			Type.Heavenly_Soldier => Abilities.heavenlySoldierSkills,
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
			_ => new string[] { "Don't know any skills for this type: " + currentType }
		};
	}*/
    /*public void OnRatingDropdownValueChanged(int index)
    {
        currentRating = (Rating)index;
    }

    public void OnTypeDropdownValueChanged(int index)
    {
        currentType = (Type)index;
    }*/
} 