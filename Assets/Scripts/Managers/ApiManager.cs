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
	public static HttpRequest INIT_ENV_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/init/env");

	/// <summary>
	/// Controlling in Ingame.
	/// </summary>
	/* Joystick : 방향키 Relay */
	public static HttpRequest CONTROL_DIRECTION_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/control/direction");

	/// <summary>
	/// 멤버정보
	/// </summary>
	/* 
	 * 전화번호로 멤버 조회 
	 * @Param: num(string)
	 */
	public static HttpRequest MEMBER_PHONE_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/member/phone");

	/* 
	 * 멤버 가입
	 * @Param: body(RegisgterBody struct as JSON)
	 */
	public static HttpRequest MEMBER_REGISTER_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.POST, "http://gachadoll.cafe24.com/member/register");
	/* 
	 * 멤버 Id로 멤버 조회
	 * @Path Param: memberId(integer)
	 */
	public static HttpRequest MEMBER_GET_REQ = new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/member/register/{0}");

	// Login
	public static HttpRequest LOGIN_URL		= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/login");

	// Lobby
	public static HttpRequest LOBBY_ROOM_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/lobby/room");

	// Store
	public static HttpRequest STORE_LIST_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/store/list");

	// MyInfo
	public static HttpRequest MYINFO_URL		= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/myinfo");
	public static HttpRequest MYINFO_SET_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/myinfo/set");

	// Postbox
	public static HttpRequest POSTBOX_LIST_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/postbox/list");
	public static HttpRequest POSTBOX_POST_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/postbox/post");

	// Ranking
	public static HttpRequest RANKING_LIST_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/ranking/list");

	// Setting
	public static HttpRequest SETTING_URL		= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/gameroom");
	public static HttpRequest SETTING_SET_URL	= new HttpRequest(HttpRequest.HTTP_METHOD.GET, "http://gachadoll.cafe24.com/gameroom/set");

	// Define status code
	public static int STATUS_CODE_OK			= 200;
	public static int STATUS_CODE_NEED_RELOGIN	= 401;

	// Member Variables
	private GameManager gameManager;

	void Start() {
		gameManager = GetComponent<GameManager> ();
	}

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
				if (httpRes.status == STATUS_CODE_OK) {
					// Success
					callback (response);
				} else if (httpRes.status == STATUS_CODE_NEED_RELOGIN) {
					// Re login...
					gameManager.ShowLogin();
				} else {
					// Failed
					Debug.LogWarning(JsonUtility.ToJson (httpRes));
				}
			}
		}
	}

	private HttpResponse getResponse(HttpRequest httpRequest, UnityWebRequest unityWebRequest) {
		if (httpRequest.Equals (INIT_ENV_REQ)) {
			HttpResponse httpRes = JsonUtility.FromJson<HttpResponse> (unityWebRequest.downloadHandler.text);
			return httpRes;
//			return JsonUtility.FromJson<InitEnvResponse> (unityWebRequest.downloadHandler.text);
		}
		return null;
	}
}
