using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine

public class MyGame : Game
{
	public int level = 0;

	MainMenu menu;
	Scene scene00;
	Scene scene01;
	Scene scene02;
	Scene scene03;

	public MyGame() : base(1366, 768, false, false)
	{
		targetFps = 90;
		Console.Title = "Slapness Nights Output";
		//-----------------------
		menu = new MainMenu();
		AddChild(menu);
		
		//scene00 = new Scene("intro", "assets/background_intro.png");
		//scene01 = new Scene("pleasant", "assets/background_pleasant.png");
		//scene02 = new Scene("unpleasant", "assets/background_unpleasant.png");
		//scene03 = new Scene("hell", "assets/background_hell.png");

		//AddChild(scene00);
	}

	void Update()
	{

	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}