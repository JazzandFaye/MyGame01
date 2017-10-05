using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

//EventMediator是自带一个全局派发器
public class TestMediator : EventMediator {
    [Inject]
    public TestView view { get; set; }
    public override void OnRegister()
    {
        UpdateListenter(true);
    }
    public override void OnRemove()
    {
        UpdateListenter(false);
    }

    protected void UpdateListenter(bool enable)
    {
        //view.dispatcher.UpdateListener(enable,ViewEvent.Test,TestDebug);
        dispatcher.UpdateListener(enable, GameConfig.CoreEvent.GAME_START, TestDebug);
    }

    void TestDebug(IEvent e)
    {
        dispatcher.Dispatch(ViewEvent.TestDug);
    }
}
