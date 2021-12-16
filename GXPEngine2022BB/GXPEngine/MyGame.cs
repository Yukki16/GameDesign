using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using TiledMapParser;
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	//Player player;
	//Map mapTest;
	GXPEngine.Scenes.SceneManager sceneManager;
	
	public MyGame() : base(1024/2, 576/2, false, false, 1024, 576, true)		// Create a window that's 800x600 and NOT fullscreen
	{
		//camera = new Camera(0,0, 1024/2, 576/2);
		//AddChild(camera);
		sceneManager = new GXPEngine.Scenes.SceneManager("MainMenu");
		AddChild(sceneManager);

		//Sprite sprite = new Player(null);
		//AddChild(sprite);
		//sprite.x = 100;
		//sprite.y = 100;
		
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		//sceneManager.x = -sceneManager.level1.player.x +width/2;
		//sceneManager.y = -sceneManager.level1.player.y + height/2;
		
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}