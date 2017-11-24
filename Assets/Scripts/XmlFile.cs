using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System;
using AOT;

namespace Match_Creator
{
	public class XmlFile {

		private bool IsLoaded;

		XmlDocument file = new XmlDocument();
		string name;
		string path;

		public XmlFile(string _name)
		{
			name = _name;
			path = Application.persistentDataPath;

			Directory.CreateDirectory (path + "/XmlFiles");

			try
			{
				LoadFile();
				IsLoaded = true;
			} catch
			{
				Debug.Log ("Nie udalo sie zaladowac pliku!");
				Debug.Log (path);
				CreateFile();
				IsLoaded = false;
			}
		}

		public bool Raport()
		{
			return IsLoaded;
		}

		private void CreateFile()
		{
			file = new XmlDocument();
			XmlNode docNode = file.CreateXmlDeclaration("1.0", "UTF-8", null);
			file.AppendChild(docNode);

			XmlNode playersNode = file.CreateElement("Players");
			file.AppendChild(playersNode);
		}

		public void DeleteFile()
		{
			File.Delete(path + "/XmlFiles/" + name + ".xml");
		}

		public void AddPlayer(Player player)
		{
			XmlNode playerNode = file.CreateElement("player");
			XmlElement temp;

			temp = file.CreateElement("name");
			temp.InnerText = player.Name;
			playerNode.AppendChild(temp);

			temp = file.CreateElement("postition");
			temp.InnerText = player.Position;
			playerNode.AppendChild(temp);

			temp = file.CreateElement("skill");
			temp.InnerText = player.Skill.ToString();
			playerNode.AppendChild(temp);

			file["Players"].AppendChild(playerNode);
		}

		public void EditPlayer(int id, Player editPlayer)
		{
			Debug.Log("Player Edited");
			XmlNodeList player = file.GetElementsByTagName("player");

			XmlElement temp = file.CreateElement("name");
			temp.InnerText = editPlayer.Name;
			Debug.Log("Old Name: " + temp.Value);
			Debug.Log("New Name: " + editPlayer.Name);
			player[id].ReplaceChild(temp, player[id].ChildNodes[0]);

			temp = file.CreateElement("position");
			temp.InnerText = editPlayer.Position;
			player[id].ReplaceChild(temp, player[id].ChildNodes[1]);

			temp = file.CreateElement("skill");
			temp.InnerText = editPlayer.Skill.ToString();
			player[id].ReplaceChild(temp, player[id].ChildNodes[2]);
		}

		public void DeletePlayer(int id)
		{
			Debug.Log("Delete Player");
			XmlNodeList player = file.GetElementsByTagName("player");
			player[id].ParentNode.RemoveChild(player[id]);
		}

		public string GetPath()
		{
			return path;
		}

		public List<Player> GetPlayers()
		{
			List<Player> players = new List<Player>();
			XmlNodeList playerNodes = file.GetElementsByTagName("player");

			foreach (XmlNode p in playerNodes)
			{
				if (p.ChildNodes.Count != 0)
				{
					Player player = new Player(p.ChildNodes[0].InnerText, p.ChildNodes[1].InnerText, Int32.Parse(p.ChildNodes[2].InnerText));
					players.Add(player);
				}
			}

			return players;
		}

		public List<string> GetFiles()
		{
			List<string> files = new List<string>();

			foreach (String element in Directory.GetFiles(path + "/XmlFiles")) 
				files.Add(element);
			
			return reducePath(files);
		}

		private List<string> reducePath(List<string> files)
		{
			string temp = string.Empty;

			int begin, end;

			List<string> newList = new List<string> ();

			foreach (string element in files) 
			{
				temp = string.Empty;
				for (int i = element.Length - 1; i >= 0; i--) 
				{
					if (element [i] == '/') 
					{
						begin = i + 10;

						for (int j = begin; j < element.Length; j++)
							if (element [j] == '.') 
							{
								end = j - 1;

								for (int k = begin; k <= end; k++)
									temp += element [k];

								break;
							}

						break;
					}
				}

				newList.Add (temp);
			}

			return newList;
		}

		public void LoadFile()
		{
			Debug.Log ("Funkcja LoadFile");
			file.Load(path + "/XmlFiles/" + name + ".xml");
		}

		public void SaveFile()
		{
			Debug.Log ("Funkcja SaveFile");
			file.Save(path + "/XmlFiles/" + name + ".xml");
		}
	}
}