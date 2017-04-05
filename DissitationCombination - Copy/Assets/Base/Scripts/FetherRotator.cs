using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//This system was oringaly devloped to to rotate the fethers dependent on the current 
//timeline poition before that additon of the limb structure
// this system has since been replaced but was an imoprtent first step towards creating
//the final result

public class FetherRotator : MonoBehaviour {

    public float XVal;
    public float YVal;
    public float ZVal;

    public float toolAdjument = 90;

     public List<TimeLineControler>ListOfControlers;

    // Update is called once per frame
    void Update () {
        foreach (TimeLineControler TLCIn in ListOfControlers)
        {
            setAxis(TLCIn);
        }
    }

    void setAxis( TimeLineControler TLC)
    {

        switch (TLC.axisSelect)
        {
            case TimeLineControler.axis.XPos:

                XVal = ((TLC.curentZ * 50)+ toolAdjument);

                break;
            case TimeLineControler.axis.YPos:

                YVal = ((TLC.curentZ * 50)+ toolAdjument);
      
                break;
            case TimeLineControler.axis.ZPos:

                ZVal = (TLC.curentZ*50);
  
                break;
                
        }
    }

}
