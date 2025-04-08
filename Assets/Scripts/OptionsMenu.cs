using UnityEngine;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
	public SaveData settings;

	[Header("Leveling Up UI Elements")]
	public TMP_InputField startingStatPointsField;
	public TMP_InputField statPointsPerLevelField;
	public TMP_InputField percentChanceBonusPointField;
	public TMP_InputField increaseInBonusChancePerLevelField;
	public TMP_InputField startingSkillsField;
	public TMP_InputField upgradePointsPerLevelField;
	public TMP_InputField maxSkillsField;
	public TMP_InputField maxFeatsField;
	public TMP_InputField maxSkillLevelField;
	public TMP_InputField maxFeatLevelField;

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

	public void Awake()
	{
		LoadSettings();
		AddListeners();
	}

	private void LoadSettingsIntoUI()
	{
		startingStatPointsField.text = settings.startingStatPoints.ToString();
		statPointsPerLevelField.text = settings.statPointsPerLevelUp.ToString();
		percentChanceBonusPointField.text = settings.percentChanceOfBonusPointOnRatingUp.ToString();
		increaseInBonusChancePerLevelField.text = settings.increaseInBonusChancePerLevel.ToString();
		startingSkillsField.text = settings.numberOfStartingSkills.ToString();
		upgradePointsPerLevelField.text = settings.upgradePointsPerLevel.ToString();
		maxSkillsField.text = settings.maximumSkills.ToString();
		maxFeatsField.text = settings.maximumFeats.ToString();
		maxSkillLevelField.text = settings.maximumSkillLevel.ToString();
		maxFeatLevelField.text = settings.maximumFeatLevel.ToString();

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
		// Save each setting individually using PlayerPrefs
		PlayerPrefs.SetInt("startingStatPoints", settings.startingStatPoints);
		PlayerPrefs.SetInt("statPointsPerLevelUp", settings.statPointsPerLevelUp);
		PlayerPrefs.SetInt("percentChanceOfBonusPointOnRatingUp", settings.percentChanceOfBonusPointOnRatingUp);
		PlayerPrefs.SetInt("increaseInBonusChancePerLevel", settings.increaseInBonusChancePerLevel);
		PlayerPrefs.SetInt("numberOfStartingSkills", settings.numberOfStartingSkills);
		PlayerPrefs.SetInt("upgradePointsPerLevel", settings.upgradePointsPerLevel);
		PlayerPrefs.SetInt("maximumSkills", settings.maximumSkills);
		PlayerPrefs.SetInt("maximumFeats", settings.maximumFeats);
		PlayerPrefs.SetInt("maximumSkillLevel", settings.maximumSkillLevel);
		PlayerPrefs.SetInt("maximumFeatLevel", settings.maximumFeatLevel);

		PlayerPrefs.SetInt("F", settings.F);
		PlayerPrefs.SetInt("E", settings.E);
		PlayerPrefs.SetInt("D", settings.D);
		PlayerPrefs.SetInt("C", settings.C);
		PlayerPrefs.SetInt("B", settings.B);
		PlayerPrefs.SetInt("A", settings.A);
		PlayerPrefs.SetInt("S", settings.S);
		PlayerPrefs.SetInt("SS", settings.SS);

		PlayerPrefs.SetFloat("percentOfCoinpurseAsTreasure", settings.percentOfCoinpurseAsTreasure);
		PlayerPrefs.SetFloat("percentOfStashAsTreasure", settings.percentOfStashAsTreasure);
		PlayerPrefs.SetFloat("percentOfLockboxAsTreasure", settings.percentOfLockboxAsTreasure);
		PlayerPrefs.SetFloat("percentOfSafeAsTreasure", settings.percentOfSafeAsTreasure);
		PlayerPrefs.SetFloat("percentOfTreasuryAsTreasure", settings.percentOfTreasuryAsTreasure);
		PlayerPrefs.SetFloat("percentOfHordeAsTreasure", settings.percentOfHordeAsTreasure);
		PlayerPrefs.SetInt("treasureVariance", settings.treasureVariance);
		PlayerPrefs.SetFloat("exitTreasureGenerationEarlyChance", settings.exitTreasureGenerationEarlyChance);

		// Make sure to save the changes immediately
		PlayerPrefs.Save();
	}

	public void LoadSettings()
	{
		// Check if PlayerPrefs has saved values and load them
		if (PlayerPrefs.HasKey("startingStatPoints"))
		{
			settings.startingStatPoints = PlayerPrefs.GetInt("startingStatPoints");
			settings.statPointsPerLevelUp = PlayerPrefs.GetInt("statPointsPerLevelUp");
			settings.percentChanceOfBonusPointOnRatingUp = PlayerPrefs.GetInt("percentChanceOfBonusPointOnRatingUp");
			settings.increaseInBonusChancePerLevel = PlayerPrefs.GetInt("increaseInBonusChancePerLevel");
			settings.numberOfStartingSkills = PlayerPrefs.GetInt("numberOfStartingSkills");
			settings.upgradePointsPerLevel = PlayerPrefs.GetInt("upgradePointsPerLevel");
			settings.maximumSkills = PlayerPrefs.GetInt("maximumSkills");
			settings.maximumFeats = PlayerPrefs.GetInt("maximumFeats");
			settings.maximumSkillLevel = PlayerPrefs.GetInt("maximumSkillLevel");
			settings.maximumFeatLevel = PlayerPrefs.GetInt("maximumFeatLevel");

			settings.F = PlayerPrefs.GetInt("F");
			settings.E = PlayerPrefs.GetInt("E");
			settings.D = PlayerPrefs.GetInt("D");
			settings.C = PlayerPrefs.GetInt("C");
			settings.B = PlayerPrefs.GetInt("B");
			settings.A = PlayerPrefs.GetInt("A");
			settings.S = PlayerPrefs.GetInt("S");
			settings.SS = PlayerPrefs.GetInt("SS");

			settings.percentOfCoinpurseAsTreasure = PlayerPrefs.GetFloat("percentOfCoinpurseAsTreasure");
			settings.percentOfStashAsTreasure = PlayerPrefs.GetFloat("percentOfStashAsTreasure");
			settings.percentOfLockboxAsTreasure = PlayerPrefs.GetFloat("percentOfLockboxAsTreasure");
			settings.percentOfSafeAsTreasure = PlayerPrefs.GetFloat("percentOfSafeAsTreasure");
			settings.percentOfTreasuryAsTreasure = PlayerPrefs.GetFloat("percentOfTreasuryAsTreasure");
			settings.percentOfHordeAsTreasure = PlayerPrefs.GetFloat("percentOfHordeAsTreasure");
			settings.treasureVariance = PlayerPrefs.GetInt("treasureVariance");
			settings.exitTreasureGenerationEarlyChance = PlayerPrefs.GetFloat("exitTreasureGenerationEarlyChance");
		}
		else
		{
			settings = new SaveData();  // Initialize with default values
		}

		LoadSettingsIntoUI();
	}

	private void AddListeners()
	{
		startingStatPointsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.startingStatPoints));
		statPointsPerLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.statPointsPerLevelUp));
		percentChanceBonusPointField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.percentChanceOfBonusPointOnRatingUp));
		increaseInBonusChancePerLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.increaseInBonusChancePerLevel));
		startingSkillsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.numberOfStartingSkills));
		upgradePointsPerLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.upgradePointsPerLevel));
		maxSkillsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.maximumSkills));
		maxFeatsField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.maximumFeats));
		maxSkillLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.maximumSkillLevel));
		maxFeatLevelField.onEndEdit.AddListener(value => OnStatChanged(value, ref settings.maximumFeatLevel));

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