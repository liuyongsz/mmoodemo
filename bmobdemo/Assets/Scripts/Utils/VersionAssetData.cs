/// 作者 wanglc
/// 日期 20140923
/// 实现目标  资源单元数据（原系统的）


public class VersionAssetData
{
    private string idField;
    private string pathField;
    private string md5Field;
    //private string versionField;
    private int sizeField;
    private bool isHighSpeedSave;
    private int iLimitVer;

    /// <summary>
    /// 加载出错
    /// </summary>
    public bool bLoadError = false;
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    public string Path
    {
        get
        {
            return this.pathField;
        }
        set
        {
            this.pathField = value;
        }
    }

    public string Md5
    {
        get
        {
            return this.md5Field;
        }
        set
        {
            this.md5Field = value;
        }
    }

    public int Size
    {
        get
        {
            return this.sizeField;
        }
        set
        {
            this.sizeField = value;
        }
    }

    public bool IsHighSpeedSave
    {
        get
        {
            return this.isHighSpeedSave;
        }
        set
        {
            this.isHighSpeedSave = value;
        }
    }

    public int LimitVer
    {
        get
        {
            return this.iLimitVer;
        }
        set
        {
            this.iLimitVer = value;
        }
    }
}
