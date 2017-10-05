using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class CustomAPI : IUnitAPI {

    public List<T> LoadConfig<T>() where T : class
    {
        return JsonMapper.ToObject<List<T>>(Resources.Load<TextAsset>(string.Format("Config/{0}", typeof(T).Name))
            .ToString());
    }
}
