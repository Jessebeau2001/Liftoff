using System;									// System contains a lot of default C# libraries 
using GXPEngine;								// GXPEngine contains the engine

public class MyGame : Game
{
	scene1 sceneTest;

	public MyGame() : base(1920, 1080, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		sceneTest = new scene1();
		AddChild(sceneTest);

		// Debree rock = new Debree();
		// AddChild(rock);
	}

	void Update()
	{
		// Empty
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}