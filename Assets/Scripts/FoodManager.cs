using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using ARLogger;

public class FoodManager : MonoBehaviour
{
    // vars
    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();
    public ARRaycastManager arRaycastManager;
    //Assign camera – should work with main tag but sometimes has issues 
    public Camera arCamera;
    public FoodItemInfoPanelController infoPanel;

    private RaycastHit lastHit;

    public List<Food> foods;
    public int foodIndex = 0;

    public bool firstObjectPlaced = false;

    void Update()
    {
        // touchcount condition
        if (Input.touchCount > 0)
        {
            // touch var
            var touch = Input.GetTouch(0);
            //touch.phase condition
            if (touch.phase == TouchPhase.Ended)
            {
                // Handle No Touch
                if (Input.touchCount == 1)
                {
                    LogManager.Instance.LogInfo("Touched Screen");

                    // Handle the Screen being touched from the info menu
                    if (infoPanel.isOpen)
                        return;

                    //Raycast Planes
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {

                        Ray ray = arCamera.ScreenPointToRay(touch.position);

                        if (Physics.Raycast(ray, out RaycastHit hit))
                        {
                            if (hit.collider.tag == "FoodItem")
                            {
                                lastHit = hit;
                                LogManager.Instance.LogInfo("Food Item Touched");
                                infoPanel.Open();
                                return;
                            }
                            else
                            {
                               LogManager.Instance.LogInfo("Wasn't a Food Item");
                                var pose = arRaycastHits[0].pose;
                                CreateFood(pose.position);

                                firstObjectPlaced = true;
                                return;
                            }
                        }

                        return;
                    }


                }
            }


            // end touch phase condition
            // end touchcount condition
        }
    }

    private void CreateFood(Vector3 position)
    {
        // temp
        foodIndex = Random.Range(0, foods.Count);

        // Spawns the prefab from the ScriptableObj so we can have more than one food type.
        Food f = foods[foodIndex];
        Instantiate(f.Prefab, position, Quaternion.identity);
        infoPanel.ChangeInfo(f.Title, f.Blurb, f.RecipeUrl, f.PrepTime, f.CookTime, f.ServingSize);

        LogManager.Instance.LogInfo("Food Item Created");
    }

    public void DeleteFood()
    {
        DeleteFood(lastHit);
    }

    public void DeleteFood(RaycastHit foodRaycast)
    {
        Handheld.Vibrate();
        Destroy(foodRaycast.collider.gameObject);
        LogManager.Instance.LogInfo("Food Item Deleted");
    }
}