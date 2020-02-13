using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class scene1 : Sprite
	{
		private int frames = 0, beatInt = 45;
		private int _boxSize = 100, _debreeIndex = 0;

		Sprite guy = new Sprite("guy.png", true, false);
		Sprite raster = new Sprite("grid.png", true, false);
		AnimationSprite orbFade = new AnimationSprite("orb_fade.png", 7, 6, addCollider: false);

		Debree rock;
		List<Debree> debreeList = new List<Debree>();

		EasyDraw canvas;
		public scene1() : base("beta_background.png", false, false)
		{
			//AddChild(raster);
			AddChild(guy);
			AddChild(orbFade);
			
			//for (int i = 0; i < 6; i++)
			//{
			//	rock = new Debree(0, 300 * i, game.width / 2, game.height / 2, 5);
			//	debreeList.Add(rock);
			//	AddChild(debreeList[i]);
			//}

			for (int i = 0; i < 3; i++)
			{
				CreateHitter(game.width / 4, (game.height / 4) * (i + 1));
				CreateHitter((game.width / 4) * 3, (game.height / 4) * (i + 1));
			}

			guy.x = game.width / 2 - guy.width / 2;
			guy.y = game.height / 2 - guy.height / 2;
			orbFade.x = 10;
			orbFade.y = 10;
		}

		public void Update()
		{
			kbHandler();
			//beatHandler();

			Console.WriteLine("beatInt: " + beatInt + ", frames: " + frames + ", orbFade frame: " + orbFade.currentFrame);
		}
		public void kbHandler()
		{
			if (Input.GetKey(Key.UP)) beatInt++;
			if (Input.GetKey(Key.DOWN)) beatInt--;

			if (Input.GetKeyDown(Key.SPACE)) SpawnDebree();


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

		public void CreateHitter(int hitX, int hitY)
		{
			canvas = new EasyDraw(_boxSize, _boxSize);
			canvas.ShapeAlign(CenterMode.Min, CenterMode.Min);
			canvas.Stroke(14, 255, 0, 255);
			canvas.StrokeWeight(10);
			canvas.NoFill();
			canvas.Rect(0, 0, _boxSize, _boxSize);
			canvas.x = hitX - (_boxSize/2);
			canvas.y = hitY - (_boxSize/2);
			AddChild(canvas);
		}

		public void SpawnDebree()
		{
			rock = new Debree(0, 500, game.width / 2, game.height / 2, 5);
			debreeList.Add(rock);
			AddChild(debreeList[_debreeIndex]);
			_debreeIndex++;
		}

	}
}
