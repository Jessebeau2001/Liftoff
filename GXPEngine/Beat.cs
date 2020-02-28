using System;
using IrrKlang;

namespace GXPEngine
{
	class Beat : Pivot
	{
		public float BPM = 120 , BPS, FPB, framerate = 60, beatMs, deltaTime, offset;
		private int _timeStamp = 0;
		private bool _clap = false;

		private bool devToolsEnabled = false;

		ISoundEngine engine = new ISoundEngine();
		DebreeSpawner debreeSpawner = new DebreeSpawner();
		MapParser parser;

		Intercept interceptL;
		Intercept interceptR;

		Scoring score = new Scoring();

		public Beat(string mapName)
		{
			parser = new MapParser(mapName);
			parser.LoadBeatmap();
			BPM = parser.getBPM();
			offset = parser.getOffset();
			engine.Play2D(parser.getSongPath());

			BPS = BPM / 60;
			FPB = framerate / BPS;
			beatMs = (1000 / BPS) * 1;
			deltaTime += offset;
			
			interceptL = new Intercept(score, true, 20, game.height);
			interceptR = new Intercept(score, false, 20, game.height);
			AddChild(interceptL);
			AddChild(interceptR);

			AddChild(debreeSpawner);
			AddChild(score);
			}

		public void Update()
		{
			//----------------------------
			if (devToolsEnabled) {
			if (Input.GetKeyDown(Key.UP)) { deltaTime++; offset++; }
			if (Input.GetKeyDown(Key.DOWN)) { deltaTime--; offset--; }
			Console.WriteLine("Current selected offset: " + offset); }
			//----------------------------

			deltaTime += Time.deltaTime;
			if (deltaTime > beatMs)
			{
				deltaTime -= beatMs;
				if (parser.GetData(0, _timeStamp) == "1") debreeSpawner.SpawnDebree(-30, game.height / 2, interceptR, beatMs);
				if (parser.GetData(1, _timeStamp) == "1") debreeSpawner.SpawnDebree(game.width + 30, game.height / 2, interceptL, beatMs);
				//----------------------------
				if (devToolsEnabled) clapKick();
				//----------------------------
				_timeStamp++;
			}
		}

		public void clapKick()
		{
			if (_clap) interceptL.click();
				else interceptR.click();
			_clap = !_clap;
		}

		public void StopSound()
		{
			engine.StopAllSounds();
		}
	}
}
