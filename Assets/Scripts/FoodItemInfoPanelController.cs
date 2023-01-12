using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ARLogger;

public class FoodItemInfoPanelController : MonoBehaviour
{
    public string Title;
    public string Blurb;
    public string RecipeUrl;
    public string PrepTime;
    public string CookTime;
    public string Serves;

    public bool isOpen;

    public TextMeshProUGUI uiTitle;
    public TextMeshProUGUI uiBlurb;
    public TextMeshProUGUI uiFacts;

    public GameObject InfoPanel;
    public FoodManager foodMgr;

    private void Start() 
    {
        Close();
        SetInfo();
    }

    // Allows of the Info to be updated externally
    public void ChangeInfo(string title, string blurb, string url, string prep, string cook, string serves)
    {
        Title = title;
        Blurb = blurb;
        RecipeUrl = url;
        CookTime = cook;
        Serves = serves;

        SetInfo();
    }

    private void SetInfo()
    {
        uiTitle.text = Title;
        uiBlurb.text = Blurb;
        uiFacts.text = $"Prep: {PrepTime} Cook: {CookTime} Serves: {Serves}";
    }

    public void ClickRecipeUrl()
    {
        Application.OpenURL(RecipeUrl);
    }
    
    public void Open()
    {
        LogManager.Instance.LogInfo("Info Panel Opened");
        InfoPanel.SetActive(true);
        isOpen = true;
    }

    public void Close()
    {
        LogManager.Instance.LogInfo("Info Panel Closed");
        InfoPanel.SetActive(false);
        StartCoroutine(ReEnableUserInput());
    }

    public void ClickDelete()
    {
        foodMgr.DeleteFood();
        Close();
    }

    IEnumerator ReEnableUserInput()
    {
        yield return new WaitForSeconds(1);
        isOpen = false;
    }
        
} 