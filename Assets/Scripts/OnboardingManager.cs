using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using ARLogger;

public class OnboardingManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoUiObject;

    public VideoClip findAPlane;
    public VideoClip tapToPlace;
    
    private void Awake() 
    {
        // var plane = GetComponent<ARPlane>();
        // print(plane);
        LogManager.Instance.LogInfo("Onboarding Manager Started");
        StartCoroutine(Onboarding());
    }


    IEnumerator Onboarding()
    {
        // Start
        videoUiObject.SetActive(true);
        LogManager.Instance.LogInfo("Starting Onboarding!");
        videoPlayer.Play();

        // Find A Plane
        videoPlayer.clip = findAPlane;
        LogManager.Instance.LogInfo("Playing 'Find a Plane'");
        yield return new WaitForSeconds(5);

        // Tap To Plane
        videoPlayer.clip = tapToPlace;
        LogManager.Instance.LogInfo("Playing 'Tap to Place'");
        yield return new WaitForSeconds(5);

        // End
        videoPlayer.clip = null;
        LogManager.Instance.LogInfo("All Video's Played!");
        videoUiObject.SetActive(false);
    }

}
