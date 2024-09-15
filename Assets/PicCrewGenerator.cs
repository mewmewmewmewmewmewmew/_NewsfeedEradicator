using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PicCrewGenerator : MonoBehaviour
{
    // Start is called before the first frame update


    Dictionary<string, UnityEngine.UI.Image> _picCrewObjectPairs = new Dictionary<string, UnityEngine.UI.Image>();


    public int[] attributeIndices;

    void Start()
    {
        foreach(string key in PicCrewResources.picCrewFolderPairs.Keys)
        {
            // Create a new GameObject
            GameObject newObject = new GameObject("NewImageObject");

            // Set the parent of the GameObject (like Canvas)
            newObject.transform.SetParent(this.transform, false);

            // Add an Image component to the new GameObject
            UnityEngine.UI.Image imageComponent = newObject.AddComponent<UnityEngine.UI.Image>();
            imageComponent.material = (Material)Resources.Load("Resources/unity_builtin_extra/Sprites-Default");

                // Set the size and other properties of the Image
                RectTransform rt = newObject.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(100, 100);  // Example size, adjust as necessary
            rt.anchoredPosition = new Vector2(0, 0);  // Center the image on the parent

            // Assign the sprite to the Image component
            /*if (imageSprite != null)
            {
                imageComponent.sprite = imageSprite;
            }*/
            Debug.Log(key);
            _picCrewObjectPairs.Add(key, imageComponent);
        }
        //indices = new int[PicCrewResources.picCrewFolderPairs.Count];
        RandomizeAllPicCrewAttributes();
    }

    public void RandomizePicCrewAttribute(Texture2D[] textures, UnityEngine.UI.Image image)
    {
        int random = UnityEngine.Random.Range(0, textures.Length);
        image.sprite = Sprite.Create(textures[random], new Rect(0, 0, textures[random].width, textures[random].height), new Vector2(0, 0));
        Debug.Log(image.sprite + textures[0].name);
    }

    public void RandomizeAllPicCrewAttributes()
    {
        foreach (string key in PicCrewResources.picCrewFolderPairs.Keys)
        {
            Debug.Log(key);
            RandomizePicCrewAttribute(PicCrewResources.picCrewFolderPairs[key], _picCrewObjectPairs[key]);
        }
    }

    /*public void iterateAttributeUp(List<Sprite> myAttributeList, Image image)
    {
        indexList[0]++;
        image.sprite = myAttributeList[indexList[0]];
    }*/
    /*void setAttribute(int index)
    {

        image.sprite = myAttributeList[];
        Debug.Log(image.sprite + myAttributeList[0].name);
    }*/
    
}
