using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;



public class NewEmptyCSharpScript : MonoBehaviour
{
    [SerializeField] private CreateFractions create_fractions;
    public Button button;


    public void OnButtonClick()
    {
        create_fractions.nextFraction();
    }

    void Start()
    {
        GameObject create_fractions11 = GameObject.Find("CreateFractions");
        create_fractions = create_fractions11.GetComponent<CreateFractions>();
        button.onClick.AddListener(OnButtonClick);


    }


}
