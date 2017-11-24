using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Match_Creator
{
	public class PresentPlayers : MonoBehaviour {

		public GameObject bs;
		static GameObject button;
		static GameObject addPlayerButton;

		static float buttonWidth;
		static float buttonHeight;

		static float padding;
		static float margin;
		static float listPosition;

		static List<GameObject> buttons;
		static GameObject go;
		static GameObject button2;

		static RectTransform oldParentRectT;

		void Start ()
		{
			button = bs;
			go = gameObject;
			addPlayerButton = GameObject.Find("AddPlayer");

			buttonHeight = Screen.height / 15;
			buttonWidth = Screen.width * 6/10;

			padding = buttonHeight / 10;
			margin = 2*(buttonHeight + padding);

			buttons = new List<GameObject>();

			button2 = button;

			oldParentRectT = GameObject.Find("Scroll View").GetComponent<RectTransform>();

			generateButtons();
		}

		static public void addNextButton()
		{
			buttons.Add(Instantiate(button2) as GameObject);

			reloadButtons();
		}

		static public void generateButtons()
		{
			//buttonHeight = button.GetComponent<RectTransform>().rect.height;
			//buttonWidth = button.GetComponent<RectTransform>().rect.width;

			listPosition = 0;

			for (int i = 0; i < App.xmlFile.GetPlayers().Count; i++) 
			{
				if(i == 0) listPosition = -margin;
					else listPosition += -(buttonHeight + padding);

				buttons.Add(Instantiate(button) as GameObject);

				buttons[i].transform.SetParent(go.transform);
				buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,listPosition);
				buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(buttonWidth,buttonHeight);
				buttons[i].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
				buttons[i].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
				buttons[i].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				buttons[i].GetComponentInChildren<Text>().text = App.xmlFile.GetPlayers()[i].Name;
			}

			if(App.xmlFile.GetPlayers().Count == 0) listPosition = -margin;
				else listPosition += -(buttonHeight + padding);

			addPlayerButton.transform.SetParent(go.transform);
			addPlayerButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,listPosition);
			addPlayerButton.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonWidth, buttonHeight);
			addPlayerButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
			addPlayerButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
			addPlayerButton.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

			RectTransform goRT;
			goRT = go.GetComponent<RectTransform>();

			//goRT.sizeDelta = new Vector2(goRT.rect.width, - listPosition - oldParentRectT.rect.height - padding);
			goRT.offsetMin = new Vector2(0,oldParentRectT.rect.height + listPosition - margin + goRT.offsetMax.y - 589);
			//if(goRT.offsetMin.y < 0) goRT.offsetMax = new Vector2(goRT.offsetMax.x, goRT.offsetMin.y);
				//else goRT.offsetMax = new Vector2(goRT.offsetMax.x, 0);

			Debug.Log("oldParent " + oldParentRectT.rect.height);
			Debug.Log("List scale " + listPosition);

		}

		static public void reloadButtons()
		{
			Debug.Log("reloadButtons");
			for(int i = 0; i < buttons.Count; i++)
				Destroy(buttons[i]);
			buttons = new List<GameObject>();
			generateButtons();
		}
	}
}
