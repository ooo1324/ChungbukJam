

using System.Collections.Generic;

public interface IDataLoader<Value>
{
    List<Value> MakeList();
}
