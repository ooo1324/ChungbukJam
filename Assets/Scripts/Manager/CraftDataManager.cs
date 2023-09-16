using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CraftDataManager : Manager<CraftDataManager>, IdontDestroy
{
    private List<HandiCraft> sceneCraftsList = null;
    private List<HandiCraft> handiCraftsData = null;
    string path = null;



    public List<HandiCraft> ReturnCraftsData()
    {
        return handiCraftsData;
    }
    //json data parsing
    public override void init()
    {
        path = Path.Join(Application.dataPath, "/Resources/Crafts.json");
        Debug.Log(path);
        SaveJson();
        handiCraftsData = LoadJson<CraftsContainer, HandiCraft>(path).MakeList();
        foreach (var item in handiCraftsData)
        {
            Debug.Log(item);
        }
    }
    
    public HandiCraft RandomHandieCrafts()
    {
        return handiCraftsData[Random.Range(0, handiCraftsData.Count)];
    }


    public void SaveJson()
    {
        //write data path to save
        //path = Path.Combine(Application.dataPath, "/Crafts") ?? "wrongPath";

        File.WriteAllText(path,"");
        //File.Delete(path);

        CraftsContainer container = new CraftsContainer();

        for (int i = 0; i < 35; i++)
        {
            container.crafts[i] = new Crafts("name", "maker", "prefix", "effectpath", "imagePath");
            Debug.Log(container.crafts[i].craftName);
        }

        string jsonData = JsonUtility.ToJson(container, true);
        Debug.Log(jsonData);
        File.WriteAllText(path, jsonData);
    }

    Loader LoadJson<Loader, Value>(string path) where Loader : IDataLoader<Value>
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log(path + "null or empty");
        }
        string jsonData = File.ReadAllText(path);
        //TextAsset textAsset= Resources.Load<TextAsset>(path);
        Loader data = JsonUtility.FromJson<Loader>(jsonData);
        Debug.Log(data);
        return data;
    }
    private string SetPass(string _path)
    {
        return path = Path.Join(Application.dataPath, _path);
    }

    public void DoNotDestory()
    {
        DontDestroyOnLoad(this);
    }
}
