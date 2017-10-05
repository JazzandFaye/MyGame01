using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAPI
{
    List<T> LoadConfig<T>() where T : class;
}
