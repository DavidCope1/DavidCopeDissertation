using UnityEngine;
using System.Collections;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This class is what allows for the objects in the scene to be adjusted and moved
    //it links to components such as the spline decorator and mesh maker
public class MeshManipulator : MonoBehaviour {

    public Camera cameraIn;
    public Material setCol;
    private bool updated = false;
    private bool selected = false;
    private GameObject currentSelect;
    private Material matHold;
    private Transform pairnentHold;

    public bool getUpdated()
    {
        return updated;
    }

    //should probably be fixed update
    void Update()
    {
        //fires a ray from the current camera and
        //manipulates the object that it has struck
        RaycastHit hit;
        Ray ray = cameraIn.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction);

            if (Input.GetMouseButtonDown(0) )
            {
                //if the thing we hit is tagged so: 
                if(!selected && hit.transform.tag == "MOVABLE")
                {
                    currentSelect = hit.transform.gameObject;
                    matHold = currentSelect.GetComponent<Renderer>().material;
                    currentSelect.GetComponent<Renderer>().material = setCol;
                    selected = true;
                    pairnentHold = hit.transform.parent;
                    hit.transform.parent = null;
                }
                //if we have an item selected 
                else if(selected)
                {
                    currentSelect.GetComponent<Renderer>().material = matHold;
                   
                    selected = false;
                    updated = true;
                    if (currentSelect.transform.parent != null)
                    {
                        currentSelect.transform.parent = pairnentHold;
                    }
                    currentSelect = null;
                    pairnentHold = null;
                }                       
            }
            if (selected)
            {
                //ensures that the object remains constant in Y
                currentSelect.transform.position
                    = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }
    }
}
