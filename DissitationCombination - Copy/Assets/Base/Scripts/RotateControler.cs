using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //A simple system that allow mannual application of rotation 
public class RotateControler : MonoBehaviour {

    public Slider timeVal;
    public int rotVal;
    public int rotValfrac;

    void Awake()
    {
        rotValfrac = rotVal / 100;
    }

    void Update()
    {
        //transform.LookAt()
    }

}
