using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Match_Creator
{
	public class EditPlayer : MonoBehaviour {

		static InputField Name;
		static Text Position;
		static Text Skill;

		static int index;

		void Awake()
		{
			Name = GameObject.Find("/EditPlayer/Player/Name TB").GetComponent<InputField>();
			Position = GameObject.Find("/EditPlayer/Player/Position DD").GetComponentInChildren<Text>();
			Skill = GameObject.Find("/EditPlayer/Player/Skill DD").GetComponentInChildren<Text>();
		}

		public static void setValues ()
		{
			index = 0;

			foreach (Player p in App.xmlFile.GetPlayers()) 
			{
				if (p.Name == App.playerName) 
				{
					Debug.Log("Znaleziono");
					Name.text = p.Name;
					Position.text = p.Position;
					Skill.text = p.Skill.ToString();

					break;
				} else index++;
			}
		}

		public void updateValues ()
		{
			if (checkName (Name.text)) 
			{
				App.xmlFile.EditPlayer (index, new Player (Name.text, Position.text, Int32.Parse (Skill.text)));
				PresentPlayers.reloadButtons ();
			}
		}

		public void deleteValues ()
		{
			App.xmlFile.DeletePlayer(index);
			PresentPlayers.reloadButtons();
		}

		bool checkName (string name)
		{
			int i = 0;
			foreach (Player p in App.xmlFile.GetPlayers()) 
				if(p.Name == name) i++;
			if(i > 1) return false;
				else return true;
		}

	}
}