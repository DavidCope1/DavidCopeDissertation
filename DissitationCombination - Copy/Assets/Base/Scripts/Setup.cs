using UnityEngine;
using System.Collections;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This class is intended to ensure that all elements of the timeline contoler have 
    //been corrently set at the begining

public class Setup : MonoBehaviour {

    public BallJoint thingToSet;
    public TimeLineApplication TLCOne;
    public TimeLineApplication TLCTwo;

    public void callToSet(bool _in)
    {

            thingToSet.enabled = _in;
        //TLCOne.enabled = _in;
        //TLCTwo.enabled = _in;

    }
}
