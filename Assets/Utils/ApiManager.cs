using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour {

	// App Initializing data
	public string META_DATA_URL = "http://gachadoll.cafe24.com/test/api";

	// Login
	public string LOGIN_URL		= "http://gachadoll.cafe24.com/login";

	// Game Room
	public string GAME_ROOM_URL	= "http://gachadoll.cafe24.com/gameroom";

	// Store
	public string STORE_LIST_URL	= "http://gachadoll.cafe24.com/store/list";

	// MyInfo
	public string MYINFO_URL		= "http://gachadoll.cafe24.com/myinfo";
	public string MYINFO_SET_URL	= "http://gachadoll.cafe24.com/myinfo/set";

	// Postbox
	public string POSTBOX_LIST_URL	= "http://gachadoll.cafe24.com/postbox/list";
	public string POSTBOX_POST_URL	= "http://gachadoll.cafe24.com/postbox/post";

	// Ranking
	public string RANKING_LIST_URL	= "http://gachadoll.cafe24.com/ranking/list";

	// Setting
	public string SETTING_URL		= "http://gachadoll.cafe24.com/gameroom";
	public string SETTING_SET_URL	= "http://gachadoll.cafe24.com/gameroom/set";

	public HttpClient httpClient;

	public IEnumerator GetText(System.Action<string> callback)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(META_DATA_URL))
		{
			yield return request.Send();

			if (request.isError) // Error
			{
				callback (request.error);
			}
			else // Success
			{
				callback (request.downloadHandler.text);
			}
		}
	}
}
