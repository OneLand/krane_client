using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HttpRequest {

	public enum HTTP_METHOD {
		GET,
		POST,
		PUT,
		DELETE
	}

	public HttpRequest(HTTP_METHOD httpMethod, string url) {
		this.method = httpMethod;
		this.url = url;
	}

	public void addParam(string key, object value) {
		this.bodyParam.Add (key, value);
	}

	public HTTP_METHOD method;
	public string url;
	public Dictionary<string, object> bodyParam = new Dictionary<string, object>();
}
