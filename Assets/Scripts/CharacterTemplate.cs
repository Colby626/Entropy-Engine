using TMPro;
using UnityEngine;

public class CharacterTemplate : MonoBehaviour
{
	public CharacterList characterList;
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

	public void Delete()
	{
		characterList.DeleteCharacter(this);
	}
}