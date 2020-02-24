using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class scene1 : Sprite
	{
		private int _debreeIndex = 0;

		Sprite guy = new Sprite("guy.png", true, false);
		Debree rock;
		List<Debree> debreeList = new List<Debree>(); //Creates the Debree ArrayList
		Random rnd = new Random();

		public scene1() : base("background2.png", false, false)
		{
			AddChild(guy);
			guy.x = game.width / 2 - guy.width / 2;
			guy.y = game.height / 2 - guy.height / 2;
		}

		public void Update()
		{
			kbHandler();
		}
		
		public void kbHandler() //Handles all the keyboard inputs
		{
			if (Input.GetKeyDown(Key.D)) SpawnDebree(rnd.Next(0, game.width), rnd.Next(0, game.height));
		}

		public void SpawnDebree(float x, float y) //Spawns a piece of debree inside an arrayList to be filled with debree
		{
			rock = new Debree(x, y, game.width / 2, game.height / 2, 5);
			debreeList.Add(rock);
			AddChild(debreeList[_debreeIndex]);
			_debreeIndex++;
		}

	}
}
