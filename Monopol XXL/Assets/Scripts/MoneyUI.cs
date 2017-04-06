using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

	public static MoneyUI ins;
	public Text  player_1_name, player_1_money;
	public Text  player_2_name, player_2_money;
	public Text  player_3_name, player_3_money;
	public Text  player_4_name, player_4_money;

	void Awake()
	{
		if (ins == null) {
			ins = this;
		}else{
			Destroy (this.gameObject);
		}
	}
	void Start(){
		player_1_name.text = BoardMoveSystem.ins.playersByTurn [0].name;
		player_2_name.text = BoardMoveSystem.ins.playersByTurn [0].name;
		player_3_name.text = BoardMoveSystem.ins.playersByTurn [0].name;
		player_4_name.text = BoardMoveSystem.ins.playersByTurn [0].name;
		Refresh_UI ();
	}
	public void Refresh_UI()
	{
		player_1_name.text = BoardMoveSystem.ins.playersByTurn [0].name;
		player_2_name.text = BoardMoveSystem.ins.playersByTurn [1].name;
		player_3_name.text = BoardMoveSystem.ins.playersByTurn [2].name;
		player_4_name.text = BoardMoveSystem.ins.playersByTurn [3].name;
		player_1_money.text = "$" + BoardMoveSystem.ins.playersByTurn [0].money.ToString ("N");
		player_2_money.text = "$" + BoardMoveSystem.ins.playersByTurn [1].money.ToString ("N");
		player_3_money.text = "$" + BoardMoveSystem.ins.playersByTurn [2].money.ToString ("N");
		player_4_money.text = "$" + BoardMoveSystem.ins.playersByTurn [3].money.ToString ("N");
	}
}
