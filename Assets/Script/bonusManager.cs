using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bonusManager : MonoBehaviour
{
    public Sprite[] catManager;
    public Sprite[] dogManager;

    public string[] catPhrase;
    public string[] dogPhrase;
    public void getRandomCatImages(GameObject currentScreen)
    {
        System.Random genereator = new System.Random();

        int index = genereator.Next(this.catManager.Length);
        currentScreen.GetComponentInChildren<Image>().sprite =  this.catManager[index];
        currentScreen.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.catPhrase[index];

    }

    public void getRandomDogImage(GameObject currentScreen)
    {
        System.Random genereator = new System.Random();

        int index = genereator.Next(this.dogManager.Length);

        currentScreen.GetComponentInChildren<Image>().sprite = this.dogManager[index];
        currentScreen.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.dogPhrase[index];
    }
}
