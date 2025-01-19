using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
	public struct Character
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
	}

	public List<Character> characters = new List<Character>();
	public GameObject characterTemplatePrefab;
	public Transform contentObjectInScrollview;

	public void GenerateCharacter(Character character)
	{
		characters.Add(character);
		GameObject template = Instantiate(characterTemplatePrefab);
		template.transform.SetParent(contentObjectInScrollview);
		CharacterTemplate characterTemplate = template.GetComponent<CharacterTemplate>();
		characterTemplate.characterList = this;
		characterTemplate.characterData = character;
	}

	public void DeleteCharacter(CharacterTemplate template)
	{
		characters.Remove(template.characterData);
		Destroy(template.gameObject);
	}
}