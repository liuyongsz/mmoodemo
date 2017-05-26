using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System.Net;
using cn.bmob.json;
using cn.bmob.response;
using cn.bmob.Extensions;

// 如果程序需要为用户添加额外的字段，需要继承BmobUser
public class MyBmobUser : BmobUser
{
    public BmobInt life { get; set; }

    public BmobInt attack { get; set; }

    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);

        output.Put("life", this.life);
        output.Put("attack", this.attack);
    }

    public override void readFields(BmobInput input)
    {
        base.readFields(input);

        this.life = input.getInt("life");
        this.attack = input.getInt("attack");
    }
}