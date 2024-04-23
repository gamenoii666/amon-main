using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckRoom : MonoBehaviour
{
    public OVRSceneManager _oVRSceneManager;
    public OVRSceneRoom _sceneRoom;
    public OVRScenePlane[] _roomWalls;
    bool Started = false;
    // Start is called before the first frame update

    private void Awake()
    {
        _oVRSceneManager = FindObjectOfType<OVRSceneManager>();
        _oVRSceneManager.SceneModelLoadedSuccessfully += SceneLoaded;
       

    }
   
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = transform.rotation;
    }

    void SceneLoaded()
    {
        _sceneRoom = FindObjectOfType<OVRSceneRoom>();
        _roomWalls = _sceneRoom.Walls;
        
        _oVRSceneManager.LoadSceneModel();
        
    }

}

