using System;
using IrrKlang;

namespace GXPEngine
{
	class Beat : Pivot
	{
		public float BPM = 150 , BPS, FPB, framerate = 60, beatMs, deltaTime; //BPM: Beats Per Minute; BPS: Beats Per Second; FPB = Frames Per Beat
		private int _timeStamp = 0;

		private bool _clap = true;

		ISoundEngine engine = new ISoundEngine();
		DebreeSpawner debreeSpawner = new DebreeSpawner();
		MapParser parser = new MapParser();

		Random rnd = new Random();
		public Beat()
		{
			AddChild(debreeSpawner);
			//engine.Play2D("sounds/soundtrack.ogg"); 
			engine.Play2D("sounds/GangPlankCut.ogg");
			BPS = BPM / 60;			// 180 / 60 = 3 beats / second
			FPB = framerate / BPS;  // 60 / 3 = 20 frames / beat
			beatMs = (1000 / BPS) * 1; //The amount of time in ms that needs to pass for 1 beat ADD MULTIPLIER TO MAKE LESS ROCKS APPEAR

			parser.LoadBeatmap();
		}

		public void Update()
		{
			deltaTime += Time.deltaTime;

			if (deltaTime > beatMs)
			{
				deltaTime -= beatMs;

				if (parser.GetData(0, _timeStamp) == "1") debreeSpawner.SpawnDebree(-30, game.height / 2);
				if (parser.GetData(1, _timeStamp) == "1") debreeSpawner.SpawnDebree(game.width + 30, game.height / 2);

				//clapKick();

				_timeStamp++;
			}
		}

		public void clapKick()
		{
			if(_clap) engine.Play2D("sounds/clap.ogg");
				else engine.Play2D("sounds/kick.ogg");
			_clap = !_clap;
		}
	}
}
