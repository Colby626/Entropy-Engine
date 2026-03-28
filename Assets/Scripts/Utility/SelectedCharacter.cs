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

	private TextMeshProUGUI fiftyLevelListOfStats;
	private TextMeshProUGUI fiftyLevelAbilityDetailsText;
	private TMP_InputField fiftyLevelNotes;
	private Transform fiftyLevelCombatTab;

	public void Start()
	{
		characterList = GetComponent<CharacterTemplate>().characterList;

		lordshipListOfStats = characterList.lordshipListOfStats;
		abilityDetailsText = characterList.abilityDetailsText;
		notes = characterList.notes;
		combatTab = characterList.combatTab;
		fiftyLevelListOfStats = characterList.fiftyLevelListOfStats;
		fiftyLevelAbilityDetailsText = characterList.fiftyLevelAbilityDetailsText;
		fiftyLevelNotes = characterList.fiftyLevelNotes;
		fiftyLevelCombatTab = characterList.fiftyLevelCombatTab;
    }

	public void OnSelect(BaseEventData eventData)
	{
		npcData = GetComponent<CharacterTemplate>().npcData;
		characterList.selectedCharacter = npcData;

        StringBuilder statsText = new ();

		if (npcData.System == "Lordship")
		{
			statsText.AppendLine($"<b><u>{npcData.Name}</u></b>"); // Underline and bold
			statsText.AppendLine("Element: " + npcData.Element);
			statsText.AppendLine("AC: " + npcData.AC);
			statsText.AppendLine("DR: " + npcData.DR);
			statsText.AppendLine("Str Dmg Bonus: " + npcData.StrengthDamageBonus);
			statsText.AppendLine("Spt Dmg Bonus: " + npcData.SpiritDamageBonus);
			statsText.AppendLine("Plus To Hit: " + npcData.PlusToHit);
			statsText.AppendLine("Critical Bonus: " + npcData.CriticalBonus);
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
		}
		else if (npcData.System == "50 Level")
		{
			statsText.AppendLine($"<b><u>{npcData.Name}</u></b>"); // Underline and bold
			statsText.AppendLine($"Level: {npcData.Level}");
			statsText.AppendLine("AC: " + npcData.AC);
			statsText.AppendLine("DR: " + npcData.DR);
			statsText.AppendLine("Melee Dmg Bonus: " + npcData.MeleeDamageBonus);
			statsText.AppendLine("Ranged Dmg Bonus: " + npcData.RangedDamageBonus);
			statsText.AppendLine("Spell Dmg Bonus: " + npcData.SpellDamageBonus);
			statsText.AppendLine("Plus To Hit: " + npcData.PlusToHit);
			statsText.AppendLine("Resistance: " + npcData.Resistance);
            statsText.AppendLine("Phy Saving Throw: " + npcData.PhysicalSavingThrowBonus);
            statsText.AppendLine("Magic Saving Throw: " + npcData.MagicSavingThrowBonus);
            statsText.AppendLine("Spell Save DC: " + npcData.SpellSaveDC);
            statsText.AppendLine("Charisma: " + npcData.Charisma);
			statsText.AppendLine("Movement Spaces: " + npcData.MovementSpeed);
			statsText.AppendLine("Strength: " + npcData.Strength);
			statsText.AppendLine("Finesse: " + npcData.Finesse);
			statsText.AppendLine("Intelligence: " + npcData.Intelligence);
			statsText.AppendLine("Spirit: " + npcData.Spirit);
			statsText.AppendLine("Endurance: " + npcData.Endurance);
			statsText.AppendLine("Max Health: " + npcData.MaxHealth);
			statsText.AppendLine("Max Mana: " + npcData.MaxMana);

			fiftyLevelListOfStats.text = statsText.ToString();
			fiftyLevelAbilityDetailsText.text = npcData.Abilities;
			fiftyLevelNotes.gameObject.SetActive(true);
			fiftyLevelNotes.text = npcData.Notes;
			fiftyLevelNotes.GetComponent<UpdateNotes>().npc = npcData;
		}

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