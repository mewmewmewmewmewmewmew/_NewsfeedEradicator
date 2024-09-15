using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PicCrewResources
{
    public static Dictionary<string, Texture2D[]> picCrewFolderPairs = new Dictionary<string, Texture2D[]>();
    public static void LoadPicCrew()
    {
        string fullPath = Application.dataPath + "/Resources/picCrewResources";
        DirectoryInfo myDirectoryInfo = new DirectoryInfo(fullPath);
        foreach(var folder in myDirectoryInfo.GetDirectories())
        {
            var foundImages = Resources.LoadAll("picCrewResources/" + folder.Name, typeof(Texture2D));
            Debug.Log(folder.FullName);
            Debug.Log(foundImages.Length);
            Texture2D[] myTextureArray = new Texture2D[foundImages.Length];
            for(int i = 0;i < foundImages.Length; i++)
            {
                myTextureArray[i] = (Texture2D)foundImages[i];
            }
            picCrewFolderPairs.Add(folder.Name, myTextureArray);
        }
    }
}
