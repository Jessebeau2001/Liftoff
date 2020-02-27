using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Xml;

public class MyGame : Game
{
	Scene01 sceneTest;
	Beat beatSystem;

	public MyGame() : base(1366, 768, false,false)
	{
		targetFps = 90;
		Console.Title = "Slapness Nights Output";
		sceneTest = new Scene01();
		beatSystem = new Beat();
		AddChild(sceneTest);
		AddChild(beatSystem);
	}

	void Update()
	{
		if (Input.GetKeyDown(Key.ENTER)) 
		{
			return;
			if (sceneTest != null)
			{
				sceneTest.LateDestroy();
				beatSystem.LateDestroy();
			}
			sceneTest = new Scene01();
			beatSystem = new Beat();
			AddChild(sceneTest);
			AddChild(beatSystem);
		}
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}