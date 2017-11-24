using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Match_Creator
{
	public class AddPlayer : MonoBehaviour {

		public GameObject Name;
		public GameObject Position;
		public GameObject Skill;

		public void addPlayer ()
		{
			string name = Name.GetComponent<Text> ().text;
			string position = Position.GetComponent<Text> ().text;
			string skill = Skill.GetComponent<Text> ().text;

			if(checkName(name))
			{
				App.xmlFile.AddPlayer (new Player (name, position, Int32.Parse (skill)));
				PresentPlayers.addNextButton();
			}

			Name.GetComponent<Text>().text = String.Empty;
			Position.GetComponent<Text>().text = "Goalkeeper";
			Skill.GetComponent<Text>().text = "1";
		}

		bool checkName (string name)
		{
			foreach (Player p in App.xmlFile.GetPlayers()) 
				if(p.Name == name) return false;
			
			return true;
		}
	}
}