using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
    public Entity stats;
    
    public Button[] attacks;

    public Text likeText;
    public Text healthText;

    public attackManager attackDico;

    // Start is called before the first frame update
    void Start()
    {
        this.deactivateAttackButton();
    }

    // Update is called once per frame
    void Update()
    {
        this.likeText.text = "Likes :" + stats.likes.ToString();
        this.healthText.text = "Health :" + stats.health.ToString();


    }

    public void activateAttackButton() 
    { 
        for(int i = 0; i < attacks.Length; i++)
        {
            attacks[i].gameObject.SetActive(true);
        }

        this.likeText.transform.localPosition = new Vector3 (-111, 204, 0);
        this.healthText.transform.localPosition = new Vector3(120, 204, 0);
    }
    public void deactivateAttackButton() 
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].gameObject.SetActive(false);
        }

        //Debug.Log(this.likeText.transform.localPosition);
        //Debug.Log(this.healthText.transform.localPosition);

        this.likeText.transform.localPosition = new Vector3(0, 10, 0);
        this.healthText.transform.localPosition = new Vector3(0, -33, 0);
    }

    public void Attack1()
    {
        
    }
}
