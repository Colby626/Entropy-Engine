using UnityEngine;
using TMPro;

public class ResizeImageToText : MonoBehaviour
{
	public Vector2 padding;

	public void Update()
	{
		Vector2 textSize = new Vector2(
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().preferredWidth,
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().preferredHeight
		);

		GetComponent<RectTransform>().sizeDelta = textSize + padding;
		transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one; // Undo the effects of scaling the parent on the child
	}
}