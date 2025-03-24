using UnityEngine;
using TMPro;

public class ResizeImageToText : MonoBehaviour
{
	public Vector2 padding;

	public void Update()
	{
		TextMeshProUGUI text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		Vector2 textSize = new (
			text.renderedWidth,
			text.renderedHeight
		);

		GetComponent<RectTransform>().sizeDelta = textSize + padding;
		transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one; // Undo the effects of scaling the parent on the child
	}
}