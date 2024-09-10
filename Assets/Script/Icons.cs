using UnityEngine;

[CreateAssetMenu(fileName = "Icons", menuName = "IconsScriptableObject")]
public class Icons : ScriptableObject
{
    [Tooltip("Distance the icon can reach while sliding")]public float SlidingDistance;
    [Tooltip("Size the icon is at maximum while sliding")]public float growingMax;
    [Tooltip("Size the icon is at minimum while sliding")] public float growingMin;

}
