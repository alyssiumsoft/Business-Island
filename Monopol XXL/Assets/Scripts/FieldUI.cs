using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldUI : MonoBehaviour {

	public static FieldUI ins;
	void Awake()
	{
		if(ins == null)
		{
			ins = this;
		}
		else{
			Destroy (this.gameObject);
		}
	}


	public GameObject fieldPopUpPanel;

	public Image image;
	public Text owner;
	public Text buyOutPrice;
	public Text lvl;
	public Text income;
	public Text saleStatus;

	public Button purchase;
	public Button upgrade;
	public Button setNewPrice;
	public Button changeSaleStatus;

	public InputField newPriceInputField;
	public Field activeField;
	public void PopOut()
	{
		Populate_PopUp ();
		fieldPopUpPanel.SetActive (true);
	}
	void Populate_PopUp()
	{
		activeField = BoardMoveSystem.ins.fields [BoardMoveSystem.ins.playerInMove.currIndex];
		Enable_Field_Controlls (); // Here we check if player is the owner so field controlls can or wont be activated
		UpdateUI ();
	}
	void UpdateUI()
	{
		if (activeField.ownersID > 3) {
			owner.text = "City";
		} else {
			owner.text = BoardMoveSystem.ins.playersByTurn [activeField.ownersID].name;
		}
		image.sprite = activeField.image;
		buyOutPrice.text = "$" + activeField.price.ToString();
		lvl.text = "lvl: " + activeField.curr_lvl.ToString();
		income.text = "Income: " + activeField.income.ToString();
		if (activeField.onSale) {
			saleStatus.text = "On Sale!";

		} else {
			saleStatus.text = "Not On Sale!";
		}
	}
	public void ClosePopUp()
	{
		fieldPopUpPanel.SetActive (false);
	}






	public void Purchase_Field()
	{
		if(BoardMoveSystem.ins.playerInMove.money >= activeField.price && activeField.onSale)
		{
			activeField.onSale = false;
			BoardMoveSystem.ins.playerInMove.money -= activeField.price;
			activeField.ownersID = BoardMoveSystem.ins.playerInMove.id;
			Enable_Field_Controlls ();
			UpdateUI ();
			MoneyUI.ins.Refresh_UI ();
		}
	}
	void Enable_Field_Controlls()
	{
		if(activeField.ownersID == BoardMoveSystem.ins.playerInMove.id)
		{
			purchase.gameObject.SetActive (false);
			upgrade.gameObject.SetActive (true);
			income.gameObject.SetActive (true);
			saleStatus.gameObject.SetActive (true);
			setNewPrice.gameObject.SetActive (true);
			changeSaleStatus.gameObject.SetActive (true);
			newPriceInputField.gameObject.SetActive (true);
		}
	}
	public void Upgrade_Field()
	{
		if (BoardMoveSystem.ins.playerInMove.money >= activeField.upgradePrice) {
			BoardMoveSystem.ins.playerInMove.money -= activeField.upgradePrice;
			++activeField.curr_lvl;
			UpdateUI ();
			MoneyUI.ins.Refresh_UI ();
		}

	}
	public void Set_New_Field_Price()
	{
		string str = newPriceInputField.text;
		if(str.Length > 0)
		{
			if (int.Parse (newPriceInputField.text) > 0) {
				activeField.price = int.Parse (newPriceInputField.text);
				UpdateUI ();
			}
		}
		else {
			print ("Invalid Price");
		}
	}
	public void Change_Field_Sell_Status()
	{
		activeField.onSale = !activeField.onSale;
		UpdateUI ();
	}

	public void ClosePopOut()
	{
		fieldPopUpPanel.SetActive (false);
	}
}
