using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public static HUD ins;
	public Text DiceScore, playerInTurn, nextPlayer, autoTrowTxt, autoNextTurnTxt;
	public GameObject nextTurnButton;
	void Awake()
	{
		if(ins == null)
		{
			ins = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
