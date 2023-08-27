using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDict<T> where T : class
{
    Dictionary<char, T> ReturnDict(Dictionary<char, T> dict);

}
