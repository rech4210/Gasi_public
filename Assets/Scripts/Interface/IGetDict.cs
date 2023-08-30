using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDict<T>
{
    Dictionary<char, T> ReturnDict(Dictionary<char, T> dict);

}
