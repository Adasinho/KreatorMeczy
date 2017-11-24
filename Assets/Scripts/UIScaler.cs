using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour {

	public float editorScale;
	public bool editor;
	float newScale;

	// Use this for initialization
	void Awake () {
		CanvasScaler canvasScaler = gameObject.GetComponent<CanvasScaler>();

		newScale = Screen.width / canvasScaler.referenceResolution.x;

		if((Application.platform != RuntimePlatform.WindowsEditor) || (editor)) canvasScaler.scaleFactor = newScale;
	}
}
