using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static GenerateStats;

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

		public Rating Strength;
		public Rating Dexterity;
		public Rating Agility;
		public Rating Intelligence;
		public Rating Spirit;
		public Rating Charisma;
		public Rating Vitality;
		public Rating Fortitude;

        public int MaxHealth;
        public int CurrentHealth;
        public int MaxMana;
        public int CurrentMana;
        public int AC;
        public int MC;
        public int PlusToHit;
        public string PhysicalDamageMultiplier;
        public string MagicDamageMultiplier;
        public int DodgeBonus;
        public int MovementSpeed;

        public int Initiative;
		public string Abilities;
		public string Notes;

        public WeaponType WeaponType = WeaponType.Melee;
		public WeaponSize WeaponSize = WeaponSize.Balanced;
		public WeaponMaterial WeaponMaterial = WeaponMaterial.Iron;
		public WeaponMaterial ArrowMaterial = WeaponMaterial.Primitive;
        public WeaponEnchantment WeaponEnchantment = WeaponEnchantment.Unenchanted;
	}

    public enum WeaponType
    {
        Melee,
        Ranged,
        Magic
    }

    public enum WeaponSize
    {
        Light,
        Balanced,
        Heavy,
        Massive,
        Colossal
    }

	public enum WeaponMaterial
    {
        Primitive,
        Iron,
        Steel,
        Dlaren,
        Draconic,
        Divine_Demonic
    }

	public enum WeaponEnchantment
    {
        Unenchanted,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
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
    public NPC selectedCharacter;
    public Transform combatTab;

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

    public void GenerateNPC(NPC npc, GenerateStats.Rating npcRating)
    {
        npc.AC = ACFromAbilities(npc.Abilities, npcRating);
        npc.MC = MCFromAbilities(npc.Abilities, npcRating);
        npcs.Add(npc);
        AddNPCToScrollview(npc);
    }

    private int ACFromAbilities(string abilities, GenerateStats.Rating currentRating)
    {
        int workingBonus = 0;
        string pattern = @"(Light Armor|Medium Armor|Heavy Armor): \d+";

        Regex regex = new(pattern);

        Match match = regex.Match(abilities);

        if (!match.Success)
            return workingBonus;

        string armorType = match.Value.Split(':')[0].Trim(); // e.g. "Light Armor"
        string skillLevel = match.Value.Split(':')[1].Trim(); // e.g. "1"
        if (int.Parse(skillLevel) >= 3)
            workingBonus += 2;

        // example match.Value == "Heavy Armor: 3"
        if (currentRating == Rating.F || // Tier 1 armor
            currentRating == Rating.E)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 4;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 6;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 8;
            }
        }
        if (currentRating == Rating.D || // Tier 2 armor
            currentRating == Rating.C)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 6;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 8;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 10;
            }
        }
        if (currentRating == Rating.B || // Tier 3 armor
            currentRating == Rating.A)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 8;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 12;
            }
        }
        if (currentRating == Rating.S || // Tier 4 armor
            currentRating == Rating.SS)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 12;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 14;
            }
        }
        if (currentRating == Rating.SSS || // Tier 5 armor
            currentRating == Rating.X)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 12;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 14;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 16;
            }
        }
        pattern = @"Shields: \d+";

        regex = new Regex(pattern);

        match = regex.Match(abilities);

        if (!match.Success)
            return workingBonus;

        string shieldSkillLevel = match.Value.Split(':')[1].Trim(); // e.g. "1"
        if (int.Parse(shieldSkillLevel) >= 3)
            workingBonus += 2;

        if (currentRating == Rating.F || // Tier 1 armor
            currentRating == Rating.E)
        {
            workingBonus += 1;
        }
        if (currentRating == Rating.D || // Tier 2 armor
            currentRating == Rating.C)
        {
            workingBonus += 2;
        }
        if (currentRating == Rating.B || // Tier 3 armor
            currentRating == Rating.A)
        {
            workingBonus += 3;
        }
        if (currentRating == Rating.S || // Tier 4 armor
            currentRating == Rating.SS)
        {
            workingBonus += 4;
        }
        if (currentRating == Rating.SSS || // Tier 5 armor
            currentRating == Rating.X)
        {
            workingBonus += 5;
        }

        return workingBonus;
    }

    private int MCFromAbilities(string abilities, GenerateStats.Rating currentRating)
    {
        int workingBonus = 0;
        string pattern = @"(Light Armor|Medium Armor|Heavy Armor): \d+";

        Regex regex = new (pattern);

        Match match = regex.Match(abilities);

        if (!match.Success)
            return workingBonus;

        string armorType = match.Value.Split(':')[0].Trim(); // e.g. "Light Armor"
        string armorSkillLevel = match.Value.Split(':')[1].Trim(); // e.g. "1"
        if (int.Parse(armorSkillLevel) >= 3)
            workingBonus += 2;

        // example match.Value == "Heavy Armor: 3"
        if (currentRating == Rating.F || // Tier 1 armor
            currentRating == Rating.E)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 8;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 6;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 4;
            }
        }
        if (currentRating == Rating.D || // Tier 2 armor
            currentRating == Rating.C)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 8;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 6;
            }
        }
        if (currentRating == Rating.B || // Tier 3 armor
            currentRating == Rating.A)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 12;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 8;
            }
        }
        if (currentRating == Rating.S || // Tier 4 armor
            currentRating == Rating.SS)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 14;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 12;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 10;
            }
        }
        if (currentRating == Rating.SSS || // Tier 5 armor
            currentRating == Rating.X)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 16;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 14;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 12;
            }
        }

        pattern = @"Shields: \d+";

        regex = new Regex(pattern);

        match = regex.Match(abilities);

        if (!match.Success)
            return workingBonus;

        string shieldSkillLevel = match.Value.Split(':')[1].Trim(); // e.g. "1"
        if (int.Parse(shieldSkillLevel) >= 3)
            workingBonus += 2;

        if (currentRating == Rating.F || // Tier 1 armor
            currentRating == Rating.E)
        {
            workingBonus += 1;
        }
        if (currentRating == Rating.D || // Tier 2 armor
            currentRating == Rating.C)
        {
            workingBonus += 2;
        }
        if (currentRating == Rating.B || // Tier 3 armor
            currentRating == Rating.A)
        {
            workingBonus += 3;
        }
        if (currentRating == Rating.S || // Tier 4 armor
            currentRating == Rating.SS)
        {
            workingBonus += 4;
        }
        if (currentRating == Rating.SSS || // Tier 5 armor
            currentRating == Rating.X)
        {
            workingBonus += 5;
        }

        return workingBonus;
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