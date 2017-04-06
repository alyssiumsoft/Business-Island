using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceValueRecognizer : MonoBehaviour {

	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Dice"))
		{
			if(other.name == "1")
			{
				other.transform.parent.GetComponent<Dice> ().value = 6;	
			}
			else if(other.name == "2")
			{
				other.transform.parent.GetComponent<Dice> ().value = 5;
			}
			else if(other.name == "3")
			{
				other.transform.parent.GetComponent<Dice> ().value = 4;
			}
			else if(other.name == "4")
			{
				other.transform.parent.GetComponent<Dice> ().value = 3;
			}
			else if(other.name == "5")
			{
				other.transform.parent.GetComponent<Dice> ().value = 2;
			}

			else if(other.name == "6")
			{
				other.transform.parent.GetComponent<Dice> ().value = 1;
			}
		}
	}
}
