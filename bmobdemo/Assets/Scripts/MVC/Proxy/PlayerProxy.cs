using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProxyInstance;

public class PlayerProxy : Proxy<PlayerProxy>
{
    public PlayerProxy()
        : base(ProxyID.Player)
    {
        installEvents();
    }

    void installEvents()
    {
        KBEngine.Event.registerOut(this, "set_name");
        KBEngine.Event.registerOut(this, "set_diamond");
        KBEngine.Event.registerOut(this, "set_euro");
        KBEngine.Event.registerOut(this, "set_bodyPower");
        KBEngine.Event.registerOut(this, "set_bodyPowerBuyTimes");
        KBEngine.Event.registerOut(this, "set_euroBuyTimes");
        KBEngine.Event.registerOut(this, "onEnterScene");
        KBEngine.Event.registerOut(this, "set_vipLevel");
        KBEngine.Event.registerOut(this, "set_rmb");
        KBEngine.Event.registerOut(this, "set_roleId");
        KBEngine.Event.registerOut(this, "set_photoIndex");
        KBEngine.Event.registerOut(this, "set_level");
        KBEngine.Event.registerOut(this, "set_exp");
        KBEngine.Event.registerOut(this, "set_slogan");
        KBEngine.Event.registerOut(this, "set_club");
        KBEngine.Event.registerOut(this, "set_camp");
        KBEngine.Event.registerOut(this, "set_fightValue");
        KBEngine.Event.registerOut(this, "set_job");
        KBEngine.Event.registerOut(this, "set_formation");
        KBEngine.Event.registerOut(this, "set_benchSize");
        KBEngine.Event.registerOut(this, "set_guildDBID");
        KBEngine.Event.registerOut(this, "set_guildPower");
        KBEngine.Event.registerOut(this, "set_guildDonate");
        KBEngine.Event.registerOut(this, "set_myRank"); 
        KBEngine.Event.registerOut(this, "set_blackMoney");
        KBEngine.Event.registerOut(this, "set_arenaTimes");

    }

    void OnDestroy()
    {
        KBEngine.Event.deregisterOut(this);
    }

    public void onEnterScene()
    {
        GameProxy.Instance.GotoMainCity();
    }
 public void set_arenaTimes(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("arenaTimes");
        PlayerMediator.playerInfo.arenaTimes = int.Parse(v.ToString());

    }
    public void set_blackMoney(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("blackMoney");
        PlayerMediator.playerInfo.blackMoney = int.Parse(v.ToString());
        if (GameShopMediator.gameShopMediator != null)
        {
            GameShopMediator.gameShopMediator.panel.moneyLabel.text = PlayerMediator.playerInfo.blackMoney.ToString();
        }
    }
    public void set_myRank(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("myRank");
        PlayerMediator.playerInfo.myRank = int.Parse(v.ToString());
    }
    public void set_name(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("name");
        PlayerMediator.playerInfo.name = v.ToString();
    }
    public void set_roleId(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("roleId");
        PlayerMediator.playerInfo.roleId = int.Parse(v.ToString());
    }
    public void set_photoIndex(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("photoIndex");
        PlayerMediator.playerInfo.photoIndex = v.ToString();
    }
    public void set_level(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("level");
        PlayerMediator.playerInfo.level = int.Parse(v.ToString());
        if (MainMediator.mainMediator == null)
            return;
        Facade.SendNotification(NotificationID.Level_Change);
    }
    public void set_rmb(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("rmb");
        PlayerMediator.playerInfo.rmb = int.Parse(v.ToString());
    }
    public void set_euro(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("euro");
        PlayerMediator.playerInfo.euro = int.Parse(v.ToString());
        if (GoldMediator.goldMediator != null)
        {
            GoldMediator.goldMediator.GoldChangeCall("euro");
        }
        if (GameShopMediator.gameShopMediator != null)
        {
            GameShopMediator.gameShopMediator.panel.moneyLabel.text = PlayerMediator.playerInfo.euro.ToString();
        }
        if (GuildDonationMediator.guilddonationMediator != null)
        {
            GuildDonationMediator.guilddonationMediator.panel.myEuro_label.text = PlayerMediator.playerInfo.euro.ToString();
        }
    }
    public void set_exp(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("exp");
        PlayerMediator.playerInfo.exp = int.Parse(v.ToString());
    }
    public void set_slogan(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("slogan");
        PlayerMediator.playerInfo.slogan = v.ToString();
        if (GUIManager.HasView("playerpanel"))
        {
            PlayerMediator.playerMediator.panel.slogan.text = PlayerMediator.playerInfo.slogan;
        }
    }
    public void set_club(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("club");
        PlayerMediator.playerInfo.club = v.ToString();
    }
    public void set_camp(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("camp");
        PlayerMediator.playerInfo.camp = int.Parse(v.ToString());
    }
    public void set_fightValue(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("fightValue");
        PlayerMediator.playerInfo.fightValue = int.Parse(v.ToString());
        if (MainMediator.mainMediator == null)
            return;
        Facade.SendNotification(NotificationID.Fight_Change);
    }
    public void set_vipLevel(KBEngine.Entity entity, object v)
    {
       
        Facade.SendNotification(NotificationID.Vip_Change);
    }
    public void set_job(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("job");
        PlayerMediator.playerInfo.job = int.Parse(v.ToString());
    }
    public void set_diamond(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("diamond");
        PlayerMediator.playerInfo.diamond = int.Parse(v.ToString());
        if (GoldMediator.goldMediator != null)
        {
            GoldMediator.goldMediator.GoldChangeCall("diamond");
        }
        if (GameShopMediator.gameShopMediator != null)
        {
            GameShopMediator.gameShopMediator.panel.moneyLabel.text = PlayerMediator.playerInfo.diamond.ToString();
        }
    }
    public void set_bodyPower(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("bodyPower");
        PlayerMediator.playerInfo.bodyPower = int.Parse(v.ToString());
        if (GoldMediator.goldMediator != null)
        {
            GoldMediator.goldMediator.GoldChangeCall("bodyPower");
        }
    }
    public void set_bodyPowerBuyTimes(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("bodyPowerBuyTimes");
        PlayerMediator.playerInfo.PowerTimes = int.Parse(v.ToString());
        if (PowerMediator.powerMediator != null)
        {
            PowerMediator.powerMediator.UpdateTimes();
        }
    }
    public void set_euroBuyTimes(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("euroBuyTimes");
        PlayerMediator.playerInfo.euroBuyTimes = int.Parse(v.ToString());
        if (PowerMediator.powerMediator != null)
        {
            PowerMediator.powerMediator.UpdateTimes();
        }
    }
    public void set_formation(KBEngine.Entity entity, object v)
    {

        v = entity.getDefinedProperty("formation");
        PlayerMediator.playerInfo.formation = int.Parse(v.ToString());
      
        Facade.SendNotification(NotificationID.Formation_Change);
    }
    public void set_benchSize(KBEngine.Entity entity, object v)
    {

        v = entity.getDefinedProperty("benchSize");
        PlayerMediator.playerInfo.benchSize = int.Parse(v.ToString());

    }
    public void set_guildDBID(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("guildDBID");
        PlayerMediator.playerInfo.guildDBID = int.Parse(v.ToString());
    }

