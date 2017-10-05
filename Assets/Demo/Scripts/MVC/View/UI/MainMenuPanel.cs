using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : BasePanel
{
    //使用Awake来获取组件是最快的
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
       
    }
    public void OnPushPanel(string panelTypeString)
    {
        //转成枚举类型
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIPanelManager.Instance.PushPanel(panelType);
    }
    //暂停交互
    public override void OnPause()
    {
        //当弹出新的面板时，让主菜单不再和鼠标交互
        canvasGroup.blocksRaycasts = false;
    }
    //恢复交互
    public override void OnResume()
    {
        //开启显示  
        canvasGroup.blocksRaycasts = true;
    }
    public override void OnEnter()
    {
        //开启显示
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}
