using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverDisplayName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public TextMeshProUGUI nameDisplayText;
	private string objectName;
	private bool isHovering = false;

	private void Start()
	{
		nameDisplayText.alpha = 0;
		objectName = gameObject.name;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		nameDisplayText.text = objectName; 
		nameDisplayText.alpha = 1; 
		isHovering = true; 
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		nameDisplayText.alpha = 0; 
		isHovering = false; 
	}

	private void Update()
	{
		if (isHovering)
		{
			nameDisplayText.transform.position = Input.mousePosition;
		}
	}
}