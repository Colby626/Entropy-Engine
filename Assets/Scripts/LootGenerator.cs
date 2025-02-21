using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootGenerator : MonoBehaviour
{
	public TMP_Dropdown lootAmountDropdown;
	public TextMeshProUGUI moneyText;
	private long totalCoins = 0;

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

    public void GenerateLoot()
    {
		/*
		100 copper = 1 silver
		100 silver = 1 gold
		100 gold = 1 platinum
		1000 platinum = 1 electrum
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
				copper = (long)Random.Range(2000000, 2500000001); // 2 platinum = 2.5 electrum
			else if (weightRoll < 80) // 30% chance
				copper = (long)Random.Range(2500000000, 5000000001); // 2.5 electrum - 5 electrum
			else if (weightRoll < 95) // 15% chance
				copper = (long)Random.Range(5000000000, 7500000001); // 5 electrum - 7.5 electrum
			else // 5% chance
				copper = (long)Random.Range(7500000000, 10000000001); // 7.5 electrum - 10 electrum
		}

		totalCoins = copper;
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
		Debug.Log("Loot Amount changed to: " + currentLootAmount);
	}

	private void DisperseCoins(long copper)
	{
		// Calculate Electrum (1 electrum = 1 billion copper)
		long maxElectrum = copper / 1000000000L; 
		int electrum = Random.Range(0, (int)maxElectrum); 
		copper -= electrum * 1000000000L; 

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

		Debug.Log(money);
		moneyText.text = money;
	}

	public void MinimizeCoins()
	{
		long copper = totalCoins;
		// Calculate Electrum (1 electrum = 1 billion copper)
		long maxElectrum = copper / 1000000000L;
		copper -= maxElectrum * 1000000000L;

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

		Debug.Log(money);
		moneyText.text = money;
	}
}