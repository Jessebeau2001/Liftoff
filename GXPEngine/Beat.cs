using System;
using IrrKlang;

namespace GXPEngine
{
	class Beat : Pivot
	{
		public float BPM = 123 , BPS, FPB, framerate = 60, beatMs, deltaTime, offset;
		private int _timeStamp = 0;

		private bool _clap = true;

		ISoundEngine engine = new ISoundEngine();
		DebreeSpawner debreeSpawner = new DebreeSpawner();
		MapParser parser = new MapParser("lastSurprise");

		Intercept interceptL;
		Intercept interceptR;

		Scoring score = new Scoring();
		public Beat()
		{
			parser.LoadBeatmap();
			BPM = parser.getBPM();
			offset = parser.getOffset();
			engine.Play2D(parser.getSongPath());

			BPS = BPM / 60;
			FPB = framerate / BPS;
			beatMs = (1000 / BPS) * 1; //The amount of time in ms that needs to pass for 1 beat ADD MULTIPLIER TO MAKE LESS ROCKS APPEAR
			Console.WriteLine("beatMs: " + beatMs);
			deltaTime += offset; //Last Surprise Offset
			
			interceptL = new Intercept(score, true, 20, game.height);
			interceptR = new Intercept(score, false, 20, game.height);
			AddChild(interceptL);
			AddChild(interceptR);

			Console.WriteLine(BPM);

			AddChild(debreeSpawner);
			AddChild(score);
		}

		public void Update()
		{

			if (Input.GetKey(Key.UP)) { deltaTime++; offset++; }
			if (Input.GetKey(Key.DOWN)) { deltaTime--; offset--; }

			deltaTime += Time.deltaTime;
			if (deltaTime > beatMs)
			{
				deltaTime -= beatMs;
				if (parser.GetData(0, _timeStamp) == "1") debreeSpawner.SpawnDebree(-30, game.height / 2, interceptR, beatMs);
				if (parser.GetData(1, _timeStamp) == "1") debreeSpawner.SpawnDebree(game.width + 30, game.height / 2, interceptL, beatMs);
				//clapKick();
				_timeStamp++;
			}
		}

		public void clapKick()
		{
			//if(_clap) engine.Play2D("sounds/clap.ogg");
			//	else engine.Play2D("sounds/kick.ogg");

			if (_clap) interceptL.click();
				else interceptR.click();
			_clap = !_clap;
		}
	}
}
