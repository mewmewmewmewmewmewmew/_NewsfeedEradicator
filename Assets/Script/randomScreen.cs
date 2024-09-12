using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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
    public ParameterController sound;

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

        while (this.currentScreen.CompareTag("Enemy") || this.currentScreen.CompareTag("Upgrade") || this.currentScreen.CompareTag("Cat") || this.currentScreen.CompareTag("Dog"))
        {
            DestroyImmediate(this.currentScreen, true);
            this.currentScreen = Instantiate(this.prefabList[genereator.Next(this.prefabList.Length)], new Vector3(0, 0, 5), Quaternion.identity, GameObject.FindGameObjectWithTag("Mask").transform);
        }

        this.currentScreen.transform.SetAsFirstSibling();

        for (int i = 0; i < this.sideScreens.Length; i++)
        {
            this.sideScreens[i].transform.SetAsFirstSibling();

            if (this.sideScreens[i].CompareTag("Cat"))
                this.bonusManager.getRandomCatImages(this.sideScreens[i]);

            if (this.sideScreens[i].CompareTag("Dog"))
                this.bonusManager.getRandomDogImage(this.sideScreens[i]);
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

        

        for (int i = 0; i < this.sideScreens.Length; i++)
        {
            this.sideScreens[i].transform.SetAsFirstSibling();

            if (this.sideScreens[i].CompareTag("Cat"))
                this.bonusManager.getRandomCatImages(this.sideScreens[i]);

            if (this.sideScreens[i].CompareTag("Dog"))
                this.bonusManager.getRandomDogImage(this.sideScreens[i]);

            if (this.sideScreens[i].CompareTag("AttackEnemy"))
            {
                GameObject[] array = GameObject.FindGameObjectsWithTag("AttackIcon");

                for (int i = 0; i < array.Length; i++)
                    array[i].gameObject.SetActive(false);
            }
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
            GameObject[] array = GameObject.FindGameObjectsWithTag("AttackIcon");

            for(int i = 0; i < array.Length; i++)
                array[i].gameObject.SetActive(true);

            return;
        }

        else if (currentScreen.CompareTag("Cat"))
        {
            sound.SetParameter("GameMusic", 0);
            this.currentScreen.GetComponent<CatBonus>().AddHealth();
        }

        else if (currentScreen.CompareTag("Dog"))
        {
            sound.SetParameter("GameMusic", 0);
            this.currentScreen.GetComponent<DogBonus>().AddLikes();
        }

        else if (currentScreen.CompareTag("Upgrade"))
        {
            sound.SetParameter("GameMusic", 5);
            this.icons[0].gameObject.SetActive(false);
            this.icons[1].gameObject.SetActive(false);
            this.icons[2].gameObject.SetActive(false);
            return;
        }

        else
        {
            this.icons[0].gameObject.SetActive(true);
            this.icons[1].gameObject.SetActive(true);
            this.icons[2].gameObject.SetActive(true);
        }
    }
}
