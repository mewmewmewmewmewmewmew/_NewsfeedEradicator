using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DogBonus : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI like;

    public playerStats playerStats;
    private int bonus;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.playerStats = player.GetComponent<playerStats>();

        System.Random genereator = new System.Random();

        if (playerStats.currentDifficulty == 0)
            this.bonus = genereator.Next(1, 4);
        if (playerStats.currentLikes == 1)
            this.bonus = genereator.Next(3, 6);
        if (playerStats.currentDifficulty == 2)
            this.bonus = genereator.Next(6, 11);

        this.like.text = this.playerStats.currentLikes.ToString() + "+" + this.bonus.ToString();
        this.health.text = this.playerStats.currentHealth.ToString();
    }


    public void AddLikes()
    {
        this.playerStats.currentLikes += this.bonus;
    }
}
