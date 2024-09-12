using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class enemyHandler : MonoBehaviour
{
    [SerializeField] enemyScript enemy;
    private playerStats playerStats;

    [SerializeField] private TextMeshProUGUI sendAttack;
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI likes;
    [SerializeField] private TextMeshProUGUI enemyHealth;
    [SerializeField] private TextMeshProUGUI enemyLikes;
    [SerializeField] private TextMeshProUGUI[] attacskName;
    [SerializeField] private TextMeshProUGUI[] attacksDescription;

    [SerializeField] private Button[] attacks;

    [SerializeField] private UnityEvent playerAttack;
    [SerializeField] private UnityEvent enemyAttack;
    [SerializeField] private UnityEvent fightWin;

    [SerializeField] private GameObject attackBar;
    [SerializeField] private GameObject Message;
    [SerializeField] private GameObject EnemyPortait;
    [SerializeField] private GameObject sendAttackButton;

    private attackManager attackDico;
    private bool hasAttack;

    private int ConvertDamage;
    private bool repeatNextOne;
    private bool CopyAttack;

    private bool onelikeCancel;
    private int oneLikeBonus;
    private int futurOneLikeBonus;

    private bool repostGlowUp;
    private int glowUpBonus;

    private int likebonusRand;

    private int attackSelection;


    System.Random genereator;

    private void Start()
    {
        genereator = new System.Random();

        this.ConvertDamage = 0;
        this.repeatNextOne = false;
        this.CopyAttack = false;
        this.oneLikeBonus = 0;
        this.glowUpBonus = 0;
        this.repostGlowUp = false;
        this.onelikeCancel = true;

        this.attackDico = GameObject.FindGameObjectWithTag("Manager").GetComponent<attackManager>();
        this.playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();
        this.sendAttack.text = "End Turn";
        this.enemyName.text = this.enemy.stats.Name;
        this.enemyHealth.text = this.enemy.stats.health.ToString();
        this.enemyLikes.text = this.enemy.stats.likes.ToString();
        this.health.text = this.playerStats.currentHealth.ToString();
        this.likes.text = this.playerStats.currentLikes.ToString();

        this.hasAttack = false;

        for (int i = 0; i < attacskName.Length; i++)
        {
            this.attacskName[i].text = "";
            this.attacksDescription[i].text = "";
        }

        this.attackSelection = 120;

        this.checkCost();
    }

    public void attack1()
    {
        if (this.attackSelection != 0)
        {
            this.sendAttack.text = "Send Attack";
            this.attacskName[0].text = this.playerStats.curretnAttack1;
            this.attacksDescription[0].text = this.attackDico.manager[this.playerStats.curretnAttack1].description;
            this.attackSelection = 0;
        }
        else
        {
            this.sendAttack.text = "End Turn";
            this.attacskName[0].text = "";
            this.attacksDescription[0].text = "";
            this.attackSelection = 120;
        }
    }

    public void attack2()
    {
        if (this.attackSelection != 1)
        {
            this.sendAttack.text = "Send Attack";
            this.attacskName[0].text = this.playerStats.curretnAttack2;
            this.attacksDescription[0].text = this.attackDico.manager[this.playerStats.curretnAttack2].description;
            this.attackSelection = 1;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            this.sendAttack.text = "End Turn";
            this.attacskName[0].text = "";
            this.attacksDescription[0].text = "";
            this.attackSelection = 120;
        }
    }

    public void attack3()
    {
        if (this.attackSelection != 2)
        {
            this.sendAttack.text = "Send Attack";
            this.attacskName[0].text = this.playerStats.curretnAttack3;
            this.attacksDescription[0].text = this.attackDico.manager[this.playerStats.curretnAttack3].description;
            this.attackSelection = 2;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            this.sendAttack.text = "End Turn";
            this.attacskName[0].text = "";
            this.attacksDescription[0].text = "";
            this.attackSelection = 120;
        }
    }

    public void attack4()
    {
        if (this.attackSelection != 3)
        {
            this.sendAttack.text = "Send Attack";
            this.attacskName[0].text = this.playerStats.curretnAttack4;
            this.attacksDescription[0].text = this.attackDico.manager[this.playerStats.curretnAttack4].description;
            this.attackSelection = 3;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            this.sendAttack.text = "End Turn";
            this.attacskName[0].text = "";
            this.attacksDescription[0].text = "";
            this.attackSelection = 120;
        }
    }

    public void SendAttack()
    {
        for (int i = 0; i < this.attacks.Length; i++)
        {
            if (i == attackSelection)
            {
                this.playerAttack.Invoke();

                if (this.onelikeCancel)
                    this.playerStats.currentLikes += this.oneLikeBonus;

                if (this.repeatNextOne)
                    this.HandleRepost(this.attackDico.manager[this.attacskName[0].text].effect);

                this.HandleAttacks(this.attackDico.manager[this.attacskName[0].text].effect);

                this.likebonusRand = genereator.Next(this.attackDico.manager[this.attacskName[0].text].minLikeGain, this.attackDico.manager[this.attacskName[0].text].maxLikeGain + 1);

                if (!this.CopyAttack)
                {
                    this.playerStats.currentLikes += this.likebonusRand;
                    this.playerStats.currentLikes -= this.attackDico.manager[this.attacskName[0].text].likeCost;
                    this.enemy.currentLike -= this.attackDico.manager[this.attacskName[0].text].LikeDamege; ;
                    this.HealthNegation();
                }
                else
                {
                    this.likebonusRand = genereator.Next(this.attackDico.manager[this.attacskName[1].text].minLikeGain, this.attackDico.manager[this.attacskName[1].text].maxLikeGain + 1);
                    this.CopyOpponenetAttack(1);
                }

                this.attackSelection = 120;
                this.hasAttack = true;

                if (this.attackDico.manager[this.attacskName[0].text].effect == ATTACK_SPECIFICATION.E_MEME && this.likebonusRand == 4)
                    this.attacks[i].interactable = true;
                else
                    this.attacks[i].interactable = false;

                if (this.enemy.ConvertDamage != 0)
                {
                    for (int j = 0; j < this.enemy.ConvertDamage; j++)
                    {
                        this.playerStats.currentLikes += this.attackDico.manager[this.attacskName[0].text].Damage;
                    }

                    this.enemy.ConvertDamage = 0;
                }
            }
        }

        if (this.enemy.currentHealth <= 0)
        {
            this.fightWin.Invoke();
            this.backToNormal();
            this.UpdateTexts();
            return;
        }

        else if (this.hasAttack)
        {
            this.sendAttack.text = "End Turn";
            this.hasAttack = false;
            this.UpdateTexts();
            return;
        }

        else
        {
            this.enemyAttack.Invoke();

            this.HandleEnemyAttack();

            for (int i = 0; i < this.attacks.Length; i++)
            {
                this.attacks[i].interactable = true;
            }

            this.oneLikeBonus = 0;

            if (!this.onelikeCancel)
            {
                this.oneLikeBonus = this.futurOneLikeBonus;
                this.futurOneLikeBonus = 0;
                this.onelikeCancel = true;
            }

            this.playerStats.currentLikes += this.glowUpBonus;

            if (this.repostGlowUp)
            {
                this.repostGlowUp = false;
                this.glowUpBonus -= 2;
            }
            this.UpdateTexts();
            this.checkCost();
        }
    }

    private void checkCost()
    {
        if (this.playerStats.currentLikes - this.attackDico.manager[this.playerStats.curretnAttack1].likeCost < 0)
            this.attacks[0].interactable = false;

        if (this.playerStats.currentLikes - this.attackDico.manager[this.playerStats.curretnAttack2].likeCost < 0)
            this.attacks[1].interactable = false;

        if (this.playerStats.currentLikes - this.attackDico.manager[this.playerStats.curretnAttack3].likeCost < 0)
            this.attacks[2].interactable = false;

        if (this.playerStats.currentLikes - this.attackDico.manager[this.playerStats.curretnAttack4].likeCost < 0)
            this.attacks[3].interactable = false;
    }

    private void backToNormal()
    {
        this.EnemyPortait.SetActive(false);
        this.attackBar.SetActive(false);
        this.Message.SetActive(false);
        this.sendAttackButton.SetActive(false);

        this.playerStats.reactivate = true;
    }

    private void UpdateTexts()
    {
        this.enemyHealth.text = this.enemy.currentHealth.ToString();
        this.enemyLikes.text = this.enemy.currentLike.ToString();
        this.health.text = this.playerStats.currentHealth.ToString();
        this.likes.text = this.playerStats.currentLikes.ToString();
    }

    private void HandleAttacks(ATTACK_SPECIFICATION effect)
    {
        switch (effect)
        {
            case ATTACK_SPECIFICATION.E_DENIAL:
                this.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_REPOST:
                this.repeatNextOne = true;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                this.CopyAttack = true;
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                this.onelikeCancel = false;
                this.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                this.glowUpBonus += 2;
                break;
        }
    }
    private void HealthNegation()
    {
        if (this.attackDico.manager[this.attacskName[0].text].effect == ATTACK_SPECIFICATION.E_RATIO)
        {
            int difference = this.playerStats.currentLikes - this.enemy.currentLike;

            if (difference >= 0)
                this.enemy.currentHealth -= difference;
            else if (difference < 0)
                this.playerStats.currentHealth += difference;
        }
        else
            this.enemy.currentHealth -= this.attackDico.manager[this.attacskName[0].text].Damage;
    }

    private void HandleRepost(ATTACK_SPECIFICATION effect)
    {
        switch (effect)
        {
            case ATTACK_SPECIFICATION.E_DENIAL:
                this.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_MEME:
                this.playerStats.currentLikes += this.likebonusRand;
                break;
            case ATTACK_SPECIFICATION.E_RATIO:
                int difference = this.playerStats.currentLikes - this.enemy.currentLike;
                if (difference >= 0)
                    this.enemy.currentHealth -= difference;
                else if (difference < 0)
                    this.playerStats.currentHealth += difference;
                break;
            case ATTACK_SPECIFICATION.E_TUCHGRASS:
                this.enemy.currentHealth = this.attackDico.manager[this.attacskName[0].text].Damage;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                this.CopyOpponenetAttack(1);
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                this.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                this.repostGlowUp = true;
                this.glowUpBonus += 2;
                break;
        }
    }

    private void HandleEnemyRepost(ATTACK_SPECIFICATION effect)
    {
        switch (effect)
        {
            case ATTACK_SPECIFICATION.E_DENIAL:
                this.enemy.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_MEME:
                this.enemy.currentLike += this.enemy.likebonusRand;
                break;
            case ATTACK_SPECIFICATION.E_RATIO:
                int difference = this.enemy.currentLike - this.playerStats.currentLikes;
                if (difference >= 0)
                    this.playerStats.currentHealth -= difference;
                else if (difference < 0)
                    this.enemy.currentHealth += difference;
                break;
            case ATTACK_SPECIFICATION.E_TUCHGRASS:
                this.playerStats.currentHealth -= this.attackDico.manager[this.attacskName[1].text].Damage;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                this.CopyOpponenetAttack(0);
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                this.enemy.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                this.enemy.repostGlowUp = true;
                this.enemy.glowUpBonus += 2;
                break;
        }
    }

    private void HandleEnemyAttack(ATTACK_SPECIFICATION effect)
    {
        switch (effect)
        {
            case ATTACK_SPECIFICATION.E_DENIAL:
                this.enemy.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_REPOST:
                this.enemy.repeatNextOne = true;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                this.enemy.CopyAttack = true;
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                this.enemy.onelikeCancel = false;
                this.enemy.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                this.enemy.glowUpBonus += 2;
                break;
        }
    }

    private void HealthNegationEnemy()
    {
        if (this.attackDico.manager[this.attacskName[1].text].effect == ATTACK_SPECIFICATION.E_RATIO)
        {
            int difference = this.playerStats.currentLikes - this.enemy.currentLike;

            if (difference >= 0)
                this.playerStats.currentHealth -= difference;
            else if (difference < 0)
                this.enemy.currentHealth += difference;
        }
        else
            this.enemy.currentHealth -= this.attackDico.manager[this.attacskName[1].text].Damage;
    }

    private void CopyOpponenetAttack(int i)
    {
        this.playerStats.currentLikes += this.likebonusRand;
        this.playerStats.currentLikes -= this.attackDico.manager[this.attacskName[i].text].likeCost;
        this.enemy.currentLike -= this.attackDico.manager[this.attacskName[i].text].LikeDamege;

        if (this.attackDico.manager[this.attacskName[i].text].effect == ATTACK_SPECIFICATION.E_RATIO)
        {
            int difference = this.playerStats.currentLikes - this.enemy.currentLike;

            if (difference >= 0)
                this.enemy.currentHealth -= difference;
            else if (difference < 0)
                this.playerStats.currentHealth += difference;
        }
        else
            this.enemy.currentHealth -= this.attackDico.manager[this.attacskName[1].text].Damage;
    }

    public void HandleEnemyAttack()
    {
        string enemyAttack = this.enemy.enemyAttack();

        if (this.enemy.currentLike - this.attackDico.manager[enemyAttack].likeCost >= 0)
        {

            if (this.enemy.onelikeCancel)
                this.enemy.currentLike += this.enemy.oneLikeBonus;

            if (this.enemy.repeatNextOne)
                this.HandleEnemyRepost(this.attackDico.manager[this.attacskName[0].text].effect);

            this.HandleEnemyAttack(this.attackDico.manager[this.attacskName[0].text].effect);

            this.enemy.likebonusRand = genereator.Next(this.attackDico.manager[enemyAttack].minLikeGain, this.attackDico.manager[enemyAttack].maxLikeGain + 1);

            if (!this.enemy.CopyAttack)
            {
                this.playerStats.currentLikes -= this.attackDico.manager[enemyAttack].LikeDamege;
                this.enemy.currentLike -= this.attackDico.manager[enemyAttack].likeCost;
                this.enemy.currentLike += this.likebonusRand;
                this.HealthNegationEnemy();
            }
            else
            {
                this.likebonusRand = genereator.Next(this.attackDico.manager[this.attacskName[0].text].minLikeGain, this.attackDico.manager[this.attacskName[1].text].maxLikeGain + 1);
                this.CopyOpponenetAttack(0);
            }

            if (this.ConvertDamage != 0)
            {
                for (int i = 0; i < this.ConvertDamage; i++)
                {
                    this.playerStats.currentLikes += this.attackDico.manager[enemyAttack].Damage;
                }

                this.ConvertDamage = 0;
            }

            this.attacskName[1].text = enemyAttack;
            this.attacksDescription[1].text = this.attackDico.manager[enemyAttack].description;
        }
        else
        {
            this.attacskName[1].text = "Not enouh likes";
            this.attacksDescription[1].text = "I don't have enought like to throw my attack. You're lucky !";
        }
    }
}
