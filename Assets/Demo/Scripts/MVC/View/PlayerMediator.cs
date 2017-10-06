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
    public FightingCommon Common { get; set; }
    [Inject]
    public User user { get; set; }

    [Inject]
    public IUnitAPI common { get; set; }

    public override void OnRegister()
    {
        //var config = dataBase.GetConfigByID(user.PlayerId, dataBase.PlayerConfigList);
        //config = common.LoadConfig<PlayerConfig>();
        //Debug.Log(dataBase.GetConfigByID(user.PlayerId, dataBase.PlayerConfigList));
        //foreach (var item in dataBase.PlayerConfigList)
        //{
        //    Debug.Log(item);
        //}
        //Debug.Log(user.PlayerId);
        //playerView.Init(config);
        //GetComponent<Rigidbody>().isKinematic = false;
        UpdateListeners(true);        
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
        var config = dataBase.GetConfigByID(user.PlayerId, dataBase.PlayerConfigList);
        playerView.Init(config);
        Debug.Log(config.Atk);
        Debug.Log("test");
        GetComponent<Rigidbody>().isKinematic = false;
    }
    protected override void OnGameRestart()
    {
        InitData();
        GetComponent<Rigidbody>().isKinematic = false;
        base.OnGameRestart();
    }
}
