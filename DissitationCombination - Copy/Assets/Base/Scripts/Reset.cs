using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//David Cope 
//A Tool for Wing Creation
//53037834
//This line is 90 chars long ------------------------------------------------------------

    // a simple reloading tool to reset a scene

public class Reset : MonoBehaviour {

    public void reset()
    {
        SceneManager.LoadScene(0);

    }
}
