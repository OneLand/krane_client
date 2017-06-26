using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public ApiManager apiManager;
	public CanvasManager canvasManager;

	// Use this for initialization
	void Start () {
		// 현재 로그인은 Guest만 지원
		GameObject googleLoginBtn = GameObject.Find ("LoginCanvas/GoogleLoginBtn");
		googleLoginBtn.GetComponent<Button> ().interactable = false;
		googleLoginBtn = GameObject.Find ("LoginCanvas/FacebookLoginBtn");
		googleLoginBtn.GetComponent<Button> ().interactable = false;

		canvasManager.Show (CanvasManager.CANVAS_TYPES.CANVAS_TYPE_LOGIN);
		// App Initialzing data 획득
		if (apiManager != null) {
			StartCoroutine (apiManager.SendRequest (apiManager.INIT_ENV_REQ, (httpResponse) => {
				InitEnvResponseHandler(httpResponse);
			}));
		} else {
			// ErrorCode에 의한 팝업
			Debug.LogError ("apiManager is NULL.");
		}
	}

	void InitEnvResponseHandler(HttpResponse httpResponse) {
		Debug.Log ("response: " + httpResponse.body);
//		AppInfo appInfo = JsonUtility.FromJson<AppInfo>(httpResponse.body);
//		Debug.Log ("appInfo: " + JsonUtility.ToJson(appInfo));
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Login(LoginManager.LOGIN_TYPES loginType) {
		// Show game room canvas
		canvasManager.Show (CanvasManager.CANVAS_TYPES.CANVAS_TYPE_GAME_ROOM);

		// Disable event left/right buttons
		GameObject arrowButton = GameObject.Find ("GameRoomCanvas/EventCanvas/LeftButton");
		arrowButton.GetComponent<Button> ().interactable = false;
		arrowButton = GameObject.Find ("GameRoomCanvas/EventCanvas/RightButton");
		arrowButton.GetComponent<Button> ().interactable = false;

		// Disable game mode left/right buttons
		arrowButton = GameObject.Find ("GameRoomCanvas/ModeCanvas/LeftButton");
		arrowButton.GetComponent<Button> ().interactable = false;
		arrowButton = GameObject.Find ("GameRoomCanvas/ModeCanvas/RightButton");
		arrowButton.GetComponent<Button> ().interactable = false;
	}

}
