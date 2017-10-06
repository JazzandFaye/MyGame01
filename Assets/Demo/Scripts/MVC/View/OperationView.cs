using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationView : FightingBaseView {


    [Inject]
    public MapModel map { get; set; }

    public void Update()
    {
        GameUpdate();
    }

    //监听玩家对角色的输入
    public override void GameUpdate()
    {
        //移动
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
        //停止
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
        //被攻击
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("按下鼠标左键");
            CustomOperationEventData data = new CustomOperationEventData
            {
                type = GameConfig.OperationEvent.BEATTACKED,
                ismoving = false,
                OperationEventType = GameConfig.OperationEvent.BEATTACKED
            };
            Debug.Log("发送BEATTACKED事件");
            dispatcher.Dispatch(GameConfig.OperationEvent.BEATTACKED, data);
        }

     
    }
}
