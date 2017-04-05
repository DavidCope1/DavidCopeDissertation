using UnityEngine;
using System.Collections;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

//This class is a simple rotation tool that will force an object to assume a certain
//roation

public class simpleRoter : MonoBehaviour {

    private Transform pairent;
    public Transform extraRotation;
    // Use this for initialization
    void Awake () {
        pairent = gameObject.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = pairent.rotation * extraRotation.rotation;


    }
}
