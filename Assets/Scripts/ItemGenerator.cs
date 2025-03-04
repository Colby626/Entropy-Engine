using TMPro;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
	public TextMeshProUGUI itemText;

	private bool itemEnchantable = true;
    public void GenerateItem()
    {
		string itemType = DetermineItemType();
		int itemTierNumber = DetermineItemTier();
		string itemEnchanted = "";

		if (itemEnchantable)
		{
			bool isItemEnchanted = DetermineItemEnchantment(itemTierNumber);

			if (isItemEnchanted)
				itemEnchanted = "Enchanted";
			else
				itemEnchanted = "Unenchanted";
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

		string item;
		if (itemEnchantable)
		{
			item = itemEnchanted + " " + itemTier + " " + itemType;
		}
		else
			item = itemTier + " " + itemType;

		itemText.text = item;
	}

	private string DetermineItemType()
	{
		float itemTypeRoll = Random.Range(0, 100f);
		itemEnchantable = true;

		if (itemTypeRoll >= 0 && itemTypeRoll < 38) // 38%
		{
			itemEnchantable = false;
			return "Misc";
		}
		else if (itemTypeRoll >= 38 && itemTypeRoll < 40) // 2%
			return "Greatsword";
		else if (itemTypeRoll >= 40 && itemTypeRoll < 42) // 2%
			return "Greataxe";
		else if (itemTypeRoll >= 42 && itemTypeRoll < 44) // 2%
			return "GreatHammer";
		else if (itemTypeRoll >= 44 && itemTypeRoll < 46) // 2%
			return "GreatSpear";
		else if (itemTypeRoll >= 46 && itemTypeRoll < 48) // 2%
			return "GreatBow";
		else if (itemTypeRoll >= 48 && itemTypeRoll < 50) // 2%
			return "Ballista";
		else if (itemTypeRoll >= 50 && itemTypeRoll < 52) // 2%
			return "Polearm";
		else if (itemTypeRoll >= 52 && itemTypeRoll < 54) // 2%
			return "Thrown Weapon";
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
			return "Maul";
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
			return "Heavy Armor";
		else if (itemTypeRoll >= 82 && itemTypeRoll < 84) // 2%
			return "Light Armor";
		else if (itemTypeRoll >= 84 && itemTypeRoll < 86) // 2%
			return "Medium Armor";
		else if (itemTypeRoll >= 86 && itemTypeRoll < 88) // 2%
			return "Amulet";
		else if (itemTypeRoll >= 88 && itemTypeRoll < 90) // 2%
			return "Ring";
		else if (itemTypeRoll >= 90 && itemTypeRoll < 92) // 2%
			return "Rapier";
		else if (itemTypeRoll >= 92 && itemTypeRoll < 94) // 2%
			return "Colossal";
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

		if (itemTierRoll >= 0 && itemTierRoll < 50) // 50% will be a common tier item
			return 1;
		else if (itemTierRoll >= 50 && itemTierRoll < 80) // 30%
			return 2;
		else if (itemTierRoll >= 80 && itemTierRoll < 93) // 13%
			return 3;
		else if (itemTierRoll >= 93 && itemTierRoll < 99) // 6%
			return 4;
		else if (itemTierRoll >= 99 && itemTierRoll <= 100) // 1%
			return 5;
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
		else
			return false;
	}
}