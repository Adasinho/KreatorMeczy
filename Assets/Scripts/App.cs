using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Match_Creator
{
	public class App : MonoBehaviour {
		public static XmlFile xmlFile;

		public GameObject path;

		public GameObject newCavas;
		static GameObject nC;

		public static string playerName;

		public static TeamsGenerator teamsGenerator;

		public GameObject Teams;

		public static bool bySkill;

		void Awake()
		{
			nC = newCavas;
			xmlFile = new XmlFile ("DataBase");

			//xmlFile.AddPlayer (new Player ("Adam", "ST", Random.Range(1,3)));

			xmlFile.SaveFile();

			Text text;
			text = path.GetComponent<Text> ();
			text.text = xmlFile.GetPath ();
		}

		void OnApplicationQuit()
		{
			xmlFile.SaveFile();
		}

		public static GameObject specialTrick()
		{
			return nC;
		}

		public void setTeams ()
		{
			Teams.GetComponent<PresentTeams>().setTeams();
		}
	}
}
