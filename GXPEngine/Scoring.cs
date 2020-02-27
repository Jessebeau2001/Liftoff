namespace GXPEngine
{
	class Scoring : EasyDraw
	{
		private int _score = 0;
		private string _zero = "000000";

		public Scoring() : base (400, 200, false)
		{
			Text("Score:" + _zero, 60, 60);
		}

		public void Update()
		{
			Clear( 0 );
			Text( "Score:\t" + _zero.Substring(_score.ToString().Length) + _score.ToString(), 20, 60);
		}

		public void changeScore(int score)
		{
			_score += score;
		}
	}
}
