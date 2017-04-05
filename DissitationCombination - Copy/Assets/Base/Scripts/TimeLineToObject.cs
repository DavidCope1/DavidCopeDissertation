using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------


    //This class draws a visual aid to show whitch of the locations the timeline was 
    //bound to.
public class TimeLineToObject : MonoBehaviour {

    LineRenderer LR;
    public GameObject RootObj;
	// Use this for initialization
	void Start () {
        LR = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        LR.SetPosition(0, transform.position);
        LR.SetPosition(1,RootObj.transform.position);

	}
}
