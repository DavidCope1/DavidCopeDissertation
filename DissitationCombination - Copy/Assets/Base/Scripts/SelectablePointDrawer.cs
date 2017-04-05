using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------


//This class is intened to allow the drawning of points on a 2D plane that will then 
//be adjustable later on it has since been abandoned in favor of other systems
public class SelectablePointDrawer : MonoBehaviour {

    public GameObject template;
    public SplineDecorator SP;
    public Camera displayCam;
    public Canvas canvas;
    List<GameObject> pointList;
    bool hasCreated = false;

    void createPoints()
    {
        pointList = new List<GameObject>();
        foreach(GameObject go in SP.controlPoints)
        {
            GameObject GO = Instantiate(template);
            GO.GetComponent<RectTransform>().anchoredPosition = template.GetComponent<RectTransform>().anchoredPosition;
            pointList.Add(GO);

        }
    }

	// Update is called once per frame
	void Update () {


        if(isReady()&& hasCreated == false)
        {
            hasCreated = true;
            createPoints();
        }
        else
        {
            return;
        }

	
        foreach(GameObject go in SP.controlPoints)
        {
            displayCam.WorldToScreenPoint(go.transform.position);
        }



	}
    bool isReady()
    {
        if (SP.controlPoints.Count > 0)
        {
            return true;
        }
        else return false;
    }


}
