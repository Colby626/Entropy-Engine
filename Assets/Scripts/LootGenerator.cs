using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootGenerator : MonoBehaviour
{
	public TMP_Dropdown lootAmountDropdown;
	public TextMeshProUGUI moneyText;
	public GameObject minimizeCoinsButton;
	public GameObject generateTreasureButton;
	public TextMeshProUGUI treasureText;
	private long totalCoins = 0;
	private SaveData settings;

	private enum LootAmount
	{
		Coinpurse,
		Stash,
		Lockbox,
		Safe,
		Treasury,
		Horde
	}

	private LootAmount currentLootAmount;

	// Called by the button
	public void GenerateLoot()
    {
		settings = FindFirstObjectByType<OptionsMenu>().settings;
		/*
		100 copper = 1 silver
		100 silver = 1 gold
		100 gold = 1 platinum
		100 platinum = 1 electrum
		*/
		long copper = 0;
		if (currentLootAmount == LootAmount.Coinpurse) // 1 copper - 1 silver
		{
			copper = (long)Random.Range(1, 101);
		}
		else if (currentLootAmount == LootAmount.Stash) // 1 silver - 25 silver
		{
			copper = (long)Random.Range(100, 2501);
		}
		else if (currentLootAmount == LootAmount.Lockbox) // 25 silver - 3 gold
		{
			copper = (long)Random.Range(2500, 30001); 
		}
		else if (currentLootAmount == LootAmount.Safe) // 3 gold - 40 gold
		{
			int weightRoll = Random.Range(0, 101);
			if (weightRoll < 40) // 40% chance
				copper = (long)Random.Range(30000, 100001); // 3 gold - 10 gold 
			else if (weightRoll < 70) // 30% chance
				copper = (long)Random.Range(100000, 200001); // 10 gold - 20 gold
			else if (weightRoll < 90) // 20% chance
				copper = (long)Random.Range(200000, 300001); // 20 gold - 30 gold
			else // 10% chance
				copper = (long)Random.Range(300000, 400001); // 30 gold - 40 gold
		}
		else if (currentLootAmount == LootAmount.Treasury) // 40 gold - 2 platinum
		{
			int weightRoll = Random.Range(0, 101);
			if (weightRoll < 40) // 40% chance
				copper = (long)Random.Range(400000, 500001); // 40 gold - 50 gold
			else if (weightRoll < 70) // 30% chance
				copper = (long)Random.Range(500000, 1000001); // 50 gold - 1 platinum
			else if (weightRoll < 90) // 20% chance
				copper = (long)Random.Range(1000000, 1500001); // 1 platinum - 1.5 platinum
			else // 10% chance
				copper = (long)Random.Range(1500000, 2000001); // 1.5 platinum - 2 platinum
		}
		else if (currentLootAmount == LootAmount.Horde) // 2 platinum - 10 electrum
		{
			int weightRoll = Random.Range(0, 101);
			if (weightRoll < 50) // 50% chance
				copper = (long)Random.Range(2000000, 250000001); // 2 platinum = 2.5 electrum
			else if (weightRoll < 80) // 30% chance
				copper = (long)Random.Range(250000000, 500000001); // 2.5 electrum - 5 electrum
			else if (weightRoll < 95) // 15% chance
				copper = (long)Random.Range(500000000, 750000001); // 5 electrum - 7.5 electrum
			else // 5% chance
				copper = (long)Random.Range(750000000, 1000000001); // 7.5 electrum - 10 electrum
		}

		totalCoins = copper;
		if (totalCoins > 25 && CalculateTreasureValue() > 0)
		{
			generateTreasureButton.SetActive(true);
		}
		DisperseCoins(copper);
	}

	public void Start()
	{
		// Sets the dropdown menus' to have the correct enum to choose from
		lootAmountDropdown.options.Clear();
		foreach (string rarityName in Enum.GetNames(typeof(LootAmount)))
		{
			lootAmountDropdown.options.Add(new TMP_Dropdown.OptionData(rarityName));
		}

		lootAmountDropdown.onValueChanged.AddListener(OnLootAmountDropdownChanged);
		lootAmountDropdown.RefreshShownValue();
	}

	public void OnLootAmountDropdownChanged(int index)
	{
		currentLootAmount = (LootAmount)index;
	}

	private void DisperseCoins(long copper)
	{
		// Calculate Electrum (1 electrum = 100 million copper)
		long maxElectrum = copper / 100000000L; 
		int electrum = Random.Range(0, (int)maxElectrum); 
		copper -= electrum * 100000000L; 

		// Calculate Platinum (1 platinum = 1 million copper)
		long maxPlatinum = copper / 1000000L;
		int platinum = Random.Range(0, (int)maxPlatinum); 
		copper -= platinum * 1000000L;

		// Calculate Gold (1 gold = 10,000 copper)
		long maxGold = copper / 10000L;
		int gold = Random.Range(0, (int)maxGold); 
		copper -= gold * 10000L; 

		// Calculate Silver (1 silver = 100 copper)
		long maxSilver = copper / 100L;
		int silver = Random.Range(0, (int)maxSilver); 
		copper -= silver * 100L;

		string money;
		if (electrum > 0)
			money = $"Electrum: {electrum} Platinum: {platinum} Gold: {gold} Silver: {silver} Copper: {copper}";
		else if (platinum > 0)
			money = $"Platinum: {platinum} Gold: {gold} Silver: {silver} Copper: {copper}";
		else if (gold > 0)
			money = $"Gold: {gold} Silver: {silver} Copper: {copper}";
		else if (silver > 0)
			money = $"Silver: {silver} Copper: {copper}";
		else 
			money = $"Copper: {copper}";

		moneyText.text = money;

		if (silver < maxSilver || gold < maxGold || platinum < maxPlatinum || electrum < maxElectrum)
			minimizeCoinsButton.SetActive(true);
	}

	// Called by the button
	public void MinimizeCoins()
	{
		long copper = totalCoins;
		// Calculate Electrum (1 electrum = 1 billion copper)
		long maxElectrum = copper / 100000000L;
		copper -= maxElectrum * 100000000L;

		// Calculate Platinum (1 platinum = 1 million copper)
		long maxPlatinum = copper / 1000000L;
		copper -= maxPlatinum * 1000000L;

		// Calculate Gold (1 gold = 10,000 copper)
		long maxGold = copper / 10000L;
		copper -= maxGold * 10000L;

		// Calculate Silver (1 silver = 100 copper)
		long maxSilver = copper / 100L;
		copper -= maxSilver * 100L;

		string money;
		if (maxElectrum > 0)
			money = $"Electrum: {maxElectrum} Platinum: {maxPlatinum} Gold: {maxGold} Silver: {maxSilver} Copper: {copper}";
		else if (maxPlatinum > 0)
			money = $"Platinum: {maxPlatinum} Gold: {maxGold} Silver: {maxSilver} Copper: {copper}";
		else if (maxGold > 0)
			money = $"Gold: {maxGold} Silver: {maxSilver} Copper: {copper}";
		else if (maxSilver > 0)
			money = $"Silver: {maxSilver} Copper: {copper}";
		else
			money = $"Copper: {copper}";

		moneyText.text = money;
	}

	// Called by the button
	public void GenerateTreasure()
	{
		settings = FindFirstObjectByType<OptionsMenu>().settings;
		long treasureValue = CalculateTreasureValue();

		if (treasureValue == 0)
		{
			return;
		}

		string chosenTreasuresString = "";
		Dictionary<string, int> chosenTreasures = new(); // <Name, Quantity>
		Dictionary<string, Variables.Treasure> affordableTreasures = new(Variables.treasureDictionary); // <Name, Treasure>
		long sumOfTreasureValue = 0;

		while (treasureValue >= 25) // The cheapest treasure
		{
			List<string> treasuresToRemove = new();

			foreach (var kvp in affordableTreasures)
			{
				if (kvp.Value.value > treasureValue)
				{
					treasuresToRemove.Add(kvp.Key);
				}
			}

			foreach (var treasure in treasuresToRemove)
			{
				affordableTreasures.Remove(treasure);
			}

			if (affordableTreasures.Count == 0)
			{
				break;
			}

			List<Variables.Treasure> topTreasures = affordableTreasures.Values
				.OrderByDescending(t => t.value)
				.Take(settings.treasureVariance)
				.ToList();

			while (topTreasures.Count < settings.treasureVariance)
			{
				topTreasures.Add(new Variables.Treasure("Nothing", 0));
			}

			int indexToPick = Random.Range(0, topTreasures.Count);
			var selectedTreasure = topTreasures[indexToPick];

			if (selectedTreasure.value == 0)
				break;

			treasureValue -= selectedTreasure.value;
			sumOfTreasureValue += selectedTreasure.value;

			string treasureName = selectedTreasure.name;

			if (selectedTreasure.breakdown.Count() > 0)
			{
				int breakdownIndex = Random.Range(0, selectedTreasure.breakdown.Count() - 1);
				treasureName = selectedTreasure.breakdown[breakdownIndex];
			}

			if (chosenTreasures.ContainsKey(treasureName))
			{
				chosenTreasures[treasureName]++;
			}
			else
			{
				chosenTreasures[treasureName] = 1;
			}

			if (Random.Range(0, 100) < settings.exitTreasureGenerationEarlyChance * 100)
			{
				break;
			}
		}

		foreach (var treasure in chosenTreasures)
		{
			string plural = treasure.Value > 1 ? "s" : "";

			// Finds the treasure, even if treasure.Key is from the breakdown of the original treasure
			Variables.Treasure originalTreasure = Variables.treasureDictionary.ContainsKey(treasure.Key)
				? Variables.treasureDictionary[treasure.Key]
				: Variables.treasureDictionary.Values.FirstOrDefault(t => t.breakdown.Contains(treasure.Key));

			long treasureWorth = originalTreasure.name != null ? originalTreasure.value : 0;

			chosenTreasuresString += $"{treasure.Value} {treasure.Key}{plural} {ConvertToLargestCoinage(treasureWorth)}\n";
		}

		chosenTreasuresString += "Sum: " + ConvertToLargestCoinage(sumOfTreasureValue);
		treasureText.text = chosenTreasuresString;

		totalCoins -= sumOfTreasureValue;
		DisperseCoins(totalCoins);
	}

	private long CalculateTreasureValue()
	{
		if (currentLootAmount == LootAmount.Coinpurse)
		{
			return (long)Math.Round(settings.percentOfCoinpurseAsTreasure * totalCoins);
		}
		else if (currentLootAmount == LootAmount.Stash)
		{
			return (long)Math.Round(settings.percentOfStashAsTreasure * totalCoins);
		}
		else if (currentLootAmount == LootAmount.Lockbox)
		{
			return (long)Math.Round(settings.percentOfLockboxAsTreasure * totalCoins);
		}
		else if (currentLootAmount == LootAmount.Safe)
		{
			return (long)Math.Round(settings.percentOfSafeAsTreasure * totalCoins);
		}
		else if (currentLootAmount == LootAmount.Treasury)
		{
			return (long)Math.Round(settings.percentOfTreasuryAsTreasure * totalCoins);
		}
		else if (currentLootAmount == LootAmount.Horde)
		{
			return (long)Math.Round(settings.percentOfHordeAsTreasure * totalCoins);
		}
		else
		{
			Debug.LogWarning("Loot Amount not accounted for");
			return 0;
		}
	}

	public static string ConvertToLargestCoinage(long coppers)
	{
		const decimal copperPerElectrum = 100_000_000; // 100 Platinum
		const decimal copperPerPlatinum = 1_000_000;   // 100 Gold
		const decimal copperPerGold = 10_000;          // 100 Silver
		const decimal copperPerSilver = 100;           // 100 Copper

		if (coppers >= copperPerElectrum) 
		{
			decimal valueInElectrum = coppers / copperPerElectrum;
			return valueInElectrum % 1 == 0 ? $"{valueInElectrum:F0} electrum" : $"{valueInElectrum:F2} electrum";
		}
		if (coppers >= copperPerPlatinum) 
		{
			decimal valueInPlatinum = coppers / copperPerPlatinum;
			return valueInPlatinum % 1 == 0 ? $"{valueInPlatinum:F0} platinum" : $"{valueInPlatinum:F2} platinum";
		}
		if (coppers >= copperPerGold) 
		{
			decimal valueInGold = coppers / copperPerGold;
			return valueInGold % 1 == 0 ? $"{valueInGold:F0} gold" : $"{valueInGold:F2} gold";
		}
		if (coppers >= copperPerSilver) 
		{
			decimal valueInSilver = coppers / copperPerSilver;
			return valueInSilver % 1 == 0 ? $"{valueInSilver:F0} silver" : $"{valueInSilver:F2} silver";
		}

		return $"{coppers} copper";
	}
}