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

		public int Strength;
		public int Dexterity;
		public int Agility;
		public int Spirit;
		public int Endurance;

        public int MaxHealth;
        public int CurrentHealth;
        public int MaxMana;
        public int CurrentMana;
        public int AC;
        public int DR;
        public int PlusToHit;
        public int CriticalBonus;
        public int MovementSpeed;
        public int InitiativeBonus;

        public int StrengthDamageBonus;
        public int DexterityDamageBonus;
        public int SpiritDamageBonus;

        public int Initiative;
        public string Element;
		public string Abilities;
		public string Notes;

        public WeaponType WeaponType = WeaponType.Melee;
		public WeaponSize WeaponSize = WeaponSize.Balanced;
		public Material WeaponMaterial = Material.Iron;
		public Material ArrowMaterial = Material.Iron;
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

	public enum Material
    {
        Iron,
        Steel,
        Dlaren,
        Valkyrian,
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

    public void GenerateNPC(NPC npc, Rarity npcRarity)
    {
        npc.AC = ((int)npc.Agility / 10 >= 15 ? 15 : (int)npc.Agility / 10) + 8;
        npc.DR = (int)npc.Endurance / 5 + DRFromAbilities(npc.Abilities, npcRarity); 
        npcs.Add(npc);
        AddNPCToScrollview(npc);
    }

    /*private int ACReducedFromHeavyArmor(string abilities)
    {
        string pattern = @"Heavy Armor";

        Regex regex = new(pattern);

        Match match = regex.Match(abilities);

        if (!match.Success)
            return 0;
        else
            return -4;
    }*/

    private int DRFromAbilities(string abilities, Rarity currentRarity)
    {
        int workingBonus = 0;
        int rarityValue = ((int)currentRarity) / 3;
        string pattern = @"(Light Armor|Medium Armor|Heavy Armor): \d+";

        Regex regex = new(pattern);

        Match match = regex.Match(abilities);

        if (!match.Success)
            return workingBonus;

        string armorType = match.Value.Split(':')[0].Trim(); // e.g. "Light Armor"

        // example match.Value == "Heavy Armor: 3"
        if (rarityValue == (int)Material.Iron)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 0;
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
        if (rarityValue == (int)Material.Steel)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 5;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 25;
            }
        }
        if (rarityValue == (int)Material.Dlaren)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 10;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 25;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 50;
            }
        }
        if (rarityValue == (int)Material.Valkyrian)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 25;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 50;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 100;
            }
        }
        if (rarityValue == (int)Material.Draconic)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 50;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 100;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 150;
            }
        }
        if (rarityValue == (int)Material.Divine_Demonic)
        {
            if (armorType == "Light Armor")
            {
                workingBonus += 150;
            }
            if (armorType == "Medium Armor")
            {
                workingBonus += 200;
            }
            if (armorType == "Heavy Armor")
            {
                workingBonus += 250;
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
                npc.Initiative += npc.InitiativeBonus;
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