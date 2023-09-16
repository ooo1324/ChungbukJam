using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HandiCraft
{
    string craftName;
    string makerName;
    string prefix;
    GameObject effect;
    Image craftImage;

    public void SetInfo(string name, string maker, string prefix, string effectpath,string Imagepath)
    {
        craftName = name;
        makerName = maker;
        this.prefix = prefix;
        effect = Resources.Load<GameObject>(effectpath)?? null;
        craftImage = Resources.Load<Image>(Imagepath)?? null;
    }
}
