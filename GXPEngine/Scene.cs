namespace GXPEngine
{
	class Scene : Sprite
	{
		public Scene(string mapName) : base("assets/background_pleasant.png", false, false)
		{
			Beat beatSystem = new Beat(mapName);
			AddChild(beatSystem);
			Health healthbar = new Health(5, beatSystem);
			AddChild(healthbar);
		}
	}
}
