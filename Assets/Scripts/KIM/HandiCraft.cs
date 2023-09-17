using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
        
public class HandiCraft
{
    public string craftName;
    public string makerName;
    public string prefix;
    public string description;
    public GameObject effect;
    public Sprite craftImage;

    public void SetInfo(string name, string maker, string prefix, string effectpath,string Imagepath)
    {
        craftName = name;
        makerName = maker;
        this.prefix = prefix;
        this.description = "";
        effect = Resources.Load<GameObject>(@"effect\" + effectpath);
        craftImage = Resources.Load<Sprite>(@"handicraft\" + Imagepath);
    }
}
