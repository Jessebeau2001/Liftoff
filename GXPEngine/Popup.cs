using System.Drawing;

namespace GXPEngine
{
	class Popup : EasyDraw
	{
		private float tSize = 35f, tSizeExp = .1f;
		private string score;


		public Popup(float x, float y, string score) : base(200, 200)
		{
			this.x = x;
			this.y = y;
			this.score = score;

			TextAlign(CenterMode.Center, CenterMode.Center);
		}

		public void Update()
		{
			Clear(Color.Transparent);
			TextSize(tSize);
			Text(score, width / 2, height / 2);
			tSizeExp *= 1.03f;
			tSize -= tSizeExp;
			if (tSize < 1) Destroy();
		}
	}
}
