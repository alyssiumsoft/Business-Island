using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderWaterInfrontBillb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer> ().material.renderQueue = 2450;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
