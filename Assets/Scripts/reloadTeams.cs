using UnityEngine;
using System.Collections;

namespace Match_Creator
{
	public class reloadTeams : MonoBehaviour {
		public GameObject teams;

		public void reload ()
		{
			teams.GetComponent<PresentTeams>().reload();
		}
	}
}
