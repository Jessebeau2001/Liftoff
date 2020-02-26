using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class scene1 : EasyDraw
	{
		Sprite guy = new Sprite("guy.png", true, false);
		Sprite background = new Sprite("background2.png", false, false);

		public scene1() : base(20, 20)
		{
			x = game.width / 2;
			y = game.height / 2;

			background.SetOrigin(background.width / 2, background.height / 2);
			//AddChild(background);

			guy.SetOrigin(guy.width / 2, guy.height / 2);
			guy.scale = 0.6f;
			//AddChild(guy);

			Rect(0, 0, width, height);
		}

		public void Update()
		{

		}
	}
}
