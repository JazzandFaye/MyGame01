using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediator : FightingBaseMediator {
    [Inject]
    public PlayerView playerView { get; set; }

    [Inject]
    public DataBaseCommon dataBase { get; set; }
    [Inject]
    public FightingCommon common { get; set; }
    [Inject]
    public User user { get; set; }


    public override void OnRegister()
    {
        UpdateListeners(true);
        //playerView.dispatcher.AddListener(GameConfig.PlayerState.MOVE, playerView.MoveToDirection);
    }
    public override void OnRemove()
    {
        UpdateListeners(false);
    }
    protected override void UpdateListeners(bool enable)
    {
        dispatcher.UpdateListener(enable, GameConfig.PlayerState.MOVE, playerView.MoveToDirection);
        dispatcher.UpdateListener(enable, GameConfig.CoreEvent.GAME_UPDATE, playerView.GameUpdate);
        dispatcher.UpdateListener(enable, GameConfig.PropsState.ONPAUSE, OnPause);
        dispatcher.UpdateListener(enable, GameConfig.PropsState.PAUSE_RELEASE, Pause_Release);
        base.UpdateListeners(enable);
    }
    private void OnPause(IEvent payload)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Pause_Release(IEvent payload)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    protected override void InitData()
    {
        Debug.Log("开始");
        var config = dataBase.GetConfigByID(user.PlayerId, dataBase.PlayerConfigList);
        playerView.Init(config);
        GetComponent<Rigidbody>().isKinematic = false;
    }
    protected override void OnGameRestart()
    {
        InitData();
        GetComponent<Rigidbody>().isKinematic = false;
        base.OnGameRestart();
    }
}
