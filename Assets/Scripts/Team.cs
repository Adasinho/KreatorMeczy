using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Match_Creator
{
	public class Team {
		
		string Name { get; set; }
		public List<Player> players { get; set; }

		public Team(string name)
		{
			Name = name;
			players = new List<Player>();
		}

		public int GetSkill()
		{
			int sum = 0;
			for (int i = 0; i < players.Count; i++)
				sum += players[i].Skill;

			return sum;
		}
	}
}