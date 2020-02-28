namespace GXPEngine
{
	class MainMenu : Sprite
	{


		private int frames;
		private bool fadeOut = false;

		public MainMenu() : base("assets/main_menu.png", true, false)
		{

		}

		public void Update()
		{
			if (fadeOut) FadeOut();
		}

		public void FadeOut()
		{
			alpha -= alpha / frames;
			frames--;
		}

		public void StartFade(int frames)
		{
			this.frames = frames;
			fadeOut = true;
		}

		public bool Done()
		{
			if (alpha < 1) return true;
				else return false;
		}
	}
}
