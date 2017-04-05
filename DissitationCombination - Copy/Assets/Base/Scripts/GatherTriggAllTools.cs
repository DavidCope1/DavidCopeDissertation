using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------


//This class manages the triggering of the begining of the process of the feathers
//This system has since been replace by the joint rotaion system
public class GatherTriggAllTools : MonoBehaviour {


    FetherTool[] scripts;
    public CloneObj Clo;
    SplineDecorator spd;

    // Use this for initialization
    void Start () {
        scripts = GetComponents<FetherTool>();
        spd = GetComponent<SplineDecorator>();
        
    }
	
	// Update is called once per frame
	public void triggerTransfom()
    {
      //  spd.Launch();

	    foreach(FetherTool FT in scripts)
        {
            FT.triggerStart();
        }
        Clo.createClone();

	}

    public void TriggerUpdatePos()
    {
        foreach (FetherTool FT in scripts)
        {
            FT.triggerUpdate();
        }

    }
}
