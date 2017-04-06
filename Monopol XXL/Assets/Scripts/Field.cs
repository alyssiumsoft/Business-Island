using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {


	public string name;
	public Sprite image;
	public int ownersID; // when player buys this field his id will be stores here
	public int price;
	public int upgradePrice;
	public bool onSale; // if true anyone can buy this field, when bought we change it to false but if player wants to sell he will mark it true
	public int curr_lvl, income, income_lvl_1, income_lvl_2, income_lvl_3, income_lvl_4;
}
