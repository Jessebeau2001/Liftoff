using System;
using System.Collections.Generic;

namespace GXPEngine
{
	class DebreeSpawner : Pivot
	{
		Debree rock;
		List<Debree> debreeList = new List<Debree>(); //Creates the Debree ArrayList

		private int _debreeIndex = 0;

		public DebreeSpawner() { }

		public void SpawnDebree(float x, float y) //Spawns a piece of debree inside an arrayList to be filled with debree
		{
			rock = new Debree(x, y, game.width / 2, game.height / 2, 5);
			debreeList.Add(rock);
			AddChild(debreeList[_debreeIndex]);
			_debreeIndex++;
		}
	}
}
