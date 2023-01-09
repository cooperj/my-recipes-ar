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
    public GameObject lasagnaPrefab;

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
                if (Input.touchCount == 1)
                {
                    LogManager.Instance.LogInfo("Touched Screen");

                    //Raycast Planes
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {

                        Ray ray = arCamera.ScreenPointToRay(touch.position);

                        if (Physics.Raycast(ray, out RaycastHit hit))
                        {
                            if (hit.collider.tag == "FoodItem")
                            {
                                LogManager.Instance.LogInfo("Food Item Touched");
                                DeleteFood(hit.collider.gameObject);
                                return;
                            }
                            else
                            {
                               LogManager.Instance.LogInfo("Wasn't a Food Item");
                                var pose = arRaycastHits[0].pose;
                                CreateFood(pose.position);
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
        Instantiate(lasagnaPrefab, position, Quaternion.identity);
        LogManager.Instance.LogInfo("Food Item Created");
    }

    private void DeleteFood(GameObject lasagnaPrefab)
    {
        Handheld.Vibrate();
        Destroy(lasagnaPrefab);
        LogManager.Instance.LogInfo("Food Item Deleted");
    }
}