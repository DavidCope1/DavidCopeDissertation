using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //this class rotates the current object based on the distance away from the root of 
    //the target object 
public class DistanceRotator : MonoBehaviour {
    public GameObject distanceObject;
    public int positionOnWing;
    private FetherRotator FR;

    

    public float Y;

    void Start()
    {
        
        FR = GameObject.Find("ScriptHolder").GetComponent<FetherRotator>();
    }

    public float baseVal = 0.0f;
    // Update is called once per frame
    void Update () {

        Y = FR.YVal;

        float distance = Vector3.Distance(transform.position, 
            distanceObject.transform.position);

        transform.rotation =
            Quaternion.Euler(FR.XVal+transform.parent.transform.rotation.x,
            (FR.YVal + -(Mathf.Clamp(distance,0.0f,90.0f)))
            + transform.parent.transform.rotation.y, FR.ZVal 
            + transform.parent.transform.rotation.z);
       // print(transform.rotation);
        
    }
}
