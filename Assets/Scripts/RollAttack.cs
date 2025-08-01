using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Variables;

public class RollAttack : MonoBehaviour
{
    public ToggleGroup weaponTypeGroup;
    public ToggleGroup weaponSizeGroup;
    public ToggleGroup weaponMaterialGroup;
    public ToggleGroup arrowMaterialGroup;
    public ToggleGroup enchantmentLevelGroup;
    public TextMeshProUGUI combatLog;
    public Toggle sneakAttackToggle;
    public CharacterSheet characterSheet;
    private CharacterList characterList;

    public void Start()
    {
        characterList = FindAnyObjectByType<CharacterList>();
	}

	// Called by button 
	public void AttackRoll()
    {
        var selectedCharacter = characterSheet != null && characterSheet.gameObject.activeSelf ? characterSheet.character : characterList.selectedCharacter;
        if (selectedCharacter == null)
            return;

		StringBuilder stringBuilder = new StringBuilder();
        var weaponType = weaponTypeGroup.GetFirstActiveToggle();
		var weaponSize = weaponSizeGroup.GetFirstActiveToggle();
		var weaponMaterial = weaponMaterialGroup.GetFirstActiveToggle();
		var arrowMaterial = arrowMaterialGroup.GetFirstActiveToggle();
		var enchantmentLevel = enchantmentLevelGroup.GetFirstActiveToggle();

        int diceRoll = 0;
        int materialBonus = 0;
        int damageMultiplier = 1;
        int enchantmentDamageRoll = 0;
        int enchantmentMultiplier = 1;
        int sneakAttackBonus = sneakAttackToggle.isOn ? 1 : 0;
		int physicalDamage = 0;
		int magicalDamage = 0;

		switch (weaponSize.name)
        {
            case "Light": //1d6
				diceRoll = RollExplodingDice(1, 6);
                break;

            case "Balanced": //1d8
				diceRoll = RollExplodingDice(1, 8);
                break;

            case "Heavy": //2d6
				diceRoll = RollExplodingDice(2, 6);
                break;

            case "Massive": //2d8
				diceRoll = RollExplodingDice(2, 8);
                break;

            case "Colossal": //4d12
				diceRoll = RollExplodingDice(4, 12);
                break;

            default:
                break;
        }

		if (weaponType.name == "Magic")
			materialBonus += 3;
		switch (weaponMaterial.name)
        {
            case "F":
				materialBonus += 2;
                break;

            case "E":
				materialBonus += 4;
                break;

            case "D":
				materialBonus += 6;
                break;

            case "C":
				materialBonus += 8;
                break;

            case "B":
				materialBonus += 10;
                break;

            case "A":
                materialBonus += 12;
                break;

            case "S":
                materialBonus += 14;
                break;

            case "SS":
                materialBonus += 16;
                break;

            case "SSS":
                materialBonus += 18;
                break;

            case "X":
                materialBonus += 20;
                break;

            default:
                break;
        }

        if (weaponType.name == "Melee" || weaponType.name == "Ranged")
		{
            switch (enchantmentLevel.name)
            {
                case "Unenchanted":
                    break;

                case "Common": //1d8
					enchantmentDamageRoll = Random.Range(1, 9);
                    break;

                case "Uncommon": //2d8
					enchantmentDamageRoll = Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
                    break;

                case "Rare": //3d8
					enchantmentDamageRoll = Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
                    break;

                case "Epic": //4d8
					enchantmentDamageRoll = Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
                    break;

                case "Legendary": //5d8
					enchantmentDamageRoll = Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
					enchantmentDamageRoll += Random.Range(1, 9);
                    break;

                default:
                    break;
            }

            switch (selectedCharacter.Intelligence)
            {
                case Rating.F:
					enchantmentMultiplier = 1 + sneakAttackBonus;
                    break;

                case Rating.E: // 1d2
					enchantmentMultiplier = RollDice(1, 2) + sneakAttackBonus;
                    break;

                case Rating.D: // 1d4
					enchantmentMultiplier = RollDice(1, 4) + sneakAttackBonus;
					break;

                case Rating.C: // 1d6
					enchantmentMultiplier = RollDice(1, 6) + sneakAttackBonus;
					break;

                case Rating.B: // 1d8
					enchantmentMultiplier = RollDice(1, 8) + sneakAttackBonus;
					break;

                case Rating.A: // 2d4
					enchantmentMultiplier = RollDice(2, 4) + sneakAttackBonus;
                    break;

                case Rating.S: // 2d6
					enchantmentMultiplier = RollDice(2, 6) + sneakAttackBonus;
                    break;

                case Rating.SS: // 3d4
					enchantmentMultiplier = RollDice(3, 4) + sneakAttackBonus;
                    break;

                default:
                    break;
            }

            if (weaponType.name == "Melee")
            {
                switch (selectedCharacter.Strength)
                {
                    case Rating.F:
						damageMultiplier = 1 + sneakAttackBonus;
						break;

                    case Rating.E: // 1d2
						damageMultiplier = RollDice(1, 2) + sneakAttackBonus;
						break;

                    case Rating.D: // 1d4
						damageMultiplier = RollDice(1, 4) + sneakAttackBonus;
						break;

                    case Rating.C: // 1d6
						damageMultiplier = RollDice(1, 6) + sneakAttackBonus;
                        break;

                    case Rating.B: // 1d8
						damageMultiplier = RollDice(1, 8) + sneakAttackBonus;
						break;

                    case Rating.A: // 2d4
						damageMultiplier = RollDice(2, 4) + sneakAttackBonus;
						break;

                    case Rating.S: // 2d6
						damageMultiplier = RollDice(2, 6) + sneakAttackBonus;
						break;

                    case Rating.SS: // 3d4
						damageMultiplier = RollDice(3, 4) + sneakAttackBonus;
						break;

                    default:
                        break;
                }
            }
            else // Ranged
            {
                switch (arrowMaterial.name)
                {
                    case "Primitive":
						damageMultiplier = 1 + sneakAttackBonus;
						break;

                    case "Iron": // 1d4
						damageMultiplier = RollDice(1, 4) + sneakAttackBonus;
						break;

                    case "Steel": // 1d6
						damageMultiplier = RollDice(1, 6) + sneakAttackBonus;
						break;

                    case "Dlaren": // 1d8
						damageMultiplier = RollDice(1, 8) + sneakAttackBonus;
						break;

                    case "Draconic": // 2d4
						damageMultiplier = RollDice(2, 4) + sneakAttackBonus;
						break;

                    case "Divine/Demonic": // 2d6
						damageMultiplier = RollDice(2, 6) + sneakAttackBonus;
						break;

                    default:
                        break;
                }
            }

            physicalDamage = (diceRoll + materialBonus) * damageMultiplier;
            magicalDamage = enchantmentDamageRoll * enchantmentMultiplier;
        }
        else if (weaponType.name == "Magic")
        {
            switch (selectedCharacter.Intelligence)
            {
                case Rating.F:
					damageMultiplier = 1 + sneakAttackBonus;
                    break;

                case Rating.E: // 1d2
					damageMultiplier = RollDice(1, 2) + sneakAttackBonus;
					break;

                case Rating.D: // 1d4
					damageMultiplier = RollDice(1, 4) + sneakAttackBonus;
					break;

                case Rating.C: // 1d6
					damageMultiplier = RollDice(1, 6) + sneakAttackBonus;
					break;

                case Rating.B: // 1d8
					damageMultiplier = RollDice(1, 8) + sneakAttackBonus;
					break;

                case Rating.A: // 2d4
					damageMultiplier = RollDice(2, 4) + sneakAttackBonus;
					break;

                case Rating.S: // 2d6
					damageMultiplier = RollDice(2, 6) + sneakAttackBonus;
					break;

                case Rating.SS: // 3d4
					damageMultiplier = RollDice(3, 4) + sneakAttackBonus;
					break;

                default:
                    break;
            }

            magicalDamage = (diceRoll + materialBonus) * damageMultiplier;
        }

        stringBuilder.Append("Damage: " + (physicalDamage + magicalDamage) + "\n");
        stringBuilder.Append("Physical Damage: " + physicalDamage + "\n");
        stringBuilder.Append("Magical Damage: " + magicalDamage + "\n");
        if (enchantmentLevel.name != "Unenchanted")
        {
            stringBuilder.Append("Enchantment Multiplier: " + enchantmentMultiplier + "\n");
            stringBuilder.Append("Enchantment Roll: " + enchantmentDamageRoll + "\n");
        }
        stringBuilder.Append("Damage Multiplier: " + damageMultiplier + "\n");
        stringBuilder.Append("Material Bonus: " + materialBonus + "\n");
        stringBuilder.Append("Dice roll: " + diceRoll + "\n");
        combatLog.text = stringBuilder.ToString() + "\n" + combatLog.text;
	}

    private int RollDice(int numDice, int maxRoll)
    {
        int total = 0;

        for (int i = 0; i < numDice; i++)
        {
            int roll = Random.Range(1, maxRoll + 1);
            total += roll;
        }

        return total;
    }

    private int RollExplodingDice(int numDice, int maxRoll)
    {
        int total = 0;

        for (int i = 0; i < numDice; i++)
        {
            int roll = Random.Range(1, maxRoll + 1);
            total += roll;

            // If the roll is the maximum value, explode the die once and add the new roll
            if (roll == maxRoll)
            {
                total += Random.Range(1, maxRoll + 1); // Exploding roll
            }
        }

        return total;
    }

    // Called by button
    public void Clear()
	{
		combatLog.text = "";
	}
}