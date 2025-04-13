using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Text;
using static Variables;
using Type = Variables.Type;

public class GenerateStats : MonoBehaviour
{
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
	private SaveData settings;

	// Called by the Generate button
	public void GenerateLordshipStatPoints()
	{
		settings = FindObjectOfType<OptionsMenu>().settings;
        strengthRating = Rating.F;
		dexterityRating = Rating.F;
		agilityRating = Rating.F;
		intelligenceRating = Rating.F;
		spiritRating = Rating.F;
		charismaRating = Rating.F;
		vitalityRating = Rating.F;
		fortitudeRating = Rating.F;

		DistributeRatingPoints();

		int upgradePoints = settings.upgradePointsPerLevel * (int)currentRating;

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
			PlusToHit = (int)dexterityRating * 2,
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
					if (skill.Value < settings.maximumSkillLevel && upgradePoints >= skill.Value + 1) // Ensure enough points
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
					if (feat.Value < settings.maximumFeatLevel && upgradePoints >= (feat.Value + 1) * 2) // Ensure enough points
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
			_ => new string[] { "Don't know any skills for this type: " + currentType }
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
			_ => new string[] { "Don't know any abilities for this type: " + currentType }
		};
	}

	private void DistributeRatingPoints()
	{
		int pointsToDistribute = ((int)currentRating * settings.statPointsPerLevelUp) + settings.startingStatPoints;
		int bonusPoints = 0;
		float chanceOfBonus = settings.percentChanceOfBonusPointOnRatingUp;

		for (int i = 0; i < pointsToDistribute / 2; i++)
		{
			int randomNumber = Random.Range(0, 100);
			if (randomNumber < chanceOfBonus)
				bonusPoints++;
			chanceOfBonus += settings.increaseInBonusChancePerLevel;
		}

		Debug.Log("Bonus points awarded: " + bonusPoints);
		pointsToDistribute += bonusPoints;

		// Random Stat Groupings per level
		for (int i = 0; i < (int)currentRating + 1; i++)
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
							if (strengthRating == Rating.SS || (int)strengthRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
							{
								i -= 1;
								break;
							}
							strengthRating++;
							break;
                        case 1:
                            if (dexterityRating == Rating.SS || (int)dexterityRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
                            {
                                i -= 1;
                                break;
                            }
                            dexterityRating++; 
							break;
                        case 2:
                            if (agilityRating == Rating.SS || (int)agilityRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
                            {
                                i -= 1;
                                break;
                            }
                            agilityRating++; 
							break;
                        case 3:
                            if (intelligenceRating == Rating.SS || (int)intelligenceRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
                            {
                                i -= 1;
                                break;
                            }
                            intelligenceRating++; 
							break;
                        case 4:
                            if (spiritRating == Rating.SS || (int)spiritRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
                            {
                                i -= 1;
                                break;
                            }
                            spiritRating++; 
							break;
                        case 5:
                            if (charismaRating == Rating.SS || (int)charismaRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
                            {
                                i -= 1;
                                break;
                            }
                            charismaRating++; 
							break;
                        case 6:
                            if (vitalityRating == Rating.SS || (int)vitalityRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
                            {
                                i -= 1;
                                break;
                            }
                            vitalityRating++; 
							break;
                        case 7:
                            if (fortitudeRating == Rating.SS || (int)fortitudeRating >= (int)currentRating + settings.statCeilingAboveCurrentRating)
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
			return settings.F;
		else if (rating == Rating.E)
			return settings.E;
		else if (rating == Rating.D)
			return settings.D;
		else if (rating == Rating.C)
			return settings.C;
		else if (rating == Rating.B)
			return settings.B;
		else if (rating == Rating.A)
			return settings.A;
		else if (rating == Rating.S)
			return settings.S;
		else if (rating == Rating.SS)
			return settings.SS;
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