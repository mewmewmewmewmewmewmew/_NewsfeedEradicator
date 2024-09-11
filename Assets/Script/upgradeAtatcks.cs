using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeAtatcks : MonoBehaviour
{
    public Button[] UpgradeButtons;
    public Button cancelButton;
    public Button validateButton;

    public playerStats playerStats;

    public GameObject[] Titletextboxes;
    public GameObject[] descriptionTextBoxes;

    public attackManager attackManager;

    private string upgradeAttackName;

    private void Update()
    {
        if (this.playerStats.validation)
            this.validateButton.interactable = true;
    }
    public void setUpUpgradeScreen()
    {

        for (int i = 0; i < UpgradeButtons.Length; i++)
        {
            this.UpgradeButtons[i].gameObject.SetActive(true);
            this.UpgradeButtons[i].interactable = true;

            this.Titletextboxes[i].gameObject.SetActive(true);
            this.descriptionTextBoxes[i].gameObject.SetActive(true);
        }   
        
        for (int i = 0;i < 4; i++)
        {
            this.playerStats.attacks[i].gameObject.SetActive(true);
            this.playerStats.attacks[i].interactable = false;
        }

        this.validateButton.gameObject.SetActive(true);
        this.cancelButton.gameObject.SetActive(true);   

        this.cancelButton.interactable = false;
        this.validateButton.interactable = false;

        this.playerStats.likeText.transform.localPosition = new Vector3(-30, -146, 0);
        this.playerStats.healthText.transform.localPosition = new Vector3(-70, -146, 0);

        for(int i = 0; i < this.Titletextboxes.Length; i++)
        {
            string newAttack = getRandomAttack();

            this.Titletextboxes[i].GetComponent<Text>().text = newAttack;
            this.descriptionTextBoxes[i].GetComponent <Text>().text = this.attackManager.manager[newAttack].description;
        }
    }

    public void disableUpgradeScreen()
    {
        this.playerStats.validation = false;

        for (int i = 0; i < UpgradeButtons.Length; i++)
        {
            this.UpgradeButtons[i].gameObject.SetActive(false);
            this.Titletextboxes[i].gameObject.SetActive(false);
            this.descriptionTextBoxes[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            this.playerStats.attacks[i].gameObject.SetActive(false);
        }

        this.validateButton.gameObject.SetActive(false);
        this.validateButton.interactable = false;
        this.cancelButton.gameObject.SetActive(false);
        this.cancelButton.interactable = false;

        this.playerStats.healthText.transform.localPosition = new Vector3(0, 0, 0);
        this.playerStats.likeText.transform.localPosition = new Vector3(0, -30, 0);

        this.playerStats.reactivate = true;
    }

    private string getRandomAttack()
    {
        System.Random genereator = new System.Random();

        string attackName = this.attackManager.attacks[genereator.Next(this.attackManager.attacks.Length)].name;

        for(int i = 0; i < 4 ;i++)
        {
            if(attackName == this.playerStats.attacks[i].name)
            {
                attackName = getRandomAttack();
                break;
            }
        }

        for(int i = 0; i < this.Titletextboxes.Length; i++)
        {
            if(attackName == this.Titletextboxes[i].GetComponent<Text>().text)
            {
                attackName = getRandomAttack();
                break;
            }
        }

        return attackName;
    }

    public void attackSelect1()
    {
        this.UpgradeButtons[1].interactable = false;
        this.UpgradeButtons[2].interactable = false;
        this.cancelButton.interactable = true;

        for (int i = 0; i < 4; i++)
        {
            this.playerStats.attacks[i].interactable = true;
        }

        this.playerStats.isUpgrading = true;
        this.upgradeAttackName = this.Titletextboxes[0].GetComponentInChildren<Text>().text;
    }

    public void attackSelect2()
    {
        this.UpgradeButtons[0].interactable = false;
        this.UpgradeButtons[2].interactable = false;
        this.cancelButton.interactable = true;

        for (int i = 0; i < 4; i++)
        {
            this.playerStats.attacks[i].interactable = true;
        }

        this.playerStats.isUpgrading = true;
        this.upgradeAttackName = this.Titletextboxes[1].GetComponentInChildren<Text>().text;
    }

    public void attackSelect3()
    {
        this.UpgradeButtons[0].interactable = false;
        this.UpgradeButtons[1].interactable = false;
        this.cancelButton.interactable = true;

        for (int i = 0; i < 4; i++)
        {
            this.playerStats.attacks[i].interactable = true;
        }

        this.playerStats.isUpgrading = true;
        this.upgradeAttackName = this.Titletextboxes[2].GetComponentInChildren<Text>().text;
    }

    public void canacelSelect()
    {
        this.UpgradeButtons[0].interactable = true;
        this.UpgradeButtons[1].interactable = true;
        this.UpgradeButtons[2].interactable = true;

        this.cancelButton.interactable = false;

        for (int i = 0; i < 4; i++)
        {
            this.playerStats.attacks[i].interactable = false;
        }

        this.playerStats.isUpgrading = false;
        this.upgradeAttackName = "";
        this.playerStats.validation = false;
        this.validateButton.interactable = false;
    }

    public void valideButton()
    {
        switch (this.playerStats.nbrButtonUpgrade)
        {
            case 0:
                this.playerStats.curretnAttack1 = this.upgradeAttackName;
                this.playerStats.attacks[0].GetComponentInChildren<Text>().text = this.upgradeAttackName;
                break;
            case 1:
                this.playerStats.curretnAttack2 = this.upgradeAttackName;
                this.playerStats.attacks[1].GetComponentInChildren<Text>().text = this.upgradeAttackName;
                break;
            case 2:
                this.playerStats.curretnAttack3 = this.upgradeAttackName;
                this.playerStats.attacks[2].GetComponentInChildren<Text>().text = this.upgradeAttackName;
                break;
            case 3:
                this.playerStats.curretnAttack4 = this.upgradeAttackName;
                this.playerStats.attacks[3].GetComponentInChildren<Text>().text = this.upgradeAttackName;
                break;
        }

        this.disableUpgradeScreen();
    }
}
