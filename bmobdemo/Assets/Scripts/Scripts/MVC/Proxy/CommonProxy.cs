using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class CommonProxy : Proxy<CommonProxy>
{

    public string userId;
    public string userPwd;

    public CommonProxy()
        : base(ProxyID.Login)
    {
        KBEngine.Event.registerOut(this, "onKicked");
        KBEngine.Event.registerOut(this, "onDisableConnect");
        KBEngine.Event.registerOut(this, "onConnectStatus");
    }

    public void onKicked(System.UInt16 failedcode)
    {
        Debug.LogWarning("kick, disconnect!, reason=" + KBEngineApp.app.serverErr(failedcode));
    }

    /// <summary>
    /// ����ʧ��
    /// </summary>
    public void onDisableConnect()
    {
        KBEngine.Dbg.DEBUG_MSG("Disable Connect!");
    }

    public void onConnectStatus(bool success)
    {
        if (!success)
            KBEngine.Dbg.WARNING_MSG("connect(" + KBEngineApp.app.getInitArgs().ip + ":" + KBEngineApp.app.getInitArgs().port + ") is error! (���Ӵ���)");
        else
            KBEngine.Dbg.DEBUG_MSG("connect successfully, please wait...(���ӳɹ�����Ⱥ�...)");
    }
}//end ResourceConfig
