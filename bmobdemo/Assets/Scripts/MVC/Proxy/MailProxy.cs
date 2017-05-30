using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProxyInstance;
using System;

public enum MainType
{
    PRIVATE = 0,
    SYSTEM = 1,
    CLUB = 2,
}
public enum MainState
{
    Mail_State_read = 0,
    Mail_State_Has_Open_Not_Get = 1,
    Mail_State_Not_Open = 2,
}
// proxy �������� midator����ͻ��ˣ�ͨ��ע����Ϣid,facade�������

public class MailProxy : Proxy<MailProxy>
{  
    public MailProxy()
        : base(ProxyID.Mail)
    {      
        KBEngine.Event.registerOut(this,"onGetMails");
        KBEngine.Event.registerOut(this, "onOperateSuc");
    }
    /// <summary>
    /// ��ȡ�ʼ�
    /// </summary>
    public void GetMailList()
    {
        ServerCustom.instance.SendClientMethods("getMail");      
    }

    /// <summary>
    /// �����ʼ�
    /// </summary>
    public void SendMail(int dbid, int type,string title, string text)
    {
        ServerCustom.instance.SendClientMethods("sendMail", dbid, type, title, text, "", "");
    }

    /// <summary>
    /// �鿴�ʼ�
    /// </summary>
    public void ReadMail(MailInfo info)
    {
        ServerCustom.instance.SendClientMethods("readMail", info.time);    
    }   
    public void DelAllMailByType(int type)
    {
        ServerCustom.instance.SendClientMethods("delAllMailByType", type);
    }
    /// <summary>
    /// ��ȡ�ʼ������б�
    /// </summary>
    public void onGetMails(Dictionary<string, object> mails)
    {
        EmailMediator.mailInfo.Clear();
        List<object> mailList = mails["values"] as List<object>;
        for (int i = 0; i < mailList.Count; ++i)
        {
            Dictionary<string, object> Info = mailList[i] as Dictionary<string, object>;
            MailInfo data = new MailInfo();
            data.type = int.Parse(Info["mail_type"].ToString());
            data.title = Info["title"].ToString();
            data.name = Info["from_name"].ToString();
            data.text = Info["text"].ToString();
            data.time = int.Parse(Info["time"].ToString());
            data.attachment = Info["attachment"].ToString();
            data.state = int.Parse(Info["state"].ToString());
            data.extern_info = Info["extern_info"].ToString();
            EmailMediator.mailInfo.Add(data);         
        }
        if (!GUIManager.HasView("emailpanel"))
        {
            Facade.SendNotification(NotificationID.Mail_Show);
            Facade.SendNotification(NotificationID.Gold_Show);
        }   
        else
        {
            EmailMediator.emailMediator.AddMailGridShow(EmailMediator.SelectMailType);    
        }    
    }
    public void onOperateSuc(object IDType)
    {
        if (IDType.ToString()== "ReadMail")
        {
            
        }
    }
}
