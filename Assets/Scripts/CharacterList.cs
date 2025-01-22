using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
	public class Character
	{
		public string Name;

		public int Endurance;
		public int Strength;
		public int Dexterity;
		public int Agility;
		public int Intelligence;
		public int Spirit;
		
		public int MaxHealth;
		public int CurrentHealth;
		public int MaxMana;
		public int CurrentMana;
		public int PhysicalResistance;
		public int MagicResistance;
		public int PlusToHit;
		public int AgilityClass;
		public int InitiativeBonus;
		public int MovementSpeed;

		public int Initiative;
	}

	private List<Character> characters = new();
	public GameObject characterTemplatePrefab;
	public Transform contentObjectInScrollview;
	public Transform listOfStats;

	public void GenerateCharacter(Character character)
	{
		characters.Add(character);
		AddCharacterToScrollview(character);
	}

	public void DeleteCharacter(CharacterTemplate template)
	{
		characters.Remove(template.characterData);
		Destroy(template.gameObject);
	}

	public void RollInitiative()
	{
		// Each character rolls a d20 and adds their initiative bonus
		foreach (Character character in characters)
		{
			character.Initiative = Random.Range(1, 21) + character.InitiativeBonus;
		}

		// The characters are sorted from greatest initative to lowest initative
		characters.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));

		// The characters are sorted visually
		for (int i = contentObjectInScrollview.childCount - 1; i >= 0; i--)
		{
			Transform child = contentObjectInScrollview.GetChild(i);
			Destroy(child.gameObject);
		}

		foreach (Character character in characters)
		{
			AddCharacterToScrollview(character);
		}
	}

	private void AddCharacterToScrollview(Character character)
	{
		GameObject template = Instantiate(characterTemplatePrefab);
		template.transform.SetParent(contentObjectInScrollview);
		// For whatever reason, this is required for the children to scale properly within the scrollview
		template.transform.localScale = new Vector3(0.9244992f, 0.9244992f, 0.9244992f);
		if (character.Initiative != 0)
			template.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = character.Initiative.ToString();

		CharacterTemplate characterTemplate = template.GetComponent<CharacterTemplate>();
		characterTemplate.characterList = this;
		characterTemplate.characterData = character;
	}
}