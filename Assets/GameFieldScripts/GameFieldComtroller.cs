//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MoveObjectsToCardCount : MonoBehaviour
//{
//    void Start()
//    {
//        // Находим целевой CardCount (первый в иерархии)
//        GameObject cardCount = GameObject.Find("CardCount");

//        if (cardCount != null)
//        {
//            // Переносим объекты из DontDestroyOnLoad
//            MoveObjectToCardCount("player_geralt", cardCount);

//        }
//    }

//    void MoveObjectToCardCount(string objName, GameObject parent)
//    {
//        GameObject obj = GameObject.Find(objName);
//        if (obj != null)
//        {
//            // Переносим объект в текущую сцену
//            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
//            // Делаем дочерним для CardCount
//            obj.transform.SetParent(parent.transform);
//        }
//    }
//}