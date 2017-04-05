using UnityEngine;
using System.Collections;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//This class is used with the VR system to reactiveate the childen of the base objects
public class activateChild : MonoBehaviour {

	// Use this for initialization
	void Update () {
        transform.GetChild(0).gameObject.SetActive(true);
	}
	

}
