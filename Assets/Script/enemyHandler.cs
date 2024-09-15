using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class enemyHandler : MonoBehaviour
{
    [SerializeField] enemyScript enemy;
    private playerStats playerStats;
    private randomScreen screen;

    public GameObject dedScreen;

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
        this.screen = GameObject.FindGameObjectWithTag("Screen").GetComponent<randomScreen>();

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
        //Debug.Log("--------START OF THE FUNCTION PLAYER ATTACK-----------");
        //Debug.Log("Current Enemy Health : " + this.enemy.currentHealth + "Current Enemy Like : " + this.enemy.currentLike);
        //Debug.Log("Current Player Health : " + this.playerStats.currentHealth + "Current Player Like : " + this.playerStats.currentLikes);

        for (int i = 0; i < this.attacks.Length; i++)
        {
            if (i == attackSelection)
            {
                this.likebonusRand = genereator.Next(this.attackDico.manager[this.attacskName[0].text].minLikeGain, this.attackDico.manager[this.attacskName[0].text].maxLikeGain + 1);
                //Debug.Log("BONUS PLAYER LIKE//////" + this.playerStats.currentLikes + "+" + this.likebonusRand);

                this.playerAttack.Invoke();

                if (this.onelikeCancel)
                {
                    //Debug.Log("PLAYER ONE LIKE BONUS///// Current Player Like : " + this.playerStats.currentLikes + " + " + this.oneLikeBonus);
                    this.playerStats.currentLikes += this.oneLikeBonus;
                }


                if (this.repeatNextOne)
                {
                    //Debug.Log("GO TO PLAYER HANDLE REPOST");
                    this.HandleRepost(this.attackDico.manager[this.attacskName[0].text].effect);
                }

                //Debug.Log("GO TO PLAYER HANDLE ATTACK");
                this.HandleAttacks(this.attackDico.manager[this.attacskName[0].text].effect);

                if (!this.CopyAttack)
                {
                    //Debug.Log("CLASSIC ATTACK//////");
                    //Debug.Log("LIKE LOOSE : " + this.playerStats.currentLikes + "-" + this.attackDico.manager[this.attacskName[0].text].likeCost);
                    this.playerStats.currentLikes += this.likebonusRand;
                    this.playerStats.currentLikes -= this.attackDico.manager[this.attacskName[0].text].likeCost;
                    this.enemy.currentLike -= this.attackDico.manager[this.attacskName[0].text].LikeDamege;

                    //Debug.Log("HEALTH NEAGTION FUNC//////////");
                    this.HealthNegation(0);
                }
                else
                {
                    //Debug.Log("COPY OPPONENT ATTACK//////");
                    this.likebonusRand = genereator.Next(this.attackDico.manager[this.attacskName[1].text].minLikeGain, this.attackDico.manager[this.attacskName[1].text].maxLikeGain + 1);
                    //Debug.Log("NEW BONUS PLAYER LIKE//////" + this.playerStats.currentLikes + "+" + this.likebonusRand);
                    this.CopyOpponenetAttack(1);
                }

                if (this.enemy.ConvertDamage != 0)
                {
                    for (int j = 0; j < this.enemy.ConvertDamage; j++)
                    {
                        this.enemy.currentLike += this.attackDico.manager[this.attacskName[0].text].Damage;
                    }

                    this.ConvertDamage = 0;
                }

                this.attackSelection = 120;
                this.hasAttack = true;

                if (this.attackDico.manager[this.attacskName[0].text].effect == ATTACK_SPECIFICATION.E_MEME && this.likebonusRand == 4)
                    this.attacks[i].interactable = true;
                else
                    this.attacks[i].interactable = false;
            }
        }

        if(this.playerStats.currentHealth <= 0)
        {
            DestroyImmediate(this.screen.currentScreen);
            this.screen.currentScreen = Instantiate(this.dedScreen, new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
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
            this.checkCost();
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

            if (this.enemy.onelikeCancel)
                this.enemy.oneLikeBonus = 0;

            if (!this.enemy.onelikeCancel)
            {
                this.onelikeCancel = true;
            }



            this.playerStats.currentLikes += this.glowUpBonus;

            if (this.repostGlowUp)
            {
                this.repostGlowUp = false;
                this.glowUpBonus -= 2;
            }

            if (this.playerStats.currentHealth <= 0)
            {
                DestroyImmediate(this.screen.currentScreen);
                this.screen.currentScreen = Instantiate(this.dedScreen, new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
                this.playerStats.reactivate = true;

                this.playerStats.currentDifficulty = 0;

                this.playerStats.currentHealth = this.playerStats.stats.health;
                this.playerStats.currentLikes = this.playerStats.stats.likes; ;

                this.playerStats.curretnAttack1 = this.playerStats.stats.nameAttack1;
                this.playerStats.curretnAttack2 = this.playerStats.stats.nameAttack2;
                this.playerStats.curretnAttack3 = this.playerStats.stats.nameAttack3;
                this.playerStats.curretnAttack4 = this.playerStats.stats.nameAttack4;

                this.playerStats.enemyCounter = this.playerStats.Pool.enemyCounter1;
                this.playerStats.upgradeCounter = this.playerStats.Pool.upgradeCounter1;
                this.playerStats.badNewsCounter = this.playerStats.Pool.BadNewsCounter1;
                this.playerStats.goodNewsCounter = this.playerStats.Pool.GoodNewsCounter1;
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

    public void UpdateTexts()
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
                //Debug.Log("DENIAL ATTACK");
                this.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_REPOST:
                //Debug.Log("repost ATTACK");
                this.repeatNextOne = true;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                //Debug.Log("boomer ATTACK");
                this.CopyAttack = true;
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                //Debug.Log("EXTRA ATTACK");
                this.onelikeCancel = false;
                this.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                //Debug.Log("GLOWUP ATTACK");
                this.glowUpBonus += 2;
                break;
        }
    }
    private void HealthNegation(int i)
    {
        if (this.attackDico.manager[this.attacskName[i].text].effect == ATTACK_SPECIFICATION.E_RATIO)
        {
            if (i == 0)
            {
                //Debug.Log("RATIO ATTACK");

                int difference = this.playerStats.currentLikes - this.enemy.currentLike;

                //Debug.Log("HEALTH LOOSE : " + this.enemy.currentHealth + "-" + difference);
                if (difference >= 0)
                    this.enemy.currentHealth -= difference;
                else if (difference < 0)
                    this.playerStats.currentHealth += difference;
            }
            if (i == 1)
            {
                //Debug.Log("RATIO ATTACK");

                int difference = this.enemy.currentLike - this.playerStats.currentLikes;

                //Debug.Log("HEALTH LOOSE : " + this.playerStats.currentHealth + "-" + difference);
                if (difference >= 0)
                    this.playerStats.currentHealth -= difference;
                else if (difference < 0)
                    this.enemy.currentHealth += difference;
            }
        }
        else
        {
            if (i == 0)
            {
                if (this.attackDico.manager[this.attacskName[i].text].Damage < 0)
                    this.playerStats.currentHealth += this.attackDico.manager[this.attacskName[i].text].Damage;
                else
                    this.enemy.currentHealth -= this.attackDico.manager[this.attacskName[i].text].Damage;
            }
            else
                this.playerStats.currentHealth -= this.attackDico.manager[this.attacskName[i].text].Damage;
        }

    }

    private void HandleRepost(ATTACK_SPECIFICATION effect)
    {
        switch (effect)
        {
            case ATTACK_SPECIFICATION.E_DENIAL:
                //Debug.Log("DENIAL REPOST");
                this.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_MEME:
                //Debug.Log("MEME REPOST");
                Debug.Log(likebonusRand);
                this.playerStats.currentLikes += this.likebonusRand;
                this.enemy.currentHealth -= this.attackDico.manager[this.attacskName[0].text].Damage;
                break;
            case ATTACK_SPECIFICATION.E_RATIO:
                //Debug.Log("RATIO REPOST");
                int difference = this.playerStats.currentLikes - this.enemy.currentLike;
                if (difference >= 0)
                    this.enemy.currentHealth -= difference;
                else if (difference < 0)
                    this.playerStats.currentHealth += difference;
                break;
            case ATTACK_SPECIFICATION.E_TUCHGRASS:
                //Debug.Log("TOUCHGRASS REPOST");
                this.enemy.currentHealth -= this.attackDico.manager[this.attacskName[0].text].Damage;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                //Debug.Log("BOOMER REPOST");
                this.CopyOpponenetAttack(1);
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                //Debug.Log("EXTRA REPOST");
                this.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                //Debug.Log("GLOWUP REPOST");
                this.repostGlowUp = true;
                this.glowUpBonus += 2;
                break;
            case ATTACK_SPECIFICATION.E_ITSFINE:
                this.playerStats.currentHealth += this.attackDico.manager[this.attacskName[0].text].Damage;
                break;
        }
    }

    private void HandleEnemyEffect(ATTACK_SPECIFICATION effect)
    {
        switch (effect)
        {
            case ATTACK_SPECIFICATION.E_DENIAL:
                //Debug.Log("DENIAL ENEMY ATTACK");
                this.enemy.ConvertDamage += 1;
                break;
            case ATTACK_SPECIFICATION.E_BOOMER:
                //Debug.Log("boomer ATTACK");
                this.enemy.CopyAttack = true;
                break;
            case ATTACK_SPECIFICATION.E_EXTRA:
                //Debug.Log("EXTRA ATTACK");
                this.enemy.onelikeCancel = false;
                this.enemy.futurOneLikeBonus += 1;
                break;
            case ATTACK_SPECIFICATION.E_GLOWUP:
                //Debug.Log("GLOWUP ATTACK");
                this.enemy.glowUpBonus += 2;
                break;
        }
    }

    private void CopyOpponenetAttack(int i)
    {
        Debug.Log("COPY ATTACK//////");
        Debug.Log("LIKE LOOSE : " + this.playerStats.currentLikes + "-" + this.attackDico.manager[this.attacskName[i].text].likeCost);

        if (i == 0)
        {
            this.enemy.currentLike += this.enemy.likebonusRand;
            this.enemy.currentLike -= this.attackDico.manager[this.attacskName[i].text].likeCost;
            this.playerStats.currentLikes -= this.attackDico.manager[this.attacskName[i].text].LikeDamege;

            if (this.attackDico.manager[this.attacskName[i].text].effect == ATTACK_SPECIFICATION.E_RATIO)
            {
                int difference = this.enemy.currentLike - this.playerStats.currentLikes;

                //Debug.Log("HEALTH LOOSE : " + this.playerStats.currentHealth + "-" + difference);
                if (difference >= 0)
                    this.playerStats.currentHealth -= difference;
                else if (difference < 0)
                    this.enemy.currentHealth += difference;
            }

            else if (this.attackDico.manager[this.attacskName[i].text].effect == ATTACK_SPECIFICATION.E_ITSFINE)
                this.enemy.currentHealth += this.attackDico.manager[this.attacskName[i].text].Damage;

            else
                this.playerStats.currentHealth -= this.attackDico.manager[this.attacskName[i].text].Damage;
        }

        else
        {
            this.playerStats.currentLikes += this.enemy.likebonusRand;
            this.playerStats.currentLikes -= this.attackDico.manager[this.attacskName[i].text].likeCost;
            this.enemy.currentLike -= this.attackDico.manager[this.attacskName[i].text].LikeDamege;
            this.HealthNegation(0);
        }

    }

    public void HandleEnemyAttack()
    {
        string enemyAttack = this.enemy.enemyAttack();

        this.attacskName[1].text = enemyAttack;
        this.attacksDescription[1].text = this.attackDico.manager[enemyAttack].description;


        //Debug.Log("--------START OF THE FUNCTION ENEMY ATTACK-----------");
        //Debug.Log("Current Enemy Health : " + this.enemy.currentHealth + "Current Enemy Like : " + this.enemy.currentLike);
        //Debug.Log("Current Player Health : " + this.playerStats.currentHealth + "Current Player Like : " + this.playerStats.currentLikes);

        Debug.Log(this.enemy.currentLike + "+" + this.enemy.glowUpBonus);
        this.enemy.currentLike += this.enemy.glowUpBonus;

        this.enemy.likebonusRand = genereator.Next(this.attackDico.manager[enemyAttack].minLikeGain, this.attackDico.manager[enemyAttack].maxLikeGain + 1);
        //Debug.Log("LIKE GAIN :" + this.enemy.likebonusRand);

        if (this.enemy.currentLike - this.attackDico.manager[enemyAttack].likeCost >= 0)
        {

            if (this.enemy.onelikeCancel)
            {
                //Debug.Log("ENEMY ONE LIKE BONUS" + " Current Enemy Like : " + this.enemy.currentLike + " + " + this.enemy.oneLikeBonus);
                this.enemy.currentLike += this.enemy.oneLikeBonus;
            }

            //Debug.Log("GO TO ENEMY HANDLE ATTACKS");
            this.HandleEnemyEffect(this.attackDico.manager[this.attacskName[1].text].effect);




            if (!this.enemy.CopyAttack)
            {
                //Debug.Log("CLASSIC ATTACK//////");
                //Debug.Log("LIKE LOOSE : " + this.enemy.currentLike + "-" + this.attackDico.manager[this.attacskName[1].text].likeCost);
                this.playerStats.currentLikes -= this.attackDico.manager[enemyAttack].LikeDamege;
                this.enemy.currentLike -= this.attackDico.manager[enemyAttack].likeCost;
                this.enemy.currentLike += this.enemy.likebonusRand;

                this.HealthNegation(1);
            }
            else
            {
                //Debug.Log("ENEMY COPY MY ATTACK");
                this.likebonusRand = genereator.Next(this.attackDico.manager[this.attacskName[0].text].minLikeGain, this.attackDico.manager[this.attacskName[1].text].maxLikeGain + 1);
                this.CopyOpponenetAttack(0);
            }

            if (this.ConvertDamage != 0)
            {
                //Debug.Log("CONVERTING THE DAMAGE INTO LIKES");
                for (int i = 0; i < this.ConvertDamage; i++)
                {
                    this.playerStats.currentLikes += this.attackDico.manager[enemyAttack].Damage;
                }

                this.ConvertDamage = 0;
            }
        }
        else
        {
            this.attacskName[1].text = "Not enouh likes";
            this.attacksDescription[1].text = "I don't have enought like to throw my attack. You're lucky !";
        }
    }
}
