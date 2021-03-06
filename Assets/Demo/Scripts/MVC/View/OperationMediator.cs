﻿using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class OperationMediator : FightingBaseMediator {
    [Inject]
    public OperationView view { get; set; }

    [Inject]
    public DataBaseCommon dataBase { get; set; }
    [Inject]
    public User user { get; set; }

    //注册
    public override void OnRegister()
    {
        UpdateListeners(true);
    }
    //注销
    public override void OnRemove()
    {
        UpdateListeners(false);
    }

    protected override void UpdateListeners(bool enable)
    {
        view.dispatcher.UpdateListener(enable, GameConfig.OperationEvent.CLICK_DOWN, OnOperation);
        view.dispatcher.UpdateListener(enable, GameConfig.OperationEvent.MOVE, Move);
        view.dispatcher.UpdateListener(enable, GameConfig.OperationEvent.STOP, Stop);
        base.UpdateListeners(enable);
    }

    protected override void InitData()
    {
        var config = dataBase.GetConfigByID(user.PlayerId, dataBase.PlayerConfigList);
        base.InitData();
    }

    private void OnOperation(IEvent e)
    {
        CustomEventData data = e as CustomEventData;
        e.type = GameConfig.CoreEvent.USER_INPUT;
        //派发用户输入事件
        dispatcher.Dispatch(GameConfig.CoreEvent.USER_INPUT, data);
    }

    void Move(IEvent e)
    {
        CustomEventData data = e as CustomEventData;
        e.type = GameConfig.CoreEvent.USER_INPUT;
        dispatcher.Dispatch(GameConfig.CoreEvent.USER_INPUT,data);
    }

    void Stop(IEvent e)
    {
        CustomEventData data = e as CustomEventData;
        e.type = GameConfig.CoreEvent.USER_INPUT;
        dispatcher.Dispatch(GameConfig.CoreEvent.USER_INPUT, data);
    }
}
