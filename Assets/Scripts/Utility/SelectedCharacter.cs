using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedCharacter : MonoBehaviour, ISelectHandler, IDeselectHandler
{
	private Transform classListOfStats;
    private TextMeshProUGUI lordshipListOfStats;
    private CharacterList.Character characterData;
	private CharacterList.NPC npcData;
	private TextMeshProUGUI abilityDetailsText;
	private TMP_InputField notes;
	private CharacterList characterList;
	private Transform combatTab;

	public void Start()
	{
		characterList = GetComponent<CharacterTemplate>().characterList;

        classListOfStats = characterList.classListOfStats;
		lordshipListOfStats = characterList.lordshipListOfStats;
		abilityDetailsText = characterList.abilityDetailsText;
		notes = characterList.notes;
		combatTab = characterList.combatTab;
    }

	public void OnSelect(BaseEventData eventData)
	{
		characterData = GetComponent<CharacterTemplate>().characterData;
		if (characterData != null)
		{
			classListOfStats.GetChild(0).GetComponent<TextMeshProUGUI>().text = characterData.Name;
			classListOfStats.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Endurance: " + characterData.Endurance.ToString();
			classListOfStats.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Strength: " + characterData.Strength.ToString();
			classListOfStats.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Dexterity: " + characterData.Dexterity.ToString();
			classListOfStats.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Agility: " + characterData.Agility.ToString();
			classListOfStats.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Intelligence: " + characterData.Intelligence.ToString();
			classListOfStats.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Spirit: " + characterData.Spirit.ToString();
			classListOfStats.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Max Health: " + characterData.MaxHealth.ToString();
			classListOfStats.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Max Mana: " + characterData.MaxMana.ToString();
			classListOfStats.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: " + characterData.PhysicalResistance.ToString();
			classListOfStats.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: " + characterData.MagicResistance.ToString();
			classListOfStats.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Agility Class: " + characterData.AgilityClass.ToString();
			classListOfStats.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: " + characterData.PlusToHit.ToString();
			classListOfStats.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Initiative Bonus: " + characterData.InitiativeBonus.ToString();
			classListOfStats.GetChild(14).GetComponent<TextMeshProUGUI>().text = "Movement Spaces: " + characterData.MovementSpeed.ToString();
		}
		else
		{ 
			npcData = GetComponent<CharacterTemplate>().npcData;
			characterList.selectedCharacter = npcData;

            StringBuilder statsText = new ();
			statsText.AppendLine($"<b><u>{npcData.Name}</u></b>"); // Underline and bold
            statsText.AppendLine("AC: " + npcData.AC);
            statsText.AppendLine("MC: " + npcData.MC);
            statsText.AppendLine("Dodge Bonus: " + npcData.DodgeBonus);
			statsText.AppendLine("Plus To Hit: " + npcData.PlusToHit);
			statsText.AppendLine("Movement Spaces: " + npcData.MovementSpeed);
			statsText.AppendLine("Physical Damage Multiplier: " + npcData.PhysicalDamageMultiplier);
			statsText.AppendLine("Magic Damage Multiplier: " + npcData.MagicDamageMultiplier);
			statsText.AppendLine("Strength: " + npcData.Strength);
			statsText.AppendLine("Dexterity: " + npcData.Dexterity);
			statsText.AppendLine("Agility: " + npcData.Agility);
			statsText.AppendLine("Intelligence: " + npcData.Intelligence);
			statsText.AppendLine("Spirit: " + npcData.Spirit);
			statsText.AppendLine("Charisma: " + npcData.Charisma);
			statsText.AppendLine("Vitality: " + npcData.Vitality);
			statsText.AppendLine("Fortitude: " + npcData.Fortitude);
			statsText.AppendLine("Max Health: " + npcData.MaxHealth);
			statsText.AppendLine("Max Mana: " + npcData.MaxMana);

			lordshipListOfStats.text = statsText.ToString();
			abilityDetailsText.text = npcData.Abilities;
			notes.gameObject.SetActive(true);
			notes.text = npcData.Notes;
			notes.GetComponent<UpdateNotes>().npc = npcData;
			SetTogglesToCharacterDefault();
		}
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