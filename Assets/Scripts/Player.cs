using UnityEngine;
using System.Collections;

namespace Match_Creator
{
	public class Player {

		public string Name { get; set; }
		public string Position { get; set; }
		public int Skill { get; set; }

		public Player (string name, string position, int skill)
		{
			Name = name;
			Position = position;
			Skill = skill;
		}
	}
}