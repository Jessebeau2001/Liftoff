namespace GXPEngine
{
	class MainMenu : Sprite
	{
		private int frames = 100, doOnce = 0;
		private bool fadeOut = false;

		Scene intro;

		public MainMenu() : base("assets/main_menu.png", true, false)
		{

		}

		public void Update()
		{
			if (Input.GetKeyDown(Key.SPACE) && doOnce == 0) fadeOut = true;

			if (fadeOut) FadeOut();
		}

		public void FadeOut()
		{
			alpha -= alpha / frames;
			frames--;
			if (frames <= 0)
			{
				doOnce++;
				fadeOut = false;
				intro = new Scene("intro", "assets/background_intro.png");
				LateAddChild(intro);
			}
		}
	}
}
