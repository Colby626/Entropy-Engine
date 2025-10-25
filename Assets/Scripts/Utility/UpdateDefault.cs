using UnityEngine;

public class UpdateDefault : MonoBehaviour
{
    public void UpdateNPCDefault()
    {
		var selectedCharacter = FindFirstObjectByType<CharacterList>().selectedCharacter;
		if (selectedCharacter == null)
			return;
		switch (transform.parent.name)
		{
			case "Type":
				if (name == "Melee")
					selectedCharacter.WeaponType = CharacterList.WeaponType.Melee;
				else if (name == "Ranged")
					selectedCharacter.WeaponType = CharacterList.WeaponType.Ranged;
				else if (name == "Magic")
					selectedCharacter.WeaponType = CharacterList.WeaponType.Magic;
				break;

			case "Size":
				if (name == "Light")
					selectedCharacter.WeaponSize = CharacterList.WeaponSize.Light;
				else if (name == "Balanced")
					selectedCharacter.WeaponSize = CharacterList.WeaponSize.Balanced;
				else if (name == "Heavy")
					selectedCharacter.WeaponSize = CharacterList.WeaponSize.Heavy;
				else if (name == "Massive")
					selectedCharacter.WeaponSize = CharacterList.WeaponSize.Massive;
				else if (name == "Colossal")
					selectedCharacter.WeaponSize = CharacterList.WeaponSize.Colossal;
				break;

			case "WeaponMaterial":
				if (name == "Iron")
					selectedCharacter.WeaponMaterial = CharacterList.Material.Iron;
				else if (name == "Steel")
					selectedCharacter.WeaponMaterial = CharacterList.Material.Steel;
				else if (name == "Dlaren")
					selectedCharacter.WeaponMaterial = CharacterList.Material.Dlaren;
				else if (name == "Valkyrian")
					selectedCharacter.WeaponMaterial = CharacterList.Material.Valkyrian;
				else if (name == "Draconic")
					selectedCharacter.WeaponMaterial = CharacterList.Material.Draconic;
				else if (name == "Divine/Demonic")
					selectedCharacter.WeaponMaterial = CharacterList.Material.Divine_Demonic;
				break;

			case "ArrowMaterial":
				if (name == "Iron")
					selectedCharacter.ArrowMaterial = CharacterList.Material.Iron;
				else if (name == "Steel")
					selectedCharacter.ArrowMaterial = CharacterList.Material.Steel;
				else if (name == "Dlaren")
					selectedCharacter.ArrowMaterial = CharacterList.Material.Dlaren;
				else if (name == "Valkyrian")
					selectedCharacter.ArrowMaterial = CharacterList.Material.Valkyrian;
				else if (name == "Draconic")
					selectedCharacter.ArrowMaterial = CharacterList.Material.Draconic;
				else if (name == "Divine/Demonic")
					selectedCharacter.ArrowMaterial = CharacterList.Material.Divine_Demonic;
				break;

			case "Enchantment":
				if (name == "Unenchanted")
					selectedCharacter.WeaponEnchantment = CharacterList.WeaponEnchantment.Unenchanted;
				else if (name == "Common")
					selectedCharacter.WeaponEnchantment = CharacterList.WeaponEnchantment.Common;
				else if (name == "Uncommon")
					selectedCharacter.WeaponEnchantment = CharacterList.WeaponEnchantment.Uncommon;
				else if (name == "Rare")
					selectedCharacter.WeaponEnchantment = CharacterList.WeaponEnchantment.Rare;
				else if (name == "Epic")
					selectedCharacter.WeaponEnchantment = CharacterList.WeaponEnchantment.Epic;
				else if (name == "Legendary")
					selectedCharacter.WeaponEnchantment = CharacterList.WeaponEnchantment.Legendary;
				break;

			default:
				break;
		}
	}
}