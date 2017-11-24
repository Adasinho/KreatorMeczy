using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Match_Creator
{
	public class PresentXmlFiles : MonoBehaviour 
	{
		public GameObject gameObj;
		Text text1;

		int buttonWidth;
		int buttonHeight;

		int padding;

		void Start()
		{
			buttonWidth = 300;
			buttonHeight = 60;

			padding = buttonHeight + 10;

			text1 = gameObj.GetComponent<Text>();

			text1.text = App.xmlFile.GetFiles()[0];
		}

		void OnGUI()
		{
			for(int i = 0; i < App.xmlFile.GetFiles().Count; i++)
				GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, Screen.height/4 + padding * i, buttonWidth, buttonHeight), App.xmlFile.GetFiles()[i]);

		}
	}
}