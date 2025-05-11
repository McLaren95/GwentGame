using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class TypeMillitary : ScriptableObject
{
    private int type;


    public void setType(int type)
    {
        this.type = type;
    }
    

    public string getType()
    {
        List<string> types = new List<string>
        {
            "Ближний",
            "Дальний",
            "Осадный"
        };

        return types[type];
      
    }

}
