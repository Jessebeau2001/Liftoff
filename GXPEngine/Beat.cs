using System;
using IrrKlang;

namespace GXPEngine
{
	class Beat : Sprite
	{
		public int BPM = 180 , BPS, FPB, framerate = 60; //BPM: Beats Per Minute; BPS: Beats Per Second; FPB = Frames Per Beat
		private int _frame = 0, deltaTime;

		ISoundEngine engine = new ISoundEngine();

		public Beat() : base("rock.png")
		{
			engine.Play2D("sounds/soundtrack.ogg");
			x = -300;
			BPS = BPM / 60;			// 180 / 60 = 3 beats / second
			FPB = framerate / BPS;  // 60 / 3 = 20 frames / beat
			engine.Play2D("sounds/kick.ogg");
		}

		public void Update()
		{
			if (Input.GetKeyDown(Key.P)) engine.Play2D("sounds/kick.ogg");

			deltaTime += Time.deltaTime;

			if (deltaTime > (1000 / BPS))
			{
				deltaTime = 0;
				engine.Play2D("sounds/kick.ogg");
			}

			Console.WriteLine("Ellapsed time: " + deltaTime + ", Current frame: " + _frame);
		}
	}
}
