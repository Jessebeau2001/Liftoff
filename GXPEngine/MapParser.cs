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
				string beat = node["beat"].InnerText;
				Console.WriteLine("Loaded " + node.Attributes[0].Value);
				this.beat[i] = beat;
				Console.WriteLine
				i++;
			}
		}

		public string GetMapData(int side, int stamp)
		{
			if (stamp > beat.Length - 1) return "Index Length out of bounds";
				else return beat[side].Substring(stamp, 1);
		}
	}
}
