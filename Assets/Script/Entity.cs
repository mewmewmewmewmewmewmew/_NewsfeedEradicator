using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    [Tooltip("Health of the enemy")]public int health;
    [Tooltip("Likes of the enemy")]public int likes;

    public string nameAttack1;
    public string nameAttack2;
    public string nameAttack3;
    public string nameAttack4;
}
