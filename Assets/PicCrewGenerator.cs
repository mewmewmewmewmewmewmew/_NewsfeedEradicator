using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicCrewGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> ClothesAttributes = new List<GameObject>();
    GameObject CurrentClothesAttribute;
    public List<GameObject> EyeAttributes = new List<GameObject>();
    GameObject CurrentEyeAttribute;
    public List<GameObject> HairAttributes = new List<GameObject>();
    GameObject CurrentHairAttribute;
    public List<GameObject> MouthAttributes = new List<GameObject>();
    GameObject CurrentMouthAtrribute;
    public List<GameObject> BaseAttributes= new List<GameObject>();
    GameObject CurrentBaseAttribute;

    List<List<GameObject>> AllAttributes= new List<List<GameObject>>();
    void Start()
    {
        AllAttributes.Add(ClothesAttributes); AllAttributes.Add(EyeAttributes); AllAttributes.Add(HairAttributes); AllAttributes.Add(MouthAttributes); AllAttributes.Add(BaseAttributes);
    }

    void RandomizePicCrewAttribute(GameObject myAttribute, List<GameObject> myAttributeList)
    {
        myAttribute = myAttributeList(Random.Range(0, myAttributeList.Count-1));
    }

    void RandomizeAllPicCrewAttributes()
    {

    }
    void setPicCrew()
    {

    }

    void clearPicCrew()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
