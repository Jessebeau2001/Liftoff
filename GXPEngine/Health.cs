	namespace GXPEngine
{
	class Health : EasyDraw
	{
		Sprite[] hearts;
		Beat beatsystem;
		private int distance = 0, amount;

		public Health(int amount, Beat beatsystem) : base(20, 20)
		{
			this.beatsystem = beatsystem;
			x = (game.width / 2);
			y = (game.height / 2);
			Rect(0, 0, 20, 20);

			hearts = new Sprite[amount];
			this.amount = amount;
			for (int i = 0; i < hearts.Length; i++)
			{
				hearts[i] = new Sprite("assets/hearth.png", false);
				hearts[i].scale = .7f;
				hearts[i].x -= (hearts.Length*hearts[i].width + distance) / 2;
				hearts[i].x += i * hearts[i].width + distance;
				hearts[i].y -= game.height / 2;
				AddChild(hearts[i]);
			}
		}

		public bool getDamage()
		{
			if (amount == 0)
			{
				return true;
			}

			if (amount == 1) GameOver();

			hearts[amount - 1].LateDestroy();
			amount--;
			for (int i = 0; i < hearts.Length; i++)
			{
				hearts[i].x += (hearts[i].width + distance) / 2;
			}
			return true;
		}

		public void GameOver()
		{
			//----------------------------
			//beatsystem.StopSound();
			//----------------------------
		}
	}
}
