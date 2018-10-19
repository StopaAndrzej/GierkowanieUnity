using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSteering : MonoBehaviour {

	public MoveThePath moveThePath;
	private int isChange = 0;

	void Start(){

	}

	void OnMouseDown(){
		if(isChange == 0){
			//moveThePath.GetComponent<pat
			isChange=1;
		}else
		{
			isChange=0;
		}

	}

}
