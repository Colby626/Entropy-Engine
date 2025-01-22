using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedirectScrollInput : MonoBehaviour
{
	private ScrollRect scrollRect;
	public float scrollSensitivityWhenOverInputfield = 0.05f;

	public void Start()
	{
		scrollRect = transform.parent.parent.parent.GetComponent<ScrollRect>();
	}

	public void Update()
	{
		// Check if the scroll wheel is being used
		if (Input.mouseScrollDelta.y != 0f)
		{
			// If the pointer is over an input field, redirect the scroll input to the ScrollRect
			if (IsPointerOverInputField())
			{
				RedirectScroll();
			}
		}
	}

	private bool IsPointerOverInputField()
	{
		// Check if the pointer is currently over a UI element
		if (EventSystem.current.IsPointerOverGameObject())
		{
			// Get the currently hovered object
			PointerEventData pointerData = new PointerEventData(EventSystem.current)
			{
				position = Input.mousePosition
			};

			var raycastResults = new System.Collections.Generic.List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerData, raycastResults);

			// Check if any of the hovered objects is an InputField
			foreach (var result in raycastResults)
			{
				if (result.gameObject.GetComponent<InputField>() != null || result.gameObject.GetComponent<TMPro.TMP_InputField>() != null)
				{
					return true;
				}
			}
		}

		return false;
	}

	private void RedirectScroll()
	{
		// Apply the scroll delta to the ScrollRect's vertical normalized position
		float scrollDelta = Input.mouseScrollDelta.y;
		scrollRect.verticalNormalizedPosition += scrollDelta * scrollSensitivityWhenOverInputfield;
	}
}
