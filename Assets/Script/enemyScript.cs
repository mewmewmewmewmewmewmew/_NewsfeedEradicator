using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public playerStats player;
    public GameObject enemyObject;

    public Entity stats;

    public attackManager attackDico;

    public int currentHealth;
    public int currentLike;
    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<playerStats>();
        this.deactivateEnemy();

        this.currentHealth = this.stats.health;
        this.currentLike = this.stats.likes;

        this.attackDico = (GameObject.FindGameObjectWithTag("Manager")).GetComponent<attackManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateEnemy()
    {
        this.enemyObject.SetActive(true);
    }

    public void deactivateEnemy()
    {
        this.enemyObject.SetActive(false);  
    }

    public string enemyAttack()
    {
        System.Random genereator = new System.Random();

        int atcknbr = genereator.Next(4);

        if(atcknbr == 0)
        {
            this.currentLike += this.attackDico.manager[this.stats.nameAttack1].LikeGain;
            this.currentLike -= this.attackDico.manager[this.stats.nameAttack1].likeCost;
            this.player.currentHealth -= this.attackDico.manager[this.stats.nameAttack1].Damage;
            this.player.currentLikes -= this.attackDico.manager[this.stats.nameAttack1].LikeDamege;
            return this.attackDico.manager[this.stats.nameAttack1].description;
        }
        else if (atcknbr == 1)
        {
            this.currentLike += this.attackDico.manager[this.stats.nameAttack2].LikeGain;
            this.currentLike -= this.attackDico.manager[this.stats.nameAttack2].likeCost;
            this.player.currentHealth -= this.attackDico.manager[this.stats.nameAttack2].Damage;
            this.player.currentLikes -= this.attackDico.manager[this.stats.nameAttack2].LikeDamege;
            return this.attackDico.manager[this.stats.nameAttack2].description;
        }
        else if (atcknbr == 2)
        {
            this.currentLike += this.attackDico.manager[this.stats.nameAttack3].LikeGain;
            this.currentLike -= this.attackDico.manager[this.stats.nameAttack3].likeCost;
            this.player.currentHealth -= this.attackDico.manager[this.stats.nameAttack3].Damage;
            this.player.currentLikes -= this.attackDico.manager[this.stats.nameAttack3].LikeDamege;
            return this.attackDico.manager[this.stats.nameAttack3].description;
        }
        else if (atcknbr == 3)
        {
            this.currentLike += this.attackDico.manager[this.stats.nameAttack4].LikeGain;
            this.currentLike -= this.attackDico.manager[this.stats.nameAttack4].likeCost;
            this.player.currentHealth -= this.attackDico.manager[this.stats.nameAttack4].Damage;
            this.player.currentLikes -= this.attackDico.manager[this.stats.nameAttack4].LikeDamege;
            return this.attackDico.manager[this.stats.nameAttack4].description;
        }

        return null;
    }
}
