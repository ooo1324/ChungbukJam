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
    LightningMissileBlue,
    LightningMissileGreen,
    LightningMissilePink,
    LightningMissileYellow,
    LightningSoftMissileBlue,
    LightningSoftMissileGreen,
    LightningSoftMissilePink,
    LightningSoftMissileYellow,
    MagicAuraBlue,
    MagicAuraGreen,
    MagicAuraYellow,
    MagicEnchantBlue,
    MagicEnchantGreen,
    MagicEnchantYellow,
    MagicMissileBlue,
    MagicMissileFire,
    MagicMissileGreen,
    MagicMissilePink,
    MagicSphereBlue,
    MagicSphereGreen,
    MagicSphereYellow
}
//blazing,
//shining,
//flashing
public enum CraftEnum
{
    BrokenCraft0101,
    BrokenCraft0102,
    BrokenCraft0103,
    BrokenCraft0104,
    BrokenCraft0201,
    BrokenCraft0202,
    BrokenCraft0203,
    BrokenCraft0204,
    BrokenCraft0301,
    BrokenCraft0302,
    BrokenCraft0303,
    BrokenCraft0304,
    BrokenCraft0401,
    BrokenCraft0402,
    BrokenCraft0403,
    BrokenCraft0404,
    BrokenCraft0501,
    BrokenCraft0502,
    BrokenCraft0503,
    BrokenCraft0504,
    BrokenCraft0601,
    BrokenCraft0602,
    BrokenCraft0603,
    BrokenCraft0604,
    BrokenCraft0701,
    BrokenCraft0702,
    BrokenCraft0703,
    BrokenCraft0704,
    BrokenCraft0801,
    BrokenCraft0802,
    BrokenCraft0803,
    BrokenCraft0804,
    BrokenCraft0901,
    BrokenCraft0902,
    BrokenCraft0903,
    BrokenCraft0904
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
