using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {

	public enum EVENT_TYPES {
		OPEN,		// 오픈
		CHOOSE,		// 선택
		EXCHANGE	// 교환
	}

	public int id;
	public string message;
}
