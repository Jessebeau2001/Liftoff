using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Beat : Sprite
	{
		public int BPM = 180 , BPS, FPB, framerate = 60; //BPM: Beats Per Minute; BPS: Beats Per Second; FPB = Frames Per Beat
		private int _frame = 0, deltaTime;

		//SoundChannel soundEngine;
		Sound kick = new Sound("kick.ogg", false, true);

		public Beat() : base("rock.png")
		{
			x = 300;
			y = 300;
			BPS = BPM / 60;			// 180 / 60 = 3 beats / second
			FPB = framerate / BPS;	// 60 / 3 = 20 frames / beat
		}

		public void Update()
		{
			if (Input.GetKeyDown(Key.P)) kick.Play();

			deltaTime += Time.deltaTime;
			Console.WriteLine("Ellapsed time: " + deltaTime + ", Current frame: " + _frame);

			if (deltaTime >= 1000 / BPS)
			{
				rotation += 90;
				deltaTime = 0;
				kick.Play();
				//Console.WriteLine("BPM: " + BPM + " BPS: " + BPS + " FPB: " + FPB);
			}
		}
	}
}
