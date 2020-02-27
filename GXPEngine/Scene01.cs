namespace GXPEngine
{
	class Scene01 : EasyDraw
	{
		Health healthbar = new Health(5);

		public Scene01() : base(20, 20)
		{
			healthbar.y -= game.height / 2;
			AddChild(healthbar);

			x = game.width / 2;
			y = game.height / 2;

			Rect(0, 0, width, height);
		}

		public bool getDamage()
		{
			healthbar.getDamage();
			return true;
		}

		public void LateDestroy()
		{
			
		}
	}
}
