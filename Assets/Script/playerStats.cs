using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
    public Text likeText;
    public Text healthText;

    private enemyScript enemy;
    public Entity stats;
    
    public Button[] attacks;
    public GameObject[] textBox;

    public attackManager attackDico;

    //public GameObject selectedState;
    public GameObject enemyHealth;
    public GameObject enemyLikes;

    private bool[] attackSelection;
    private bool[] upgradeSelection;
    private bool[] attackDone;

    public int currentHealth;
    public int currentLikes;

    public bool reactivate;
    private bool hasAttack;
    public bool isUpgrading;
    public bool isAttacking;

    public UnityEvent playerAttack;
    public UnityEvent enemyAttack;
    public UnityEvent fightWin;

    public int nbrButtonUpgrade;
    public bool validation;

    public string curretnAttack1;
    public string curretnAttack2;
    public string curretnAttack3;
    public string curretnAttack4;

    public int currentDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        this.currentDifficulty = 0;

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

        this.curretnAttack1 = this.stats.nameAttack1;
        this.curretnAttack2 = this.stats.nameAttack2;
        this.curretnAttack3 = this.stats.nameAttack3;
        this.curretnAttack4 = this.stats.nameAttack4;

        this.attackSelection = new bool[attacks.Length];
        this.attackDone = new bool[attacks.Length];
        this.upgradeSelection = new bool[attacks.Length];

        this.validation = false;
        this.isUpgrading = false;
        this.isAttacking = false;
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
            this.attacks[i].interactable = true;
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

        this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";
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
        if (!this.attackDone[0])
        {
            if (!this.attackSelection[0])
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
                this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[0].GetComponentInChildren<Text>().text].description;
                this.attackSelection[0] = true;
                this.attackSelection[1] = false;
                this.attackSelection[2] = false;
                this.attackSelection[3] = false;
            }
            else
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";
                this.attackSelection[0] = false;
                this.textBox[0].GetComponent<Text>().text = "";
            }
        }
    }


    public void Attack2()
    {
        if (!this.attackDone[1])
        {
            if (!this.attackSelection[1])
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
                //this.selectedState.SetActive(true);
                this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[1].GetComponentInChildren<Text>().text].description;
                //this.selectedState.transform.localPosition = this.attacks[1].transform.localPosition;
                this.attackSelection[0] = false;
                this.attackSelection[1] = true;
                this.attackSelection[2] = false;
                this.attackSelection[3] = false;
            }
            else
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";
                this.attackSelection[1] = false;
                //this.selectedState.SetActive(false);
                this.textBox[0].GetComponent<Text>().text = "";
            }
        }
    }

    public void Attack3()
    {
        if (!this.attackDone[2])
        {
            if (!this.attackSelection[2])
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
                //this.selectedState.SetActive(true);
                this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[2].GetComponentInChildren<Text>().text].description;
                //this.selectedState.transform.localPosition = this.attacks[2].transform.localPosition;
                this.attackSelection[0] = false;
                this.attackSelection[1] = false;
                this.attackSelection[2] = true;
                this.attackSelection[3] = false;
            }
            else
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";
                this.attackSelection[2] = false;
                //this.selectedState.SetActive(false);
                this.textBox[0].GetComponent<Text>().text = "";
            }
        }
    }

    public void Attack4()
    {
        if (!this.attackDone[3])
        {
            if (!this.attackSelection[3])
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "Send Attack";
                //this.selectedState.SetActive(true);
                this.textBox[0].GetComponent<Text>().text = this.attackDico.manager[this.attacks[3].GetComponentInChildren<Text>().text].description;
                //this.selectedState.transform.localPosition = this.attacks[3].transform.localPosition;
                this.attackSelection[0] = false;
                this.attackSelection[1] = false;
                this.attackSelection[2] = false;
                this.attackSelection[3] = true;
            }
            else
            {
                this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";
                this.attackSelection[3] = false;
                //this.selectedState.SetActive(false);
                this.textBox[0].GetComponent<Text>().text = "";
            }
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
                    return;
                }

                this.playerAttack.Invoke();
                this.currentLikes += this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].LikeGain;
                this.currentLikes -= this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].likeCost;
                this.enemy.currentHealth -= this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].Damage;
                this.enemy.currentLike -= this.attackDico.manager[this.attacks[i].GetComponentInChildren<Text>().text].LikeDamege;
                this.attackSelection[i] = false;
                this.attackDone[i] = true;
                this.hasAttack = true;
                this.attacks[i].interactable = false;
            }
        }

        if (this.enemy.currentHealth <= 0)
        {
            this.fightWin.Invoke()
;            this.backToNormal();
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
            this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";
            //this.selectedState.SetActive(false);
            this.hasAttack = false;
            return;
        }
        else 
        {
            this.enemyAttack.Invoke();
            this.textBox[3].GetComponent<Text>().text = this.textBox[2].GetComponent<Text>().text;
            this.textBox[3].GetComponent<Text>().alignment = this.textBox[2].GetComponent<Text>().alignment;
            this.textBox[2].GetComponent<Text>().text = this.textBox[1].GetComponent<Text>().text;
            this.textBox[2].GetComponent<Text>().alignment = this.textBox[1].GetComponent<Text>().alignment;
            this.textBox[1].GetComponent<Text>().text = this.enemy.enemyAttack();
            this.textBox[1].GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            //this.selectedState.SetActive(false);
            this.attacks[4].GetComponentInChildren<Text>().text = "End Turn";

            for(int i = 0; i < this.attackSelection.Length; i++)
            {
                this.attackSelection[i] = false;
                this.attackDone[i] = false;
                this.attacks[i].interactable = true;
            }
            
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
        //this.selectedState.SetActive(false);

        for (int i = 0; i < textBox.Length; i++)
        {
            this.textBox[i].GetComponent<Text>().text = "";
            this.textBox[i].SetActive(false);
        }


        for (int i = 0;i < this.attackSelection.Length; i++)
        {
            this.attackSelection[i] = false;
            this.attackDone[i] = false; 
        }

        this.isAttacking = false;
        this.reactivate = true;
    }

    public void Button1()
    {
        if(this.isAttacking)
        {
            this.Attack1();
            return;
        }   

        if (this.isUpgrading)
        {
            this.validation = true;
            this.nbrButtonUpgrade = 0;
            return;
        }
    }

    public void Button2()
    {
        if (this.isAttacking)
        {
            this.Attack2();
            return;
        }

        if (this.isUpgrading)
        {
            this.nbrButtonUpgrade = 1;
            this.validation = true;
            return;
        }
    }

    public void Button3()
    {
        if (this.isAttacking)
        {
            this.Attack3();
            return;
        }

        if (this.isUpgrading)
        {
            this.nbrButtonUpgrade = 2;
            this.validation = true;
            return;
        }
    }

    public void Button4()
    {
        if (this.isAttacking)
        {
            this.Attack4();
            return;
        }

        if (this.isUpgrading)
        {
            this.nbrButtonUpgrade = 3;
            this.validation = true;
            return;
        }
    }
}
