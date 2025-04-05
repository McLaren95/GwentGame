using UnityEngine;


    [CreateAssetMenu(fileName = "TypeMillitarty", menuName = "Scriptable Objects/TypeMillitarty")]
    public class TypeMillitarty : ScriptableObject
    {
        string type;

        string get_type()
        {
            return type;
        }

        void set_type(int type)
        {
            return;
        }

    }
