using System.Collections.Generic;
using UnityEngine;

public class Context
{
    private Dictionary<string, string> _variables = new();

    public void SetVariable(string ID, string value)
    {
        Debug.Log($"[Core] set context variable {ID} = {value}");
        _variables[ID] = value;
    }

    public string GetVariable(string ID)
    {
        if (_variables.TryGetValue(ID, out string value))
        {
            return value;
        }
        return "";
    }
}
