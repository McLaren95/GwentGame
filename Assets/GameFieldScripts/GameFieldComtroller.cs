//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MoveObjectsToCardCount : MonoBehaviour
//{
//    void Start()
//    {
//        // ������� ������� CardCount (������ � ��������)
//        GameObject cardCount = GameObject.Find("CardCount");

//        if (cardCount != null)
//        {
//            // ��������� ������� �� DontDestroyOnLoad
//            MoveObjectToCardCount("player_geralt", cardCount);

//        }
//    }

//    void MoveObjectToCardCount(string objName, GameObject parent)
//    {
//        GameObject obj = GameObject.Find(objName);
//        if (obj != null)
//        {
//            // ��������� ������ � ������� �����
//            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
//            // ������ �������� ��� CardCount
//            obj.transform.SetParent(parent.transform);
//        }
//    }
//}