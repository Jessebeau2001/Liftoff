using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Xml;

public class MyGame : Game
{
	Scene scene00;
	Scene scene01;
	Scene scene02;
	Scene scene03;

	public MyGame() : base(1366, 768, false, false)
	{
		targetFps = 90;
		Console.Title = "Slapness Nights Output";

		//scene00 = new Scene("intro");
		scene01 = new Scene("pleasant");
		//scene02 = new Scene("unpleasant");
		//scene03 = new Scene("hell");
		
		AddChild(scene01);
	}

	void Update()
	{		
		
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}