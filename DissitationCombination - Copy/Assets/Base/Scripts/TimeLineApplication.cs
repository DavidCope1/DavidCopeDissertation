using UnityEngine;
using System.Collections;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This class takes the basics of the linked timeline and uses it in operations
    //dependent on what part of it is toggled.

public class TimeLineApplication : MonoBehaviour
{
    public int multiply;
    public bool fudgeRot180;
    public GameObject timeline;
    public bool invertVal;

    private bool pairentisBall = false;
    private bool setUp = false;
    private int delay = 10;
    private int fudge = 0;

    private GameObject valueProduce;
    private Vector3 baseRot;
    private TimeLineControler TLC;
    private BallJoint BallJ;

    //due to the menu system several other operations must take place prior 
    //to the begining of this, to ensure that all other options are compleate
    //This is only called after a cerain number of frames.
    void delayedSetup()
    {
        valueProduce = timeline.transform.GetChild(0).gameObject;
        TLC = valueProduce.GetComponent<TimeLineControler>();
        baseRot = transform.rotation.eulerAngles;

        if(invertVal)
        {
            baseRot = -baseRot;
        }
        if(fudgeRot180)
        {
            fudge = 180;
        }
        BallJ = transform.parent.GetComponent<BallJoint>();
        if (BallJ)
        {
            pairentisBall = true;
        }

    }


    void Update()
    {
        if(delay > 0 )
        {
            delay = delay - 1;
            return;
        }
        if(!setUp)
        {
            delayedSetup();
            setUp = true;
        }

        //if the pairent is a ball jount the axis of rotation additon will operate
        //slightly difforently
        if (!pairentisBall)
        {
            switch (TLC.axisSelect)
            {
                case TimeLineControler.axis.XPos:
                    transform.rotation =
                        new Quaternion
                        (baseRot.z + (TLC.curentZ * multiply),baseRot.y,baseRot.z, 1.0f);
                    break;

                case TimeLineControler.axis.YPos:
                    transform.eulerAngles = 
                        new Vector3
                        (baseRot.x, (TLC.curentZ * multiply) + fudge, baseRot.z);
                    break;

                case TimeLineControler.axis.ZPos:
                    transform.rotation =
                        new Quaternion
                        (baseRot.x, baseRot.y,baseRot.z + (TLC.curentZ * multiply),1.0f);
                    break;

            }
        }
        else
        {
            switch (TLC.axisSelect)
            {
                case TimeLineControler.axis.XPos:
                    transform.rotation 
                        = new Quaternion
                        (baseRot.z + (TLC.curentZ * multiply),baseRot.y,baseRot.z, 1.0f);
                    break;

                case TimeLineControler.axis.YPos:
                    transform.eulerAngles = 
                        new Vector3
                        (baseRot.x, (TLC.curentZ * multiply) + fudge, baseRot.z)
                        + BallJ.deltaRotation;

                    break;
                case TimeLineControler.axis.ZPos:
                    transform.rotation =
                        new Quaternion
                        (baseRot.x, baseRot.y,baseRot.z + (TLC.curentZ * multiply),1.0f);
                    break;

            }
        }

    }
}
