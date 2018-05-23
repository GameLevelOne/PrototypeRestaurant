using UnityEngine;

public static class Constants {

	public static class PrefKey
	{
		public static class Ints
		{
			public const string HAS_RESULT = "HasResult";
			public const string IS_TRAINING = "IsTraining";


		}
		public static class Strings
		{
			public const string LAST_RESULT_EXPIRED_DATE = "LastResultExpiredDate";
			public const string SCENE_TO_LOAD = "SceneToLoad";

		}
		public static class Floats
		{
			public const string LAST_RESULT_AMOUNT = "LastResultAmount";
		}
	}

	public static class SceneName
	{
		public const string SCENE_MAIN = "SceneMain";
		public const string SCENE_GAME1 = "Game1";
		public const string SCENE_GAME2 = "Game2";
		public const string SCENE_GAME3 = "Game3";
		public const string SCENE_PRELOAD = "ScenePreload";
	}
}