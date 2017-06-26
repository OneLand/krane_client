using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 방향키 Relay
 */
public class Direction {

	public enum VALUE {
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public VALUE value;
	public bool move;
}
