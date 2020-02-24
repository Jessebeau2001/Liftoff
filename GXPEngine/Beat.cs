using System;
using IrrKlang;

namespace GXPEngine
{
	class Beat : Sprite
	{
		public int BPM = 180 , BPS, FPB, framerate = 60; //BPM: Beats Per Minute; BPS: Beats Per Second; FPB = Frames Per Beat
		private int _frame = 0, deltaTime;


		DebreeSpawner debreeSpawner = new DebreeSpawner();
		ISoundEngine engine = new ISoundEngine();

		public Beat() : base("rock.png")
		{
			AddChild(debreeSpawner);
			//engine.Play2D("sounds/soundtrack.ogg");
			BPS = BPM / 60;			// 180 / 60 = 3 beats / second
			FPB = framerate / BPS;  // 60 / 3 = 20 frames / beat
			engine.Play2D("sounds/kick.ogg");
		}

		public void Update()
		{ 
			deltaTime += Time.deltaTime;

			if (deltaTime > (1000 / BPS) * 4)
			{
				deltaTime = 0;
				debreeSpawner.SpawnDebree(-30, game.height / 2);
			}

			Console.WriteLine("Ellapsed time: " + deltaTime + ", Current frame: " + _frame);
		}
	}
}
