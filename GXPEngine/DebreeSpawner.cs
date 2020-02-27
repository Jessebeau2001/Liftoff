using System.Collections.Generic;

namespace GXPEngine
{
	class DebreeSpawner : Pivot
	{
		Debree rock;
		List<Debree> debreeList = new List<Debree>();

		private int _debreeIndex = 0;
		public DebreeSpawner() { }

		public void SpawnDebree(float x, float y, Intercept intercept, float beatMs)
		{
			rock = new Debree(x, y, intercept.getX(), game.height / 2, beatMs);
			debreeList.Add(rock);
			AddChild(debreeList[_debreeIndex]);
			_debreeIndex++;
		}
	}
}
