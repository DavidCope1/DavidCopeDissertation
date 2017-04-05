using UnityEngine;
using System.Collections;

public class FixXandY : MonoBehaviour {

    Vector3 myXY;

	// Use this for initialization
	void Start () {

        myXY = transform.position;


	}
	
	// Update is called once per frame
	void Update () {
	if(myXY.x != transform.position.x)
        {
            transform.position = new Vector3(myXY.x,transform.position.y,transform.position.z);
        }
        if (myXY.y != transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, myXY.y, transform.position.z);
        }


    }
}
