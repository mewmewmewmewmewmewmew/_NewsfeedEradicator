using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public playerStats player;
    public GameObject enemyObject;

    private Entity stats;
    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<playerStats>();
        this.deactivateEnemy();
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
}
