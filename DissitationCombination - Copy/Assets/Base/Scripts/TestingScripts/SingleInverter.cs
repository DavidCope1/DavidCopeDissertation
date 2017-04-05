using UnityEngine;
using System.Collections;

public class SingleInverter : MonoBehaviour {

    GameObject clone;
    public float distInX;

	// Use this for initialization
	void Awake() {
        clone = Instantiate(gameObject);
 
        clone.GetComponent<SingleInverter>().enabled = false;
        clone.transform.position = -transform.position +transform.root.position;
        clone.transform.rotation = Quaternion.Euler(-transform.rotation.eulerAngles);
	}
	
	// Update is called once per frame
	void Update () {
        clone.transform.position = new Vector3(transform.position.x-distInX, transform.position.y, transform.position.z);
        clone.transform.rotation = new Quaternion(transform.rotation.x, -transform.rotation.y, -transform.rotation.z,1.0f);
    


    }
}
