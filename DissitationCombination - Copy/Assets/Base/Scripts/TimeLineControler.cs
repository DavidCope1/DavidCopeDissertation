using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This class controls and updates the transfomation of the timeline controler 
    //along with gathering data about itself, such as the current elivation of 
    //the progression bar. 
public class TimeLineControler : MonoBehaviour {

    public List<GameObject> animationPoints;
    public List<GameObject> markerPoint;
    public SplineFollower SPF;
    public GameObject startPos;
    public GameObject endPos;
    public GameObject bar;
   // private LineRenderer LR;
    public SplineFollower currentPoint;

    public enum axis {
        XPos,
        YPos,
        ZPos
    }
    public axis axisSelect;
    
    private float currentPos;
    public float curentZ;
    bool ballJoint;
    public Transform ballrot;


    //the pairent of the object will inform if it has the qualifications of "Ball"
    public void setBall(bool _in)
    {
        ballJoint = _in;
    }

    // Use this for initialization
    void Start () {
        //This is currenly toggled off but acts as a visual representation 
        //of progress simalour to the ball
        bar.transform.position = startPos.transform.position;
      
    }
	
	// Update is called once per frame
	void Update () {
        //a ball joint will follow its own update rout
        if (!ballJoint)
        {
            calcZ();
        }
    }

    //called as a ball joint
    public void manualFindZ()
    {
        calcZ();
    }

    //The value that will be used by alternate functions
    void calcZ()
    {
        float currentVal = currentPoint.progress;
        bar.transform.position =
            Vector3.Lerp(startPos.transform.position, 
            endPos.transform.position, currentVal);

        curentZ = currentPoint.transform.position.z;
        curentZ = (curentZ - transform.root.transform.position.z);
    }


}
