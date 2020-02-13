using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Grapher : Sprite
	{
		private float _x1, _y1, _x2, _y2, _direcCof, _xDist, _yDist;

		public Grapher() : base("rock.png", true)
		{
			SetOrigin(width / 2, height / 2);

			_x1 = 1200;
			_y1 = 800;

			x = _x1;
			y = _y1;

			_x2 = game.width / 2;
			_y2 = game.height / 2;
		}

		public void Update()
		{
			if (Input.GetKey(Key.RIGHT)) { x += 10;  }
			if (Input.GetKey(Key.LEFT)) { x -= 10;  }
			if (Input.GetKey(Key.UP)) { y -= 10; }
			if (Input.GetKey(Key.DOWN)) { y += 10; }

			if(Input.GetKey(Key.K))
			{

				_xDist = _x2 - x;
				_yDist = _y2 - y;

				if (Math.Abs(_xDist) > 1 && Math.Abs(_yDist) > 1)
				{
					_direcCof = _yDist / _xDist;
				}
				
				Console.WriteLine(_direcCof);
				x += Time.deltaTime * Math.Sign(_xDist);
				y -= _direcCof * Time.deltaTime;
			}
		}
	}
}
