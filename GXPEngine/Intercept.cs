using IrrKlang;

namespace GXPEngine
{
	class Intercept : EasyDraw
	{
		public float distance = 230;
		public int thisKey = Key.Z;
		
		private bool _active = false, _mirrored = false;

		//AnimationSprite bar = new AnimationSprite("bar_anim.png", 10, 2, addCollider:true);
		AnimationSprite bar = new AnimationSprite("rainbow_bar.png", 13, 1, addCollider: false);

		ISoundEngine engine = new ISoundEngine();

		public Intercept(bool mirrored, int width, int height) : base (width, height)
		{
			_mirrored = mirrored;
			bar.SetOrigin(bar.width / 2, 0);
			if (!mirrored)
			{
				x = game.width / 2 - distance;
			}
			else
			{
				x = game.width / 2 + distance;
				thisKey = Key.X;
			}
			bar.Mirror(mirrored, false);
			bar.currentFrame = bar.frameCount;
			bar.width = 100;
			AddChild(bar);

			//AddChild(border);
			//border.SetOrigin(bar.width / 2, 0);
		}

		public void Update()
		{
			_active = false;
			if (bar.frameCount > bar.currentFrame + 1)
			{
				bar.NextFrame();
			}

			if (Input.GetKeyDown(thisKey) && bar.currentFrame >= 5)
			{
				bar.currentFrame = 0;
				_active = true;

				if (_mirrored) engine.Play2D("sounds/clap.ogg");
					else engine.Play2D("sounds/kick.ogg");
			}
		}

		public bool isActive(float debX)
		{
			if (Mathf.Abs(x - debX) > 0) { }
			return _active;
		}
	}
}
