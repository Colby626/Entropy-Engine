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
    public TextMeshProUGUI nameText;
	public TextMeshProUGUI healthText;
	public TextMeshProUGUI manaText;

	public void Start()
	{
		if (characterData != null)
		{
			nameText.text = characterData.Name;
			healthText.text = characterData.MaxHealth.ToString();
			manaText.text = characterData.MaxMana.ToString();
		}
		else
		{
            nameText.text = npcData.Name;
            healthText.text = npcData.MaxHealth.ToString();
            manaText.text = npcData.MaxMana.ToString();
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
}