

using System.Collections.Generic;

public interface IDataLoader<Key,Value>
{
    Dictionary<Key, Value> MakeDict();
}
