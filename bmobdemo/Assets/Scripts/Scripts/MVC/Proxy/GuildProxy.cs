using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProxyInstance;
/// <summary>
/// ����
/// </summary>
public class GuildProxy: Proxy<GuildProxy>
{
    //�������� name, introduce
    public static string OnClientCreateGuild = "onClientCreateGuild";

    //�ͻ������󹫻��б�
    public static string OnClientGuildList = "onClientGuildList";
    
    //�ͻ���������빫�� id
    public static string OnClientApplyJoinGuild = "onClientApplyJoinGuild";

    //�ͻ��������Լ�������Ϣ
    public static string OnClientGetGuildInfo = "onClientGetGuildInfo";

    //�ͻ���������list
    public static string OnClientBuildList = "onClientBuildList";

    //�ͻ������󹫻��Ա�б�
    public static string OnClientGetGuildMember = "onClientGetGuildMember";

    //�ͻ���������������б�
    public static string OnClientGetGuildApply = "onClientGetGuildApply";

    //�ͻ���ȡ��������빫�� id
    public static string OnClientCancelApply = "onClientCancelApply";

    //�ͻ������빫�ḱ�᳤����� id
    public static string OnClientGetViceIntroduce = "onClientGetViceIntroduce";

    //�ͻ���������ļ��͹��� 
    // ����4��  �Ƿ��޸ļ��  ������� �Ƿ��޸Ĺ��� ��������
    public static string OnClientChangeNotice = "onClientChangeNotice";

    //�ͻ��������޸Ĺ�������
    //����1�� ��������
    public static string OnClientChangeName = "onClientChangeName";

    //�ͻ����������
    //����1�� ŷԪ
    public static string OnClientDonate = "onClientDonate";

    //�ͻ�������������
    //����1�� ����ID
    public static string OnClientBuildUpgrade = "onClientBuildUpgrade";

    //�ͻ��˽�����������
    //����2�� ����ID  ����Сʱ
    public static string OnClientBuildSpeed = "onClientBuildSpeed";

    //�ͻ���������ְ
    //����2�� ��ԱID ְλ
    public static string OnClientAppointPower = "onClientAppointPower";

    //�ͻ��˹���ת��
    //����1�� ��ԱID 
    public static string OnClientGuildTransfer = "onClientGuildTransfer";

    //�ͻ��˾ܾ��������
    //����1�� applyID
    public static string OnClientRejectApply = "onClientRejectApply";

    //�ͻ��˽����������
    //����1�� applyID
    public static string OnClientAgreeJoin = "onClientAgreeJoin";

    //�ͻ��˵����᳤
    public static string OnClientImpeach = "onClientImpeach";
    
    //�ͻ��˿���
    public static string OnClientKickOut = "onClientKickOut";
    
    //�ͻ��������ɢ����
    public static string OnClientDismissGuild = "onClientDismissGuild";

    //�ͻ�������ȡ����ɢ����
    public static string OnClientCancelDismiss = "onClientCancelDismiss";

    //�ͻ����˳�����
    public static string OnClientQuitGuild = "onClientQuitGuild";
    //���������ع�
    //����3����  playerID guildID  appealID
    public static string OnClientAppealExposure = "onClientAppealExposure";

    //�ͻ��˹��򹫻ᱣ��ʱ��
    public static string OnClientBuyGuildProtect = "onClientBuyGuildProtect";

    //�ͻ��������ֺ���������
    //����ID id
    public static string OnClientAdviserFriend = "onClientAdviserFriend";

    //�ͻ��˹��ʹ�����Ѷ�
    //����ID id
    public static string OnClientAdviserGuildList = "onClientAdviserGuildList";

    //�ͻ������������Ϣ 
    public static string OnClientAdviserList = "onClientAdviserList";

    //�ͻ������󹫻�����Ѻö�
    //����ID
    public static string OnClientGuildAdviser = "onClientGuildAdviser";

    //�ͻ������󹫻�����Ѻö�
    //����ID id  ��£ID ��1��2��
    public static string OnClientAdviserRope = "onClientAdviserRope";
    


