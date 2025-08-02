using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

using static Variables;

public class CharacterList : MonoBehaviour
{
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
        public int DR;
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

	private List<NPC> npcs = new();
	public GameObject characterTemplatePrefab;
    public Transform lordshipContentObjectInScrollview;
    public TextMeshProUGUI lordshipListOfStats;
    public TextMeshProUGUI abilityDetailsText;
	public TMP_InputField notes;
    public NPC selectedCharacter;
    public Transform combatTab;

    public void GenerateNPC(NPC npc, Rating npcRating)
    {
        npc.AC = 10 + (int)npc.Agility * 2 + ACReducedFromHeavyArmor(npc.Abilities);
        npc.DR = (npc.Fortitude == 0 ? 0 : ((int)Mathf.Pow(2, (int)npc.Fortitude))) + DRFromAbilities(npc.Abilities, npcRating); 
        npcs.Add(npc);
        AddNPCToScrollview(npc);
    }

    private int ACReducedFromHeavyArmor(string abilities)
    {
        string pattern = @"Heavy Armor";

        Regex regex = new(pattern);

        Match match = regex.Match(abilities);

        if (!match.Success)
            return 0;
        else
            return -4;
    }

    private int DRFromAbilities(string abilities, Rating currentRating)
    {
        int workingBonus = 0;
        string pattern = @"(Light Armor|Medium Armor|Heavy Armor): \d+";

        Regex regex = new(pattern);

        Match match = regex.Match(abilities);

        if (!match.Success)
            return workingBonus;

        string armorType = match.Value.Split(':')[0].Trim(); // e.g. "Light Armor"
        string armorSkillLevel = match.Value.Split(':')[1].Trim(); // e.g. "1"
        if (int.Parse(armorSkillLevel) >= 3)
            workingBonus += 2;

        // example match.Value == "Heavy Armor: 3"
        if (currentRating == Rating.F)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 3;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 4;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 5;
            }
        }
        if (currentRating == Rating.E)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 4;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 5;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 10;
            }
        }
        if (currentRating == Rating.D)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 6;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 15;
            }
        }
        if (currentRating == Rating.C)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 15;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 20;
            }
        }
        if (currentRating == Rating.B)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 15;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 20;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 30;
            }
        }
        if (currentRating == Rating.A)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 20;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 30;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 40;
            }
        }
        if (currentRating == Rating.S)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 30;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 45;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 60;
            }
        }
        if (currentRating == Rating.SS)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 45;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 70;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 90;
            }
        }
        if (currentRating == Rating.SSS)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 70;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 105;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 135;
            }
        }
        if (currentRating == Rating.X)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 105;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 160;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 200;
            }
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