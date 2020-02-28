namespace GXPEngine
{
	class Scene : Pivot
	{
		public Scene(string mapName, string backgroundFile) : base()
		{
			Sprite background = new Sprite(backgroundFile);
			AddChild(background);

			Beat beatSystem = new Beat(mapName);
			AddChild(beatSystem);
			Health healthbar = new Health(5, beatSystem);
			AddChild(healthbar);

			Sprite jeff = new Sprite("assets/jeff.png");
			AddChild(jeff);
		}
	}
}
