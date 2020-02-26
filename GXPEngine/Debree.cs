using System;

namespace GXPEngine
{
	internal class Debree : EasyDraw
	{
		public int healthTimer = 0;
		private float _xSpeed, _ySpeed, _distance, _turnSpeed;

		Sprite rock = new Sprite("rock.png", false);

		public Debree(float x, float y, float _xTarg, float _yTarg, int turnSpeed) : base(20, 20)
		{
			rock.SetOrigin(rock.width / 2, rock.height / 2);
			this.x = x;
			this.y = y;
			_turnSpeed = turnSpeed;

			SetOrigin(width / 2, height / 2);

			AddChild(rock);

			_distance = Extensions.GetDistance(_xTarg, _yTarg, x, y);
			_xSpeed = (_xTarg - x) / _distance; //Calculates the amount of x its needs to move to get to its destenation
			_ySpeed = (_yTarg - y) / _distance; //Calculates the y amount to move and stay in sync with its x
		}

		public void Update()
		{
			rotation += _turnSpeed;
			x += _xSpeed * 5;
			y += _ySpeed * 5;

			if (x > game.width + 30 || x < -30)
			{
				if (y > game.height || y < -30)
				{
					LateDestroy();
				}
			}
		}

		void OnCollision(GameObject other)
		{
			var children = other.GetChildren();

			if (other is Intercept && (other as Intercept).isActive(x))
			{
				LateDestroy();
			}


			//if (other.name == "rock.png") LateDestroy();
		}
	}

	static class Extensions
	{
		///<summary> Re-maps a number from one range to another.</summary>wel
		public static float Map(this float value, float from1, float to1, float from2, float to2)
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}
		///<summary> Pythagoras equation.</summary>
		public static float GetDistance(float x1, float y1, float x2, float y2)
		{
			return (float)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
		}
	}
}
