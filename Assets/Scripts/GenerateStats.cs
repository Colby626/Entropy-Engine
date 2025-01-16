using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Unity.VisualScripting;

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

	public TMP_Dropdown rarityDropdown;
    public TMP_Dropdown classDropdown;

    private Rarity currentRarity;
    private Class currentClass;

    private int enduranceStat = 1;
    private int strengthStat = 0;
    private int dexterityStat = 0;
    private int agilityStat = 0;
    private int intelligenceStat = 0;
    private int spiritStat = 0;

    public LayoutGroup statCellsLayoutGroup;
	public LayoutGroup derivedStatCellsLayoutGroup;

	public CharacterList characterList;

	// Called by the Generate button
    public void GenerateStatPoints()
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

		// Functionality of OriginalScene
		if (characterList == null)
		{
			// Set the text in the table to match the variables in this script
			statCellsLayoutGroup.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = enduranceStat.ToString();
			statCellsLayoutGroup.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = strengthStat.ToString();
			statCellsLayoutGroup.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = dexterityStat.ToString();
			statCellsLayoutGroup.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = agilityStat.ToString();
			statCellsLayoutGroup.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = intelligenceStat.ToString();
			statCellsLayoutGroup.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = spiritStat.ToString();

			CalculateDerivedValues();

			return;
		}

		characterList.characters.Add(new CharacterList.Character()
		{
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
			MovementSpeed = (agilityStat / 10) * 5 + 25
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

	private void CalculateDerivedValues()
	{
		int health = enduranceStat * 3;
		int mana = spiritStat * 2;
		int damageResist = enduranceStat / 10;
		int magicResist = spiritStat / 10;
		int plusToHit = dexterityStat / 5;
		int acInitiative = (agilityStat / 5);
		int movementSpeed = (agilityStat / 10) * 5 + 25;

		derivedStatCellsLayoutGroup.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = health.ToString();
		derivedStatCellsLayoutGroup.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = mana.ToString();
		derivedStatCellsLayoutGroup.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = damageResist.ToString();
		derivedStatCellsLayoutGroup.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = magicResist.ToString();
		derivedStatCellsLayoutGroup.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = plusToHit.ToString();
		derivedStatCellsLayoutGroup.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = acInitiative.ToString();
		derivedStatCellsLayoutGroup.transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().text = movementSpeed.ToString();
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
}