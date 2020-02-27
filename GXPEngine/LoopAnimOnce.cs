namespace GXPEngine
{
	class LoopAnimOnce : Pivot
	{
		private int animFrames, elapsedFrames;
		private float rotaSpeed, currentScale, scaleMultiplier, currentOpac, targetOpac;

		Sprite sprite;

		public LoopAnimOnce(Sprite sprite, int animFrames, float rotaSpeed, float currentScale, float scaleMultiplier) : base()
		{
			this.sprite = sprite;
			this.animFrames = animFrames;
			this.rotaSpeed = rotaSpeed;
			sprite.scale = currentScale;
			this.scaleMultiplier = scaleMultiplier;

			x = 200;
			y = 200;

			sprite.SetOrigin(sprite.width / 2, sprite.height / 2);
			AddChild(sprite);
		}

		public void Update()
		{
			rotation += rotaSpeed;
			scale *= scaleMultiplier;
			sprite.alpha -= sprite.alpha / animFrames;
			elapsedFrames++;
			//if (elapsedFrames > animFrames) LateDestroy();
		}
	}
}
