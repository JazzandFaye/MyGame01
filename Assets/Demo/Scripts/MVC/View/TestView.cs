using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class TestView : EventView {

    public void Update()
    {
        TestDug();
    }
    public void TestDug()
    {
        //dispatcher.Dispatch(ViewEvent.Test);
        //dispatcher.Dispatch(GameConfig.CoreEvent.GAME_START);
    }
}
