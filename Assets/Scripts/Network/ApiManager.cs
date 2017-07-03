using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;

public class ApiManager : MonoBehaviour {
	/// <summary>
	/// Application initalizing api.
	/// </summary>
	/* Init : 클라이언트 초기 정보 요청 */
	public HttpRequest INIT_ENV_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/init/env");

	/// <summary>
	/// Controlling in Ingame.
	/// </summary>
	/* Joystick : 방향키 Relay */
	public HttpRequest CONTROL_DIRECTION_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/control/direction");

	/// <summary>
	/// 멤버정보
	/// </summary>
	/* 
	 * 전화번호로 멤버 조회 
	 * @Param: num(string)
	 */
	public HttpRequest MEMBER_PHONE_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/member/phone");

	/* 
	 * 멤버 가입
	 * @Param: body(RegisgterBody struct as JSON)
	 */
	public HttpRequest MEMBER_REGISTER_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.POST, "http://gachadoll.cafe24.com/member/register");
	/* 
	 * 멤버 Id로 멤버 조회
	 * @Path Param: memberId(integer)
	 */
	public HttpRequest MEMBER_GET_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.POST, "http://gachadoll.cafe24.com/member/register/{0}");

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

	public IEnumerator SendRequest(HttpRequest httpRequest, System.Action<string> callback)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(httpRequest.url))
		{
			yield return request.Send();

			if (request.isError) {
				// Error
				Debug.LogWarning("Request is error.");
//				HttpResponse httpResponse = new HttpResponse();
//				httpResponse.status = (int)HttpResponse.STATUS_CODES.NETWORK_ERROR;
//				callback (httpResponse);
			} else {
				string response = request.downloadHandler.text;
				HttpResponse httpRes = JsonUtility.FromJson<HttpResponse> (response);
				if (httpRes.status == 200) {
					// Success
					callback (response);
				} else {
					// Failed
					Debug.LogWarning(JsonUtility.ToJson (httpRes));
				}
			}
		}
	}

	private HttpResponse getResponse(HttpRequest httpRequest, UnityWebRequest unityWebRequest) {
		if (httpRequest.Equals (INIT_ENV_REQ)) {
			Debug.Log("It's INIT_ENV_REQ");
			HttpResponse httpRes = JsonUtility.FromJson<HttpResponse> (unityWebRequest.downloadHandler.text);
			return httpRes;
//			return JsonUtility.FromJson<InitEnvResponse> (unityWebRequest.downloadHandler.text);
		}
		return null;
	}

	private void testJson() {
		var enemies = new List <Enemy> ();
		enemies.Add ( new Enemy ( "슬라임" , new List < string > () { "공격" }));
		enemies.Add ( new Enemy ( "킹 슬라임" , new List < string > () { "공격" , "회복" }));
		Debug.Log (JsonUtility.ToJson (enemies));

		// List <T> -> Json 문자열 (예 : List <Enemy>) 
		string str = JsonUtility.ToJson ( new Serialization <Enemy> (enemies)); // 출력 : { "target": [{ "name ":"슬라임 ","skills ":"공격 "]}, {"name ":"킹 슬라임 ","skills ":"공격 ","회복 "]}]} 
		Debug.Log(str);
		// Json 문자열 -> List <T>
		List <Enemy> enemyList = JsonUtility.FromJson <Serialization <Enemy >> (str) .ToList ();
		Debug.Log (enemyList);

	}
}
