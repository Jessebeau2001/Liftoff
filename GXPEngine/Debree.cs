using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	internal class Debree : Sprite
	{
		public int healthTimer = 0;
		private float _xSpeed = 0, _ySpeed = 0, _centreX = 0, _centreY = 0, _speedMod = 300; //make _speedMod larger to make the rock/debree go slower
		public Debree(float spawnX, float spawnY) : base("rock.png", true)
		{
			_centreX = game.width / 2;
			_centreY = game.height / 2;
			x = spawnX;
			y = spawnY;

			_xSpeed = (_centreX - x) / _speedMod;
			_ySpeed = (_centreY - y) / _speedMod;

			SetOrigin(width / 2, height / 2);
		}

		public void Update()
		{
			rotation += 10;

			x += _xSpeed;
			y += _ySpeed;
		}
	}
}