    public GuildProxy()
        : base(ProxyID.Clone)
    {

        KBEngine.Event.registerOut(this, "onFindCamp");//���ع����б�
        KBEngine.Event.registerOut(this, "onResponse");//����������
        KBEngine.Event.registerOut(this, "onGetGuildInfo");//������Ϣ
        KBEngine.Event.registerOut(this, "onGuildApplyList");//����������Ϣ
        KBEngine.Event.registerOut(this, "onApplyGuildIDList");//�Ѿ�������� ����ID
        KBEngine.Event.registerOut(this, "onGuildMemberList");//���ع����Ա�б�
        KBEngine.Event.registerOut(this, "onGuildViceIntroduce");//��ȡ���ḱ�᳤�����
        KBEngine.Event.registerOut(this, "onClientGuildBuildInfo");//���ع��Ὠ����Ϣ
        KBEngine.Event.registerOut(this, "onGuildError");//���᷵�ش�����Ϣ 
        KBEngine.Event.registerOut(this, "onGuildUpgradeSucc");//���������ɹ�
        KBEngine.Event.registerOut(this, "onChangeNameSucc");//���᷵���޸Ĺ�������
        KBEngine.Event.registerOut(this, "onChangeNoticeSucc");//���᷵���޸Ĺ���
        KBEngine.Event.registerOut(this, "onGuildReadyDismiss");//����׼����ɢ
        KBEngine.Event.registerOut(this, "onGuildDonateSucc");//�����Ǯ�ɹ�
        KBEngine.Event.registerOut(this, "onGuilRefreshMemeber");//����ˢ�³�Ա��Ϣ
        KBEngine.Event.registerOut(this, "onClientGuildFunds");//����ˢ�¹����ʽ�
        KBEngine.Event.registerOut(this, "onKictOutSucc");//���Ὺ��
        KBEngine.Event.registerOut(this, "onBuyGuildProtectSucc");//���򱣻�ʱ��ɹ�
        
        KBEngine.Event.registerOut(this, "onAdviserError");//���ʴ�����
        KBEngine.Event.registerOut(this, "onAdviserGuildRank");//���ʹ���
        KBEngine.Event.registerOut(this, "onAdviserList");//������Ϣ
        KBEngine.Event.registerOut(this, "onGuildAdviserList");//��������Ѻö�
        KBEngine.Event.registerOut(this, "onUpdataAdviserGuild");//���¹��ʹ����Ѻö�
        KBEngine.Event.registerOut(this, "onUpdateGuildAdviser");//���¹�������Ѻö�




    }

    //��ȡ���ḱ�᳤�����
    public void onGuildViceIntroduce(List<object> list,object val)
    {

        string introduce = GameConvert.StringConvert(val);
        List<GuildMemberInfo> listMember = new List<GuildMemberInfo>();
        GuildMemberInfo info = null;
        for (int i=0; i<list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;
            info = ChangeMemberData(data);
            listMember.Add(info);
        }

        GuildInfoMediator.guildinfoMediator.SetGuildInfo(introduce, listMember);
    }

    //����������Ϣ
    public void onGuildApplyList(List<object> list)
    {
        MyGuildInfo info = GuildMainMediator.mMyGuild;
        info.applyList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;
            GuildApplyInfo apply = ChangeApplyData(data);
            info.applyList.Add(apply);
        }

