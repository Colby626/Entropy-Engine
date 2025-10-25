using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedCharacter : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private TextMeshProUGUI lordshipListOfStats;
	private CharacterList.NPC npcData;
	private TextMeshProUGUI abilityDetailsText;
	private TMP_InputField notes;
	private CharacterList characterList;
	private Transform combatTab;

	public void Start()
	{
		characterList = GetComponent<CharacterTemplate>().characterList;

		lordshipListOfStats = characterList.lordshipListOfStats;
		abilityDetailsText = characterList.abilityDetailsText;
		notes = characterList.notes;
		combatTab = characterList.combatTab;
    }

	public void OnSelect(BaseEventData eventData)
	{
		npcData = GetComponent<CharacterTemplate>().npcData;
		characterList.selectedCharacter = npcData;

        StringBuilder statsText = new ();
		statsText.AppendLine($"<b><u>{npcData.Name}</u></b>"); // Underline and bold
        statsText.AppendLine("AC: " + npcData.AC);
		statsText.AppendLine("DR: " + npcData.DR);
		statsText.AppendLine("Str Dmg Bonus: " + npcData.StrengthDamageBonus);
        statsText.AppendLine("Dex Dmg Bonus: " + npcData.DexterityDamageBonus);
        statsText.AppendLine("Spt Dmg Bonus: " + npcData.SpiritDamageBonus);
        statsText.AppendLine("Plus To Hit: " + npcData.PlusToHit);
		statsText.AppendLine("Movement Spaces: " + npcData.MovementSpeed);
		statsText.AppendLine("Strength: " + npcData.Strength);
		statsText.AppendLine("Dexterity: " + npcData.Dexterity);
		statsText.AppendLine("Agility: " + npcData.Agility);
		statsText.AppendLine("Spirit: " + npcData.Spirit);
		statsText.AppendLine("Endurance: " + npcData.Endurance);
		statsText.AppendLine("Max Health: " + npcData.MaxHealth);
		statsText.AppendLine("Max Mana: " + npcData.MaxMana);

		lordshipListOfStats.text = statsText.ToString();
		abilityDetailsText.text = npcData.Abilities;
		notes.gameObject.SetActive(true);
		notes.text = npcData.Notes;
		notes.GetComponent<UpdateNotes>().npc = npcData;
		SetTogglesToCharacterDefault();
	}

	private void SetTogglesToCharacterDefault()
	{
		Transform typeToggles = combatTab.GetChild(0);
		string targetName = characterList.selectedCharacter.WeaponType.ToString();

		foreach (Transform child in typeToggles)
		{
			if (child.TryGetComponent<Toggle>(out Toggle toggle))
			{
				toggle.isOn = (child.name == targetName);
			}
		}

		Transform sizeToggles = combatTab.GetChild(1);
		targetName = characterList.selectedCharacter.WeaponSize.ToString();

		foreach (Transform child in sizeToggles)
		{
			if (child.TryGetComponent<Toggle>(out Toggle toggle))
			{
				toggle.isOn = (child.name == targetName);
			}
		}

		Transform materialToggles = combatTab.GetChild(2);
		targetName = characterList.selectedCharacter.WeaponMaterial.ToString();

		foreach (Transform child in materialToggles)
		{
			if (child.TryGetComponent<Toggle>(out Toggle toggle))
			{
				toggle.isOn = (child.name == targetName);
			}
		}

		Transform arrowMaterialToggles = combatTab.GetChild(3);
		targetName = characterList.selectedCharacter.ArrowMaterial.ToString();

		foreach (Transform child in arrowMaterialToggles)
		{
			if (child.TryGetComponent<Toggle>(out Toggle toggle))
			{
				toggle.isOn = (child.name == targetName);
			}
		}

		Transform enchantmentToggles = combatTab.GetChild(4);
		targetName = characterList.selectedCharacter.WeaponEnchantment.ToString();

		foreach (Transform child in enchantmentToggles)
		{
			if (child.TryGetComponent<Toggle>(out Toggle toggle))
			{
				toggle.isOn = (child.name == targetName);
			}
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		
	}
}