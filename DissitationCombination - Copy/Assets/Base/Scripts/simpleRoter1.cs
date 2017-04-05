using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    //This class is a simple rotation tool that will force an object to assume a certain
    //roation

public class simpleRoter1 : MonoBehaviour {

    private Transform pairent;
    public Transform extraRotation;
    public bool dir;
    // Use this for initialization
    void Awake () {
        pairent = gameObject.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        if (dir)
        {
            transform.rotation = pairent.rotation * extraRotation.rotation;
        }
        else
        {
            transform.rotation = Quaternion.Inverse(pairent.rotation) * extraRotation.rotation;
        }

    }
}
