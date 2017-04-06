using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowCubes : MonoBehaviour {
	public static TrowCubes ins;
	public bool myTurn;
	public int cubeOne_value, cubeTwo_value, combined_value;
	public GameObject dice_1, dice_2;
	public Rigidbody rb_dice_1, rb_dice_2;
	public float trowForce;
	public Transform diceSpawnPoint_1, diceSpawnPoint_2;
	public Dice dice_1_value, dice_2_value;
	void Awake()
	{
		if (ins == null) {
			ins = this;
		} else {
			Destroy(this.gameObject); 
		}
	}
	public void Trow_Cubes()
	{
		if(!BoardMoveSystem.ins.turnInProgress)
		{
			Invoke ("Trow_Cubes_Results", 2f);
			Roll ();
			BoardMoveSystem.ins.turnInProgress = true;
			autoTrow = false;
			autoTrowCnt = timeToAutoTrow;
			HUD.ins.autoTrowTxt.enabled = false;
		}
	}
	void Trow_Cubes_Results()
	{
		combined_value = dice_1_value.value + dice_2_value.value; 
		HUD.ins.DiceScore.text = combined_value.ToString();
		int indexToJumpOn;
		indexToJumpOn = BoardMoveSystem.ins.playerInMove.currIndex + combined_value;
		if (indexToJumpOn == 40) 
		{
			indexToJumpOn = 0;
		}
		else if(indexToJumpOn > 40)
		{
			indexToJumpOn = indexToJumpOn - 40;
		}
		BoardMoveSystem.ins.playerInMove.finalIndex = indexToJumpOn;
		BoardMoveSystem.ins.move = true;
	}

	void Update()
	{
		combined_value = dice_1_value.value + dice_2_value.value; 
		HUD.ins.DiceScore.text = combined_value.ToString();
		AutoTrowCubes ();

	}

	public void Roll()
	{
		dice_1.SetActive (true);
		dice_1.transform.rotation = diceSpawnPoint_1.rotation;
		dice_1.transform.position = diceSpawnPoint_1.position;
		rb_dice_1.AddForce (rb_dice_1.transform.forward * trowForce, ForceMode.Impulse);
		rb_dice_1.AddTorque (Random.Range(100f, 360f), Random.Range(100f, 360f), Random.Range(100f, 360f), ForceMode.Impulse);

		dice_2.SetActive (true);
		dice_2.transform.rotation = diceSpawnPoint_2.rotation;
		dice_2.transform.position = diceSpawnPoint_2.position;
		rb_dice_2.AddForce (rb_dice_2.transform.forward * trowForce, ForceMode.Impulse);
		rb_dice_2.AddTorque (Random.Range(100f, 360f), Random.Range(100f, 360f), Random.Range(100f, 360f), ForceMode.Impulse);
	}

	public float timeToAutoTrow, autoTrowCnt;
	public bool autoTrow = true;
	void AutoTrowCubes()
	{
		if(autoTrow)
		{
			if (autoTrowCnt > 0) {
				autoTrowCnt -= Time.deltaTime;
				HUD.ins.autoTrowTxt.text = "Auto Trow In: " + autoTrowCnt.ToString ("####");
			} else {
				Trow_Cubes ();
			}
		}
	}
}
