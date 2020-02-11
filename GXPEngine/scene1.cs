using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class scene1 : Sprite
	{
		private int frames = 0, beatInt = 45; 
		Sprite orb = new Sprite("orb_fade03.png", false);
		AnimationSprite orbFade = new AnimationSprite("orb_fade.png", 7, 6, addCollider: false);

		public scene1() : base("whiteBG.png", false, false)
		{
			AddChild(orbFade);
			orbFade.x = 10;
			orbFade.y = 10;
			//orbFade.currentFrame = orbFade.frameCount;
			
		}


		public void Update()
		{
			if (Input.GetKey(Key.UP))
			{
				beatInt++;
			}
			if (Input.GetKey(Key.DOWN))
			{
				beatInt--;
			}

			beatHandler();

			Console.WriteLine("beatInt: " + beatInt + ", frames: " + frames + ", orbFade frame: " + orbFade.currentFrame);
		}

		public void beatHandler()
		{
			frames++;
			if (orbFade.currentFrame < orbFade.frameCount - 1)
			{
				orbFade.NextFrame();
			}

			if (frames >= beatInt)
			{
				orbFade.currentFrame = 0;
				frames = 0;
			}
		}
	}
}
