using System;
using System.Xml;

namespace GXPEngine
{
	class MapParser : Pivot
	{
		public string[] beat = {"", ""};

		public MapParser()
		{

		}

		public void LoadBeatmap()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("beatmap.xml");

			int i = 0;
			foreach (XmlNode node in doc.DocumentElement)
			{
				beat[i] = node["beat"].InnerText;
				Console.WriteLine("Loaded " + node.Attributes[0].Value);
				Console.WriteLine(beat[i]);
				i++;
			}
			Console.WriteLine("0: " + beat[0] + ", 1: " + beat[1]);
		}

		public string GetMapData(int side, int stamp)
		{
			if (stamp > beat[0].Length - 1) return "Index Length out of bounds";
				else return beat[side].Substring(stamp, 1);
		}
	}
}
