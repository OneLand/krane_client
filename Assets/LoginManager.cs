using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour {

	public enum LOGIN_TYPES {
		LOGIN_TYPE_GOOGLE,
		LOGIN_TYPE_FACEBOOK,
		LOGIN_TYPE_GUEST
	}

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoginByGoogle() {
		Debug.Log ("LoginByGoogle");
	}

	public void LoginByFacebook() {
		Debug.Log ("LoginByFacebook");
	}

	public void LoginByGuest() {
		Debug.Log ("LoginByGuest");
		gameManager.Login (LOGIN_TYPES.LOGIN_TYPE_GUEST);
	}
}
