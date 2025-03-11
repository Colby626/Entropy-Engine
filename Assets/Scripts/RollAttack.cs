using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RollAttack : MonoBehaviour
{
    public ToggleGroup weaponTypeGroup;
    public ToggleGroup weaponSizeGroup;
    public ToggleGroup weaponMaterialGroup;
    public ToggleGroup otherMaterialGroup;
    public ToggleGroup enchantmentLevelGroup;
    public TextMeshProUGUI combatLog;

    // Called by button 
    public void AttackRoll()
    {
		StringBuilder stringBuilder = new StringBuilder();
        var weaponType = weaponTypeGroup.GetFirstActiveToggle();
		stringBuilder.Append("Attack type: " + weaponType.name + "\n");
		var weaponSize = weaponSizeGroup.GetFirstActiveToggle();
		stringBuilder.Append("Weapon size: " + weaponSize.name + "\n");
		var weaponMaterial = weaponMaterialGroup.GetFirstActiveToggle();
		stringBuilder.Append("Weapon material: " + weaponMaterial.name + "\n");
		var otherMaterial = otherMaterialGroup.GetFirstActiveToggle();
		stringBuilder.Append("Other material: " + otherMaterial.name + "\n");
		var enchantmentLevel = enchantmentLevelGroup.GetFirstActiveToggle();
		stringBuilder.Append("Enchantment level: " + enchantmentLevel.name + "\n\n");
		combatLog.text = stringBuilder.ToString() + "\n" + combatLog.text;
	}

	// Called by button
	public void Clear()
	{
		combatLog.text = "";
	}
}