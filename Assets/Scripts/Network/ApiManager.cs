using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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

	public IEnumerator SendRequest(HttpRequest httpRequest, System.Action<HttpResponse> callback)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(httpRequest.url))
		{
			yield return request.Send();

			if (request.isError) {
				// Error
				HttpResponse httpResponse = new HttpResponse ();
				httpResponse.status = (int)HttpResponse.STATUS_CODES.NETWORK_ERROR;
				callback (httpResponse);
			}
			else {
				// Success
				Debug.Log("### request.downloadHandler.text: " + request.downloadHandler.text);
				HttpResponse httpResponse = JsonUtility.FromJson<HttpResponse> (request.downloadHandler.text);
				Debug.Log ("### Status: " + httpResponse.status);
				Debug.Log ("### Message: " + httpResponse.message);
				Debug.Log ("### Body: " + httpResponse.body.ToString());
				callback (JsonUtility.FromJson<HttpResponse> (request.downloadHandler.text));
			}
		}
	}
}
