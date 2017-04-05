using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This class allows the blending of the three axis of roation from three seporate 
    //timelines to produce a ball joint three axis roation
public class BallJoint : MonoBehaviour {

    public TimeLineControler XRot;
    public TimeLineControler YRot;
    public TimeLineControler ZRot;
    public int fudge = 0;
    public Vector3 deltaRotation;

    public int multiply;

    void Start()
    {
        XRot.setBall(true);
        YRot.setBall(true);
        ZRot.setBall(true);
    }

    //manualy update our timelines to get the current postion of X
    void Update()
    {


        XRot.manualFindZ();
        YRot.manualFindZ();
        ZRot.manualFindZ();

        //my current Transfom;
        deltaRotation = transform.rotation.eulerAngles;

        transform.eulerAngles = 
            new Vector3(XRot.curentZ * multiply, (YRot.curentZ * multiply)
            + fudge, ZRot.curentZ * multiply);

        deltaRotation = (deltaRotation  - transform.rotation.eulerAngles);
        
    }





}
