using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
	bool itemEnchantable = true;
    public void GenerateItem()
    {
		string itemType = DetermineItemType();
		int itemTierNumber = DetermineItemTier();
		string itemEnchanted = "";
		string itemQuality = "";

		if (itemEnchantable)
		{
			bool isItemEnchanted = DetermineItemEnchantment(itemTierNumber);
			int itemQualityNumber = DetermineItemQuality();

			if (isItemEnchanted)
				itemEnchanted = "Enchanted";
			else
				itemEnchanted = "Unenchanted";

			if (itemQualityNumber == 1)
				itemQuality = "Standard";
			else if (itemQualityNumber == 2)
				itemQuality = "Quality";
			else if (itemQualityNumber == 3)
				itemQuality = "Well-Made";
			else if (itemQualityNumber == 4)
				itemQuality = "Exceptional";
			else if (itemQualityNumber == 5)
				itemQuality = "Masterwork";
			else if (itemQualityNumber == 6)
				itemQuality = "Magnum Opus";
		}

		string itemTier = "";
		if (itemTierNumber == 1)
			itemTier = "Common";
		else if (itemTierNumber == 2)
			itemTier = "Uncommon";
		else if (itemTierNumber == 3)
			itemTier = "Rare";
		else if (itemTierNumber == 4)
			itemTier = "Epic";
		else if (itemTierNumber == 5)
			itemTier = "Legendary";
		else if (itemTierNumber == 6)
			itemTier = "Cataclysmic";

		string item;
		if (itemEnchantable)
			item = itemEnchanted + " " + itemQuality + " " + itemTier + " " + itemType;
		else
			item = itemTier + " " + itemType;

		Debug.Log(item);
	}

	private string DetermineItemType()
	{
		float itemTypeRoll = Random.Range(0, 100f);
		itemEnchantable = true;

		if (itemTypeRoll >= 0 && itemTypeRoll < 24) // 24%
		{
			itemEnchantable = false;
			return "Misc";
		}
		else if (itemTypeRoll >= 24 && itemTypeRoll < 39) // 15%
		{
			itemEnchantable = false;
			return "Skill book";
		}
		else if (itemTypeRoll >= 39 && itemTypeRoll < 54) // 15%
		{
			itemEnchantable = false;
			return "Spell tome";
		}
		else if (itemTypeRoll >= 54 && itemTypeRoll < 56) // 2%
			return "Shortsword";
		else if (itemTypeRoll >= 56 && itemTypeRoll < 58) // 2%
			return "Longsword";
		else if (itemTypeRoll >= 58 && itemTypeRoll < 60) // 2%
			return "Waraxe";
		else if (itemTypeRoll >= 60 && itemTypeRoll < 62) // 2%
			return "Battleaxe";
		else if (itemTypeRoll >= 62 && itemTypeRoll < 64) // 2%
			return "Mace";
		else if (itemTypeRoll >= 64 && itemTypeRoll < 66) // 2%
			return "Warhammer";
		else if (itemTypeRoll >= 66 && itemTypeRoll < 68) // 2%
			return "Shortspear";
		else if (itemTypeRoll >= 68 && itemTypeRoll < 70) // 2%
			return "Spear";
		else if (itemTypeRoll >= 70 && itemTypeRoll < 72) // 2%
			return "Dagger";
		else if (itemTypeRoll >= 72 && itemTypeRoll < 74) // 2%
			return "Longbow";
		else if (itemTypeRoll >= 74 && itemTypeRoll < 76) // 2%
			return "Shortbow";
		else if (itemTypeRoll >= 76 && itemTypeRoll < 78) // 2%
			return "Crossbow";
		else if (itemTypeRoll >= 78 && itemTypeRoll < 80) // 2%
			return "Staff";
		else if (itemTypeRoll >= 80 && itemTypeRoll < 82) // 2%
			return "Heavy armor";
		else if (itemTypeRoll >= 82 && itemTypeRoll < 84) // 2%
			return "Light armor";
		else if (itemTypeRoll >= 84 && itemTypeRoll < 86) // 2%
			return "Medium armor";
		else if (itemTypeRoll >= 86 && itemTypeRoll < 88) // 2%
			return "Amulet";
		else if (itemTypeRoll >= 88 && itemTypeRoll < 90) // 2%
			return "Ring";
		else if (itemTypeRoll >= 90 && itemTypeRoll < 92) // 2%
			return "Rapier";
		else if (itemTypeRoll >= 92 && itemTypeRoll < 94) // 2%
			return "Scythe";
		else if (itemTypeRoll >= 94 && itemTypeRoll < 96) // 2%
			return "Shield";
		else if (itemTypeRoll >= 96 && itemTypeRoll < 98) // 2%
			return "Arrows";
		else if (itemTypeRoll >= 98 && itemTypeRoll <= 100) // 2%
			return "Bolts";
		else
			return "";
	}

	private int DetermineItemTier()
	{
		float itemTierRoll = Random.Range(0, 100f);

		if (itemTierRoll >= 0 && itemTierRoll < 50) // 50%
			return 1;
		else if (itemTierRoll >= 50 && itemTierRoll < 80) // 30%
			return 2;
		else if (itemTierRoll >= 80 && itemTierRoll < 93) // 13%
			return 3;
		else if (itemTierRoll >= 93 && itemTierRoll < 99) // 6%
			return 4;
		else if (itemTierRoll >= 99 && itemTierRoll < 99.8) // .8%
			return 5;
		else if (itemTierRoll >= 99.8 && itemTierRoll <= 100) // .2%
			return 6;
		else
			return 0;
	}

	private bool DetermineItemEnchantment(int itemTierNumber)
	{
		if (itemTierNumber == 1)
			return Random.Range(0, 100) > 80f; // 80% chance a common item will be unenchanted
		else if (itemTierNumber == 2)
			return Random.Range(0, 100) > 60f; // 60%
		else if (itemTierNumber == 3)
			return Random.Range(0, 100) > 40f; // 40%
		else if (itemTierNumber == 4)
			return Random.Range(0, 100) > 20f; // 20%
		else if (itemTierNumber == 5)
			return Random.Range(0, 100) > 10f; // 10%
		else if (itemTierNumber == 6)
			return Random.Range(0, 100) > 5f; // 5% 
		else
			return false;
	}

	private int DetermineItemQuality()
	{
		float itemQualityRoll = Random.Range(0, 100f);

		if (itemQualityRoll >= 0 && itemQualityRoll < 50) // 50%
			return 1;
		else if (itemQualityRoll >= 50 && itemQualityRoll < 75) // 25%
			return 2;
		else if (itemQualityRoll >= 75 && itemQualityRoll < 90) // 15%
			return 3;
		else if (itemQualityRoll >= 90 && itemQualityRoll < 96) // 6%
			return 4;
		else if (itemQualityRoll >= 96 && itemQualityRoll < 99) // 3%
			return 5;
		else if (itemQualityRoll >= 99 && itemQualityRoll <= 100) // 1%
			return 6;
		else
			return 0;
	}
}