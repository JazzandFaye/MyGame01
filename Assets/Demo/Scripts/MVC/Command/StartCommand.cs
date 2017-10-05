using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using Sirenix.OdinInspector.Demos;
using UnityEngine;

public class StartCommand : EventCommand {

    [Inject]
    public DataBaseCommon database { get; set; }

    [Inject]
    public MapModel map { get; set; }

    //开始命令，用来做一些初始化工作，框架外的东西也可以在这里Init
    //当这个命令执行时，默认调用Execute方法
    public override void Execute()
    {
        //这里做数据的初始化和储存
        database.Init();
        map.MapDir = new string[4] { "North", "West", "South", "East" };
        map.DirArray = new string[4] { "W", "A", "S", "D" };

        Debug.Log("StartCommand Execute");
        MapGenerator mapGenerator = GameObject.Find("Edge").GetComponent<MapGenerator>();
        ObjectPlacer objGenerator = GameObject.Find("Element").GetComponent<ObjectPlacer>();
        dispatcher.Dispatch(GameConfig.CoreEvent.GAME_START);
        

        mapGenerator.GenerateMap();
        objGenerator.ClearAndRepositionObjects();
        InventoryManager.Instance.Init();
        //UIPanelManager.Instance.Init();
        //UIPanelManager.Instance.PushPanel(UIPanelType.MainMenuPanel);
    }
}
