using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonusManager : MonoBehaviour
{
    public Sprite[] catManager;
    public Sprite[] dogManager;
    public void getRandomCatImages(GameObject currentScreen)
    {
        System.Random genereator = new System.Random();

        currentScreen.GetComponentInChildren<Image>().sprite =  this.catManager[genereator.Next(this.catManager.Length)];
    }

    public void getRandomDogImage(GameObject currentScreen)
    {
        System.Random genereator = new System.Random();

        currentScreen.GetComponentInChildren<Image>().sprite = this.dogManager[genereator.Next(this.dogManager.Length)];
    }
}
