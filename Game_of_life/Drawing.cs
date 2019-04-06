namespace Game_of_life
{
	class Drawing
	{
		
		public static void DrawAll  ()
		{
			Colony.ColonyCheck();
			Colony.DrawColony();
			Colony.UpdateColony();
		}
	}
}
