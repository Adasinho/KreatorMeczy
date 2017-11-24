using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Match_Creator
{
	public class SpecialChangeCanvas : MonoBehaviour {

		static GameObject oldCanvas;
		static GameObject newCanvas;
		
		void Start()
		{
			oldCanvas = GameObject.Find("PrepareMatch");
			newCanvas = App.specialTrick();
		}

		public void changeCanvas()
		{
			//oldCanvas.SetActive(false);
			//newCanvas.SetActive(true);

			oldCanvas.GetComponent<Animator>().Play("Move");
			newCanvas.GetComponent<Animator>().Play("Back");
		}

		public void remeberPlayer()
		{
			App.playerName = GetComponentInChildren<Text>().text;
			EditPlayer.setValues();
		}
	}
}