using System;
using IrrKlang;
using System.Collections.Generic;

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
		Scoring score;

		List<EasyDraw> popupList = new List<EasyDraw>();
		Popup popup;
		Random rnd = new Random();

		public Intercept(Scoring score, bool mirrored, int width, int height) : base (width, height)
		{
			this.score = score;
			Rect(0, game.height / 2, width, height);
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
		}

		public void Update()
		{
			_active = false;
			if (bar.frameCount > bar.currentFrame + 1)
			{
				bar.NextFrame();
			}

			if (Input.GetKeyDown(thisKey) && bar.currentFrame >= 5) click();
		}

		public void click()
		{
			bar.currentFrame = 0;
			_active = true;

			if (_mirrored) engine.Play2D("sounds/clap.ogg");
			else engine.Play2D("sounds/kick.ogg");
		}

		public void GetHit(float debX)
		{
			switch (Mathf.Abs(x - debX))
			{
				case float n when (n <= 10 && n >= 0):
					score.changeScore(300);
					scorePop(300);
					break;
				case float n when (n < 20 && n >= 10):
					score.changeScore(150);
					scorePop(150);
					break;
				case float n when (n > 20):
					score.changeScore(50);
					scorePop(50);
					break;
			}
		}

		public void scorePop(int score)
		{
			//popup = new Popup(rnd.Next(x - 50, x + 50), rnd.Next(y - 50, y + 50), score.ToString());
			popup = new Popup(rnd.Next(-75, 75), 300 + rnd.Next(-75, 75), score.ToString());
			popupList.Add(popup);
			Console.WriteLine(popupList.Count);
			LateAddChild(popupList[popupList.Count - 1]);
		}

		public bool isActive(float debX)
		{
			if (_active) GetHit(debX);
			return _active;
		}
	}
}
