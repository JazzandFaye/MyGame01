﻿using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class RoleBaseEventView : FightingBaseView {

    //protected是在外部不可以调用，并且只能在子类里实现
    //protected bool MoveState { get; set; } //移动状态
    //protected RoleModel.Direction dir { get; set; }
    [Inject]
    public RoleModel role { get; set; }



    
    public virtual void Init(RoleModel Role)
    {
        //初始化数据和一些组件
        role = Role;
        role.RoleDir = RoleModel.Direction.None;
    }
    

}