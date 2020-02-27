using System.Collections.Generic;

namespace GXPEngine
{
	class DebreeSpawner : Pivot
	{
		Debree rock;
		List<Debree> debreeList = new List<Debree>();

		private int _debreeIndex = 0;
		private string _texturePath;

		public DebreeSpawner() { }

		public void SpawnDebree(float x, float y, Intercept intercept, float beatMs)
		{
			if (x < game.width / 2) _texturePath = "assets/note_red.png";
				else _texturePath = "assets/note_blue.png";

			rock = new Debree(x, y, intercept.getX(), game.height / 2, beatMs, _texturePath);
			debreeList.Add(rock);
			AddChild(debreeList[_debreeIndex]);
			_debreeIndex++;
		}
	}
}
