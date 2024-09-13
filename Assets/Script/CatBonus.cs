using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatBonus : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI like;

    public playerStats playerStats;
    private int bonus;
    public bool isEvil;
    private int healthornot;

    [SerializeField] private Button button;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.playerStats = player.GetComponent<playerStats>();

        System.Random genereator = new System.Random();

        this.healthornot = genereator.Next(0, 2);
        this.bonus = genereator.Next(1, 4);

        Debug.Log(this.healthornot);

        this.health.text = this.playerStats.currentHealth.ToString();
        this.like.text = this.playerStats.currentLikes.ToString();
    }

    public void AddHealth()
    {
        if(this.isEvil)
        {
            if(this.healthornot == 0)
            {
                this.playerStats.currentHealth -= this.bonus;
                this.health.text = this.playerStats.currentHealth.ToString() + " - " + this.bonus;
            }
            else if (this.healthornot == 1)
            {
                this.playerStats.currentLikes -= this.bonus;
                this.like.text = this.playerStats.currentLikes.ToString() + " - " + this.bonus;
            }
               
        }
        else
        {
            if (this.healthornot == 0)
            {
                this.playerStats.currentHealth += this.bonus;
                this.health.text = this.playerStats.currentHealth.ToString() + " + " + this.bonus;
            }
            else if (this.healthornot == 1)
            {
                this.playerStats.currentLikes += this.bonus;
                this.like.text = this.playerStats.currentLikes.ToString() + " + " + this.bonus;
            }
        }

        button.interactable = false;
    }
}