    public void set_guildPower(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("guildPower");
        PlayerMediator.playerInfo.guildPower = int.Parse(v.ToString());

    }
    public void set_guildDonate(KBEngine.Entity entity, object v)
    {
        v = entity.getDefinedProperty("guildDonate");
        int hasDonate = GameConvert.IntConvert(v) - PlayerMediator.playerInfo.guildDonate;
        PlayerMediator.playerInfo.guildDonate = int.Parse(v.ToString());
        if (GameShopMediator.gameShopMediator != null)
        {
            GameShopMediator.gameShopMediator.panel.moneyLabel.text = PlayerMediator.playerInfo.guildDonate.ToString();
        }

        if (GuildDonationMediator.guilddonationMediator != null)
        {
            string content = string.Format(TextManager.GetSystemString("ui_system_guild21"), hasDonate);
            GUIManager.SetJumpText(content);
            GuildDonationMediator.guilddonationMediator.panel.gongxian_label.text = PlayerMediator.playerInfo.guildDonate.ToString();
        }

        if (GuildMainMediator.guildmainMediator != null)
        {
            GuildMainMediator.guildmainMediator.panel.gongxian_label.text = PlayerMediator.playerInfo.guildDonate.ToString();
        }
    }
}
public class PlayerInfo
{
    public int roleId;
    public int ranking;      // ���� 
    public string name;      // ����� 
    public int myRank;       // ���ID    public int roleId;       // ���ID
    public string cardId;    // ���ǿ���ID
    public string photoIndex;// ���ͷ�� 
    public int level;        // ��ҵȼ� 
    public int exp;          // ��Ҿ���ֵ 
    public string slogan;    // ��Ҹ���ǩ�� 
    public string club;         //��Ҿ��ֲ� 
    public string guildName;    //������ 
    public int camp;       //������� 
    public int officalPosition;  //��ҹ�ְ
    public int achievements;     //������� 
    public int fightValue;   //���ս���� 
    public int vipLevel;     //���VIP�ȼ� 
    public int job;         //���λ�� 
    public int diamond;      //�����ʯ 
    public int bodyPower;    //������� 
    public int PowerTimes;   //��������������
    public int euroBuyTimes;  //���ŷԪ�������
    public int rmb;          //���RMB����ֵ ��Ҫ��������vip��
    public int euro;          //ŷԪ
    public int blackMoney;    //���б�    public int formation;  //����
    public int benchSize; //�油��������
    public int arenaTimes;
    public string masterName;
    public int guildDBID; // ��ҹ���ID
    public int guildPower; // ��ҹ���ְλ
    public int guildDonate; // ��ҹ��ṱ�׵�
    public int formation;
}