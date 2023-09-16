using System.IO;
using UnityEngine;
using UnityEngine.UI;
        
public class HandiCraft
{
    public string craftName;
    public string makerName;
    public string prefix;
    public GameObject effect;
    public Sprite craftImage;

    public void SetInfo(string name, string maker, string prefix, string effectpath,string Imagepath)
    {
        craftName = name;
        makerName = maker;
        this.prefix = prefix;
        effect = Resources.Load(effectpath) as GameObject ?? new GameObject();
        craftImage = Resources.Load<Sprite>(Imagepath);
    }
}
