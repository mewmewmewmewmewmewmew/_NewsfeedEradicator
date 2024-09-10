using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    [Tooltip("Health of the enemy")]public int health;
    [Tooltip("Likes of the enemy")]public float likes;

    private string nameAttack1;
    private string nameAttack2;
    private string nameAttack3;
    private string nameAttack4;
}
