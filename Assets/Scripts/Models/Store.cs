using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 상점 정보
 */
public class Store {
	public enum STORE_TYPES {
		COIN,
		RUBY,
		VOUCHER
	}

	public int id;
	public string imageUrl;
	public string reward;
	public string price;
}
