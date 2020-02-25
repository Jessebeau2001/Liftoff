using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class scene1 : Sprite
	{
		Sprite guy = new Sprite("guy.png", true, true);

		public scene1() : base("background2.png", false, false)
		{
			guy.SetOrigin(guy.width / 2, guy.height / 2);

			guy.x = game.width / 2;
			guy.y = game.height / 2;

			AddChild(guy);
		}

		public void Update()
		{

		}
	}
}
