using System.Collections.Generic;
using UnityEngine;

public class randomScreen : MonoBehaviour
{
    public GameObject[] icons;
    public GameObject[] prefabList;
    private GameObject currentScreen;
    private GameObject[] sideScreens;

    private int numberOne;
    private int numberTwo;
    private int numberThree;
    private System.Random genereator;

    public playerStats playerStats;
    public bonusManager bonusManager;
    public attackManager attackManager;
    public ParameterController sound;

    public Mesh upgradeMesh;
    public Material upgradeMaterial;

    public Mesh attackMesh;
    public Material attackMaterail;

    public Mesh feedMesh;
    public Material feedMaterail;


    void Start()
    {
        this.sideScreens = new GameObject[3];

        genereator = new System.Random();

        this.numberOne = genereator.Next(this.prefabList.Length);
        this.numberTwo = genereator.Next(this.prefabList.Length);
        this.numberThree = genereator.Next(this.prefabList.Length);

        this.sideScreens[0] = Instantiate(this.prefabList[numberOne], new Vector3(0, 0, 6), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
        this.sideScreens[1] = Instantiate(this.prefabList[numberTwo], new Vector3(0, 0, 6), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
        this.sideScreens[2] = Instantiate(this.prefabList[numberThree], new Vector3(0, 0, 6), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);

        this.currentScreen = Instantiate(this.prefabList[genereator.Next(this.prefabList.Length)], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);

        while (this.currentScreen.CompareTag("Enemy") || this.currentScreen.CompareTag("Upgrade") || this.currentScreen.CompareTag("FeedPost"))
        {
            DestroyImmediate(this.currentScreen, true);
            this.currentScreen = Instantiate(this.prefabList[genereator.Next(this.prefabList.Length)], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
        }

        this.currentScreen.transform.SetAsFirstSibling();

        for (int i = 0; i < this.sideScreens.Length; i++)
        {
            this.sideScreens[i].transform.SetAsFirstSibling();

            if (this.sideScreens[i].CompareTag("FeedPost"))
            {
                this.FeedPostRandom(i);
                this.icons[i].GetComponent<MeshFilter>().sharedMesh = this.feedMesh;
                this.icons[i].GetComponent<MeshRenderer>().material = this.feedMaterail;
            }

            if (this.sideScreens[i].CompareTag("Enemy"))
            {
                this.FeedPostRandom(i);
                this.icons[i].GetComponent<MeshFilter>().sharedMesh = this.attackMesh;
                this.icons[i].GetComponent<MeshRenderer>().material = this.attackMaterail;
            }

            if (this.sideScreens[i].CompareTag("Upgrade"))
            {
                this.FeedPostRandom(i);
                this.icons[i].GetComponent<MeshFilter>().sharedMesh = this.upgradeMesh;
                this.icons[i].GetComponent<MeshRenderer>().material = this.upgradeMaterial;
            }

        }

        for (int i = 0; i < this.icons.Length; i++)
        {
            this.icons[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (this.playerStats.reactivate)
        {
            for (int i = 0; i < this.icons.Length; i++) 
            {
                this.icons[i].SetActive(true);
            }

            this.playerStats.reactivate = false;
        }
            
    }

    public void Switchto(int number)
    {
        GameObject temp = currentScreen;
        this.currentScreen.transform.SetAsFirstSibling();

        //if (this.currentScreen.CompareTag("Enemy"))
        //{
        //    GameObject[] icons = GameObject.FindGameObjectsWithTag("AttackIcon");

        //    for(int i = 0;i < icons.Length; i++)
        //    {
        //        DestroyImmediate(icons[i]);
        //    }
        //}

        switch (number)
        {
            case 0:
                this.currentScreen = this.sideScreens[0];
                DestroyImmediate(temp, true);
                DestroyImmediate(this.sideScreens[1], true);
                DestroyImmediate(this.sideScreens[2], true);
                this.icons[2].SetActive(true);
                this.icons[1].SetActive(true);
                this.icons[0].SetActive(true);
                break;
            case 1:
                this.currentScreen = this.sideScreens[1];
                DestroyImmediate(temp, true);
                DestroyImmediate(this.sideScreens[0], true);
                DestroyImmediate(this.sideScreens[2], true);
                this.icons[2].SetActive(true);
                this.icons[1].SetActive(true);
                this.icons[0].SetActive(true);
                break;
            case 2:
                this.currentScreen = this.sideScreens[2];
                DestroyImmediate(temp, true);
                DestroyImmediate(this.sideScreens[1], true);
                DestroyImmediate(this.sideScreens[0], true);
                this.icons[2].SetActive(true);
                this.icons[1].SetActive(true);
                this.icons[0].SetActive(true);
                break;
        }

        this.handleScreenTag();

        this.numberOne = genereator.Next(this.prefabList.Length);
        this.numberTwo = genereator.Next(this.prefabList.Length);
        this.numberThree = genereator.Next(this.prefabList.Length);

        this.sideScreens[0] = Instantiate(this.prefabList[numberOne], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
        this.sideScreens[1] = Instantiate(this.prefabList[numberTwo], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
        this.sideScreens[2] = Instantiate(this.prefabList[numberThree], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);

        this.HandlePool();


        for (int i = 0; i < this.sideScreens.Length; i++)
        {
            this.sideScreens[i].transform.SetAsFirstSibling();

            if (this.sideScreens[i].CompareTag("FeedPost"))
                this.FeedPostRandom(i);
        }
    }

    private void HandlePool()
    {
        List<string> list = new List<string>();

        if (this.playerStats.badNewsCounter == 0 && this.playerStats.goodNewsCounter == 0)
            list.Add("FeedPost");

        if (this.playerStats.upgradeCounter == 0)
            list.Add("Upgrade");

        bool isOkay = true;
        
        for(int i = 0; i < this.sideScreens.Length; i++)
        {
            for(int j = 0; j < list.Count; j++)
            {
                if (this.sideScreens[i].CompareTag(list[j]))
                    isOkay = false;
            }

            if (!isOkay)
            {
                DestroyImmediate(this.sideScreens[i], true);
                this.sideScreens[i] = Instantiate(this.prefabList[this.genereator.Next(this.prefabList.Length)], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform); ;
                i--;
            }

            isOkay = true;
        }
    }

    public void MoveScreen(Vector3 position)
    {
        this.currentScreen.transform.position = position;
    }

    public void SetScreenBehind(int number)
    {
        switch (number)
        {
            case 0:
                this.sideScreens[0].transform.SetAsFirstSibling();
                this.sideScreens[1].transform.SetAsFirstSibling();
                this.sideScreens[2].transform.SetAsFirstSibling();
                
                break;
            case 1:
                this.sideScreens[1].transform.SetAsFirstSibling();
                this.sideScreens[2].transform.SetAsFirstSibling();
                this.sideScreens[0].transform.SetAsFirstSibling();
                break;
            case 2:
                this.sideScreens[2].transform.SetAsFirstSibling();
                this.sideScreens[1].transform.SetAsFirstSibling();
                this.sideScreens[0].transform.SetAsFirstSibling();
                break;
        }
    }

    private void handleScreenTag()
    {
        if (currentScreen.CompareTag("Enemy"))
        {
            this.icons[0].gameObject.SetActive(false);
            this.icons[1].gameObject.SetActive(false);
            this.icons[2].gameObject.SetActive(false);
            sound.SetParameter("GameMusic", playerStats.currentDifficulty + 1);

            if (--this.playerStats.enemyCounter == 0) 
            {
                this.playerStats.currentDifficulty += 1;
                this.playerStats.ResetCounters(this.playerStats.currentDifficulty);
            }



            //Instantiate(this.attackManager.manager[this.playerStats.curretnAttack1].Icon);
            //Instantiate(this.attackManager.manager[this.playerStats.curretnAttack2].Icon);
            //Instantiate(this.attackManager.manager[this.playerStats.curretnAttack3].Icon);
            //Instantiate(this.attackManager.manager[this.playerStats.curretnAttack4].Icon);

            return;
        }

        else if (currentScreen.CompareTag("FeedPost"))
        {
            sound.SetParameter("GameMusic", 0);
            bool good = this.currentScreen.GetComponent<CatBonus>().isEvil;

            if (good) 
                this.playerStats.badNewsCounter--;
            else 
                this.playerStats.goodNewsCounter--;
        }

        else if (currentScreen.CompareTag("Upgrade"))
        {
            sound.SetParameter("GameMusic", 5);
            this.icons[0].gameObject.SetActive(false);
            this.icons[1].gameObject.SetActive(false);
            this.icons[2].gameObject.SetActive(false);
            this.playerStats.upgradeCounter--;
            return;
        }

        else
        {
            this.icons[0].gameObject.SetActive(true);
            this.icons[1].gameObject.SetActive(true);
            this.icons[2].gameObject.SetActive(true);
        }
    }

    private void FeedPostRandom(int number)
    {
        int lol = this.genereator.Next(1);

        if (this.playerStats.goodNewsCounter == 0)
            lol = 1;

        if(this.playerStats.badNewsCounter == 0) 
            lol = 0;

        if(lol == 0)
        {
            this.bonusManager.getRandomCatImages(this.sideScreens[number]);
            this.sideScreens[number].GetComponent<CatBonus>().isEvil = false;
        }

        else if (lol == 1)
        {
            this.bonusManager.getRandomDogImage(this.sideScreens[number]);
            this.sideScreens[number].GetComponent<CatBonus>().isEvil = true;
        }
    }
}
