using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatBonus : MonoBehaviour
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

        this.bonus = genereator.Next(1, 4);

        this.health.text = this.playerStats.currentHealth.ToString() + "+" + this.bonus.ToString();
        this.like.text = this.playerStats.currentLikes.ToString();
    }

    public void AddHealth()
    {
        this.playerStats.currentHealth += this.bonus;
    }
}
