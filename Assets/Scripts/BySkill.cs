using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Match_Creator
{
	public class BySkill : MonoBehaviour {

		public GameObject gameObj;

		// Use this for initialization
		void Start () {
			gameObj.GetComponent<Image>().SetNativeSize();
			App.bySkill = true;
		}

		public void bySkill ()
		{
			App.bySkill = gameObject.GetComponent<Toggle>().isOn;
		}
	}
}