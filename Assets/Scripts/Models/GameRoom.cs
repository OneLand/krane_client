using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 게임방 정보
 */
public class GameRoom {

	public enum GOODS_TYPES {
		RUBY,
		COIN
	}

	public GOODS_TYPES goodsType;
	public string rewardName;
	public string rewardImageUrl;
	public string rewardSize;
	public string rewardDescription;

	public int observers;
	public int reservers;
	public int lefts;
}
