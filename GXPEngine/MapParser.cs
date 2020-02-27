using System;
using System.Xml;

namespace GXPEngine
{
	class MapParser : Pivot
	{
		public string[] beat = {"", ""};
		private int BPM, offset;
		private string song, beatmap;

		public MapParser(string beatmap)
		{
			this.beatmap = beatmap;
		}

		public void LoadBeatmap()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("beatmaps/" + beatmap + ".xml");
			XmlElement root = doc.DocumentElement;
			song = root.GetAttribute("fileName");
			BPM = Int32.Parse(root.GetAttribute("BPM"));
			offset = Int32.Parse(root.GetAttribute("offset"));
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Loaded song             | " + song);
			Console.WriteLine("BPM of the soundtrack   | " + BPM);
			Console.WriteLine("Soundtrack offset in ms | " + offset);
			Console.WriteLine("-------------------------------------");
			int i = 0;
			foreach (XmlNode node in doc.DocumentElement)
			{
				beat[i] = node["beat"].InnerText;
				Console.WriteLine("Loaded " + node.Attributes[0].Value + "data: ");
				Console.WriteLine(beat[i]);
				i++;
			}
			Console.WriteLine("-------------------------------------");
		}

		public string GetData(int side, int stamp)
		{
			if (stamp > beat[0].Length - 1) return "Index Length out of bounds";
				else return beat[side].Substring(stamp, 1);
		}
		
		public string getSongPath()
		{
			return "sounds/" + song;
		}

		public int getBPM() { return BPM; }

		public int getOffset() { return offset; }
	}
}