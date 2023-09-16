using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CraftDataManager : Manager<CraftDataManager>, IdontDestroy
{
    private List<HandiCraft> handiCraftsData = null;
    private HandiCraft currentCraft = null;
    string path = null;

    //public List<string> prefixList;
    //public List<GameObject> effectList;
    //public List<Sprite> imageList;

    PrefixEnum prefix;
    EffectEnum effect;
    CraftEnum craft;

    public void AddCraftList(HandiCraft handi)
    {
        handiCraftsData.Add(handi);
        currentCraft = handi;
    }
    public void RemoveCraftList()
    {
        handiCraftsData?.Remove(currentCraft);
        currentCraft = null;
    }

    public List<HandiCraft> ReturnCraftsData()
    {
        return handiCraftsData;
    }
    //json data parsing
    public override void init()
    {
        DoNotDestory();
    }
    
    public HandiCraft RandomHandieCrafts()
    {
        var prefixCount = Enum.GetNames(typeof(PrefixEnum)).Length;
        var effectCount = Enum.GetNames(typeof(EffectEnum)).Length;
        var imageCount = Enum.GetNames(typeof(CraftEnum)).Length;
        HandiCraft handiCraft = new HandiCraft();

        prefix = (PrefixEnum)UnityEngine.Random.Range(0, prefixCount);
        effect = (EffectEnum)UnityEngine.Random.Range(0, effectCount);
        craft = (CraftEnum)UnityEngine.Random.Range(0, imageCount);

        handiCraft.SetInfo("name", "maker", prefix.ToString(), effect.ToString(), craft.ToString());
        currentCraft = handiCraft;
        return handiCraft;
    }

    public void DoNotDestory()
    {
        DontDestroyOnLoad(this);
    }

}

//public void SaveJson()
//{
//    //write data path to save
//    //path = Path.Combine(Application.dataPath, "/Crafts") ?? "wrongPath";

//    File.WriteAllText(path,"");
//    //File.Delete(path);

//    CraftsContainer container = new CraftsContainer();

//    for (int i = 0; i < 35; i++)
//    {
//        container.crafts[i] = new Crafts("name", "maker", "prefix", "effectpath", "imagePath");
//        Debug.Log(container.crafts[i].craftName);
//    }

//    string jsonData = JsonUtility.ToJson(container, true);
//    Debug.Log(jsonData);
//    File.WriteAllText(path, jsonData);
//}

//Loader LoadJson<Loader, Value>(string path) where Loader : IDataLoader<Value>
//{
//    if (string.IsNullOrEmpty(path))
//    {
//        Debug.Log(path + "null or empty");
//    }
//    string jsonData = File.ReadAllText(path);
//    //TextAsset textAsset= Resources.Load<TextAsset>(path);
//    Loader data = JsonUtility.FromJson<Loader>(jsonData);
//    Debug.Log(data);
//    return data;
//}
//private string SetPass(string _path)
//{
//    return path = Path.Join(Application.dataPath, _path);
//}
