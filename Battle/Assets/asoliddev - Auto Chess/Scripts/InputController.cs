using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controlls player input
/// </summary>
public class InputController : MonoBehaviour
{
    public UIController uiController;
    public GamePlayController gamePlayController;
    public GameObject hitObject;

    //map script
    public Map map;


    public LayerMask triggerLayer;

    //declare ray starting position var
    private Vector3 rayCastStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set position of ray starting point to trigger objects
        rayCastStartPosition = new Vector3(0, 20, 0);
        uiController = GameObject.Find("Scripts").GetComponent<UIController>();
    }

    //to store mouse position
    private Vector3 mousePosition;

    
    [HideInInspector]
    public TriggerInfo triggerInfo = null;

    /// Update is called once per frame
    void Update()
    {
        triggerInfo = null;
        map.resetIndicators();

        //declare rayhit
        RaycastHit hit;

        //convert mouse screen position to ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if ray hits something
        if (Physics.Raycast(ray, out hit, 100f, triggerLayer, QueryTriggerInteraction.Collide))
        {
            //get trigger info of the  hited object
            triggerInfo = hit.collider.gameObject.GetComponent<TriggerInfo>();
            hitObject = hit.collider.gameObject;
            

            //this is a trigger
            if(triggerInfo != null)
            {
                //get indicator
                GameObject indicator = map.GetIndicatorFromTriggerInfo(triggerInfo);

                //set indicator color to active
                indicator.GetComponent<MeshRenderer>().material.color = map.indicatorActiveColor;
            }
            else
                map.resetIndicators(); //reset colors
        }
               

        if (Input.GetMouseButtonDown(0))
        {
            gamePlayController.StartDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(gamePlayController.enableSell == true)
            {
                if(gamePlayController.draggedChampion != null)
                {
                    Destroy(gamePlayController.draggedChampion);
                    gamePlayController.currentGold += gamePlayController.draggedChampion.GetComponent<ChampionController>().champion.cost;
                    uiController.goldText.text = gamePlayController.currentGold.ToString();
                }
            }
            else
            {
                gamePlayController.StopDrag();
            }
        }

        //store mouse position
        mousePosition = Input.mousePosition;
    }
}
