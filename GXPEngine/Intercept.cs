using System;
using IrrKlang;

namespace GXPEngine
{
	class Intercept : AnimationSprite
	{
		public float distance = 230;
		public int thisKey = Key.Z;
		private bool _active = false, _mirrored = false;

		ISoundEngine engine = new ISoundEngine();

		public Intercept(bool mirrored) : base("bar_anim.png", 10, 2)
		{
			_mirrored = mirrored;
			width = 100;
			SetOrigin(width / 2, 0);

			if (mirrored)
			{
				x = (game.width / 2) - distance;
			} else
			{
				x = (game.width / 2) + distance;
				thisKey = Key.X;
			}

			Mirror(mirrored, false);
			currentFrame = frameCount;
		}

		public void Update()
		{
			_active = false;
			if (frameCount > currentFrame + 1)
			{
				NextFrame();
			}

			if (Input.GetKeyDown(thisKey))
			{
				currentFrame = 0;
				_active = true;

				if (_mirrored) engine.Play2D("sounds/kick.ogg");
					else engine.Play2D("sounds/clap.ogg");
			}

			Console.WriteLine(_active);
		}

		public bool isActive()
		{
			return _active;
		}
	}
}
