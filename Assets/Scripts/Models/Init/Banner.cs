using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public struct Banner {
	int id;

	// 배너 URL
	string bannerUrl;

	// 설명
	string description;

	// 배너 노출 시작 시간
	DateTime startDt;

	// 배너 노출 종료 시간
	DateTime endDt;
}
