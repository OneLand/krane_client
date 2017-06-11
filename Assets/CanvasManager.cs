using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

	public enum CANVAS_TYPES {
		CANVAS_TYPE_COMMON,		// (상단 재화 + 하단 탭)
		CANVAS_TYPE_LOGIN,
		CANVAS_TYPE_GAME_ROOM,	// 메인 게임
		CANVAS_TYPE_STORE,
		CANVAS_TYPE_MYINFO,
		CANVAS_TYPE_POSTBOX,
		CANVAS_TYPE_RANKING,
		CANVAS_TYPE_SETTING
	}

	private Dictionary<CANVAS_TYPES, GameObject> canvasMap;

	private CANVAS_TYPES currentShowingCanvasType;

	// Use this for initialization
	void Start () {
		canvasMap = new Dictionary<CANVAS_TYPES, GameObject> ();
		RegistAllCanvasObjects ();
	}

	private void RegistAllCanvasObjects() {
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_COMMON, GameObject.Find ("CommonCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_LOGIN, GameObject.Find ("LoginCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_GAME_ROOM, GameObject.Find ("GameRoomCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_STORE, GameObject.Find ("StoreCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_MYINFO, GameObject.Find ("MyInfoCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_POSTBOX, GameObject.Find ("PostboxCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_RANKING, GameObject.Find ("RankingCanvas"));
		canvasMap.Add (CANVAS_TYPES.CANVAS_TYPE_SETTING, GameObject.Find ("SettingCanvas"));
	}

	public void Show(CANVAS_TYPES targetCanvasType) {
		GameObject targetCanvas;
		canvasMap.TryGetValue (targetCanvasType, out targetCanvas);
		if (targetCanvas) {
			for (int i = 0; i < canvasMap.Count; ++i) {
				Dictionary<CANVAS_TYPES, GameObject>.Enumerator enumerator = canvasMap.GetEnumerator ();
				while (enumerator.MoveNext ()) {
					if (targetCanvas != enumerator.Current.Value) {
						enumerator.Current.Value.SetActive (false);
					}
				}
			}
			targetCanvas.SetActive (true);
		}

		if (targetCanvasType != CANVAS_TYPES.CANVAS_TYPE_LOGIN) {
			canvasMap.TryGetValue (CANVAS_TYPES.CANVAS_TYPE_COMMON, out targetCanvas);
			targetCanvas.SetActive (true);
		}
	}

	public GameObject GetCanvas(CANVAS_TYPES canvasType) {
		GameObject returnCanvas;
		canvasMap.TryGetValue (canvasType, out returnCanvas);
		return returnCanvas;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
