using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Transform classListOfStats;
    private Transform lordshipListOfStats;
    private CharacterList.Character characterData;
	private CharacterList.NPC npcData;
	private TextMeshProUGUI abilityDetailsText;

	public void Start()
	{
		CharacterList characterList = GetComponent<CharacterTemplate>().characterList;

        classListOfStats = characterList.classListOfStats;
		lordshipListOfStats = characterList.lordshipListOfStats;
		abilityDetailsText = characterList.abilityDetailsText;
    }

	public void OnPointerEnter(PointerEventData eventData)
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
            lordshipListOfStats.GetChild(0).GetComponent<TextMeshProUGUI>().text = npcData.Name;
            lordshipListOfStats.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Strength: " + npcData.Strength.ToString();
			lordshipListOfStats.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Dexterity: " + npcData.Dexterity.ToString();
            lordshipListOfStats.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Agility: " + npcData.Agility.ToString();
			lordshipListOfStats.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Intelligence: " + npcData.Intelligence.ToString();
			lordshipListOfStats.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Spirit: " + npcData.Spirit.ToString();
			lordshipListOfStats.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Charisma: " + npcData.Charisma.ToString();
			lordshipListOfStats.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Vitality: " + npcData.Vitality.ToString();
			lordshipListOfStats.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Fortitude: " + npcData.Fortitude.ToString();
			lordshipListOfStats.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Max Health: " + npcData.MaxHealth.ToString();
			lordshipListOfStats.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Max Mana: " + npcData.MaxMana.ToString();
			lordshipListOfStats.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: " + npcData.PhysicalResistance.ToString();
			lordshipListOfStats.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: " + npcData.MagicResistance.ToString();
			lordshipListOfStats.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Agility Bonus: " + npcData.AgilityBonus.ToString();
			lordshipListOfStats.GetChild(14).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: " + npcData.PlusToHit.ToString();
			lordshipListOfStats.GetChild(15).GetComponent<TextMeshProUGUI>().text = "Physical Damage Bonus: " + npcData.PhysicalDamageBonus.ToString();
			lordshipListOfStats.GetChild(16).GetComponent<TextMeshProUGUI>().text = "Magic Damage Bonus: " + npcData.MagicDamageBonus.ToString();
			lordshipListOfStats.GetChild(17).GetComponent<TextMeshProUGUI>().text = "Movement Spaces: " + npcData.MovementSpeed.ToString();
			abilityDetailsText.text = npcData.Abilities;

        }
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		/*
		if (characterData != null)
		{
			classListOfStats.GetChild(0).GetComponent<TextMeshProUGUI>().text = "?";
			classListOfStats.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Endurance: ?";
			classListOfStats.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Strength: ?";
			classListOfStats.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Dexterity: ?";
			classListOfStats.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Agility: ?";
			classListOfStats.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Intelligence: ?";
			classListOfStats.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Spirit: ?";
			classListOfStats.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Max Health: ?";
			classListOfStats.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Max Mana: ?";
			classListOfStats.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: ?";
			classListOfStats.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: ?";
			classListOfStats.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Agility Class: ?";
			classListOfStats.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: ?";
			classListOfStats.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Initiative Bonus: ?";
			classListOfStats.GetChild(14).GetComponent<TextMeshProUGUI>().text = "Movement Spaces: ?";
		}
        else
        {
            npcData = GetComponent<CharacterTemplate>().npcData;
            lordshipListOfStats.GetChild(0).GetComponent<TextMeshProUGUI>().text = npcData.Name;
            lordshipListOfStats.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Strength: ?";
            lordshipListOfStats.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Dexterity: ?";
            lordshipListOfStats.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Agility: ?";
            lordshipListOfStats.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Intelligence: ?";
            lordshipListOfStats.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Spirit: ?";
            lordshipListOfStats.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Charisma: ?";
            lordshipListOfStats.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Vitality: ?";
            lordshipListOfStats.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Fortitude: ?";
            lordshipListOfStats.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Max Health: ?";
            lordshipListOfStats.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Max Mana: ?";
            lordshipListOfStats.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: ?";
            lordshipListOfStats.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: ?";
            lordshipListOfStats.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Agility Bonus: ?";
            lordshipListOfStats.GetChild(14).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: ?";
            lordshipListOfStats.GetChild(15).GetComponent<TextMeshProUGUI>().text = "Physical Damage Bonus: ?";
            lordshipListOfStats.GetChild(16).GetComponent<TextMeshProUGUI>().text = "Magic Damage Bonus: ?";
            lordshipListOfStats.GetChild(17).GetComponent<TextMeshProUGUI>().text = "Movement Spaces: ?";
			abilityDetailsText.text = "";
        }
		*/
    }
}
