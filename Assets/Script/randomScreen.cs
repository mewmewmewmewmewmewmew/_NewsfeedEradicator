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
    public int length;
    private GameObject currentScreen;
    private GameObject[] sideScreens;

    private int numberOne;
    private int numberTwo;
    private int numberThree;
    private System.Random genereator;

    public playerStats playerStats;
    public upgradeAtatcks upgradeAtatcks;
    public bonusManager bonusManager;

    void Start()
    {
        this.sideScreens = new GameObject[3];

        genereator = new System.Random();

        this.numberOne = genereator.Next(length);
        this.numberTwo = genereator.Next(length);
        this.numberThree = genereator.Next(length);

        this.sideScreens[0] = Instantiate(this.prefabList[numberOne], new Vector3(0, 0, 0.2f), Quaternion.identity);
        this.sideScreens[1] = Instantiate(this.prefabList[numberTwo], new Vector3(0, 0, 0.2f), Quaternion.identity);
        this.sideScreens[2] = Instantiate(this.prefabList[numberThree], new Vector3(0, 0, 0.2f), Quaternion.identity);

        this.currentScreen = Instantiate(this.prefabList[genereator.Next(length)], new Vector3(0, 0, 0), Quaternion.identity);

        while (this.currentScreen.CompareTag("Enemy") || this.currentScreen.CompareTag("Upgrade") || this.currentScreen.CompareTag("Cat") || this.currentScreen.CompareTag("Dog"))
        {
            DestroyImmediate(this.currentScreen, true);
            this.currentScreen = Instantiate(this.prefabList[genereator.Next(length)], new Vector3(0, 0, 0), Quaternion.identity);
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

        if (this.currentScreen.CompareTag("Cat"))
            this.bonusManager.deleteImage();
        else if (this.currentScreen.CompareTag("Dog"))
            this.bonusManager.deleteImage();

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

        this.numberOne = genereator.Next(length);
        this.numberTwo = genereator.Next(length);
        this.numberThree = genereator.Next(length);

        this.sideScreens[0] = Instantiate(this.prefabList[numberOne], new Vector3(0, 0, 0.5f), Quaternion.identity);
        this.sideScreens[1] = Instantiate(this.prefabList[numberTwo], new Vector3(0, 0, 0.5f), Quaternion.identity);
        this.sideScreens[2] = Instantiate(this.prefabList[numberThree], new Vector3(0, 0, 0.5f), Quaternion.identity);

        for(int i = 0; i < 3; i++)
        {
            if(this.sideScreens[i].CompareTag("Enemy"))
                this.sideScreens[i].GetComponent<enemyScript>().deactivateEnemy();
        }

        this.handleScreenTag();
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
                this.sideScreens[1].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[2].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[0].transform.position = new Vector3(0, 0, 0.2f);
                break;
            case 1:
                this.sideScreens[0].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[2].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[1].transform.position = new Vector3(0, 0, 0.2f);
                break;
            case 2:
                this.sideScreens[0].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[1].transform.position = new Vector3(0, 0, 1);
                this.sideScreens[2].transform.position = new Vector3(0, 0, 0.2f);
                break;
        }
    }

    private void handleScreenTag()
    {
        if (currentScreen.CompareTag("Enemy"))
        {
            this.playerStats.activateAttackButton();
            this.icons[0].gameObject.SetActive(false);
            this.icons[1].gameObject.SetActive(false);
            this.icons[2].gameObject.SetActive(false);
            this.currentScreen.GetComponent<enemyScript>().ActivateEnemy();
            this.playerStats.isAttacking = true;
            return;
        }

        else if (currentScreen.CompareTag("Upgrade"))
        {
            this.icons[0].gameObject.SetActive(false);
            this.icons[1].gameObject.SetActive(false);
            this.icons[2].gameObject.SetActive(false);
            this.upgradeAtatcks.setUpUpgradeScreen();
            return;
        }

        else if (currentScreen.CompareTag("Cat"))
        {
            this.bonusManager.getRandomCatImages(this.playerStats);
            return;
        }

        else if (currentScreen.CompareTag("Dog"))
        {
            this.bonusManager.getRandomDogImage(this.playerStats);
            return;
        }

        else
        {
            this.playerStats.deactivateAttackButton();
            this.icons[0].gameObject.SetActive(true);
            this.icons[1].gameObject.SetActive(true);
            this.icons[2].gameObject.SetActive(true);
        }
    }
}
