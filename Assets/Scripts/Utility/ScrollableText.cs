using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableText : MonoBehaviour
{
	private TextMeshProUGUI text;
	private string lastText;
	private ScrollRect scrollRect;
	public float maxTextHeight = 500f;

	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
		lastText = text.text;
		scrollRect = transform.parent.parent.GetComponent<ScrollRect>();
	}

	private void Update()
	{
		if (text.preferredHeight > maxTextHeight)
		{
			scrollRect.vertical = true;
		}
		else
		{
			scrollRect.vertical = false;
		}

		if (text.text != lastText)
		{
			scrollRect.verticalNormalizedPosition = 1f;
			lastText = text.text;
		}

		RectTransform contentRect = scrollRect.content;
		contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, text.preferredHeight);
	}
}