using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSceneManager : MonoBehaviour
{
    LobbySceneManager lobbySceneManager;
    public GameObject option;

    // Start is called before the first frame update
    void Start()
    {
        lobbySceneManager = GameObject.Find("LobbySceneManager").GetComponent<LobbySceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //  public void Option()
    //  {
    //      option.SetActive(true);
    //  }
    //  
    //  public void OptionClose()
    //  {
    //      option.SetActive(false);
    //  }
}
