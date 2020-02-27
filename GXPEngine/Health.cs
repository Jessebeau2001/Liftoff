
namespace GXPEngine
{
	class Health : Pivot
	{
		Sprite[] hearts;
		private int distance = 0, amount;

		public Health(int amount) : base()
		{
			hearts = new Sprite[amount];
			this.amount = amount;
			for (int i = 0; i < hearts.Length; i++)
			{
				hearts[i] = new Sprite("assets/hearth.png", false);
				hearts[i].scale = .7f;
				hearts[i].x -= (hearts.Length*hearts[i].width + distance) / 2;
				hearts[i].x += i * hearts[i].width + distance;
				AddChild(hearts[i]);
			}
		}

		public void getDamage()
		{
			if (amount == 0) return;
			hearts[amount - 1].LateDestroy();
			amount--;
		}
	}
}
