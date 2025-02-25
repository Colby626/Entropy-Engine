using UnityEditor;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
		EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
	}
}
