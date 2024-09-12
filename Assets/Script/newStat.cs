using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public enum ATTACK_SPECIFICATION
{
    E_DENIAL, 
    E_MEME, 
    E_RATIO, 
    E_REPOST, 
    E_TUCHGRASS,
    E_BOOMER, 
    E_EXTRA, 
    E_GLOWUP
}

[CreateAssetMenu(fileName = "newStat", menuName = "Attack")]
public class newStat : ScriptableObject
{
    public ATTACK_SPECIFICATION effect;
    public int Damage;
    public int LikeDamege;
    public int minLikeGain;
    public int maxLikeGain;
    public int likeCost;

    public string description;

    public GameObject Icon;
}
