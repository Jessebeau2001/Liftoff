namespace GXPEngine
{
	class scene1 : EasyDraw
	{
		Health healthbar = new Health(5);

		public scene1() : base(20, 20)
		{
			
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
	}
}
