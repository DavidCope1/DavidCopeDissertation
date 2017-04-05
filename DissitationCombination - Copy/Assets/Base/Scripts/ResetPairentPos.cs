using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This is a debugging tool intended to reset roation to zero

public class ResetPairentPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.L))
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
	}
}
