using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Entity stats;

    public int currentHealth;
    public int currentLike;

    private bool ConvertDamage;
    private bool repeatNextOne;
    private bool CopyAttack;
    private bool oneLikeBonus;
    private int glowUpBonus;

    void Start()
    {
        this.currentHealth = this.stats.health;
        this.currentLike = this.stats.likes;

        this.ConvertDamage = false;
        this.repeatNextOne = false;
        this.CopyAttack = false;
        this.oneLikeBonus = false;
        this.glowUpBonus = 0;
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
