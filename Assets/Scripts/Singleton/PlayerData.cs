using System;
using UnityEngine;

public class PlayerData : MonoBehaviour {
	protected static PlayerData instance = null;
	public static PlayerData Instance{
		get{ return instance; }
	}

	protected void Awake()
	{
		if(instance != null && instance != this) Destroy(gameObject);
		else instance = this;

		DontDestroyOnLoad(this.gameObject);
	}
		
	#region setter getter
	public bool HasResult{
		get{ return PlayerPrefs.GetInt(Constants.PrefKey.Ints.HAS_RESULT,0) == 0 ? false : true; }
		set{ PlayerPrefs.SetInt(Constants.PrefKey.Ints.HAS_RESULT,value == false ? 0 : 1); }
	}

	public bool IsTraining{
		get{ return PlayerPrefs.GetInt(Constants.PrefKey.Ints.IS_TRAINING,0) == 0 ? false : true; }
		set{ PlayerPrefs.SetInt(Constants.PrefKey.Ints.IS_TRAINING,value == false ? 0 : 1); }
	}

	public float LastResultAmount{
		get{ return PlayerPrefs.GetFloat(Constants.PrefKey.Floats.LAST_RESULT_AMOUNT,0f); }
		set{ PlayerPrefs.SetFloat(Constants.PrefKey.Floats.LAST_RESULT_AMOUNT,value); }
	}

	public DateTime LastResultDate{
		get{ return DateTime.Parse( PlayerPrefs.GetString ( Constants.PrefKey.Strings.LAST_RESULT_EXPIRED_DATE,DateTime.Now.ToString() ) ); }
		set{ PlayerPrefs.SetString( Constants.PrefKey.Strings.LAST_RESULT_EXPIRED_DATE,value.ToString() ); }
	}
	#endregion
}
