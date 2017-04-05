using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloneObj : MonoBehaviour {

    public GameObject ctO1;
    public GameObject ctO2;
    public GameObject ctO3;
    public GameObject fethers;
    public GameObject rootObj;
    public Material _inMat;

    //Hack job and a half
     float x =1;
     float y =0.5f;
     float z = 0.38f;


    public MeshMaker MM;
    Mesh invertedMesh;
    GameObject invertedMem;

    FetherTool littleFeth;
    FetherTool bigFeth;
    GameObject clonectO1;
    GameObject clonectO2;
     GameObject clonectO3;
    bool beginWing = false;
    bool beginMemb = false;
    public float distInX = 0;

    public List<GameObject> clonedFethersbig;
    public List<GameObject> clonedFethersLittle;

    // Use this for initialization
    public void createClone() {
        if(beginWing)
        {
            return;
        }
        rootObj = Instantiate(new GameObject());
        rootObj.name = "CloneRoot";
        rootObj.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        beginWing = true;
        clonectO1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        clonectO1.transform.position = new Vector3(-(ctO1.transform.position.x + distInX), ctO1.transform.position.y, ctO1.transform.position.z);

        clonectO2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        clonectO2.transform.position = new Vector3(-((ctO2.transform.position.x) - clonectO1.transform.position.x), ctO2.transform.position.y, ctO2.transform.position.z);
        clonectO3 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        clonectO3.transform.position = new Vector3(-((ctO3.transform.position.x)- clonectO2.transform.position.x), ctO3.transform.position.y, ctO3.transform.position.z);

        FetherTool[] allFT = fethers.GetComponents<FetherTool>();
        littleFeth = allFT[1];
        bigFeth = allFT[0];




        foreach(GameObject go in bigFeth.getCreatedFethers())
        {
            GameObject cgo = Instantiate(bigFeth.items[0]);       
    
            cgo.GetComponent<MeshFilter>().mesh = bigFeth.items[0].GetComponent<MeshFilter>().mesh;
            clonedFethersbig.Add(cgo);
            cgo.transform.parent = rootObj.transform;
        }

        foreach (GameObject go in littleFeth.getCreatedFethers())
        {
            GameObject cgo = Instantiate(littleFeth.items[0]);

         
            clonedFethersLittle.Add(cgo);
            cgo.transform.parent = rootObj.transform;
        }




        rootObj.transform.rotation = new Quaternion(-90f, -90f, 180f, 1.0f);
        //foreach (GameObject go in littleFeth.getCreatedFethers())
        //{
        //    clonedFethersLittle.Add(Instantiate(littleFeth.items[0]));
        //}




    }
	
	// Update is called once per frame
	void Update () {
        if (beginWing)
        {
            rootObj.transform.rotation = new Quaternion(-90f, -90f, 180f, 1.0f);
            //Set new pos invertes
            clonectO1.transform.position = new Vector3(-(ctO1.transform.position.x + distInX), ctO1.transform.position.y, ctO1.transform.position.z);
            clonectO2.transform.position = new Vector3(-((ctO2.transform.position.x) - clonectO1.transform.position.x), ctO2.transform.position.y, ctO2.transform.position.z);
            clonectO3.transform.position = new Vector3(-((ctO3.transform.position.x) - clonectO2.transform.position.x), ctO3.transform.position.y, ctO3.transform.position.z);

            //set new rotation inverts
            clonectO1.transform.rotation = new Quaternion(ctO1.transform.rotation.x, -ctO1.transform.rotation.y, -ctO1.transform.rotation.z, 1.0f);

            clonectO2.transform.rotation = new Quaternion(ctO2.transform.rotation.x, -ctO2.transform.rotation.y, -ctO2.transform.rotation.z, 1.0f);

            clonectO3.transform.rotation = new Quaternion(ctO3.transform.rotation.x, ctO3.transform.rotation.y, -ctO3.transform.rotation.z, 1.0f);

            plaseFethersinInversePos();
        }

        if(beginMemb)
        {

        }
    }

    public void plaseFethersinInversePos()
    {

        List<GameObject> tempFeth = bigFeth.getCreatedFethers();
        for(int i = 0; i < clonedFethersbig.Count;i++)
        {
            clonedFethersbig[i].transform.position = new Vector3(-(tempFeth[i].transform.position.x + distInX), tempFeth[i].transform.position.y, tempFeth[i].transform.position.z);

            clonedFethersbig[i].transform.localRotation = new Quaternion(x,y,z, 1.0f);
       
        }

        for (int i = 0; i < clonedFethersLittle.Count; i++)
        {
            clonedFethersLittle[i].transform.position = new Vector3(-(tempFeth[i].transform.position.x + distInX), tempFeth[i].transform.position.y, tempFeth[i].transform.position.z);

            clonedFethersLittle[i].transform.localRotation = new Quaternion(x, y, z, 1.0f);

        }

        //foreach (GameObject go in clonedFethersLittle)
        //{
        //    littleFeth.getCreatedFethers()[i] 
        //}



    }

    public void cloneMembrain()
    {
        if(beginMemb)
        {
            return;
        }
        beginMemb = true;

        invertedMem = new GameObject();
        invertedMem.AddComponent<MeshRenderer>();
        invertedMem.AddComponent<MeshFilter>();
        invertedMem.AddComponent<NormalFipper>();

        invertedMem.GetComponent<Renderer>().material = _inMat;
        invertedMem.GetComponent<MeshFilter>().mesh = MM.getModel();
        invertedMem.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

    }
}
