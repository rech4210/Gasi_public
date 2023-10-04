using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDict<T>
{
    Dictionary<int, T> ReturnDict(Dictionary<int, T> dict);

}