        if (GUIManager.HasView("guildofficepanel"))
        {
            GuildOfficeMediator.guildOfficeMediator.SetApplyGridData();
        }
    }

    //������Ϣ
    public void onGetGuildInfo(object val, object val1, object val2, object val3, object val4, object val5,object val6, object val7, object val8, object val9, object val10, List<object> list)
    {

        Facade.SendNotification(NotificationID.GuildList_Hide);

        MyGuildInfo info = GuildMainMediator.mMyGuild;
        info.level = GameConvert.IntConvert(val);
        info.name = GameConvert.StringConvert(val1);
        info.memberNum = GameConvert.IntConvert(val2);
        info.guildFunds = GameConvert.IntConvert(val3);
        info.reputation = GameConvert.IntConvert(val4);
        info.notice = GameConvert.StringConvert(val5);
        info.dismissTime = GameConvert.LongConvert(val6);
        info.id = GameConvert.IntConvert(val7);
        info.introduction = GameConvert.StringConvert(val8);
        info.protectTime = GameConvert.IntConvert(val9);
        info.ropleTime = GameConvert.IntConvert(val10);


        for (int i = 0; i < list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;
            int id = GameConvert.IntConvert(data["id"]);
            GuildBuildInfo build = GuildBuildConfig.GetGuildBuildInfo(id);
            build.id = id;
            build.level = GameConvert.IntConvert(data["level"]);
            build.state = GameConvert.IntConvert(data["state"]);
            build.endTimes = GameConvert.LongConvert(data["endTime"]);
        }
        Facade.SendNotification(NotificationID.GuildMain_Show);

        //if (GUIManager.HasView("guildmainpanel"))
        //{
        //    GuildMainMediator.guildmainMediator.SetBuild();
        //}
    }

    //���ع��Ὠ����Ϣ
    public void onClientGuildBuildInfo(Dictionary<string, object> data)
    {
        int id = GameConvert.IntConvert(data["id"]);
        GuildBuildInfo info = GuildBuildConfig.GetGuildBuildInfo(id);
        info.id = id;
        info.level = GameConvert.IntConvert(data["level"]);
        info.state = GameConvert.IntConvert(data["state"]);
        info.endTimes = GameConvert.LongConvert(data["endTime"]);

        if (GUIManager.HasView("guildmainpanel"))
        {
            GuildMainMediator.guildmainMediator.SetBuildInfo(info);
        }
    }
    //�����Ա�б���Ϣ
    public void onGuildMemberList(List<object> list)
    {
        MyGuildInfo guild = GuildMainMediator.mMyGuild;
        guild.memberList.Clear();

       GuildMemberInfo info = null;
        for (int i = 0; i < list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;
            info = ChangeMemberData(data);
            guild.memberList.Add(info);
        }

        if (GUIManager.HasView("guildofficepanel"))
        {
            GuildOfficeMediator.guildOfficeMediator.SetMemberGridData();
        }
        if (GUIManager.HasView("guilddonationpanel"))
        {
            GuildDonationMediator.guilddonationMediator.SetDayDonateData();
        }
    }
    //�Ѿ�������� ����ID
    public void onApplyGuildIDList(List<object> list)
    {
        GuildBaseConfig.mApplyGuildIdList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            int guildId = GameConvert.IntConvert(list[i]);
            GuildBaseConfig.mApplyGuildIdList.Add(guildId);
        }
        GuildListMediator.guildlistMediator.RefreshApplyItem();
    }
    //���� # 1 ��������ɹ�  2 �Ѿ��ǳ�Ա 3�Ѿ�������� 4����ɹ����ȴ���������Ӧ 5  # �޸Ĺ���ɹ� 6  # �뿪���� 7 # �����ɹ� 8 �����ɹ�

    public void onResponse(object val)
    {
        int result = GameConvert.IntConvert(val);

        if (result == 13 && PlayerMediator.playerInfo.guildPower != 5)
        {//����������
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild20"));
            CloseAllGuildPanel();
        }
        else if (result == 14 && PlayerMediator.playerInfo.guildPower == 5)
        {
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild1"));
            Facade.SendNotification(NotificationID.GuildCreat_Hide);
        }
        else if(result ==16)//��ɢ
        {
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild" + result));
        }
        else if (result == 11)//ת��
        {
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild" + result));
            Facade.SendNotification(NotificationID.GuildInteract_Hide);
        } 
        else if(result == 15)
        {
            
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild" + result));
            ServerCustom.instance.SendClientMethods("onClientGetGuildValueRank", 0);
        }
        else if(result == 17)
        {
            GuildMainMediator.mMyGuild.dismissTime = 0;
            if (GUIManager.HasView("guildmainpanel"))
                GuildMainMediator.guildmainMediator.SetDismissTime();
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild" + result));

        }
        else if(result == 18)
        {
            CloseAllGuildPanel();
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild" + result));

        }
        else           
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild" + result));

    }

    //���ع��������Ϣ
    // 1  �������ֲ����Ϲ��� ,2 �����鲻���Ϲ���, 3 ��ʯ����, 4�ظ������� , 5�Ѿ����빫��, 6�����ڵĹ��� ,
    //7���ڹ�����, 8�Ѿ�������, 9 �����鲻���Ϲ���,10  ��û���빫��,11û��Ȩ�� , 12������Ա���������ڳ��ռ����ԣ�,13��������ʱ�䲻��7�� 14ŷԪ����
    //15 ��ְλ��Ա���������ڳ��ռ����ԣ�

    public void onGuildError(object val)
    { 
        int errorID = GameConvert.IntConvert(val);
        GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild_err" + errorID));
    }
    //���ع����б�
    public void onFindCamp(object val,List<object> list)
    {
        int amount = GameConvert.IntConvert(val);
        GuildBaseConfig.mGuildList.Clear();

        GuildInfo info;
        for (int i = 0; i < list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;
            info = ChangeGuildInfo(data);
            GuildBaseConfig.mGuildList.Add(info);
        }

        GuildListMediator.guildlistMediator.SetData();
    }

    //���������ɹ�
    public void onGuildUpgradeSucc(object val,object val1)
    {
        int level = GameConvert.IntConvert(val);
        GuildMainMediator.mMyGuild.level = level;
        GuildMainMediator.mMyGuild.reputation = GameConvert.IntConvert(val1); ;

        GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild10"));
        if (GUIManager.HasView("guildmainpanel"))
        {
            GuildMainMediator.guildmainMediator.SetGuildReputation();

        }
    }

    //���ع��ṫ��
    public void onChangeNoticeSucc(object val ,object val1)
    {
        GuildMainMediator.mMyGuild.notice = GameConvert.StringConvert(val);
        GuildMainMediator.mMyGuild.introduction = GameConvert.StringConvert(val1);

        if (GUIManager.HasView("guildmainpanel"))
        {
            GuildMainMediator.guildmainMediator.SetGuildNotice();

        }

    }

    //���ع�������
    public void onChangeNameSucc(object val)
    {
        GuildMainMediator.mMyGuild.name = GameConvert.StringConvert(val);
        if (GUIManager.HasView("guildmainpanel"))
        {
            GUIManager.SetJumpText(TextManager.GetSystemString("ui_system_guild12"));
            GuildMainMediator.guildmainMediator.SetGuildName();
        }

    }

    //��Ǯ�ɹ�
    public void onGuildDonateSucc(object val, Dictionary<string, object> data)
    {
        GuildMainMediator.mMyGuild.guildFunds = GameConvert.IntConvert(val);
        GuildMemberInfo info = ChangeMemberData(data);
        for(int i = 0; i<GuildMainMediator.mMyGuild.memberList.Count; i++)
        {
            GuildMemberInfo item = GuildMainMediator.mMyGuild.memberList[i];
            if (item.id == info.id)
            {
                GuildMainMediator.mMyGuild.memberList.Remove(item);
                GuildMainMediator.mMyGuild.memberList.Add(info);
            }
        }
        if (GUIManager.HasView("guildmainpanel"))
        {
            GuildMainMediator.guildmainMediator.SetGuildFunds();
        }

        if (GUIManager.HasView("guilddonationpanel"))
        {
            GuildDonationMediator.guilddonationMediator.SetDayDonateData();
            GuildDonationMediator.guilddonationMediator.SetDonationInfo();
        }
    }
    //����ˢ�³�Ա��Ϣ
    public void onGuilRefreshMemeber(Dictionary<string, object> data)
    {
        GuildMemberInfo info = ChangeMemberData(data);
        for (int i = 0; i < GuildMainMediator.mMyGuild.memberList.Count; i++)
        {
            GuildMemberInfo item = GuildMainMediator.mMyGuild.memberList[i];
            if (item.id == info.id)
            {
                GuildMainMediator.mMyGuild.memberList.Remove(item);
                GuildMainMediator.mMyGuild.memberList.Add(info);
            }
        }
        
        if (GUIManager.HasView("guildofficepanel"))
        {
            GuildOfficeMediator.guildOfficeMediator.SetMemberGridData();
        }
        if (GUIManager.HasView("guilddonationpanel"))
        {
            GuildDonationMediator.guilddonationMediator.SetDayDonateData();
            GuildDonationMediator.guilddonationMediator.SetDonationInfo();
        }
        if (GUIManager.HasView("guildinteractpanel"))
        {
            if (GuildInteractMediator.guildinteractMediator.mInfo.id != info.id)
                return;
            GuildInteractMediator.guildinteractMediator.mInfo = info;
            GuildInteractMediator.guildinteractMediator.SetPowerGridDate();
        }
    }


    //����ˢ�¹����ʽ�
    public void onClientGuildFunds(object val)
    {
        int  funds = GameConvert.IntConvert(val);
        GuildMainMediator.mMyGuild.guildFunds = funds;
        if (GUIManager.HasView("guildmainpanel"))
        {
            GuildMainMediator.guildmainMediator.SetGuildFunds();
        }
    }
    //���Ὺ��
    public void onKictOutSucc(object val)
    {
        int roleId = GameConvert.IntConvert(val);
        for(int i =0; i<GuildMainMediator.mMyGuild.memberList.Count; i++)
        {
            GuildMemberInfo info = GuildMainMediator.mMyGuild.memberList[i];
            if (info.id == roleId)
                GuildMainMediator.mMyGuild.memberList.Remove(info);
        }

        if (GUIManager.HasView("guildofficepanel"))
        {
            GuildOfficeMediator.guildOfficeMediator.SetMemberGridData();
        }
        if (GUIManager.HasView("guilddonationpanel"))
        {
            GuildDonationMediator.guilddonationMediator.SetDayDonateData();
            GuildDonationMediator.guilddonationMediator.SetDonationInfo();
        }
        if (GUIManager.HasView("guildinteractpanel"))
        {
            GuildInteractMediator.guildinteractMediator.SetPowerGridDate();
        }

    }
    //�����ɢ
    public void onGuildReadyDismiss(object val)
    {
        GuildMainMediator.mMyGuild.dismissTime = GameConvert.LongConvert(val);
        if (GUIManager.HasView("guildmainpanel"))
        {
            GuildMainMediator.guildmainMediator.SetDismissTime();
        }
    }
    //���ᱣ������ɹ�
    public void onBuyGuildProtectSucc(object val)
    {
        GuildMainMediator.mMyGuild.protectTime = GameConvert.IntConvert(val);
        if(GuildTacticMediator.guildtacticMediator!=null)
        {
            GuildTacticMediator.guildtacticMediator.SetCutOffTime();
        }
    }

    //���ʴ���ʧ��
    public void onAdviserError(object val)
    {
        int id = GameConvert.IntConvert(val);
    }
    //������Ϣ
    public void onAdviserList(List<object> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;

            AdviserInfo info = changeAdviserData(data);

            if (!GuildCounselorConfig.mAdviserDict.ContainsKey(info.dbid))
                GuildCounselorConfig.mAdviserDict.Add(info.dbid, info);
            else
                GuildCounselorConfig.mAdviserDict[info.dbid] = info;
            
        }

        if (GuildCounselorMediator.guildcounselorMediator != null)
        {
            ServerCustom.instance.SendClientMethods(OnClientGuildAdviser,PlayerMediator.playerInfo.guildDBID);
        }

    }
    //���ʹ�����Ѷ��б�
    public void onAdviserGuildRank(List<object> list)
    {

        GuildCounselorConfig.mGuildFriendsList.Clear();
        for(int i=0; i<list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;

            AdviserGuildInfo info = ChangeAdviserGuildData(data);
            GuildCounselorConfig.mGuildFriendsList.Add(info);
        }
        if (GuildCounselorMediator.guildcounselorMediator != null)
        {
            GuildCounselorMediator.guildcounselorMediator.SetAdviserGuildList();
        }

    }
    //���¹��ʹ�����Ѷ�
    public void onUpdataAdviserGuild(Dictionary<string, object> data)
    {
        AdviserGuildInfo adviserGuild = ChangeAdviserGuildData(data);

        for(int i=0; i < GuildCounselorConfig.mGuildFriendsList.Count; i++)
        {
            AdviserGuildInfo info = GuildCounselorConfig.mGuildFriendsList[i];

            if(info.guildID == adviserGuild.guildID)
                GuildCounselorConfig.mGuildFriendsList.Remove(info);
        }

        GuildCounselorConfig.mGuildFriendsList.Add(adviserGuild);

        if (GuildCounselorMediator.guildcounselorMediator != null)
        {
            GuildCounselorMediator.guildcounselorMediator.SetAdviserGuildList();
        }

    }
    //��������Ѻö�
    public void onGuildAdviserList(List<object> list)
    {
        GuildMainMediator.mMyGuild.adviserList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            Dictionary<string, object> data = list[i] as Dictionary<string, object>;

            GuildAdviser info = ChangeGuildAdviserData(data);
            GuildMainMediator.mMyGuild.adviserList.Add(info);
        }
        if(GuildCounselorMediator.guildcounselorMediator!=null)
        {
            GuildCounselorMediator.guildcounselorMediator.SetAdviserList();
        }
    }

    //���¹�����ʺ��Ѷ�
    public void onUpdateGuildAdviser(Dictionary<string, object> data)
    {
        GuildAdviser info = ChangeGuildAdviserData(data);
        for(int i=0; i < GuildMainMediator.mMyGuild.adviserList.Count; i++)
        {
            GuildAdviser item = GuildMainMediator.mMyGuild.adviserList[i];
            if (item.id == info.id)
                item.friendliness = info.friendliness;
        }
        
        if (GuildCounselorMediator.guildcounselorMediator != null)
        {
            GuildCounselorMediator.guildcounselorMediator.SetAdviserList();
        }
    }
    //��������ת��
    private GuildInfo ChangeGuildInfo(Dictionary<string, object> data)
    {
        GuildInfo info = new GuildInfo();

        info.id = GameConvert.IntConvert(data["dbid"]); 
        info.guildName = GameConvert.StringConvert(data["guildName"]);
        info.camp = GameConvert.IntConvert(data["camp"]); 
        info.level = GameConvert.IntConvert(data["level"]); 
        info.count = GameConvert.IntConvert(data["count"]); 
        info.leader = GameConvert.StringConvert(data["leader"]); 
        return info;

    }

    //��Ա����ת��
    private GuildMemberInfo ChangeMemberData(Dictionary<string, object> data)
    {
        GuildMemberInfo info = new GuildMemberInfo();

        info.id = GameConvert.IntConvert(data["dbid"]); 
        info.playerName = GameConvert.StringConvert(data["playerName"]);
        info.power = GameConvert.IntConvert(data["power"]); 
        info.level = GameConvert.IntConvert(data["level"]); 
        info.offical = GameConvert.IntConvert(data["offical"]); 
        info.dayDonate = GameConvert.IntConvert(data["dayDonate"]); 
        info.weekDonate = GameConvert.IntConvert(data["weekDonate"]); 
        info.sumDonate = GameConvert.IntConvert(data["sumDonate"]); 
        info.onlineState = GameConvert.IntConvert(data["onlineState"]);         
        return info;
    }
    //��������ת��
    private GuildApplyInfo ChangeApplyData(Dictionary<string, object> data)
    {
        GuildApplyInfo apply = new GuildApplyInfo();
        apply.id = GameConvert.IntConvert(data["dbid"]);
        apply.playerName = GameConvert.StringConvert(data["playerName"]);
        apply.offical = GameConvert.IntConvert(data["offical"]);
        apply.level = GameConvert.IntConvert(data["level"]);
        apply.applyTime = GameConvert.DoubleConvert(data["applyTime"]);
        return apply;
    }
    //��������ת��
    private AdviserInfo changeAdviserData(Dictionary<string, object> data)
    {
        AdviserInfo info = new AdviserInfo();

        info.dbid = GameConvert.IntConvert(data["dbid"]);
        info.guildDBID = GameConvert.IntConvert(data["guidDBID"]);
        info.configID = GameConvert.IntConvert(data["configID"]);
        info.guilidName = GameConvert.StringConvert(data["guildName"]);
        info.friendliness = GameConvert.IntConvert(data["friendliness"]);

        return info;
    }
    //���ʹ�����Ѷ�ת��
    private AdviserGuildInfo ChangeAdviserGuildData(Dictionary<string, object> data)
    {
        AdviserGuildInfo info = new AdviserGuildInfo();

        info.guildID = GameConvert.IntConvert(data["guildID"]);
        info.guildName = GameConvert.StringConvert(data["guildName"]);
        info.friendliness = GameConvert.IntConvert(data["friendliness"]);
        
        return info;
    }

    //��������Ѻö�
    private GuildAdviser ChangeGuildAdviserData(Dictionary<string, object> data)
    {
        GuildAdviser info = new GuildAdviser();
        
        info.id = GameConvert.IntConvert(data["dbid"]);
        info.friendliness = GameConvert.IntConvert(data["friendliness"]);
        return info;

    }


    //�رչ������
    private void CloseAllGuildPanel()
    {
        Facade.SendNotification(NotificationID.GuildMain_Hide);
        Facade.SendNotification(NotificationID.GuildAlterName_Hide);
        Facade.SendNotification(NotificationID.GuildAlterNotice_Hide);
        Facade.SendNotification(NotificationID.GuildOffice_Hide);
        Facade.SendNotification(NotificationID.GuildSpeed_Hide);
        Facade.SendNotification(NotificationID.GuildTactic_Hide);
        Facade.SendNotification(NotificationID.GuildLVUp_Hide);
        Facade.SendNotification(NotificationID.GuildInteract_Hide);
        Facade.SendNotification(NotificationID.GuildCounselor_Hide);

    }

}


