using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour {

	public string META_DATA_URL = "http://gachadoll.cafe24.com/test/api";

	public HttpClient httpClient;

	public string GetMetaData() {
		WWW www = httpClient.GET (META_DATA_URL);
		if (www.error != null) {
			return www.error;
		} else {
			return www.text;
		}
	}

	public IEnumerator GetText(System.Action<string> callback)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(META_DATA_URL))
		{
			yield return request.Send();

			if (request.isError) // Error
			{
				callback (request.error);
			}
			else // Success
			{
				callback (request.downloadHandler.text);
			}
		}
	}
}
