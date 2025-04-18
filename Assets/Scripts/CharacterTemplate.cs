using TMPro;
using UnityEngine;

public class CharacterTemplate : MonoBehaviour
{
	[HideInInspector]
	public CharacterList characterList;
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
		placeholderNameText.text = npcData.Name;
		if (npcData.Initiative > 0)
			nameText.text = npcData.Name;

		placeholderHealthText.text = npcData.MaxHealth.ToString();
		healthText.text = npcData.CurrentHealth.ToString();

		placeholderManaText.text = npcData.MaxMana.ToString();
		manaText.text = npcData.CurrentMana.ToString();
	}

	// Called by the delete button on the UI of the character template
	public void Delete()
	{
		characterList.DeleteNPC(this);
	}

	// Called by the name input field of the character template
	public void UpdateName(string name)
	{
		npcData.Name = name;
	}

	// Called by the health input field of the character template
	public void UpdateHealth(string health)
	{
		npcData.CurrentHealth = int.Parse(health);
	}

	// Called by the mana input field of the character template
	public void UpdateMana(string mana)
	{
		npcData.CurrentMana = int.Parse(mana);
	}
}