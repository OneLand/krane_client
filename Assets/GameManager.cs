using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

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
		StartCoroutine (apiManager.SendRequest (apiManager.INIT_ENV_REQ, (httpResponse) => {
			InitEnvResponseHandler(httpResponse);
		}));
	}

	void InitEnvResponseHandler(string response) {
		InitEnvResponse initEnvRes = JsonUtility.FromJson<InitEnvResponse> (response);
		Debug.Log ("response: " + response);
		AppInfo appInfo = initEnvRes.body;
		if (!appInfo.available) {
			Debug.LogError ("Not available server.");
			return;
		}
		// check update.
//		if (appInfo.checkUpdate) {
			if (appInfo.recentVersion > Global.APP_VERISON) {
				if (appInfo.requireMinVersion > Global.APP_VERISON) {
					EditorUtility.DisplayDialog ("Update", "새로운 버전이 업데이트 되었습니다.", "확인");
					// TODO: 강제 업데이트 
					Debug.Log ("Go app store.");
				} else {
					// TODO: 앱 업데이트를 하시겠습니까? POPUP
					// 게임진행은 됨
					if (EditorUtility.DisplayDialog ("Update", "업데이트가 필요합니다.", "확인", "다음에 하기")) {
						Debug.Log ("Go app store.");
					} else {
						Debug.Log ("Game Play!");
					}
				}
			}
//		} else {
//			Debug.Log ("Game Play!");
//		}
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
