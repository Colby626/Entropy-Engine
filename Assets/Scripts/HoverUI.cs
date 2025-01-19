using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject hoverWindowPrefab;
	private GameObject hoverWindowInstance;
	private RectTransform hoverWindowTransform;
	private Canvas parentCanvas;
	private CharacterList.Character characterData;

	public void Start()
	{
		parentCanvas = FindObjectOfType<Canvas>();
		hoverWindowInstance = Instantiate(hoverWindowPrefab, parentCanvas.transform);
		hoverWindowTransform = hoverWindowInstance.GetComponent<RectTransform>();
		hoverWindowInstance.SetActive(false);
	}

	public void Update()
	{
		if (hoverWindowInstance.activeSelf)
		{
			Vector2 mousePosition;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(
				parentCanvas.transform as RectTransform,
				Input.mousePosition,
				parentCanvas.worldCamera,
				out mousePosition);

			hoverWindowTransform.anchoredPosition = mousePosition;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		hoverWindowInstance.SetActive(true);
		characterData = GetComponent<CharacterTemplate>().characterData;

		hoverWindowInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Endurance: " + characterData.Endurance.ToString();
		hoverWindowInstance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Strength: " + characterData.Strength.ToString();
		hoverWindowInstance.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Dexterity: " + characterData.Dexterity.ToString();
		hoverWindowInstance.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Agility: " + characterData.Agility.ToString();
		hoverWindowInstance.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Intelligence: " + characterData.Intelligence.ToString();
		hoverWindowInstance.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Spirit: " + characterData.Spirit.ToString();
		hoverWindowInstance.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Max Health: " + characterData.MaxHealth.ToString();
		hoverWindowInstance.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Max Mana: " + characterData.MaxMana.ToString();
		hoverWindowInstance.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Physical Resistance: " + characterData.PhysicalResistance.ToString();
		hoverWindowInstance.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Magical Resistance: " + characterData.MagicResistance.ToString();
		hoverWindowInstance.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Agility Class: " + characterData.AgilityClass.ToString();
		hoverWindowInstance.transform.GetChild(11).GetComponent<TextMeshProUGUI>().text = "Plus To Hit: " + characterData.PlusToHit.ToString();
		hoverWindowInstance.transform.GetChild(12).GetComponent<TextMeshProUGUI>().text = "Initiative Bonus: " + characterData.InitiativeBonus.ToString();
		hoverWindowInstance.transform.GetChild(13).GetComponent<TextMeshProUGUI>().text = "Movement Speed: " + characterData.MovementSpeed.ToString();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hoverWindowInstance.SetActive(false);
	}
}
