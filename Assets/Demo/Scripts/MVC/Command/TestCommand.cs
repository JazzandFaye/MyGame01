using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class TestCommand : EventCommand {

    public override void Execute()
    {
        Debug.Log("测试成功");
    }
}
