using TMPro;
using UnityEngine;

public class CharacterTemplate : MonoBehaviour
{
	[HideInInspector]
	public CharacterList characterList;
	[HideInInspector]
	public CharacterList.Character characterData;
	[HideInInspector]
	public CharacterList.NPC npcData;
    public TextMeshProUGUI placeholderNameText;
	public TextMeshProUGUI placeholderHealthText;
	public TextMeshProUGUI placeholderManaText;
	public TMP_InputField nameText;
	public TMP_InputField healthText;
	public TMP_InputField manaText;

	public void Start()
	{
		if (characterData != null)
		{
			placeholderNameText.text = characterData.Name;
			if (characterData.Initiative > 0)
				nameText.text = characterData.Name;

			placeholderHealthText.text = characterData.MaxHealth.ToString();
			healthText.text = characterData.CurrentHealth.ToString();

			placeholderManaText.text = characterData.MaxMana.ToString();
			manaText.text = characterData.CurrentMana.ToString();
		}
		else
		{
			placeholderNameText.text = npcData.Name;
			if (npcData.Initiative > 0)
				nameText.text = npcData.Name;

			placeholderHealthText.text = npcData.MaxHealth.ToString();
			healthText.text = npcData.CurrentHealth.ToString();

			placeholderManaText.text = npcData.MaxMana.ToString();
			manaText.text = npcData.CurrentMana.ToString();
		}
	}

	// Called by the delete button on the UI of the character template
	public void Delete()
	{
		if (characterData != null)
			characterList.DeleteCharacter(this);
		else
			characterList.DeleteNPC(this);
	}

	// Called by the name input field of the character template
	public void UpdateName(string name)
	{
		if (characterData != null)
			characterData.Name = name;
		else
			npcData.Name = name;
	}

	// Called by the health input field of the character template
	public void UpdateHealth(string health)
	{
		if (characterData != null)
			characterData.CurrentHealth = int.Parse(health);
		else
			npcData.CurrentHealth = int.Parse(health);
	}

	// Called by the mana input field of the character template
	public void UpdateMana(string mana)
	{
		if (characterData != null)
			characterData.CurrentMana = int.Parse(mana);
		else
			npcData.CurrentMana = int.Parse(mana);
	}
}