using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Transform listOfStats;
	private CharacterList.Character characterData;

	public void Start()
	{
		listOfStats = GetComponent<CharacterTemplate>().characterList.listOfStats;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		characterData = GetComponent<CharacterTemplate>().characterData;

		listOfStats.GetChild(0).GetComponent<TextMeshProUGUI>().text = characterData.Name;
		listOfStats.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Endurance: " + characterData.Endurance.ToString();
		listOfStats.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Strength: " + characterData.Strength.ToString();
		listOfStats.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Dexterity: " + characterData.Dexterity.ToString();
		listOfStats.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Agility: " + characterData.Agility.ToString();
		listOfStats.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Intelligence: " + characterData.Intelligence.ToString();
		listOfStats.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Spirit: " + characterData.Spirit.ToString();
		listOfStats.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Max Health: " + characterData.MaxHealth.ToString();
		listOfStats.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Max Mana: " + characterData.MaxMana.ToString();
		listOfStats.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: " + characterData.PhysicalResistance.ToString();
		listOfStats.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: " + characterData.MagicResistance.ToString();
		listOfStats.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Agility Class: " + characterData.AgilityClass.ToString();
		listOfStats.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: " + characterData.PlusToHit.ToString();
		listOfStats.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Initiative Bonus: " + characterData.InitiativeBonus.ToString();
		listOfStats.GetChild(14).GetComponent<TextMeshProUGUI>().text = "Movement Spaces: " + characterData.MovementSpeed.ToString();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		listOfStats.GetChild(0).GetComponent<TextMeshProUGUI>().text = "?";
		listOfStats.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Endurance: ?";
		listOfStats.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Strength: ?";
		listOfStats.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Dexterity: ?";
		listOfStats.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Agility: ?";
		listOfStats.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Intelligence: ?";
		listOfStats.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Spirit: ?";
		listOfStats.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Max Health: ?";
		listOfStats.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Max Mana: ?";
		listOfStats.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: ?";
		listOfStats.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: ?";
		listOfStats.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Agility Class: ?";
		listOfStats.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: ?";
		listOfStats.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Initiative Bonus: ?";
		listOfStats.GetChild(14).GetComponent<TextMeshProUGUI>().text = "Movement Spaces: ?";
	}
}
