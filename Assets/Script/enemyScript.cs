using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Entity stats;

    public int currentHealth;
    public int currentLike;

    public int ConvertDamage;
    public bool repeatNextOne;
    public bool CopyAttack;

    public bool onelikeCancel;
    public int oneLikeBonus;
    public int futurOneLikeBonus;

    public bool repostGlowUp;
    public int glowUpBonus;

    public int likebonusRand;

    private attackManager attackDico;
    private playerStats playerStats;

    System.Random genereator;

    void Start()
    {
        genereator = new System.Random();

        this.attackDico = GameObject.FindGameObjectWithTag("Manager").GetComponent<attackManager>();
        this.playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();

        this.currentHealth = this.stats.health;
        this.currentLike = this.stats.likes;

        this.ConvertDamage = 0;
        this.repeatNextOne = false;
        this.CopyAttack = false;
        this.oneLikeBonus = 0;
        this.glowUpBonus = 0;
        this.repostGlowUp = false;
        this.onelikeCancel = true;
    }

    public string enemyAttack()
    {
        System.Random genereator = new System.Random();

        int atcknbr = genereator.Next(4);

        if(atcknbr == 0)
        {
            return this.stats.nameAttack1;
        }
        else if (atcknbr == 1)
        {
            return this.stats.nameAttack2;
        }
        else if (atcknbr == 2)
        {
            return this.stats.nameAttack3;
        }
        else if (atcknbr == 3)
        {
            return this.stats.nameAttack4;
        }

        return null;
    }

}
