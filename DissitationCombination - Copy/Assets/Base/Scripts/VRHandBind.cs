using UnityEngine;
using System.Collections;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//This class is inteded to bind the VR controler to the IK rig hand target on start

public class VRHandBind : MonoBehaviour {


	void Awake() {

        transform.position = transform.parent.transform.position; 

   
	}
	


}
