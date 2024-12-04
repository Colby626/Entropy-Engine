using UnityEngine;
using TMPro;
using UnityEngine.UI;
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

	private static readonly Dictionary<Class, float[]> classWeights = new Dictionary<Class, float[]>
	{
		{ Class.Warrior, new float[] { 0.35f, 0.35f, 0.2f, 0.1f, 0f, 0f } },
		{ Class.Archer, new float[] { 0.2f, 0.2f, 0.4f, 0.2f, 0f, 0f } },
		{ Class.Rogue, new float[] { 0.2f, 0.2f, 0.2f, 0.4f, 0f, 0f } },
		{ Class.Mage, new float[] { 0.15f, 0.0f, 0.0f, 0.15f, 0.35f, 0.35f } },
		{ Class.All_Rounder, new float[] { 0.225f, 0.1875f, 0.175f, 0.2f, 0.0875f, 0.0875f } },
		{ Class.Warrior_Archer, new float[] { 0.3005f, 0.3005f, 0.2995f, 0.0995f, 0.0f, 0.0f } },
		{ Class.Warrior_Rogue, new float[] { 0.2983f, 0.2983f, 0.1587f, 0.2447f, 0.0f, 0.0f } },
		{ Class.Warrior_Mage, new float[] { 0.2825f, 0.0f, 0.0f, 0.2675f, 0.225f, 0.225f } },
		{ Class.Archer_Warrior, new float[] { 0.2005f, 0.2005f, 0.499f, 0.1f, 0.0f, 0.0f } },
		{ Class.Archer_Rogue, new float[] { 0.1667f, 0.1667f, 0.2667f, 0.3f, 0.0f, 0.0f } },
		{ Class.Archer_Mage, new float[] { 0.185f, 0.0f, 0.0f, 0.135f, 0.45f, 0.45f } },
		{ Class.Rogue_Warrior, new float[] { 0.2583f, 0.2583f, 0.1983f, 0.2851f, 0.0f, 0.0f } },
		{ Class.Rogue_Archer, new float[] { 0.1677f, 0.1667f, 0.3079f, 0.4079f, 0.0f, 0.0f } },
		{ Class.Rogue_Mage, new float[] { 0.1f, 0.0f, 0.0f, 0.1f, 0.4f, 0.4f } },
		{ Class.Mage_Warrior, new float[] { 0.27f, 0.0f, 0.0f, 0.27f, 0.23f, 0.23f } },
		{ Class.Mage_Archer, new float[] { 0.125f, 0.0f, 0.0f, 0.2f, 0.4f, 0.4f } },
		{ Class.Mage_Rogue, new float[] { 0.1f, 0.0f, 0.0f, 0.1f, 0.4f, 0.4f } },
		{ Class.Warrior_Archer_Rogue, new float[] { 0.2675f, 0.2675f, 0.2333f, 0.2333f, 0.0f, 0.0f } },
		{ Class.Warrior_Archer_Mage, new float[] { 0.3f, 0.0f, 0.0f, 0.225f, 0.175f, 0.175f } },
		{ Class.Warrior_Rogue_Archer, new float[] { 0.3417f, 0.2583f, 0.1583f, 0.2417f, 0.0f, 0.0f } },
		{ Class.Warrior_Rogue_Mage, new float[] { 0.3f, 0.0f, 0.0f, 0.225f, 0.175f, 0.175f } },
		{ Class.Warrior_Mage_Archer, new float[] { 0.3f, 0.0f, 0.0f, 0.225f, 0.175f, 0.175f } },
		{ Class.Warrior_Mage_Rogue, new float[] { 0.3f, 0.0f, 0.0f, 0.225f, 0.175f, 0.175f } },
		{ Class.Archer_Warrior_Rogue, new float[] { 0.3005f, 0.2005f, 0.299f, 0.2f, 0.0f, 0.0f } },
		{ Class.Archer_Warrior_Mage, new float[] { 0.175f, 0.0f, 0.0f, 0.175f, 0.25f, 0.25f } },
		{ Class.Archer_Rogue_Warrior, new float[] { 0.3667f, 0.1667f, 0.3167f, 0.3667f, 0.0f, 0.0f } },
		{ Class.Archer_Rogue_Mage, new float[] { 0.325f, 0.0f, 0.0f, 0.23f, 0.4f, 0.4f } },
		{ Class.Archer_Mage_Warrior, new float[] { 0.175f, 0.0f, 0.0f, 0.175f, 0.25f, 0.25f } },
		{ Class.Archer_Mage_Rogue, new float[] { 0.125f, 0.0f, 0.0f, 0.125f, 0.4f, 0.4f } },
		{ Class.Rogue_Warrior_Archer, new float[] { 0.2583f, 0.2583f, 0.1583f, 0.2417f, 0.0f, 0.0f } },
		{ Class.Rogue_Warrior_Mage, new float[] { 0.225f, 0.0f, 0.0f, 0.225f, 0.175f, 0.175f } },
		{ Class.Rogue_Archer_Warrior, new float[] { 0.1667f, 0.1667f, 0.2667f, 0.3667f, 0.0f, 0.0f } },
		{ Class.Rogue_Archer_Mage, new float[] { 0.125f, 0.0f, 0.0f, 0.125f, 0.4f, 0.4f } },
		{ Class.Rogue_Mage_Warrior, new float[] { 0.1f, 0.0f, 0.0f, 0.1f, 0.4f, 0.4f } },
		{ Class.Rogue_Mage_Archer, new float[] { 0.1f, 0.0f, 0.0f, 0.1f, 0.4f, 0.4f } },
		{ Class.Mage_Warrior_Archer, new float[] { 0.175f, 0.0f, 0.0f, 0.175f, 0.25f, 0.25f } },
		{ Class.Mage_Warrior_Rogue, new float[] { 0.175f, 0.0f, 0.0f, 0.175f, 0.25f, 0.25f } },
		{ Class.Mage_Archer_Warrior, new float[] { 0.175f, 0.0f, 0.0f, 0.175f, 0.25f, 0.25f } },
		{ Class.Mage_Archer_Rogue, new float[] { 0.125f, 0.0f, 0.0f, 0.125f, 0.4f, 0.4f } },
		{ Class.Mage_Rogue_Warrior, new float[] { 0.1f, 0.0f, 0.0f, 0.1f, 0.4f, 0.4f } },
		{ Class.Mage_Rogue_Archer, new float[] { 0.1f, 0.0f, 0.0f, 0.1f, 0.4f, 0.4f } }
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

    public LayoutGroup statsTextLayoutGroup;

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

		// Set the text in the table to match the variables in this script
		statsTextLayoutGroup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = enduranceStat.ToString();
		statsTextLayoutGroup.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = strengthStat.ToString();
		statsTextLayoutGroup.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dexterityStat.ToString();
		statsTextLayoutGroup.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = agilityStat.ToString();
		statsTextLayoutGroup.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = intelligenceStat.ToString();
		statsTextLayoutGroup.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = spiritStat.ToString();
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
			Rarity.Low_Common => Random.Range(1, 31),
			Rarity.Mid_Common => Random.Range(31, 61),
			Rarity.High_Common => Random.Range(61, 91),
			Rarity.Low_Uncommon => Random.Range(91, 141),
			Rarity.Mid_Uncommon => Random.Range(141, 191),
			Rarity.High_Uncommon => Random.Range(191, 241),
			Rarity.Low_Rare => Random.Range(241, 311),
			Rarity.Mid_Rare => Random.Range(311, 381),
			Rarity.High_Rare => Random.Range(381, 451),
			Rarity.Low_Epic => Random.Range(451, 541),
			Rarity.Mid_Epic => Random.Range(541, 631),
			Rarity.High_Epic => Random.Range(631, 721),
			Rarity.Low_Legendary => Random.Range(721, 831),
			Rarity.Mid_Legendary => Random.Range(831, 941),
			Rarity.High_Legendary => Random.Range(941, 1051),
			Rarity.Low_Cataclysmic => Random.Range(1051, 1181),
			Rarity.Mid_Cataclysmic => Random.Range(1181, 1311),
			Rarity.High_Cataclysmic => Random.Range(1311, 1441),
			_ => 0,
		};
	}

    private int CalculateStatPointsBasedOnLevel(int level)
    {
        int sum = 0;
        for (int i = 0; i < level; i++)
        {
            if (i <= 90) // For commons, they get 3 stat points per level
            {
                sum += 3;
            }
            else if (i <= 240) // Uncommons get 5 stat points per level
            {
                sum += 5;
            }
            else if (i <= 450)
			{
				sum += 7;
			}
			else if (i <= 720)
			{
				sum += 9;
			}
			else if (i <= 1050)
			{
				sum += 11;
			}
			else if (i <= 1440)
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