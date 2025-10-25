using System;
using TMPro;
using UnityEngine;
using static Variables;

public class CharacterSheet : MonoBehaviour
{
    public CharacterList.NPC character;
	public TMP_Dropdown strengthDropdown;
	public TMP_Dropdown agilityDropdown;
	public TMP_Dropdown dexterityDropdown;
	public TMP_Dropdown enduranceDropdown;
	public TMP_Dropdown spiritDropdown;

	public void Start()
	{
		strengthDropdown.options.Clear();
		agilityDropdown.options.Clear();
		dexterityDropdown.options.Clear();
		enduranceDropdown.options.Clear();
		spiritDropdown.options.Clear();

		foreach (string ratingName in Enum.GetNames(typeof(Rating)))
		{
			if (ratingName == "SSS" || ratingName == "X") continue;

			strengthDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			agilityDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			dexterityDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			enduranceDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			spiritDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
		}

		strengthDropdown.onValueChanged.AddListener(OnStrengthDropdownValueChanged);
		agilityDropdown.onValueChanged.AddListener(OnAgilityDropdownValueChanged);
		dexterityDropdown.onValueChanged.AddListener(OnDexterityDropdownValueChanged);
		enduranceDropdown.onValueChanged.AddListener(OnEnduranceDropdownValueChanged);
		spiritDropdown.onValueChanged.AddListener(OnSpiritDropdownValueChanged);

		strengthDropdown.RefreshShownValue();
		agilityDropdown.RefreshShownValue();
		dexterityDropdown.RefreshShownValue();
		enduranceDropdown.RefreshShownValue();
		spiritDropdown.RefreshShownValue();

		character = new CharacterList.NPC();
	}

	public void OnStrengthDropdownValueChanged(int index)
	{
		character.Strength = index;
	}

	public void OnAgilityDropdownValueChanged(int index)
	{
		character.Agility = index;
	}

	public void OnDexterityDropdownValueChanged(int index)
	{
		character.Dexterity = index;
	}

	public void OnEnduranceDropdownValueChanged(int index)
	{
		character.Endurance = index;
	}

	public void OnSpiritDropdownValueChanged(int index)
	{
		character.Spirit = index;
	}
}