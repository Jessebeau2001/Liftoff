using System;
using IrrKlang;

namespace GXPEngine
{
	class Beat : Pivot
	{
		public int BPM = 180 , BPS, FPB, framerate = 60; //BPM: Beats Per Minute; BPS: Beats Per Second; FPB = Frames Per Beat
		private int deltaTime, _spawnSide = 0;

		DebreeSpawner debreeSpawner = new DebreeSpawner();
		ISoundEngine engine = new ISoundEngine();

		Random rnd = new Random();
		public Beat()
		{
			AddChild(debreeSpawner);
			engine.Play2D("sounds/soundtrack.ogg");
			BPS = BPM / 60;			// 180 / 60 = 3 beats / second
			FPB = framerate / BPS;  // 60 / 3 = 20 frames / beat
			engine.Play2D("sounds/kick.ogg");
		}

		public void Update()
		{ 
			deltaTime += Time.deltaTime;

			if (deltaTime > (1000 / BPS) * 2)
			{
				deltaTime = 0;

				_spawnSide = rnd.Next(0, 2);
				Console.WriteLine(_spawnSide);
				if (_spawnSide == 0) debreeSpawner.SpawnDebree(-30, game.height / 2);
					else debreeSpawner.SpawnDebree(game.width + 30, game.height / 2);
			}
		}
	}
}
