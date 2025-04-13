using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class TypeMillitarty : MonoBehaviour
{
    string type;

    public string set_type(int type)
    {
        List<string> types = new List<string>
        {
            "Ближний",
            "Дальний",
            "Осадный"
        };

        return types[type];
        //try
        //{
        //    return types[type];
        //} catch (indexer)
        //{
        //    Console.Write("Не верный тип");
        //    return "";
        //}
    }

}
