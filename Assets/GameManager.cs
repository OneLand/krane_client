using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public ApiManager apiManager;

	// Use this for initialization
	void Start () {
		if (apiManager != null) {
			StartCoroutine (apiManager.GetText ((returnValue) => {
				Debug.Log (returnValue);
			}));
		} else {
			Debug.LogError ("apiManager is NULL.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
;