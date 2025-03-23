using UnityEngine;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
	public Variables settings;

	[Header("Leveling Up UI Elements")]
	public TMP_InputField startingStatPointsField;
	public TMP_InputField statPointsPerLevelField;
	public TMP_InputField percentChanceBonusPointField;
	public TMP_InputField startingSkillsField;
	public TMP_InputField upgradePointsPerLevelField;
	public TMP_InputField maxSkillsField;
	public TMP_InputField maxFeatsField;

	[Header("Modifier UI Elements")]
	public TMP_InputField fField;
	public TMP_InputField eField;
	public TMP_InputField dField;
	public TMP_InputField cField;
	public TMP_InputField bField;
	public TMP_InputField aField;
	public TMP_InputField sField;
	public TMP_InputField ssField;

	[Header("Miscellaneous UI Elements")]
	public TMP_InputField percentCoinpurseField;
	public TMP_InputField percentStashField;
	public TMP_InputField percentLockboxField;
	public TMP_InputField percentSafeField;
	public TMP_InputField percentTreasuryField;
	public TMP_InputField percentHordeField;
	public TMP_InputField treasureVarianceField;
	public TMP_InputField exitTreasureChanceField;

	private void Awake()
	{
		LoadSettings();
		AddListeners();
	}

	private void LoadSettingsIntoUI()
	{
		startingStatPointsField.text = settings.startingStatPoints.ToString();
		statPointsPerLevelField.text = settings.statPointsPerLevelUp.ToString();
		percentChanceBonusPointField.text = settings.percentChanceOfBonusPointOnRatingUp.ToString();
		startingSkillsField.text = settings.numberOfStartingSkills.ToString();
		upgradePointsPerLevelField.text = settings.upgradePointsPerLevel.ToString();
		maxSkillsField.text = settings.maximumSkills.ToString();
		maxFeatsField.text = settings.maximumFeats.ToString();

		fField.text = settings.F.ToString();
		eField.text = settings.E.ToString();
		dField.text = settings.D.ToString();
		cField.text = settings.C.ToString();
		bField.text = settings.B.ToString();
		aField.text = settings.A.ToString();
		sField.text = settings.S.ToString();
		ssField.text = settings.SS.ToString();

		percentCoinpurseField.text = settings.percentOfCoinpurseAsTreasure.ToString();
		percentStashField.text = settings.percentOfStashAsTreasure.ToString();
		percentLockboxField.text = settings.percentOfLockboxAsTreasure.ToString();
		percentSafeField.text = settings.percentOfSafeAsTreasure.ToString();
		percentTreasuryField.text = settings.percentOfTreasuryAsTreasure.ToString();
		percentHordeField.text = settings.percentOfHordeAsTreasure.ToString();
		treasureVarianceField.text = settings.treasureVariance.ToString();
		exitTreasureChanceField.text = settings.exitTreasureGenerationEarlyChance.ToString();
	}

	public void OnStatChanged(string value, ref int setting)
	{
		if (int.TryParse(value, out int result))
			setting = result;
	}

	public void OnFloatStatChanged(string value, ref float setting)
	{
		if (float.TryParse(value, out float result))
			setting = result;
	}

	public void SaveSettings()
	{
		PlayerPrefs.SetInt("StartingStatPoints", settings.startingStatPoints);
		PlayerPrefs.SetInt("StatPointsPerLevel", settings.statPointsPerLevelUp);
		PlayerPrefs.SetFloat("BonusPointChance", settings.percentChanceOfBonusPointOnRatingUp);
		PlayerPrefs.SetInt("StartingSkills", settings.numberOfStartingSkills);
		PlayerPrefs.SetInt("UpgradePointsPerLevel", settings.upgradePointsPerLevel);
		PlayerPrefs.SetInt("MaxSkills", settings.maximumSkills);
		PlayerPrefs.SetInt("MaxFeats", settings.maximumFeats);

		PlayerPrefs.SetInt("Modifier_F", settings.F);
		PlayerPrefs.SetInt("Modifier_E", settings.E);
		PlayerPrefs.SetInt("Modifier_D", settings.D);
		PlayerPrefs.SetInt("Modifier_C", settings.C);
		PlayerPrefs.SetInt("Modifier_B", settings.B);
		PlayerPrefs.SetInt("Modifier_A", settings.A);
		PlayerPrefs.SetInt("Modifier_S", settings.S);
		PlayerPrefs.SetInt("Modifier_SS", settings.SS);

		PlayerPrefs.SetFloat("PercentCoinpurse", settings.percentOfCoinpurseAsTreasure);
		PlayerPrefs.SetFloat("PercentStash", settings.percentOfStashAsTreasure);
		PlayerPrefs.SetFloat("PercentLockbox", settings.percentOfLockboxAsTreasure);
		PlayerPrefs.SetFloat("PercentSafe", settings.percentOfSafeAsTreasure);
		PlayerPrefs.SetFloat("PercentTreasury", settings.percentOfTreasuryAsTreasure);
		PlayerPrefs.SetFloat("PercentHorde", settings.percentOfHordeAsTreasure);
		PlayerPrefs.SetInt("TreasureVariance", settings.treasureVariance);
		PlayerPrefs.SetFloat("ExitTreasureChance", settings.exitTreasureGenerationEarlyChance);

		PlayerPrefs.Save();
	}

	public void LoadSettings()
	{
		settings.startingStatPoints = PlayerPrefs.GetInt("StartingStatPoints", settings.startingStatPoints);
		settings.statPointsPerLevelUp = PlayerPrefs.GetInt("StatPointsPerLevel", settings.statPointsPerLevelUp);
		settings.percentChanceOfBonusPointOnRatingUp = PlayerPrefs.GetFloat("BonusPointChance", settings.percentChanceOfBonusPointOnRatingUp);
		settings.numberOfStartingSkills = PlayerPrefs.GetInt("StartingSkills", settings.numberOfStartingSkills);
		settings.upgradePointsPerLevel = PlayerPrefs.GetInt("UpgradePointsPerLevel", settings.upgradePointsPerLevel);
		settings.maximumSkills = PlayerPrefs.GetInt("MaxSkills", settings.maximumSkills);
		settings.maximumFeats = PlayerPrefs.GetInt("MaxFeats", settings.maximumFeats);

		settings.F = PlayerPrefs.GetInt("Modifier_F", settings.F);
		settings.E = PlayerPrefs.GetInt("Modifier_E", settings.E);
		settings.D = PlayerPrefs.GetInt("Modifier_D", settings.D);
		settings.C = PlayerPrefs.GetInt("Modifier_C", settings.C);
		settings.B = PlayerPrefs.GetInt("Modifier_B", settings.B);
		settings.A = PlayerPrefs.GetInt("Modifier_A", settings.A);
		settings.S = PlayerPrefs.GetInt("Modifier_S", settings.S);
		settings.SS = PlayerPrefs.GetInt("Modifier_SS", settings.SS);

		settings.percentOfCoinpurseAsTreasure = PlayerPrefs.GetFloat("PercentCoinpurse", settings.percentOfCoinpurseAsTreasure);
		settings.percentOfStashAsTreasure = PlayerPrefs.GetFloat("PercentStash", settings.percentOfStashAsTreasure);
		settings.percentOfLockboxAsTreasure = PlayerPrefs.GetFloat("PercentLockbox", settings.percentOfLockboxAsTreasure);
		settings.percentOfSafeAsTreasure = PlayerPrefs.GetFloat("PercentSafe", settings.percentOfSafeAsTreasure);
		settings.percentOfTreasuryAsTreasure = PlayerPrefs.GetFloat("PercentTreasury", settings.percentOfTreasuryAsTreasure);
		settings.percentOfHordeAsTreasure = PlayerPrefs.GetFloat("PercentHorde", settings.percentOfHordeAsTreasure);
		settings.treasureVariance = PlayerPrefs.GetInt("TreasureVariance", settings.treasureVariance);
		settings.exitTreasureGenerationEarlyChance = PlayerPrefs.GetFloat("ExitTreasureChance", settings.exitTreasureGenerationEarlyChance);

		LoadSettingsIntoUI();
	}

	private void AddListeners()
	{
		startingStatPointsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.startingStatPoints));
		statPointsPerLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.statPointsPerLevelUp));
		percentChanceBonusPointField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentChanceOfBonusPointOnRatingUp));
		startingSkillsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.numberOfStartingSkills));
		upgradePointsPerLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.upgradePointsPerLevel));
		maxSkillsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.maximumSkills));
		maxFeatsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.maximumFeats));

		fField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.F));
		eField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.E));
		dField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.D));
		cField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.C));
		bField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.B));
		aField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.A));
		sField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.S));
		ssField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.SS));

		percentCoinpurseField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentOfCoinpurseAsTreasure));
		percentStashField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentOfStashAsTreasure));
		percentLockboxField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentOfLockboxAsTreasure));
		percentSafeField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentOfSafeAsTreasure));
		percentTreasuryField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentOfTreasuryAsTreasure));
		percentHordeField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.percentOfHordeAsTreasure));
		treasureVarianceField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.treasureVariance));
		exitTreasureChanceField.onEndEdit.AddListener(value => OnFloatStatChanged(value, ref settings.exitTreasureGenerationEarlyChance));
	}
}