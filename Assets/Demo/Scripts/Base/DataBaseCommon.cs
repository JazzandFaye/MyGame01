using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataBaseCommon {

    [Inject]
    public IUnitAPI common { get; set; }
    public List<PlayerConfig> PlayerConfigList { get; set; }

    public void Init()
    {
        Debug.Log("导入数据");
        PlayerConfigList = common.LoadConfig<PlayerConfig>();
        
    }

    public T GetConfigByID<T>(int id, List<T> i) where T : BaseConfig
    {
        return i.Where(x => x.ID == id).SingleOrDefault();
    }

}
