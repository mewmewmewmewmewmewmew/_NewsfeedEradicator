using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgradeHandler : MonoBehaviour
{
    [SerializeField] private Button[] UpgradeButtons;
    [SerializeField] private Button[] attacks;
    [SerializeField] private Button cancelButton;
    [SerializeField] public Button validateButton;

    [SerializeField] private Image[] IconSLot1;
    [SerializeField] private Image[] IconSLot2;
    [SerializeField] private Image[] IconSLot3;

    private playerStats playerStats;

    [SerializeField] private TextMeshProUGUI[] Titletextboxes;
    [SerializeField] private TextMeshProUGUI[] descriptionTextBoxes;

    [SerializeField] private attackManager attackManager;

    private string upgradeAttackName;

    private int nbrButtonUpgrade;

    [SerializeField]private GameObject attackBar;
    [SerializeField]private GameObject upgrades;
    [SerializeField]private GameObject actions;

    [SerializeField]private TextMeshProUGUI health;
    [SerializeField]private TextMeshProUGUI likes;

    private void Start()
    {
        this.attackManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<attackManager>();
        this.playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();

        this.attacks[0].name = this.playerStats.curretnAttack1;
        this.attacks[1].name = this.playerStats.curretnAttack2;
        this.attacks[2].name = this.playerStats.curretnAttack3;
        this.attacks[3].name = this.playerStats.curretnAttack4;

        for (int i = 0; i < 4; i++)
        {
            this.attacks[i].interactable = false;
        }

        this.cancelButton.interactable = false;
        this.validateButton.interactable = false;

        for (int i = 0; i < this.Titletextboxes.Length; i++)
        {
            string newAttack = getRandomAttack();

            this.Titletextboxes[i].text = newAttack;
            this.descriptionTextBoxes[i].text = this.attackManager.manager[newAttack].description;
        }

        this.likes.text = this.playerStats.currentLikes.ToString();
        this.health.text = this.playerStats.currentHealth.ToString();


    }

    private string getRandomAttack()
    {
        System.Random genereator = new System.Random();

        string attackName = this.attackManager.attacks[genereator.Next(this.attackManager.attacks.Length)].name;

        bool isSame = this.checkSimilarity(attackName);

        while(!isSame) 
        {
            attackName = this.attackManager.attacks[genereator.Next(this.attackManager.attacks.Length)].name;
            isSame = this.checkSimilarity(attackName);
        }

        return attackName;
    }

    private bool checkSimilarity(string attackName)
    {
        for (int i = 0; i < this.attacks.Length; i++)
        {

            if (attackName == this.attacks[i].name)
            {
                return false;
            }
        }

        for (int i = 0; i < this.Titletextboxes.Length; i++)
        {
            if (attackName == this.Titletextboxes[i].text)
            {
                return false;
            }
        }

        return true;
    }

    public void attackSelect1()
    {
        this.UpgradeButtons[1].interactable = false;
        this.UpgradeButtons[2].interactable = false;
        this.cancelButton.interactable = true;

        for (int i = 0; i < 4; i++)
        {
            this.attacks[i].interactable = true;
        }

        this.upgradeAttackName = this.Titletextboxes[0].text;

        for (int i = 0; i < this.IconSLot1.Length; i++)
        {
            this.setImageTransperent(this.IconSLot2[i]);
            this.setImageTransperent(this.IconSLot3[i]);
        }
    }

    public void attackSelect2()
    {
        this.UpgradeButtons[0].interactable = false;
        this.UpgradeButtons[2].interactable = false;
        this.cancelButton.interactable = true;

        for (int i = 0; i < 4; i++)
        {
            this.attacks[i].interactable = true;
        }

        this.upgradeAttackName = this.Titletextboxes[1].text;

        for (int i = 0; i < this.IconSLot1.Length; i++)
        {
            this.setImageTransperent(this.IconSLot1[i]);
            this.setImageTransperent(this.IconSLot3[i]);
        }
    }

    public void attackSelect3()
    {
        this.UpgradeButtons[0].interactable = false;
        this.UpgradeButtons[1].interactable = false;
        this.cancelButton.interactable = true;

        for (int i = 0; i < 4; i++)
        {
            this.attacks[i].interactable = true;
        }

        this.upgradeAttackName = this.Titletextboxes[2].text;

        for (int i = 0; i < this.IconSLot1.Length; i++)
        {
            this.setImageTransperent(this.IconSLot2[i]);
            this.setImageTransperent(this.IconSLot1[i]);
        }
    }

    private void setImageTransperent(Image image)
    {
        Color color = new Color(255, 255, 255, 0.5f);

        image.color = color;
    }

    private void getImageBack(Image image)
    {
        Color color = new Color(255, 255, 255, 1);

        image.color = color;
    }

    public void cancelSelect()
    {
        
        for(int i = 0; i < this.UpgradeButtons.Length; i++)
        {
            this.UpgradeButtons[i].interactable = true;
        }

        for (int i = 0; i < this.IconSLot1.Length; i++)
        {
            this.getImageBack(this.IconSLot3[i]);
            this.getImageBack(this.IconSLot2[i]);
            this.getImageBack(this.IconSLot1[i]);
        }

        this.cancelButton.interactable = false;

        for (int i = 0; i < 4; i++)
        {
            this.attacks[i].interactable = false;
        }

        this.upgradeAttackName = "";
        this.validateButton.interactable = false;
    }

    public void valideButton()
    {
        switch (this.nbrButtonUpgrade)
        {
            case 0:
                this.playerStats.curretnAttack1 = this.upgradeAttackName;
                break;
            case 1:
                this.playerStats.curretnAttack2 = this.upgradeAttackName;
                break;
            case 2:
                this.playerStats.curretnAttack3 = this.upgradeAttackName;
                break;
            case 3:
                this.playerStats.curretnAttack4 = this.upgradeAttackName;
                break;
        }

        this.disableUpgradeScreen();
    }

    private void disableUpgradeScreen()
    {
        this.attackBar.SetActive(false);
        this.upgrades.SetActive(false);
        this.actions.SetActive(false);

        this.playerStats.reactivate = true;
    }

    public void AttackButton(int number)
    {
        this.nbrButtonUpgrade = number;
    }

    public void ActivateValidation()
    {
        this.validateButton.interactable = true;
    }
}
