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
    
    public GameObject[] textBox;

    public attackManager attackDico;

    public GameObject selectedState;

    private bool[] attackSelection;

    public int currentHealth;
    public int currentLikes;

    public GameObject enemyHealth;
    public GameObject enemyLikes;

    
    private enemyScript enemy;

    public bool reactivate;
    private bool hasAttack;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <textBox.Length; i++)
        {
            this.textBox[i].SetActive(false);
        }

        this.hasAttack = false;
        this.currentHealth = this.stats.health;
        this.currentLikes = this.stats.likes;

        this.deactivateAttackButton();
        this.attacks[0].GetComponentInChildren<Text>().text = this.stats.nameAttack1;
        this.attacks[1].GetComponentInChildren<Text>().text = this.stats.nameAttack2;
        this.attacks[2].GetComponentInChildren<Text>().text = this.stats.nameAttack3;
        this.attacks[3].GetComponentInChildren<Text>().text = this.stats.nameAttack4;

        this.attackSelection = new bool[attacks.Length];
    }

    // Update is called once per frame
    void Update()
    {
        this.likeText.text = "L :" + this.currentLikes.ToString();
        this.healthText.text = "H :" + this.currentHealth.ToString();

        if(this.enemy != null)
        {
            this.enemyLikes.GetComponent<Text>().text = "L :" + this.enemy.currentLike.ToString();
            this.enemyHealth.GetComponent<Text>().text = "H :" + this.enemy.currentHealth.ToString();
        }
    }

    public void activateAttackButton() 
    { 
        for(int i = 0; i < attacks.Length; i++)
        {
            attacks[i].gameObject.SetActive(true);
        }

        this.likeText.transform.localPosition = new Vector3 (-10, -146, 0);
        this.healthText.transform.localPosition = new Vector3(-70, -146, 0);

        GameObject temp = GameObject.FindGameObjectWithTag("Enemy");
        this.enemy = temp.GetComponent<enemyScript>();

        this.enemyHealth.SetActive(true);
        this.enemyLikes.SetActive(true);

        for (int i = 0; i < textBox.Length; i++)
        {
            this.textBox[i].SetActive(true);
            this.textBox[i].GetComponent<Text>().text = "";
        }

        this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
    }
    public void deactivateAttackButton() 
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].gameObject.SetActive(false);
        }

        this.likeText.transform.localPosition = new Vector3(0, 0, 0);
        this.healthText.transform.localPosition = new Vector3(0, -30, 0);
    }

    public void Attack1()
    {
        if (!this.attackSelection[0])
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
            this.selectedState.SetActive(true);
            this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[0].GetComponentInChildren<Text>().text].description;
            this.selectedState.transform.localPosition = this.attacks[0].transform.localPosition;
            this.attackSelection[0] = true;
            this.attackSelection[1] = false;
            this.attackSelection[2] = false;
            this.attackSelection[3] = false;
        }
        else
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
            this.attackSelection[0] = false;
            this.attackSelection[1] = false;
            this.attackSelection[2] = false;
            this.attackSelection[3] = false;
            this.selectedState.SetActive(false);
            this.textBox[0].GetComponent<Text>().text = "";
        }

    }

    public void Attack2()
    {
        if (!this.attackSelection[1])
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
            this.selectedState.SetActive(true);
            this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[1].GetComponentInChildren<Text>().text].description;
            this.selectedState.transform.localPosition = this.attacks[1].transform.localPosition;
            this.attackSelection[0] = false;
            this.attackSelection[1] = true;
            this.attackSelection[2] = false;
            this.attackSelection[3] = false;
        }
        else
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
            this.attackSelection[0] = false;
            this.attackSelection[1] = false;
            this.attackSelection[2] = false;
            this.attackSelection[3] = false;
            this.selectedState.SetActive(false);
            this.textBox[0].GetComponent<Text>().text = "";
        }
    }

    public void Attack3()
    {
        if (!this.attackSelection[2])
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
            this.selectedState.SetActive(true);
            this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[2].GetComponentInChildren<Text>().text].description;
            this.selectedState.transform.localPosition = this.attacks[2].transform.localPosition;
            this.attackSelection[0] = false;
            this.attackSelection[1] = false;
            this.attackSelection[2] = true;
            this.attackSelection[3] = false;
        }
        else
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
            this.attackSelection[0] = false;
            this.attackSelection[1] = false;
            this.attackSelection[2] = false;
            this.attackSelection[3] = false;
            this.selectedState.SetActive(false);
            this.textBox[0].GetComponent<Text>().text = "";
        }
    }

    public void Attack4()
    {
        if (!this.attackSelection[3])
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
            this.selectedState.SetActive(true);
            this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[3].GetComponentInChildren<Text>().text].description;
            this.selectedState.transform.localPosition = this.attacks[3].transform.localPosition;
            this.attackSelection[0] = false;
            this.attackSelection[1] = false;
            this.attackSelection[2] = false;
            this.attackSelection[3] = true;
        }
        else
        {
            this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
            this.attackSelection[0] = false;
            this.attackSelection[1] = false;
            this.attackSelection[2] = false;
            this.attackSelection[3] = false;
            this.selectedState.SetActive(false);
            this.textBox[0].GetComponent<Text>().text = "";
        }
    }

    public void SendAttack()
    {
        for(int i = 0; i < this.attackSelection.Length; i++)
        {
            if (this.attackSelection[i])
            {
                if (this.currentLikes - this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].likeCost < 0)
                {
                    Debug.Log("TOO MANY LIKES COSTING");
                    return;
                }

                this.currentLikes += this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].LikeGain;
                this.currentLikes -= this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].likeCost;
                this.enemy.currentHealth -= this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].Damage;
                this.enemy.currentLike -= this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].LikeDamege;
                this.attackSelection[i] = false;
                this.hasAttack = true;
            }
        }

        if (this.enemy.currentHealth <= 0)
        {
            this.backToNormal();
            return;
        }
        else if(hasAttack)
        {
            for (int i = this.textBox.Length - 2; i >= 0; i--)
            {
                this.textBox[i + 1].GetComponent<Text>().text = this.textBox[i].GetComponent<Text>().text;
                this.textBox[i + 1].GetComponent<Text>().alignment = this.textBox[i].GetComponent<Text>().alignment;
            }

            this.textBox[0].GetComponent<Text>().text = "";
            this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
            this.selectedState.SetActive(false);
            this.hasAttack = false;
            return;
        }
        else 
        {
            this.textBox[3].GetComponent<Text>().text = this.textBox[2].GetComponent<Text>().text;
            this.textBox[3].GetComponent<Text>().alignment = this.textBox[2].GetComponent<Text>().alignment;
            this.textBox[2].GetComponent<Text>().text = this.textBox[1].GetComponent<Text>().text;
            this.textBox[2].GetComponent<Text>().alignment = this.textBox[1].GetComponent<Text>().alignment;
            this.textBox[1].GetComponent<Text>().text = this.enemy.enemyAttack();
            this.textBox[1].GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            this.selectedState.SetActive(false);
            this.attacks[4].GetComponentInChildren<Text>().text = "Skip Turn";
            return;
        }

    }

    private void backToNormal()
    {
        this.enemy.deactivateEnemy();
        this.enemy = null;
        this.enemyHealth.SetActive(false);
        this.enemyLikes.SetActive(false);
        this.deactivateAttackButton();
        this.selectedState.SetActive(false);

        for (int i = 0; i < textBox.Length; i++)
        {
            this.textBox[i].GetComponent<Text>().text = "";
            this.textBox[i].SetActive(false);
        }


        for (int i = 0;i < this.attackSelection.Length; i++)
        {
            this.attackSelection[i] = false;
        }

        this.reactivate = true;
    }
}
