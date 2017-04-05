using UnityEngine;
using System.Collections.Generic;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//Initaly built with the assistance of:
//http://catlikecoding.com/unity/tutorials/curves-and-splines/
//It has since been exstencivly modified and assigned to purpose.

//This class populates a splines length with objects, in this instance the objects that 
//will become the locations of vertext points of the mesh that follows the spline. 
public class SplineDecorator : MonoBehaviour
{
    [Range(-30.0f,30.0f )]
    public float zchange;
    public bool EnableVR;
    public GameObject VRHEAD;
    public GameObject VRELBOW;
    public GameObject VRHAND;
    public int frequency;
    public bool lookForward;
    public GameObject[] items;
    public float testVal = -7f;
    public bool seeControlNodes;
    public bool adjustZ;
    public List<GameObject> controlPoints;
    public List<Transform> controlNodes;

    private float lastVal;
    private BezierSpline spline;
    private Vector3[] splinePoints;
    private GameObject item;
    private List<GameObject> vertexPoints = null;
    private MeshManipulator meshMap;
    private bool launched = false;
    private MeshMaker shapeHold;
    private MeshMaker shapeholdTwo;
    private bool chanaging = false;
    bool setToUpdate = false;
    bool manualLaunch = false;



    public void setZchange(float _In)
    {
        chanaging = true;
        zchange = 30 *_In;

    }

    //once triggered a new set of mesh locations will be genorated along with all
    //nessesry containers. 
    public void launch()
    {
        if (!launched)
        {
            launched = true;        
            spline = GetComponent<BezierSpline>();
            controlPoints = new List<GameObject>();
            setControlObjet();
            shapeHold = GameObject.Find("ScriptHolder").GetComponent<MeshMaker>();

            shapeHold.Begin();
            items[0] = shapeHold.pointPrefab;
            
            vertexPoints = new List<GameObject>();
            splinePoints = new Vector3[spline.points.Length];
            meshMap = GetComponent<MeshManipulator>();


                identPos();
                runCreation();             
        }     
    }

    //These control objects are what govern the mesh shape and location 
    //They are directly connected to the Spline points and are what alter the structre
    void setControlObjet()
    {
        int counter = 0;
        int nodeCounter = 0;
        int VRCounter = 0;
        foreach (Vector3 Vec in spline.points)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            go.tag = "MOVABLE";
            go.AddComponent<ControlObject>();
            go.GetComponent<ControlObject>().m_myState = StateObject.GAMESTATE.DRAWMEMB;
            go.transform.position = Vec;

            if (EnableVR)
            {

                go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                VRPairenting(VRCounter, go);
                VRCounter++;
            }
            else
            {
                go.transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            }
            controlPoints.Add(go);
            if (!EnableVR)
            {
                go.transform.parent = controlNodes[nodeCounter];
            }
            go.GetComponent<Renderer>().material.color = Color.green;

            counter++;
            if ((counter == 3)&&(nodeCounter != 2))
            {
                counter = 0;
                nodeCounter++;
            }
            if (!seeControlNodes)
            {
                go.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    //If VR is elected to be used, creates a control structure with pairenting
    void VRPairenting(int Count, GameObject go)
    {
        if (Count > 0)
        {
            if(Count < 4)
            {
                go.transform.parent = VRELBOW.transform;
            }
            else
            {
                go.transform.parent = VRHAND.transform;
            }
        }
        else
        {
            go.transform.parent = VRHEAD.transform;
        }
    }

    //updates the spline point list to reflect the position of control points
    void identPos()
    {
        int cout = 0;
        foreach (Vector3 vec in spline.points)
        {
            splinePoints[cout++] = vec;
        }
    }
    //checks if any of the control points have been adjuted and takes action 
    //acordingly 
    bool testChange()
    {
        if (testIdet() == true || testShape() == true)
        {
            return true;
        }
        return false;
    }

    //Checks several factors to see if a new update is requred
    bool testIdet()
    {

        for (int i = 0; i < spline.points.Length; i++)
        {
            if (spline.points[i] != splinePoints[i])
            {
                identPos();
                vertexPoints.Clear();
                vertexPoints.TrimExcess();
                return true;
            }
        }
        return false;
    }

    //A testing for update value
    bool testLastVal()
    {
        if (lastVal != testVal)
        {
            lastVal = testVal;
            return true;
        }
        return false;
    }
    //Test uf the mesh map shape has been updated

    bool testShape()
    {
        print(meshMap.getUpdated());
        return meshMap.getUpdated();

    }

    //Move a control object to match the current set of control points
    void movNode()
    {
        if(spline == null)
        {
            return;
        }

        for (int i = 0; i < spline.points.Length; i++)
        {
            spline.points[i] = controlPoints[i].transform.position;
        }
    }

    private void Update()
    {
        //inital setup and launching
        if (launched)
        {
            movNode();
            if (testIdet())
            {
                runCreation();

            }
        }

        //Manual launch for debuging 
        if(Input.GetKeyDown(KeyCode.U))
        {
            if(!manualLaunch)
            {
                launch();
                manualLaunch = true;
            }
        }
    }

    //Placing a serise of object that will be come the points that 
    //vertex points exist in when the mesh is created
    void runCreation()
    {
        int iterCounter = 0;
        int endAdjuster=0;
        if (frequency <= 0 || items == null || items.Length == 0)
        {
            return;
        }
        float testValForEnd = 0;
        float stepSize = 1f / (frequency * items.Length);
        for (int p = 0, f = 0; f < frequency; f++)
        {
            if(iterCounter++ > 9)
            {
                endAdjuster+= 4 ;
            }

            //for all the childern of the inital shape
            for (int i = 0; i < items.Length; i++, p++)
            {

               item = Instantiate(items[0]) as GameObject;

                vertexPoints.Add(item);
  
                if (f == frequency - 2)
                {
                    testValForEnd = 1.5f;
                }
                else if (f == frequency - 1)
                {
                    testValForEnd = testValForEnd * 2;
                }

                //a small fudge to correct rotations
                if (adjustZ)
                {
                    Transform tr = item.transform.GetChild(3).transform;

                    tr.position = tr.position
                        = new Vector3((testVal + (p / 10) - testValForEnd),
                        (tr.position.y), ((-zchange - 10) + endAdjuster));

                    tr = item.transform.GetChild(4).transform;

                    tr.position = tr.position
                        = new Vector3((testVal + (p / 10) - testValForEnd),
                        (tr.position.y), ((-zchange - 10) + endAdjuster));
                 
                }

                 Destroy(item);
                Vector3 position = spline.GetPoint(p * stepSize);
                item.transform.localPosition = position;
                if (lookForward)
                {
                    item.transform.LookAt(position + spline.GetDirection(p * stepSize));
                }
                item.transform.parent = transform;
            }
            foreach (Transform child in item.transform)
            {

                vertexPoints.Add(child.gameObject);
                 Destroy(child.gameObject);
            }




        }

        //activate the mesh making process with the current vertex points
        shapeHold.createMesh();

    }





    public List<GameObject> getPointList()
    {
        return vertexPoints;
    }


}
