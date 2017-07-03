using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AppInfo {	
	// 서비스 활성 여부
	[SerializeField]
	public bool available;

	// 업데이트 여부 (버전 체크 필요)
	[SerializeField]
	public bool checkUpdate;

	// 현재 알고있는 최신 버전
	[SerializeField]
	public int recentVersion;

	// 지원하는 최소 버전
	[SerializeField]
	public int requireMinVersion;

	[SerializeField]
	public List<Banner> banners;

	public override string ToString() {
		return "available: " + available + ", checkUpdate: " + checkUpdate + ", recentVersion: " + recentVersion +
		", requireMinVersion: " + requireMinVersion;
	}
}
