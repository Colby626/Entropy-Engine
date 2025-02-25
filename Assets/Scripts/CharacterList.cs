using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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
		public string Notes;
    }

	private List<Character> characters = new();
	private List<NPC> npcs = new();
	public GameObject characterTemplatePrefab;
	public Transform classContentObjectInScrollview;
	public Transform classListOfStats;
    public Transform lordshipContentObjectInScrollview;
    public TextMeshProUGUI lordshipListOfStats;
    public TextMeshProUGUI abilityDetailsText;
	public TMP_InputField notes;

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

		// Clear text if deleting the selected NPC
		int newlineIndex = lordshipListOfStats.text.IndexOf("\n");
		if (newlineIndex >= 0)
		{
			string npcName = lordshipListOfStats.text.Substring(0, newlineIndex);
			npcName = RemoveHtmlTags(npcName).Trim();
			if (template.npcData.Name == npcName)
			{
				lordshipListOfStats.text = "";
				abilityDetailsText.text = "";
				notes.gameObject.SetActive(false);
			}
		}

        Destroy(template.gameObject);
    }

	public string RemoveHtmlTags(string input)
	{
		// Remove anything between < and >, including the angle brackets
		return Regex.Replace(input, "<.*?>", string.Empty);
	}

	// Called by the roll initiative button in the Class System tab
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

	// Called by the roll initiative button in the Lordship tab
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