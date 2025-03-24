using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverDisplayName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Image nameDisplayTextBackground;
	public Color textColor = Color.white;
	public bool textBackground;
	public float xOffset;
	public float yOffset;
	[Range(0f, 1f)]
	public float backgroundOpacity = 0f;
	private string objectName;
	private bool isHovering = false;
	private TextMeshProUGUI text;

	private void Start()
	{
		text = nameDisplayTextBackground.GetComponentInChildren<TextMeshProUGUI>();
		text.alpha = 0;
		objectName = gameObject.name;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (textBackground)
			nameDisplayTextBackground.color = new Color(1, 1, 1, backgroundOpacity); 
		text.text = objectName; 
		text.alpha = 1; 
		text.color = textColor;
		isHovering = true; 
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (textBackground)
			nameDisplayTextBackground.color = new Color(1, 1, 1, 0);
		text.alpha = 0; 
		isHovering = false; 
	}

	private void Update()
	{
		if (isHovering)
		{
			nameDisplayTextBackground.transform.position = Input.mousePosition + new Vector3(xOffset, yOffset, 0);
		}
	}
}