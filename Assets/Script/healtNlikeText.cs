using UnityEngine;
using TMPro;

public class healtNlikeText : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI like;
        
    private playerStats playerStats;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.playerStats = player.GetComponent<playerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        this.health.text = this.playerStats.currentHealth.ToString();
        this.like.text = this.playerStats.currentLikes.ToString();
    }
}
