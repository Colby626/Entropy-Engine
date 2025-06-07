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

			case "Material":
				if (name == "Primitive")
					selectedCharacter.WeaponMaterial = CharacterList.WeaponMaterial.Primitive;
				else if (name == "Iron")
					selectedCharacter.WeaponMaterial = CharacterList.WeaponMaterial.Iron;
				else if (name == "Steel")
					selectedCharacter.WeaponMaterial = CharacterList.WeaponMaterial.Steel;
				else if (name == "Dlaren")
					selectedCharacter.WeaponMaterial = CharacterList.WeaponMaterial.Dlaren;
				else if (name == "Draconic")
					selectedCharacter.WeaponMaterial = CharacterList.WeaponMaterial.Draconic;
				else if (name == "Divine/Demonic")
					selectedCharacter.WeaponMaterial = CharacterList.WeaponMaterial.Divine_Demonic;
				break;

			case "ArrowMaterial":
				if (name == "Primitive")
					selectedCharacter.ArrowMaterial = CharacterList.WeaponMaterial.Primitive;
				else if (name == "Iron")
					selectedCharacter.ArrowMaterial = CharacterList.WeaponMaterial.Iron;
				else if (name == "Steel")
					selectedCharacter.ArrowMaterial = CharacterList.WeaponMaterial.Steel;
				else if (name == "Dlaren")
					selectedCharacter.ArrowMaterial = CharacterList.WeaponMaterial.Dlaren;
				else if (name == "Draconic")
					selectedCharacter.ArrowMaterial = CharacterList.WeaponMaterial.Draconic;
				else if (name == "Divine/Demonic")
					selectedCharacter.ArrowMaterial = CharacterList.WeaponMaterial.Divine_Demonic;
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