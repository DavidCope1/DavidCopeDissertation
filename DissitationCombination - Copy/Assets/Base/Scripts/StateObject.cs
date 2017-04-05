using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------


    //This class in intended to be an a tool that will allow for multiple elements to 
    //exsit in the same scene without the need to load in to a new enviroment.
    //aswell as control the general state of the program

public class StateObject : MonoBehaviour {

public enum GAMESTATE
    {
            TITLE = 0,
            DRAWWING,
            DRAWMEMB,
            ANIMATE,
            MUSTBELAST
    }
    public GAMESTATE gameState;
    private GAMESTATE lastState;

    public List<ControlObject> objListdy;


    public void QuitProgram()
    {
        Application.Quit();
    }

    //Find all marked objects so that state changes can be marked arround
    void Start()
    {
        objListdy = new List<ControlObject>();
        setMainState();

        ControlObject[] objList = FindObjectsOfType<ControlObject>();

        foreach (ControlObject ctrl in objList)
        {
            objListdy.Add(ctrl);
        }

        change();
    }
       

    //update all state changes on objects
    public void chanageState(int _in)
    {
        gameState = (GAMESTATE)_in;
        updateObjects();
    }

    void updateObjects()
    {

        foreach(ControlObject obj in objListdy)
        {
            if (obj != null)
            {
                obj.gameObject.SetActive(true);
                obj.updateState();
            }


        }
    }

    void Update()
    {

        if (gameState != lastState)
        {
            change();
            
        }
        
    }

    void change()
    {
        updateObjects();
        setMainState();
  
    }

    void setMainState()
    {
        lastState = gameState;
    }

    void initalSet()
    {

        foreach (ControlObject obj in objListdy)
        {
            obj.updateState();
        }
    }

    
    
}
