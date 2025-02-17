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

	public class NPC
	{
		public string Name;

		public GenerateStats.Rating Strength;
		public GenerateStats.Rating Dexterity;
		public GenerateStats.Rating Agility;
		public GenerateStats.Rating Intelligence;
		public GenerateStats.Rating Spirit;
		public GenerateStats.Rating Charisma;
		public GenerateStats.Rating Vitality;
		public GenerateStats.Rating Fortitude;

        public int MaxHealth;
        public int CurrentHealth;
        public int MaxMana;
        public int CurrentMana;
        public int PhysicalResistance;
        public int MagicResistance;
        public int PlusToHit;
        public int PhysicalDamageBonus;
        public int MagicDamageBonus;
        public int AgilityBonus;
        public int MovementSpeed;

        public int Initiative;
		public string Abilities;
    }

	private List<Character> characters = new();
	private List<NPC> npcs = new();
	public GameObject characterTemplatePrefab;
	public Transform classContentObjectInScrollview;
	public Transform classListOfStats;
    public Transform lordshipContentObjectInScrollview;
    public Transform lordshipListOfStats;
    public TextMeshProUGUI abilityDetailsText;

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

    public void GenerateNPC(NPC npc)
    {
        npcs.Add(npc);
        AddNPCToScrollview(npc);
    }

    public void DeleteNPC(CharacterTemplate template)
    {
        npcs.Remove(template.npcData);
        Destroy(template.gameObject);
    }

    public void RollInitiative()
	{
		// Each character rolls a d20 and adds their initiative bonus
		foreach (Character character in characters)
		{
			if (character.Initiative == 0)
			{
				character.Initiative = Random.Range(1, 21) + character.InitiativeBonus;
			}
		}

		// The characters are sorted from greatest initative to lowest initative
		characters.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));

		// The characters are sorted visually
		for (int i = classContentObjectInScrollview.childCount - 1; i >= 0; i--)
		{
			Transform child = classContentObjectInScrollview.GetChild(i);
			Destroy(child.gameObject);
		}

        foreach (Character character in characters)
		{
			AddCharacterToScrollview(character);
		}
	}

    public void RollLordshipInitiative()
    {
        // Each character rolls a d20 and adds their initiative bonus
        foreach (NPC npc in npcs)
        {
            if (npc.Initiative == 0)
            {
                npc.Initiative = Random.Range(1, 21);
            }
        }

        // The characters are sorted from greatest initative to lowest initative
        npcs.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));

        // The characters are sorted visually
        for (int i = lordshipContentObjectInScrollview.childCount - 1; i >= 0; i--)
        {
            Transform child = lordshipContentObjectInScrollview.GetChild(i);
            Destroy(child.gameObject);
        }

        foreach (NPC npc in npcs)
        {
            AddNPCToScrollview(npc);
        }
    }

    private void AddCharacterToScrollview(Character character)
	{
		GameObject template = Instantiate(characterTemplatePrefab);
		template.transform.SetParent(classContentObjectInScrollview);
		// For whatever reason, this is required for the children to scale properly within the scrollview
		template.transform.localScale = new Vector3(0.9244992f, 0.9244992f, 0.9244992f);
		if (character.Initiative != 0)
			template.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = character.Initiative.ToString();

		CharacterTemplate characterTemplate = template.GetComponent<CharacterTemplate>();
		characterTemplate.characterList = this;
		characterTemplate.characterData = character;
	}

    private void AddNPCToScrollview(NPC npc)
    {
        GameObject template = Instantiate(characterTemplatePrefab);
        template.transform.SetParent(lordshipContentObjectInScrollview);
        // For whatever reason, this is required for the children to scale properly within the scrollview
        template.transform.localScale = new Vector3(0.9244992f, 0.9244992f, 0.9244992f);
        if (npc.Initiative != 0)
            template.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = npc.Initiative.ToString();

        CharacterTemplate characterTemplate = template.GetComponent<CharacterTemplate>();
        characterTemplate.characterList = this;
        characterTemplate.npcData = npc;
    }
}