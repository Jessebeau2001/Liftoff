﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	internal class Debree : Sprite
	{
		public int healthTimer = 0;
		private float _xSpeed = 0, _ySpeed = 0, _distance = 0;

		public Debree(float x, float y, float targX, float targY, float speed) : base("rock.png", true)
		{
			this.x = x;
			this.y = y;

			_distance = Extensions.GetDistance(targX, targY, x, y);

			_xSpeed = (targX - x) / _distance;
			_ySpeed = (targY - y) / _distance;
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