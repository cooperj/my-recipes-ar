using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using ARLogger;
using TMPro;

public class OnboardingManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoUiObject;
    public TextMeshProUGUI uiHint;

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
        videoPlayer.Play();
        videoPlayer.clip = findAPlane;

        // Start
        videoUiObject.SetActive(true);
        uiHint.text = "Keep an eye on your surroundings!";
        LogManager.Instance.LogInfo("Starting Onboarding!");
        yield return new WaitForSeconds(3);

        // Find A Plane
        uiHint.text = "Find a Table...";
        LogManager.Instance.LogInfo("Playing 'Find a Plane'");
        yield return new WaitForSeconds(5);

        // Tap To Plane
        videoPlayer.clip = tapToPlace;
        uiHint.text = "Tap on the Table to Place Your Dish!";
        LogManager.Instance.LogInfo("Playing 'Tap to Place'");
        yield return new WaitForSeconds(5);

        // End
        videoPlayer.clip = null;
        uiHint.text = "Tap on the Dish to View More";
        LogManager.Instance.LogInfo("All Video's Played!");
        videoUiObject.SetActive(false);
        yield return new WaitForSeconds(5);

        uiHint.text = "";
    }

}
