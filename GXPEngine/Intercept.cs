﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	class Intercept : AnimationSprite
	{
		public float distance = 230;
		public int thisKey = Key.Z;


		public Intercept(bool mirrored) : base("bar_anim.png", 10, 2)
		{
			SetOrigin(width / 2, 0);

			if (mirrored) { x = (game.width / 2) - distance; }
			else { x = (game.width / 2) + distance; thisKey = Key.X; }

			Mirror(mirrored, false);
			currentFrame = frameCount;
		}

		public void Update()
		{
			Console.WriteLine("currentframe: " + currentFrame + " frameCount: " + frameCount);

			if (frameCount > currentFrame + 1)
			{
				NextFrame();
			}

			if (Input.GetKeyDown(thisKey))
			{
				currentFrame = 0;
			}


		}
	}
}
