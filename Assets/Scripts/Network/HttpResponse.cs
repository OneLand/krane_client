using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HttpResponse {

	public enum STATUS_CODES {
		OK						= 0,
		NOT_ACCEPTABLE			= 406,
		INTERNAL_SERVER_ERROR	= 500,
		NOT_FOUND				= 404,

		NETWORK_ERROR			= 10000
	}

	public int status;
	public string message;
	public AppInfo body;
}
