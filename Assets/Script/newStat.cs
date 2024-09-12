using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newStat", menuName = "Attack")]
public class newStat : ScriptableObject
{
    public int Damage;
    public int LikeDamege;
    public int LikeGain;
    public int likeCost;

    public string description;
}
