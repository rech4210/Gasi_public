using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IGetDict<T,U>
{
    Dictionary<T, U> ReturnDict(Dictionary<T, U> dict);

}
