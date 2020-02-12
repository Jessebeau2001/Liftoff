using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	internal class Debree : Sprite
	{
		public int healthTimer = 0;
		private float _xSpeed = 0, _ySpeed = 0, _centerX = 0, _centerY = 0, _speedMod = 300; //make _speedMod larger to make the rock/debree go slower
		private float _distX = 0, _distY, _distance = 0;

		public Debree(float spawnX, float spawnY) : base("rock.png", true)
		{
			x = spawnX;
			y = spawnY;
			
			_centerX = 500;
			_centerY = 500;

			_distance = Extensions.GetDistance(_centerX, _centerY, x, y);

			_xSpeed = (_centerX - x) / _distance;
			_ySpeed = (_centerY - y) / _distance;
			SetOrigin(width / 2, height / 2);
		}

		public void Update()
		{
			rotation += 10;
			x += _xSpeed * 5;
			y += _ySpeed * 5;

			Console.WriteLine(_distance);
		}
	}
	static class Extensions
	{
		///<summary> Re-maps a number from one range to another.</summary>
		public static float Map(this float value, float from1, float to1, float from2, float to2)
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}
		///<summary> Pythagoras his equation.</summary>
		public static float GetDistance(float x1, float y1, float x2, float y2)
		{
			return (float)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
		}
	}
}
