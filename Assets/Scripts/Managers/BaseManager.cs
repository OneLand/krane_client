using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

	protected ApiManager apiManager;
	protected CanvasManager canvasManager;

	// Use this for initialization
	protected void Start () {
		if (apiManager == null) {
			apiManager = this.gameObject.AddComponent<ApiManager> ();
		}
		if (canvasManager == null) {
			canvasManager = this.gameObject.AddComponent<CanvasManager> ();
			canvasManager.Init ();
		}
	}
}
