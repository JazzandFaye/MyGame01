using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : FightingBaseView
{
    [Inject]
    public MapModel map { get; set; }

    private bool moving;

    [Inject]
    public RoleModel role { get; set; }

    [Inject]
    public DataBaseCommon dataBase { get; set; }

     

    public virtual void Init(RoleModel Role)
    {
        //初始化数据和一些组件
        role = Role;
        role.RoleDir = RoleModel.Direction.None;
        
    }

    public void Update()
    {
        GameUpdate();
        Debug.Log(DataBaseManager.Instance.FindRole(0).Atk);
    }

    public override void GameUpdate()
    {
        if (role == null)
            return;
        //在这里更新速度
        if (moving)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            for (int i = 0; i < 4; i++)
            {
                if (map.MapDir[i] == "North")
                {
                    if (i == 0)
                    {
                        break;
                    }
                    if (i == 1)
                    {
                        float temp;
                        temp = v;
                        v = -h;
                        h = temp;
                        break;
                    }
                    if (i == 2)
                    {
                        h = -h;
                        v = -v;
                        break;
                    }
                    if (i == 3)
                    {
                        float temp;
                        temp = h;
                        h = -v;
                        v = temp;
                        break;
                    }
                }
            }

            Debug.Log(role);
            GetComponent<CharacterController>().SimpleMove(new Vector3(h * 5, 0, v * 5));
            //GetComponent<CharacterController>().SimpleMove(new Vector3(h * role.MoveSpeed, 0, v * role.MoveSpeed));

        }
        if (!moving)
        {
            GetComponent<CharacterController>().SimpleMove(new Vector3(0, 0, 0));
        }
    }

    public virtual void MoveToDirection(IEvent e)
    {
        var cd = e as CustomOperationEventData;
        moving = cd.ismoving;
        //RoleModel.Direction _dir = cd.dir;//强制转换传过来的数据为方向
        //if (_dir != null)
        //{
        //    role.RoleDir = _dir;

        //}
    }
    //public GameObject _p_up;
    //public GameObject _p_down;
    //public GameObject _p_left;
    //public GameObject _p_right;

    //protected override void Start()
    //{
    //    _p_down.SetActive(true);
    //    _p_up.SetActive(false);
    //    _p_left.SetActive(false);
    //    _p_right.SetActive(false);
    //}

    //// Update is called once per frame
    //void Update ()
    //{
    //    ShowPlayer(role.RoleDir);
    //}

    //public void ShowPlayer(RoleModel.Direction dir)
    //{
    //    if (dir == RoleModel.Direction.Up)
    //    {
    //        _p_down.SetActive(false);
    //        _p_up.SetActive(true);
    //        _p_left.SetActive(false);
    //        _p_right.SetActive(false);
    //    }
    //    else if (dir == RoleModel.Direction.Down)
    //    {
    //        _p_down.SetActive(true);
    //        _p_up.SetActive(false);
    //        _p_left.SetActive(false);
    //        _p_right.SetActive(false);
    //    }
    //    else if (dir == RoleModel.Direction.Left)
    //    {
    //        _p_down.SetActive(false);
    //        _p_up.SetActive(false);
    //        _p_left.SetActive(true);
    //        _p_right.SetActive(false);
    //    }
    //    else if (dir == RoleModel.Direction.Right)
    //    {
    //        _p_down.SetActive(false);
    //        _p_up.SetActive(false);
    //        _p_left.SetActive(false);
    //        _p_right.SetActive(true);
    //    }
    //}

}
