using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class CraftDataManager : Manager<CraftDataManager>, IdontDestroy
{
    private List<HandiCraft> handiCraftsData = null;
    private HandiCraft currentCraft = null;
    string path = null;
    //public List<string> prefixList;
    //public List<GameObject> effectList;
    //public List<Sprite> imageList;

    [SerializeField]
    public SpriteRenderer render;

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

    public HandiCraft ReturnCraftsData()
    {
        return currentCraft;
    }
    //json data parsing
    public override void init()
    {
        DoNotDestory();
        handiCraftsData = new List<HandiCraft>();
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


    public string fileName = "UI_Screenshot.png";

    public Texture2D GetTextureFromCamera(Camera camera)
    {
        RenderTexture prev = camera.targetTexture;
        Rect rect = new Rect(600,300,camera.pixelWidth,camera.pixelHeight);

        RenderTexture renderTexture = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 24);
        Texture2D screenshot = new Texture2D(camera.pixelWidth, camera.pixelHeight, TextureFormat.RGBA32, false);

        camera.targetTexture = renderTexture;
        camera.Render();

        screenshot.ReadPixels(rect, 0, 0);
        screenshot.Apply();

        byte[] pngBytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(Path.Combine(Application.dataPath, fileName), pngBytes);
        RenderTexture.active = renderTexture;

        camera.targetTexture = prev;


        return screenshot;
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
