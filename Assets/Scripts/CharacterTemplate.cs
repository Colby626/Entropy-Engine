using TMPro;
using UnityEngine;

public class CharacterTemplate : MonoBehaviour
{
	[HideInInspector]
	public CharacterList characterList;
	[HideInInspector]
	public CharacterList.Character characterData;
    public TextMeshProUGUI nameText;
	public TextMeshProUGUI healthText;
	public TextMeshProUGUI manaText;

	public void Start()
	{
		nameText.text = characterData.Name;
		healthText.text = characterData.MaxHealth.ToString();
		manaText.text = characterData.MaxMana.ToString();
	}

	// Called by the delete button on the UI of the character template
	public void Delete()
	{
		characterList.DeleteCharacter(this);
	}

	// Called by the name input field of the character template
	public void UpdateName(string name)
	{
		characterData.Name = name;
	}
}