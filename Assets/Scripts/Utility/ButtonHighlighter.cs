using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlighter : MonoBehaviour
{
	public Button button1;
	public Button button2;

	public Color normalColor = Color.grey;
	public Color highlightedColor = Color.white;

	private void Start()
	{
		ResetButtonColors();

		button1.onClick.AddListener(() => HighlightButton(button1));
		button2.onClick.AddListener(() => HighlightButton(button2));

		HighlightButton(button1);
	}

	private void HighlightButton(Button clickedButton)
	{
		ResetButtonColors();

		ColorBlock cb = clickedButton.colors;
		cb.normalColor = highlightedColor;
		clickedButton.colors = cb;
	}

	private void ResetButtonColors()
	{
		Button[] buttons = { button1, button2 };

		foreach (Button btn in buttons)
		{
			ColorBlock cb = btn.colors;
			cb.normalColor = normalColor;
			btn.colors = cb;
		}
	}
}