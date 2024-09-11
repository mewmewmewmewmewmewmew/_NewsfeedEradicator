using System.Collections.Generic;
using UnityEngine;

public class attackManager : MonoBehaviour
{
    public Dictionary<string, newStat> manager;
    public newStat[] attacks;
    // Start is called before the first frame update
    void Start()
    {
        this.manager = new Dictionary<string, newStat>();

        for(int i = 0; i < attacks.Length; i++)
        {
            this.manager[attacks[i].name] = attacks[i];
        }
    }
}
