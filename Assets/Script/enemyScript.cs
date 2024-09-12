using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Entity stats;

    public int currentHealth;
    public int currentLike;

    void Start()
    {
        this.currentHealth = this.stats.health;
        this.currentLike = this.stats.likes;
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
