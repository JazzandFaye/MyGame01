using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationView : FightingBaseView {

    [Inject]
    public FightingCommon common { get; set; }

    [Inject]
    public MapModel map { get; set; }

    //有按键按下时
    //public void OnClick(GameObject o)
    //{
    //    Debug.Log("输入"+o.name);
    //    CustomOperationEventData data = new CustomOperationEventData
    //    {
    //        type = GameConfig.OperationEvent.CLICK_DOWN,
    //        str = o.name,
           
    //        OperationEventType = GameConfig.OperationEvent.CLICK_DOWN
            
    //    };
        
    //    common.SwithMoveDir(data);
    //    common.SwithCamDir(data);
    //    dispatcher.Dispatch(GameConfig.OperationEvent.CLICK_DOWN, data);
    //}

    ////有按键抬起时
    //public void OnRelease(GameObject o)
    //{
    //    CustomOperationEventData data = new CustomOperationEventData
    //    {
    //        type = GameConfig.OperationEvent.CLICK_UP,
    //        str = o.name,
    //     OperationEventType = GameConfig.OperationEvent.CLICK_UP
    //    };
    //    common.SwithMoveDir(data);
    //    common.SwithCamDir(data);
    //    dispatcher.Dispatch(GameConfig.OperationEvent.CLICK_UP, data);
    //}

    public void Update()
    {
        GameUpdate();
    }

    //监听玩家对角色的输入
    public override void GameUpdate()
    {
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {
            CustomOperationEventData data = new CustomOperationEventData
            {
                type = GameConfig.OperationEvent.MOVE,
                ismoving = true,
                OperationEventType = GameConfig.OperationEvent.MOVE
            };
            dispatcher.Dispatch(GameConfig.OperationEvent.MOVE, data);
        }
        if (Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S))
        {
            CustomOperationEventData data = new CustomOperationEventData
            {
                type = GameConfig.OperationEvent.STOP,
                ismoving = false,
                OperationEventType = GameConfig.OperationEvent.STOP
            };
            dispatcher.Dispatch(GameConfig.OperationEvent.STOP, data);
        }

     
    }
}
