using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicCrewGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Sprite> ClothesAttributes = new List<Sprite>();
    Sprite CurrentClothesAttribute;
    public List<Sprite> EyeAttributes = new List<Sprite>();
    Sprite CurrentEyeAttribute;
    public List<Sprite> HairAttributes = new List<Sprite>();
    Sprite CurrentHairAttribute;
    public List<Sprite> MouthAttributes = new List<Sprite>();
    Sprite CurrentMouthAtrribute;
    public List<Sprite> BaseAttributes= new List<Sprite>();
    Sprite CurrentBaseAttribute;

    public Image Clothes;
    public Image Eye;
    public Image Hair;
    public Image Mouth;
    public Image Base;

    List<Image> images= new List<Image>();

    List<List<Sprite>> AllAttributeLists= new List<List<Sprite>>();
    List<Sprite> AllAttributes= new List<Sprite>();
    void Start()
    {
        //5
        images.Add(Clothes);  images.Add(Eye); images.Add(Hair); images.Add (Base); images.Add(Mouth);
        //5
        AllAttributes.Add(CurrentClothesAttribute); AllAttributes.Add(CurrentEyeAttribute); AllAttributes.Add(CurrentHairAttribute); AllAttributes.Add(CurrentBaseAttribute); AllAttributes.Add(CurrentMouthAtrribute);
        //5
        AllAttributeLists.Add(ClothesAttributes); AllAttributeLists.Add(EyeAttributes); AllAttributeLists.Add(HairAttributes); AllAttributeLists.Add(BaseAttributes); AllAttributeLists.Add(MouthAttributes);
        RandomizeAllPicCrewAttributes();
    }

    void RandomizePicCrewAttribute( List<Sprite> myAttributeList, Image image)
    {

        image.sprite = myAttributeList[Random.Range(0, myAttributeList.Count)];
        Debug.Log(image.sprite + myAttributeList[0].name);

    }

    public void RandomizeAllPicCrewAttributes()
    {
        for (int i = 0; i < AllAttributeLists.Count; i++)
        {

            RandomizePicCrewAttribute(AllAttributeLists[i], images[i]);
        }
    }
}
