using UnityEngine;
using System.Collections;
using System.Collections.Generic;



//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//initaly built from :http://catlikecoding.com/unity/tutorials/curves-and-splines/

//This class is the counterpoint to the membrain tool and creates and update the 
//feather positions based on the current update

public class FetherTool : MonoBehaviour {
    public BezierSpline spline;
    public bool enabaled =true;
    public bool rotRight;
    public bool rotLeft;
    public int frequency;

    public float publicTool;
    public bool lookForward;

    public Transform Root;
    public Transform ControlObjectOne;
    public Transform ControlObjectTwo;
    private List<GameObject> splineRelatedControlPoints;

    public GameObject[] items;
    private List<GameObject> createdFethers;

    public List<GameObject> getCreatedFethers()
    {
        return createdFethers;
    }

    void collatePoints()
    {

        splineRelatedControlPoints = GetComponent<SplineDecorator>().controlPoints;
    }

    public void triggerStart()
    {
        createFethers();
        collatePoints();
    }

    public void triggerUpdate()
    {
        clearPrev();
        createFethers();
    }

    private void clearPrev()
    {
        foreach(GameObject go in createdFethers)
        {
            Destroy(go);
        }
    }

    private bool testPoints()
    {
        SplineDecorator SPD = GetComponent<SplineDecorator>();
        if(splineRelatedControlPoints == null)
        {
            collatePoints();

        }


        for (int i = 0; i < splineRelatedControlPoints.Count; i++)
        {
            if (SPD.controlPoints[i].gameObject.transform.position
                != splineRelatedControlPoints[i].transform.position)
            {
                splineRelatedControlPoints[i].transform.position
                    = GetComponent<SplineDecorator>().controlPoints[i].transform.position;
                print("Returning true");
                return true;
            }
        }
        return false;
    }

    //inital setup and populating pool
    private void createFethers()
    {
        if (enabaled)
        {
            createdFethers = new List<GameObject>();
            if (frequency <= 0 || items == null || items.Length == 0)
            {
                return;
            }
            float stepSize = frequency * items.Length;
            if (spline.Loop || stepSize == 1)
            {
                stepSize = 1f / stepSize;
            }
            else
            {
                stepSize = 1f / (stepSize - 1);
            }

            //sets the pairent depending on position along the spline 
            for (int p = 0, f = 0; f < frequency; f++)
            {
                for (int i = 0; i < items.Length; i++, p++)
                {
                    GameObject item = Instantiate(items[i]) as GameObject;
                    Vector3 position = spline.GetPoint(p * stepSize);
                    item.gameObject.AddComponent<DistanceRotator>();
                    item.GetComponent<DistanceRotator>().distanceObject
                        = GameObject.Find("Root");
                    item.GetComponent<DistanceRotator>().positionOnWing = f;

                    item.transform.localPosition = position;

                    placeOwner(item);
                    createdFethers.Add(item);
                    if (lookForward)
                    {
                        item.transform.LookAt(position
                            + spline.GetDirection(p * stepSize));
                    }
                    //item.transform.parent = transform;
                }
            }
        }
    }

    void Update()
    {
   
        if(testPoints())
        {

            triggerUpdate();
        }

    }


    void placeOwner(GameObject Go)
    {
        
        if(Go.GetComponent<DistanceRotator>().positionOnWing <34)
        {
            Go.transform.SetParent(Root);
        
        }
        else if(Go.GetComponent<DistanceRotator>().positionOnWing < 67)
        {
         Go.transform.SetParent(ControlObjectOne);
            
        }
        else
        {
            Go.transform.SetParent(ControlObjectTwo);
          
        }

    }
}