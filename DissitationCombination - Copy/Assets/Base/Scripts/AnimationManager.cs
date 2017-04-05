using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//This class was intended to allow the swapping of animation loops with the looped spline
//it would also handel the transition between the two loop locations over time
//to allow transition lerps and animation blending it has since been left 
//after the timelines took over

public class AnimationManager : MonoBehaviour {


    public List<BezierSpline> animationList;
    public SplineFollower SpF;
    int currentSpline = 0;

    void Start()
    {
        SpF.spline = animationList[currentSpline];
    }

	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.O))
        {

            if (currentSpline < animationList.Count)
            {
                SpF.spline = animationList[currentSpline++];
            }
            else
            {
                currentSpline = 0;
                SpF.spline = animationList[currentSpline];

            }
        }
	}
}
