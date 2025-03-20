using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RollAttack : MonoBehaviour
{
    public ToggleGroup weaponTypeGroup;
    public ToggleGroup weaponSizeGroup;
    public ToggleGroup weaponMaterialGroup;
    public ToggleGroup arrowMaterialGroup;
    public ToggleGroup enchantmentLevelGroup;
    public TextMeshProUGUI combatLog;
    private CharacterList characterList;

    public void Start()
    {
        characterList = FindAnyObjectByType<CharacterList>();
	}

	// Called by button 
	public void AttackRoll()
    {
		StringBuilder stringBuilder = new StringBuilder();
        var weaponType = weaponTypeGroup.GetFirstActiveToggle();
		var weaponSize = weaponSizeGroup.GetFirstActiveToggle();
		var weaponMaterial = weaponMaterialGroup.GetFirstActiveToggle();
		var arrowMaterial = arrowMaterialGroup.GetFirstActiveToggle();
		var enchantmentLevel = enchantmentLevelGroup.GetFirstActiveToggle();
        var selectedCharacter = characterList.selectedCharacter;

        int physicalDamageRoll = 0;
        int magicalDamageRoll = 0;
        int multiplier = 1;

        switch (weaponSize.name)
        {
            case "Light": //1d6
                physicalDamageRoll = RollExplodingDice(1, 6);
                break;

            case "Balanced": //1d8
                physicalDamageRoll = RollExplodingDice(1, 8);
                break;

            case "Heavy": //2d6
                physicalDamageRoll = RollExplodingDice(2, 6);
                break;

            case "Massive": //2d8
                physicalDamageRoll = RollExplodingDice(2, 8);
                break;

            case "Colossal": //4d12
                physicalDamageRoll = RollExplodingDice(4, 12);
                break;

            default:
                break;
        }

        switch (weaponMaterial.name)
        {
            case "Primitive":
                if (weaponType.name == "Magic")
                    physicalDamageRoll += 3;
                break;

            case "Iron":
                if (weaponType.name == "Magic")
                    physicalDamageRoll += 3;
                physicalDamageRoll += 3;
                break;

            case "Steel":
                if (weaponType.name == "Magic")
                    physicalDamageRoll += 3;
                physicalDamageRoll += 6;
                break;

            case "Dlaren":
                if (weaponType.name == "Magic")
                    physicalDamageRoll += 3;
                physicalDamageRoll += 9;
                break;

            case "Draconic":
                if (weaponType.name == "Magic")
                    physicalDamageRoll += 3;
                physicalDamageRoll += 12;
                break;

            case "Divine/Demonic":
                if (weaponType.name == "Magic")
                    physicalDamageRoll += 3;
                physicalDamageRoll += 15;
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
                    magicalDamageRoll = Random.Range(1, 9);
                    break;

                case "Uncommon": //2d8
                    magicalDamageRoll = Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    break;

                case "Rare": //3d8
                    magicalDamageRoll = Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    break;

                case "Epic": //4d8
                    magicalDamageRoll = Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    break;

                case "Legendary": //5d8
                    magicalDamageRoll = Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    magicalDamageRoll += Random.Range(1, 9);
                    break;

                default:
                    break;
            }

            switch (selectedCharacter.Intelligence)
            {
                case GenerateStats.Rating.F:
                    break;

                case GenerateStats.Rating.E: // 1d2
                    magicalDamageRoll *= RollDice(1, 2);
                    break;

                case GenerateStats.Rating.D: // 1d4
                    magicalDamageRoll *= RollDice(1, 4);
                    break;

                case GenerateStats.Rating.C: // 1d6
                    magicalDamageRoll *= RollDice(1, 6);
                    break;

                case GenerateStats.Rating.B: // 1d8
                    magicalDamageRoll *= RollDice(1, 8);
                    break;

                case GenerateStats.Rating.A: // 2d4
                    multiplier = RollDice(2, 4);
                    magicalDamageRoll *= multiplier;
                    break;

                case GenerateStats.Rating.S: // 2d6
                    multiplier = RollDice(2, 6);
                    magicalDamageRoll *= multiplier;
                    break;

                case GenerateStats.Rating.SS: // 3d4
                    multiplier = RollDice(3, 4);
                    magicalDamageRoll *= multiplier;
                    break;

                default:
                    break;
            }

            if (weaponType.name == "Melee")
            {
                switch (selectedCharacter.Strength)
                {
                    case GenerateStats.Rating.F:
                        break;

                    case GenerateStats.Rating.E: // 1d2
                        physicalDamageRoll *= RollDice(1, 2);
                        break;

                    case GenerateStats.Rating.D: // 1d4
                        physicalDamageRoll *= RollDice(1, 4);
                        break;

                    case GenerateStats.Rating.C: // 1d6
                        physicalDamageRoll *= RollDice(1, 6);
                        break;

                    case GenerateStats.Rating.B: // 1d8
                        physicalDamageRoll *= RollDice(1, 8);
                        break;

                    case GenerateStats.Rating.A: // 2d4
                        multiplier = RollDice(2, 4);
                        physicalDamageRoll *= multiplier;
                        break;

                    case GenerateStats.Rating.S: // 2d6
                        multiplier = RollDice(2, 6);
                        physicalDamageRoll *= multiplier;
                        break;

                    case GenerateStats.Rating.SS: // 3d4
                        multiplier = RollDice(3, 4);
                        physicalDamageRoll *= multiplier;
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
                        break;

                    case "Iron": // 1d4
                        physicalDamageRoll *= RollDice(1, 4);
                        break;

                    case "Steel": // 1d6
                        physicalDamageRoll *= RollDice(1, 6);
                        break;

                    case "Dlaren": // 1d8
                        physicalDamageRoll *= RollDice(1, 8);
                        break;

                    case "Draconic": // 2d4
                        multiplier = RollDice(2, 4);
                        physicalDamageRoll *= multiplier;
                        break;

                    case "Divine/Demonic": // 2d6
                        multiplier = RollDice(2, 6);
                        physicalDamageRoll *= multiplier;
                        break;

                    default:
                        break;
                }
            }
        }
        else if (weaponType.name == "Magic")
        {
            switch (selectedCharacter.Intelligence)
            {
                case GenerateStats.Rating.F:
                    break;

                case GenerateStats.Rating.E: // 1d2
                    physicalDamageRoll *= RollDice(1, 2);
                    break;

                case GenerateStats.Rating.D: // 1d4
                    physicalDamageRoll *= RollDice(1, 4);
                    break;

                case GenerateStats.Rating.C: // 1d6
                    physicalDamageRoll *= RollDice(1, 6);
                    break;

                case GenerateStats.Rating.B: // 1d8
                    physicalDamageRoll *= RollDice(1, 8);
                    break;

                case GenerateStats.Rating.A: // 2d4
                    multiplier = RollDice(2, 4);
                    physicalDamageRoll *= multiplier;
                    break;

                case GenerateStats.Rating.S: // 2d6
                    multiplier = RollDice(2, 6);
                    physicalDamageRoll *= multiplier;
                    break;

                case GenerateStats.Rating.SS: // 3d4
                    multiplier = RollDice(3, 4);
                    physicalDamageRoll *= multiplier;
                    break;

                default:
                    break;
            }

            magicalDamageRoll = physicalDamageRoll;
            physicalDamageRoll = 0;
        }

        stringBuilder.Append("Physical Damage: " + physicalDamageRoll + "\n");
        stringBuilder.Append("Magical Damage: " + magicalDamageRoll + "\n");
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