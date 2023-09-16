using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>, IdontDestroy
{
    public void DoNotDestory()
    {
        DontDestroyOnLoad(this);
    }

    public override void init()
    {
        DoNotDestory();
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
