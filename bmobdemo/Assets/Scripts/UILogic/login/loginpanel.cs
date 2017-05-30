using System;
using PureMVC.Interfaces;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using AssetBundles;
using UnityEngine.Events;
using XLua;

using UnityEngine;
using System.IO;
using System.Collections;
using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System.Net;
using cn.bmob.json;
using cn.bmob.response;
using cn.bmob.Extensions;


[Hotfix]
public class loginpanel : BasePanel {

    public UISprite btnClose;
    public UIButton btnBegin;
    public UIButton btnReg;
    public UIInput txtAccount;
    public UIInput txtPassword;
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
        //if (PlayerPrefs.HasKey("UserName") && PlayerPrefs.HasKey("UserPass"))
        //{
        //    panel.iptUser.value = PlayerPrefs.GetString("UserName");
        //    user = panel.iptUser.value;
        //    panel.iptPwd.value = PlayerPrefs.GetString("UserPass");
        //    pass = panel.iptPwd.value;
        //}

        Facade.SendNotification(NotificationID.UpdateResources_Close);
    }

    protected override void AddComponentEvents()
    {
        //UIEventListener.Get(m_Panel.btnClose.gameObject).onClick = OnClick;
        //UIEventListener.Get(m_Panel.btnEnter.gameObject).onClick = OnClick;
        UIEventListener.Get(m_Panel.btnReg.gameObject).onClick = OnClick;
        UIEventListener.Get(m_Panel.btnBegin.gameObject).onClick = OnClick;
    }
    /// <summary>
    /// 点击事件
    /// </summary>
    private void OnClick(GameObject go)
    {
        if (go == panel.btnBegin.gameObject)
        {
            string account = panel.txtAccount.value;
            string passwd = panel.txtPassword.value;
            HelloBmob.Bmob.Login<MyBmobUser>(account, passwd, OnBack_Login);
        }
        else if (go == panel.btnReg.gameObject)
        {
            string account = panel.txtAccount.value;
            string passwd = panel.txtPassword.value;

            MyBmobUser user = new MyBmobUser();
            user.username = account;
            user.password = passwd;
            user.email = "mb_qp@bmob.cn";
            user.life = 0;
            user.attack = 0;

            HelloBmob.Bmob.Signup<MyBmobUser>(user, OnBack_SignUp);
        }
    }

    public void OnBack_Login<T>(T response, cn.bmob.exception.BmobException exception)
    {
        if (exception != null)
        {
            Debug.Log("登录失败, 失败原因为： " + exception.Message);
            return;
        }

        //print("登录成功, @" + resp.username + "(" + resp.life + ")$[" + resp.sessionToken + "]");

        //print("登录成功, 当前用户对象Session： " + BmobUser.CurrentUser.sessionToken);

        ClosePanel(null);

        GameProxy.Instance.GotoMainCity();
    }

    public void OnBack_SignUp<T>(T response, cn.bmob.exception.BmobException exception)
    {
        if (exception != null)
        {
            Debug.Log("注册失败, 失败原因为： " + exception.Message);
            return;
        }

        Debug.Log("注册成功");
    }


    protected override void OnDestroy()
    {

        base.OnDestroy();
    }
}