using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class scene1 : Sprite
	{
		//		||All ints & floats all that bs||
		private int frames = 0, beatInt = 45;
		private int _boxSize = 100, _debreeIndex = 0;
		//		||All object initialization||
		Sprite guy = new Sprite("guy.png", true, false);
		Sprite raster = new Sprite("grid.png", true, false);
		AnimationSprite orbFade = new AnimationSprite("orb_fade.png", 7, 6, addCollider: false);
		Debree rock;
		List<Debree> debreeList = new List<Debree>(); //Creates the Debree ArrayList
		EasyDraw canvas;
		Random rnd = new Random();

		public scene1() : base("background2.png", false, false)
		{
			//AddChild(raster);
			AddChild(guy); //Temporary Sprite in the center of the scene
			AddChild(orbFade);

			for (int i = 0; i < 0; i++) //Spawns in the 6 hitboxes that would later be used for collision (REPLACE WITH 2 BARS INSTEAD OF HITBOX)
			{																		//Is to be replaced by 2 verticle shieldy bois
				CreateHitter(game.width / 4, (game.height / 4) * (i + 1));			//Is to be replaced by 2 verticle shieldy bois	
				CreateHitter((game.width / 4) * 3, (game.height / 4) * (i + 1));	//Is to be replaced by 2 verticle shieldy bois
			}																		//Is to be replaced by 2 verticle shieldy bois

			guy.x = game.width / 2 - guy.width / 2;
			guy.y = game.height / 2 - guy.height / 2;
			orbFade.x = 10;
			orbFade.y = 10;
		}

		public void Update()
		{
			kbHandler();
			//beatHandler();

		
		}
		public void kbHandler() //Handles all the keyboard inputs
		{
			if (Input.GetKey(Key.UP)) beatInt++;
			if (Input.GetKey(Key.DOWN)) beatInt--;
			if (Input.GetKeyDown(Key.SPACE)) SpawnDebree(rnd.Next(0, game.width), rnd.Next(0, game.height));
		}

		public void beatHandler() //Handles all beat related calculation (And at the moment also a fade-y boi)
		{
			frames++;
			if (orbFade.currentFrame < orbFade.frameCount - 1) orbFade.NextFrame();
			if (frames >= beatInt)
			{
				orbFade.currentFrame = 0;
				frames = 0;
			}
		}

		public void CreateHitter(int hitX, int hitY) //Create a hitbox with the canvas system
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

		public void SpawnDebree(float x, float y) //Spawns a piece of debree inside an arrayList to be filled with debree
		{
			rock = new Debree(x, y, game.width / 2, game.height / 2, 5);
			debreeList.Add(rock);
			AddChild(debreeList[_debreeIndex]);
			_debreeIndex++;
		}

	}
}
