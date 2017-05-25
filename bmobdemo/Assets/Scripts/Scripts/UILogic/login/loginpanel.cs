﻿using System;
using PureMVC.Interfaces;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using AssetBundles;
using UnityEngine.Events;
using XLua;
[Hotfix]
public class loginpanel : BasePanel {

    public UISprite btnClose;
    public UISprite btnEnter;
    public UISprite btnReg;
    public UIInput iptUser;
    public UIInput iptPwd;
}

[Hotfix]
public class LoginMediator : UIMediator<loginpanel>
{
    private loginpanel panel
    {
        get
        {
            return m_Panel as loginpanel;
        }
    }
    private string user = string.Empty;
    private string pass = string.Empty;
    public LoginMediator() : base("loginpanel")
    {
        m_isprop = false;
        RegistPanelCall(NotificationID.Login_Show, OpenPanel);
        RegistPanelCall(NotificationID.Login_Hide, ClosePanel);
    }
    protected override void OnShow(INotification notification)
    {
        if (PlayerPrefs.HasKey("UserName") && PlayerPrefs.HasKey("UserPass"))
        {
            panel.iptUser.value = PlayerPrefs.GetString("UserName");
            user = panel.iptUser.value;
            panel.iptPwd.value = PlayerPrefs.GetString("UserPass");
            pass = panel.iptPwd.value;
        }

        Facade.SendNotification(NotificationID.UpdateResources_Close);
    }

    protected override void AddComponentEvents()
    {
        //UIEventListener.Get(m_Panel.btnClose.gameObject).onClick = OnClick;
        //UIEventListener.Get(m_Panel.btnEnter.gameObject).onClick = OnClick;
        //UIEventListener.Get(m_Panel.btnReg.gameObject).onClick = OnClick;

    }
    /// <summary>
    /// 点击事件
    /// </summary>
    private void OnClick(GameObject go)
    {
        if (go == panel.btnClose.gameObject)
        {
            ClosePanel(null);
        }
        else if (go == panel.btnEnter.gameObject)
        {
            if (panel.iptUser.value.Trim(' ') == string.Empty || panel.iptPwd.value.Trim(' ') == string.Empty)
            {
                GUIManager.SetPromptInfo(TextManager.GetUIString("UIServer1"), null);
                return;
            }
            user = panel.iptUser.value.Trim(' ');
            pass = panel.iptPwd.value.Trim(' ');
            PlayerPrefs.SetString("UserName", user);
            PlayerPrefs.SetString("UserPass", pass);
            List<object> list = new List<object>();
            list.Add(user);
            list.Add(pass);
            Facade.SendNotification(NotificationID.Sever_Show, list);
        }
        else if (go == panel.btnReg.gameObject)
        {
            LoginProxy.Instance.Send_RegisterAccount(m_Panel.iptUser.text.Trim(), m_Panel.iptPwd.text.Trim());
        }
    }

    protected override void OnDestroy()
    {

        base.OnDestroy();
    }
}