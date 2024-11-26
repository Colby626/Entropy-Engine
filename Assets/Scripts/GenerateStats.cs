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
        // [Endurance, Strength, Dexterity, Agility, Intelligence, Spirit]
		{ Class.Warrior, new float[] { 0.35f, 0.35f, 0.1f, 0.05f, 0f, 0f } }, 
		{ Class.Archer, new float[] { 0.2f, 0.2f, 0.4f, 0.2f, 0f, 0f } },
        { Class.Rogue, new float[] { 0.2f, 0.2f, 0.2f, 0.4f, 0f, 0f } },
		{ Class.Mage, new float[] { 0.15f, 0.0f, 0.0f, 0.15f, 0.35f, 0.35f } }
	};

	public TMP_Dropdown rarityDropdown;
    public TMP_Dropdown classDropdown;

    private Rarity currentRarity;
    private Class currentClass;

    private int level = 0;
    private int statPoints = 0;

    private int enduranceStat = 1;
    private int strengthStat = 0;
    private int dexterityStat = 0;
    private int agilityStat = 0;
    private int intelligenceStat = 0;
    private int spiritStat = 0;

    public LayoutGroup statsTextLayoutGroup;

    public void GenerateStatPoints()
    {
        level = CalculateLevelBasedOnRarity(currentRarity);
        Debug.Log("Level calculated: " + level);
        statPoints = CalculateStatPointsBasedOnLevel(level);
        Debug.Log("Total stat points: " +  statPoints);

		// Dynamically merge classes' weights before distribution
		// Distribute stats based on class and level
		// 1 endurance is required
		// Warrior gives mostly strength/endurance
		// Archer gives mostly dexterity
		// Rogue gives mostly Agility
		// Mage gives mostly intelligence/spirit

		statsTextLayoutGroup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = enduranceStat.ToString();
		statsTextLayoutGroup.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = strengthStat.ToString();
		statsTextLayoutGroup.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dexterityStat.ToString();
		statsTextLayoutGroup.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = agilityStat.ToString();
		statsTextLayoutGroup.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = intelligenceStat.ToString();
		statsTextLayoutGroup.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = spiritStat.ToString();
	}

    private int CalculateLevelBasedOnRarity(Rarity rarity)
    {
		switch (rarity)
		{
			case Rarity.Low_Common:
				return Random.Range(1, 31);
			case Rarity.Mid_Common:
				return Random.Range(31, 61);
			case Rarity.High_Common:
				return Random.Range(61, 91);
			case Rarity.Low_Uncommon:
				return Random.Range(91, 141);
			case Rarity.Mid_Uncommon:
				return Random.Range(141, 191);
			case Rarity.High_Uncommon:
				return Random.Range(191, 241);
			case Rarity.Low_Rare:
				return Random.Range(241, 311);
			case Rarity.Mid_Rare:
				return Random.Range(311, 381);
			case Rarity.High_Rare:
				return Random.Range(381, 451);
			case Rarity.Low_Epic:
				return Random.Range(451, 541);
			case Rarity.Mid_Epic:
				return Random.Range(541, 631);
			case Rarity.High_Epic:
				return Random.Range(631, 721);
			case Rarity.Low_Legendary:
				return Random.Range(721, 831);
			case Rarity.Mid_Legendary:
				return Random.Range(831, 941);
			case Rarity.High_Legendary:
				return Random.Range(941, 1051);
			case Rarity.Low_Cataclysmic:
				return Random.Range(1051, 1181);
			case Rarity.Mid_Cataclysmic:
				return Random.Range(1181, 1311);
			case Rarity.High_Cataclysmic:
				return Random.Range(1311, 1441);
            default:
                return 0;
		}
	}

    private int CalculateStatPointsBasedOnLevel(int level)
    {
        int sum = 0;
        for (int i = 0; i < level; i++)
        {
            if (i <= 90)
            {
                sum += 3;
            }
            else if (i <= 240)
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