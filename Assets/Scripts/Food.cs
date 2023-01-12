using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Food : ScriptableObject 
{
    public string Title;
    public string Blurb;
    public string RecipeUrl;
    public GameObject Prefab;
    public string PrepTime;
    public string CookTime;
    public string ServingSize;
}