using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Xml;

public class MyGame : Game
{
	scene1 sceneTest;
	Beat beatSystem;
	Scoring score;

	public MyGame() : base(1366, 768, false)        // Create a window that's 800x600 and NOT fullscreen
	{
		Console.Title = "Slapness Nights Output";

		sceneTest = new scene1();
		beatSystem = new Beat();
	}

	void Update()
	{
		if (Input.GetKey(Key.ENTER)) 
		{
			AddChild(sceneTest);
			AddChild(beatSystem);
		}
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}