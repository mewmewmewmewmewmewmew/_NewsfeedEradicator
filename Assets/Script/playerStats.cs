using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerStats : MonoBehaviour
{
    public Entity stats;

    public int currentHealth;
    public int currentLikes;

    public bool reactivate;

    public string curretnAttack1;
    public string curretnAttack2;
    public string curretnAttack3;
    public string curretnAttack4;

    public int currentDifficulty;

    void Start()
    {
        this.currentDifficulty = 0;

        this.currentHealth = this.stats.health;
        this.currentLikes = this.stats.likes;;

        this.curretnAttack1 = this.stats.nameAttack1;
        this.curretnAttack2 = this.stats.nameAttack2;
        this.curretnAttack3 = this.stats.nameAttack3;
        this.curretnAttack4 = this.stats.nameAttack4;
    }
}
