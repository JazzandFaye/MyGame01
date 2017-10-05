using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FightingCommon  {

    //动作转向
    //public void SwithMoveDir(CustomOperationEventData data)
    //{
    //    if (data.str.ToString() == RoleModel.Direction.Left.ToString())
    //    {
    //        data.dir = RoleModel.Direction.Left;
    //    }
    //    if (data.str.ToString() == RoleModel.Direction.Right.ToString())
    //    {
    //        data.dir = RoleModel.Direction.Right;
    //    }
    //    if (data.str.ToString() == RoleModel.Direction.Up.ToString())
    //    {
    //        data.dir = RoleModel.Direction.Up;
    //    }
    //    if (data.str.ToString() == RoleModel.Direction.Down.ToString())
    //    {
    //        data.dir = RoleModel.Direction.Down;
    //    }
    //}

    //摄像机转向
    public void SwithCamDir(CustomOperationEventData data)
    {
        if (data.str.ToString() == GameConfig.TurnDirection.LEFT.ToString())
        {
            data.turnDir = GameConfig.TurnDirection.LEFT;
        }
        if (data.str.ToString() == GameConfig.TurnDirection.RIGHT.ToString())
        {
            data.turnDir = GameConfig.TurnDirection.RIGHT;
        }
    }
}