public class GuildInfo
{
    public int rank;
    public int id;                    //����ID
    public string guildName;      // ��������
    public string playerName;      // ��������
    public int camp;       // ��Ӫ
    public int ranking;     // ����
    public int reputation;  // ����
    public int level;        // �ȼ� 
    public int count;          // ����
    public string leader;    // ����
    public int guildFunds;    // ����
}

//���������Ա��Ϣ
public class GuildApplyInfo
{
    public int id;                    //���DBID
    public string playerName;      // �������
    public int offical;       // ��ְ
    public int level;        // �ȼ� 
    public double applyTime; //����ʱ��

}

//�Լ�������Ϣ
public class MyGuildInfo
{
    public int id;
    public string name;//��������
    public int level;        // �ȼ� 
    public int memberNum;    // ��������
    public int guildFunds;        // �����ʽ�
    public int reputation;        // ��������
    public string notice=string.Empty;        // ���ṫ��
    public long dismissTime;  // �����ɢʱ��
    public string introduction = string.Empty;// ������
    public int protectTime;  // ���ᱣ��ʱ��
    public int ropleTime;  // ��£����

    public List<GuildApplyInfo> applyList = new List<GuildApplyInfo>(); //�����б�
    public List<GuildMemberInfo> memberList = new List<GuildMemberInfo>(); //�����Ա�б�
    public List<GuildAdviser> adviserList = new List<GuildAdviser>(); //�����б�
}


//�����Ա��Ϣ
public class GuildMemberInfo
{

    public int id;                    //���DBID
    public string playerName;      // �������
    public int power;                    //����ְ��
    public int offical;       // ��ְ
    public int level;        // �ȼ�
    public int dayDonate;     //ÿ�չ���
    public int weekDonate;        // ���ܹ��� 
    public int sumDonate;        // �ۻ�����
    public int onlineState;        // ״̬���뿪���ڰ��

}

//���Ὠ��
public class GuildBuildInfo
{
    public int id;
    public int level;        // �ȼ� 
    public int state;    //״̬
    public long endTimes;//��������ʱ��
}

//������Ϣ
public class AdviserInfo
{
    public int dbid;   //dbid
    public int configID; 
    public int guildDBID;
    public string guilidName;
    public int friendliness;

}


//���������Ϣ
public class GuildAdviser
{
    public int id;//����id
    public int friendliness;//�Ѻö�
}

//���ʹ�����Ϣ
public class AdviserGuildInfo
{
    public int guildID;
    public int rank;
    public string guildName;
    public int friendliness;
}

