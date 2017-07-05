using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : BaseManager {

	void Start() {
		base.Start ();
	}

	public enum LOGIN_TYPES {
		LOGIN_TYPE_GOOGLE,
		LOGIN_TYPE_FACEBOOK,
		LOGIN_TYPE_GUEST
	}
		
	public GameManager gameManager;

	public void LoginByGoogle() {
		Debug.Log ("LoginByGoogle");
	}

	public void LoginByFacebook() {
		Debug.Log ("LoginByFacebook");
	}

	public void LoginByGuest() {
		Debug.Log ("LoginByGuest");
		// App Initialzing data 획득
		StartCoroutine (apiManager.SendRequest (ApiManager.LOGIN_URL, (httpResponse) => {
			LoginResponseHandler(httpResponse);
		}));
	}

	//////////////////////////////////////////////////////////////////////
	/// API Response Handlers
	//////////////////////////////////////////////////////////////////////
	void LoginResponseHandler(string response) {
		Debug.Log ("called LoginResponseHandler()");
	}
}
