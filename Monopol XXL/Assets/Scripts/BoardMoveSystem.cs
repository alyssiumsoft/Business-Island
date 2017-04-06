using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMoveSystem : MonoBehaviour {
	public static BoardMoveSystem ins;
	public List<Field> fields = new List<Field>();
	public List<Player> playersByTurn = new List<Player>();
	public Transform player_1, player_2, player_3, player_4;
	public Transform startPos, EndPos;
	public float speed = 1f, startTime, jurneyLenght;
	public Player playerInMove;
	public bool move, turnInProgress;
	void Awake()
	{
		if (ins == null) {
			ins = this;
		} else {
			Destroy(this.gameObject); 
		}
		HUD.ins.playerInTurn.text = playerInMove.name  + " Turn!";
		HUD.ins.nextPlayer.text = "Next Player - " + playersByTurn [1].name;
	}
	float distance;
	int cPlayer;
	void Update()
	{
		if(move)
		{
			if (playerInMove.currIndex != playerInMove.finalIndex) 
			{
				if(playerInMove.id == 0)
				{
					cPlayer = 0;
				}
				else if(playerInMove.id == 1)
				{
					cPlayer = 1;
				}
				else if(playerInMove.id == 2)
				{
					cPlayer = 2;
				}
				else if(playerInMove.id == 3)
				{
					cPlayer = 3;
				}
				if(playerInMove.currIndex + 1 > 40)
				{
					playerInMove.currIndex = 0;
				}
				distance = (fields [playerInMove.currIndex + 1].transform.GetChild(cPlayer).transform.position - playerInMove.transform.position).sqrMagnitude;
				playerInMove.transform.position = Vector3.Lerp (playerInMove.transform.position, fields [playerInMove.currIndex + 1].transform.GetChild(cPlayer).transform.position, speed * Time.deltaTime);
				if (distance < 0.005f) {
					//playerInMove.transform.position = fields [playerInMove.currIndex + 1].transform.GetChild (cPlayer).transform.position; // SNAPING
					playerInMove.currIndex = playerInMove.currIndex + 1;
				}
			} 
			else 
			{
				playerInMove.currIndex = playerInMove.finalIndex;
				move = false;
				autoTurn = true;
				autoTurnCnt = timeToAutoTurn;
				HUD.ins.nextTurnButton.SetActive (true);
				FieldUI.ins.PopOut ();
			}
		}
		After_Roll_Time ();
	}
		
	public float timeToAutoTurn, autoTurnCnt;
	public bool autoTurn;
	void After_Roll_Time()
	{
		if(autoTurn)
		{
			if (autoTurnCnt > 0) {
				autoTurnCnt -= Time.deltaTime;
				HUD.ins.autoNextTurnTxt.text = "Auto Next Turn In " + autoTurnCnt.ToString ("####");
			} else {
				Next_Turn ();
			}
		}
	}

	public void Next_Turn()
	{
		if(playerInMove.id == 0)
		{
			playerInMove = playersByTurn [1]; 
			HUD.ins.playerInTurn.text = playerInMove.name  + " Turn!";
			HUD.ins.nextPlayer.text = "Next Player - " + playersByTurn [2].name;
		}
		else if(playerInMove.id == 1)
		{
			playerInMove = playersByTurn [2];
			HUD.ins.playerInTurn.text = playerInMove.name  + " Turn!";
			HUD.ins.nextPlayer.text = "Next Player - " + playersByTurn [3].name;
		}
		else if(playerInMove.id == 2)
		{
			playerInMove = playersByTurn [3];
			HUD.ins.playerInTurn.text = playerInMove.name  + " Turn!";
			HUD.ins.nextPlayer.text = "Next Player - " + playersByTurn [0].name;
		}
		else if(playerInMove.id == 3)
		{
			playerInMove = playersByTurn [0];
			HUD.ins.playerInTurn.text = playerInMove.name  + " Turn!";
			HUD.ins.nextPlayer.text = "Next Player - " + playersByTurn [1].name;
		}
		turnInProgress = false;
		autoTurn = false;
		TrowCubes.ins.autoTrow = true;
		HUD.ins.autoTrowTxt.enabled = true;
		HUD.ins.autoTrowTxt.text = "Auto Trow In: " + TrowCubes.ins.autoTrow.ToString ();
		HUD.ins.autoNextTurnTxt.text = "Auto Next Turn In " + timeToAutoTurn.ToString ("####");
		HUD.ins.nextTurnButton.SetActive (false);
		FieldUI.ins.ClosePopOut ();
	}
}
