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

    public int badNewsCounter;
    public int goodNewsCounter;
    public int enemyCounter;
    public int upgradeCounter;

    public Pool Pool;


    void Start()
    {
        this.currentDifficulty = 0;

        this.currentHealth = this.stats.health;
        this.currentLikes = this.stats.likes;;

        this.curretnAttack1 = this.stats.nameAttack1;
        this.curretnAttack2 = this.stats.nameAttack2;
        this.curretnAttack3 = this.stats.nameAttack3;
        this.curretnAttack4 = this.stats.nameAttack4;

        this.enemyCounter = this.Pool.enemyCounter1;
        this.upgradeCounter = this.Pool.upgradeCounter1;
        this.badNewsCounter = this.Pool.BadNewsCounter1;
        this.goodNewsCounter = this.Pool.GoodNewsCounter1;
    }

    public void ResetCounters(int number)
    {
        if(number == 1)
        {
            this.enemyCounter = this.Pool.enemyCounter2;
            this.upgradeCounter = this.Pool.upgradeCounter2;
            this.badNewsCounter = this.Pool.BadNewsCounter2;
            this.goodNewsCounter = this.Pool.GoodNewsCounter2;
            Debug.Log("OMG LVL 2");
        }

        else if (number >= 2)
        {
            this.enemyCounter = this.Pool.enemyCounter3;
            this.upgradeCounter = this.Pool.upgradeCounter3;
            this.badNewsCounter = this.Pool.BadNewsCounter3;
            this.goodNewsCounter = this.Pool.GoodNewsCounter3;
            Debug.Log("OMG LVL 2");
        }
    }
}
