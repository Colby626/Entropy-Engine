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
	public TMP_Dropdown vitalityDropdown;
	public TMP_Dropdown intelligenceDropdown;
	public TMP_Dropdown charismaDropdown;
	public TMP_Dropdown spiritDropdown;
	public TMP_Dropdown fortitudeDropdown;

	public void Start()
	{
		strengthDropdown.options.Clear();
		agilityDropdown.options.Clear();
		dexterityDropdown.options.Clear();
		vitalityDropdown.options.Clear();
		intelligenceDropdown.options.Clear();
		charismaDropdown.options.Clear();
		spiritDropdown.options.Clear();
		fortitudeDropdown.options.Clear();

		foreach (string ratingName in Enum.GetNames(typeof(Rating)))
		{
			if (ratingName == "SSS" || ratingName == "X") continue;

			strengthDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			agilityDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			dexterityDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			vitalityDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			intelligenceDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			charismaDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			spiritDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
			fortitudeDropdown.options.Add(new TMP_Dropdown.OptionData(ratingName));
		}

		strengthDropdown.onValueChanged.AddListener(OnStrengthDropdownValueChanged);
		agilityDropdown.onValueChanged.AddListener(OnAgilityDropdownValueChanged);
		dexterityDropdown.onValueChanged.AddListener(OnDexterityDropdownValueChanged);
		vitalityDropdown.onValueChanged.AddListener(OnVitalityDropdownValueChanged);
		intelligenceDropdown.onValueChanged.AddListener(OnIntelligenceDropdownValueChanged);
		charismaDropdown.onValueChanged.AddListener(OnCharismaDropdownValueChanged);
		spiritDropdown.onValueChanged.AddListener(OnSpiritDropdownValueChanged);
		fortitudeDropdown.onValueChanged.AddListener(OnFortitudeDropdownValueChanged);

		strengthDropdown.RefreshShownValue();
		agilityDropdown.RefreshShownValue();
		dexterityDropdown.RefreshShownValue();
		vitalityDropdown.RefreshShownValue();
		intelligenceDropdown.RefreshShownValue();
		charismaDropdown.RefreshShownValue();
		spiritDropdown.RefreshShownValue();
		fortitudeDropdown.RefreshShownValue();

		character = new CharacterList.NPC();
	}

	public void OnStrengthDropdownValueChanged(int index)
	{
		character.Strength = (Rating)index;
	}

	public void OnAgilityDropdownValueChanged(int index)
	{
		character.Agility = (Rating)index;
	}

	public void OnDexterityDropdownValueChanged(int index)
	{
		character.Dexterity = (Rating)index;
	}

	public void OnVitalityDropdownValueChanged(int index)
	{
		character.Vitality = (Rating)index;
	}

	public void OnIntelligenceDropdownValueChanged(int index)
	{
		character.Intelligence = (Rating)index;
	}

	public void OnCharismaDropdownValueChanged(int index)
	{
		character.Charisma = (Rating)index;
	}

	public void OnSpiritDropdownValueChanged(int index)
	{
		character.Spirit = (Rating)index;
	}

	public void OnFortitudeDropdownValueChanged(int index)
	{
		character.Fortitude = (Rating)index;
	}
}