using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StoreItem {
	public enum ITEM_PAY_TYPE {
		INAPP,
		RUBY,
		COIN,
		FREE
	}

	int id;
	bool enable;
	ITEM_PAY_TYPE itemPayType;
	string bname;
	int value;
}
