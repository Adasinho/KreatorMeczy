using UnityEngine;
using System.Collections;

namespace Match_Creator
{
	public class PresentTeams : MonoBehaviour {

		public GameObject team1;
		public GameObject team2;

		public void setTeams ()
		{
			App.teamsGenerator = new TeamsGenerator (2, App.xmlFile.GetPlayers (), App.bySkill);

			if (team1.GetComponent<GeneratedPlayers> ().one) 
			{
				team1.GetComponent<GeneratedPlayers> ().specialStart ();
				team2.GetComponent<GeneratedPlayers> ().specialStart ();
			}

			reload();
		}

		public void reload()
		{
			team1.GetComponent<GeneratedPlayers>().reloadLabels();
			team2.GetComponent<GeneratedPlayers>().reloadLabels();
		}
	}
}