using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonusManager : MonoBehaviour
{
    public Sprite[] catManager;
    public Sprite[] dogManager;

    public GameObject currentImage;
    public void getRandomCatImages(playerStats playerStats)
    {
        System.Random genereator = new System.Random();

        this.currentImage.SetActive(true);
        this.currentImage.GetComponent<Image>().sprite =  this.catManager[genereator.Next(this.catManager.Length)];

        playerStats.currentHealth += genereator.Next(1, 3);
    }

    public void getRandomDogImage(playerStats playerStats)
    {
        System.Random genereator = new System.Random();

        this.currentImage.SetActive(true);
        this.currentImage.GetComponent<Image>().sprite = this.dogManager[genereator.Next(this.dogManager.Length)];


        if (playerStats.currentDifficulty == 0)  
            playerStats.currentLikes += genereator.Next(1, 4);
        if(playerStats.currentLikes == 1)
            playerStats.currentHealth += genereator.Next(3, 6);
        if(playerStats.currentDifficulty == 2)
            playerStats.currentLikes += genereator.Next(6, 11);
    }

    public void deleteImage()
    {
       this.currentImage.SetActive(false);
    }
}
