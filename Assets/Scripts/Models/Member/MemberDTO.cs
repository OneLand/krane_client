using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MemberDTO {
	public enum MEMBER_STATUS {
		UNREGISTERED,
		REGISTERED,
		ABUSER
	}
	public enum MEMBER_TYPE {
		GUEST,
		MEMBER,
		GOOGLE,
		FACEBOOK
	}

	int coin;
	List<CouponDTO> couponList;
	int memberId;
	MEMBER_STATUS memberStatus;
	MEMBER_TYPE memberType;
	int ruby;
}
