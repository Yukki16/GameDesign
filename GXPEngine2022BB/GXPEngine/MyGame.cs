using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using TiledMapParser;
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	GXPEngine.Scenes.SceneManager sceneManager;

	// TO DO LIST
	/*
	 1.Refactor the player movement
	 2.Add the settings and choose level menus
	 3.Add music
	 
	 */
	
	public MyGame() : base(1024/2, 576/2, false, false, 1024, 576, true)
	{
		
		sceneManager = new GXPEngine.Scenes.SceneManager();
		AddChild(sceneManager);

		sceneManager.LoadLevel("MainMenu");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		
		if(Input.GetKeyDown(Key.K))
        {
            Console.WriteLine(GetDiagnostics());
        }
		
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}