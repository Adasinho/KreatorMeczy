using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Match_Creator
{
	public class TeamsGenerator {

		public List<Team> teams;
		public List<Player> players;

		public TeamsGenerator(int teamsCount ,List<Player> _players, bool type)
		{
			teams = new List<Team>(teamsCount);
			players = _players;

			Team newTeam;
			for(int i = 0; i < 2; i++)
			{
				newTeam = new Team("Team " + i);
				teams.Add(newTeam);
			}

			SetTeams(type);
		}

		private void SetTeams(bool type)
		{
			int l = 0, p = players.Count - 1;
			int count = 0;

			SortList(type);

			while (count != players.Count)
			{
				bool exception = false;

				if(count % 2 == 0) // Team 1
				{
					if (teams[0].GetSkill() == teams[1].GetSkill())
					{
						teams[0].players.Add(players[l]);
						l++;
						count++;
					}
					else if (teams[0].GetSkill() > teams[1].GetSkill())
					{
						if (teams[0].players.Count() < teams[1].players.Count())
						{
							teams[0].players.Add(players[p]);
							p--;
							count++;
						}
						else if(teams[0].players.Count() == teams[1].players.Count())
						{
							teams[1].players.Add(players[l]);
							l++;
							count++; 
						}
						else
						{
							count++;
							exception = true;
						}
					}
					else
					{
						teams[0].players.Add(players[l]);
						l++;
						count++;
					}
				} else // Team 2
				{
					if (teams[0].players.Count() < teams[1].players.Count())
					{
						teams[0].players.Add(players[p]);
						p--;
						count++;
					}
					else
					{
						teams[1].players.Add(players[l]);
						l++;
						if (!exception)
						{
							count++;
							exception = false;
						}
					}
				}
			}
		}

		private void SortList(bool type)
		{
			if(type)
			{
				SortList(false);

				players.Sort(delegate (Player x, Player y)
					{
						return y.Skill.CompareTo(x.Skill);
					});
			} else {
				for(int i = 0; i < players.Count(); i++)
				{
					Player player;
					int number = Random.Range(0, players.Count() - 1);

					player = players[number];
					players[number] = players[i];
					players[i] = player;
				}
			}
		}
	}
}