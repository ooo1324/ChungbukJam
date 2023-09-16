using System;
using System.Collections.Generic;


public enum PrefixEnum
{
    beautiful,
    dynamic,
    artistic,
    unique,
    elaborate,
    traditional,
    modern,
    heavenly,
    defective,
    shimmering,
    small
}

public enum EffectEnum
{
    effectPath
}
//blazing,
//shining,
//flashing
public enum CraftEnum
{
    imagePath
}
public class CraftsContainer : IDataLoader<HandiCraft>
{
    public Crafts[] crafts = null;

    public CraftsContainer()
    {
        this.crafts = new Crafts[35];
    }

    public List<HandiCraft> MakeList()
    {
        List<HandiCraft> handiCrafts = new List<HandiCraft>();
        foreach (var craft in crafts) 
        {
            handiCrafts.Add(craft.GetHandieCraft());
        }
        //list.Add();
        return handiCrafts;
    }
}

[Serializable]
public class Crafts
{
    public string craftName;
    public string makerName;
    public string prefix;
    public string effectPath;
    public string craftImage;

    public Crafts(string name, string maker, string prefix, string effectpath,string craftImagePath)
    {
        this.craftName = name;
        this.makerName = maker;
        this.prefix = prefix;
        this.effectPath = effectpath;
        craftImage = craftImagePath;
    }

    public HandiCraft GetHandieCraft()
    {
        HandiCraft handiCraft = new HandiCraft();
        handiCraft.SetInfo(craftName, makerName, prefix, effectPath, craftImage);
        return handiCraft;
    }



}
