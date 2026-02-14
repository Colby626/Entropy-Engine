using UnityEngine;
using UnityEngine.UI;

public class ToggleChange : MonoBehaviour
{
    public Toggle meleeToggle;
    public Toggle rangedToggle;
    public Toggle magicToggle;

	public ToggleGroup sizeGroup;
    public ToggleGroup otherMaterialGroup;
    public ToggleGroup enchantmentLevelGroup;

    public void OnToggleValueChanged()
    {
        if (meleeToggle.isOn)
        {
			if (otherMaterialGroup != null)
			{
                foreach (Transform child in otherMaterialGroup.transform)
                {
                    child.GetComponent<Toggle>().interactable = false;
                }
            }
			if (sizeGroup != null)
			{
                foreach (Transform child in sizeGroup.transform)
                {
                    child.GetComponent<Toggle>().interactable = true;
                }
            }
			foreach (Transform child in enchantmentLevelGroup.transform)
			{
				child.GetComponent<Toggle>().interactable = true;
			}
		}
		else if (rangedToggle.isOn)
		{
			if (otherMaterialGroup != null)
			{
				foreach (Transform child in otherMaterialGroup.transform)
				{
					child.GetComponent<Toggle>().interactable = false;
				}
			}
            if (sizeGroup != null)
            {
                foreach (Transform child in sizeGroup.transform)
                {
                    if (child.gameObject.name == "One-Handed")
                        child.GetComponent<Toggle>().isOn = true;
                    child.GetComponent<Toggle>().interactable = false;
                }
            }
            foreach (Transform child in enchantmentLevelGroup.transform)
			{
				child.GetComponent<Toggle>().interactable = true;
			}
		}
		else if (magicToggle.isOn)
		{
			if (otherMaterialGroup != null)
			{
				foreach (Transform child in otherMaterialGroup.transform)
				{
					child.GetComponent<Toggle>().interactable = false;
				}
			}
            if (sizeGroup != null)
            {
                foreach (Transform child in sizeGroup.transform)
                {
                    if (child.gameObject.name == "One-Handed")
                        child.GetComponent<Toggle>().isOn = true;
                    child.GetComponent<Toggle>().interactable = false;
                }
            }
            foreach (Transform child in enchantmentLevelGroup.transform)
			{
				if (child.gameObject.name == "Unenchanted")
					child.GetComponent<Toggle>().isOn = true;
				child.GetComponent<Toggle>().interactable = false;
			}
		}
		else
		{
			Debug.LogError("Weapon type is undefined");
		}
	}
}