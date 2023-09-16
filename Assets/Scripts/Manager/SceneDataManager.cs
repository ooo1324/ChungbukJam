using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataManager : Manager<SceneDataManager>
{

    public SpriteRenderer handiCraftObj;


    public override void init()
    {
        
    }

    public void SetHandiCraftSprite()
    {
        HandiCraft handiCraft = CraftDataManager.Instance.ReturnCraftsData();

        handiCraftObj.sprite = handiCraft.craftImage;
    }
}
