using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Match_Creator
{
	public class GeneratedPlayers : MonoBehaviour {

		public GameObject lb;
		GameObject label;

		float labelWidth;
		float labelHeight;

		float padding;
		float margin;
		float listPosition;

		List<GameObject> labels;
		GameObject go;
		GameObject label2;

		RectTransform oldParentRectT;

		public int tN;
		int teamNumber;

		public bool one;

		void Start()
		{
			one = true;
		}

		public void specialStart ()
		{
			label = lb;
			go = gameObject;

			labelHeight = Screen.height / 40;
			labelWidth = Screen.width * 4/10;

			padding = labelHeight / 10;
			margin = 8 * padding;

			labels = new List<GameObject>();

			label2 = label;

			oldParentRectT = GameObject.Find("Scroll View").GetComponent<RectTransform>();

			teamNumber = tN;

			generateLabels();

			one = false;
		}

		public void generateLabels()
		{
			//buttonHeight = button.GetComponent<RectTransform>().rect.height;
			//buttonWidth = button.GetComponent<RectTransform>().rect.width;

			listPosition = 0;

			for (int i = 0; i < App.teamsGenerator.teams[teamNumber].players.Count; i++) 
			{
				if(i == 0) listPosition = -margin;
					else listPosition += -(labelHeight + padding);

				labels.Add(Instantiate(label) as GameObject);

				labels[i].transform.SetParent(go.transform);
				labels[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,listPosition);
				labels[i].GetComponent<RectTransform>().sizeDelta = new Vector2(labelWidth,labelHeight);
				labels[i].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
				labels[i].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
				labels[i].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
				labels[i].GetComponent<Text>().text = App.teamsGenerator.teams[teamNumber].players[i].Name;
			}

			RectTransform goRT;
			goRT = go.GetComponent<RectTransform>();

			//goRT.sizeDelta = new Vector2(goRT.rect.width, - listPosition - oldParentRectT.rect.height - padding);
			goRT.offsetMin = new Vector2(0,oldParentRectT.rect.height + listPosition - margin + goRT.offsetMax.y);
			//if(goRT.offsetMin.y < 0) goRT.offsetMax = new Vector2(goRT.offsetMax.x, goRT.offsetMin.y);
				//else goRT.offsetMax = new Vector2(goRT.offsetMax.x, 0);

			Debug.Log("oldParentLabels " + oldParentRectT.rect.height);
			Debug.Log("List scale Labels " + listPosition);

		}

		public void reloadLabels ()
		{
			Debug.Log ("reloadLabels");
			if (labels != null) 
			{
				for (int i = 0; i < labels.Count; i++)
					Destroy (labels [i]);
			}
			labels = new List<GameObject>();
			generateLabels();
		}
	}
}