using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SearchCreator : MonoBehaviour
{
    [SerializeField] public GameObject Cube;
    [SerializeField] public Text Etzh;
    [SerializeField] public Text fl;
    [SerializeField] public Text inText;
    [SerializeField] public InputField field;
    public GameObject _obj;
    public Text etz;
    public Text flor;
    public Button search;
    public Button cancel;
    public Button refresh;
    public Button toilm;
    public Button toilw;
    public static float x = 0f;
    public static float y = 0f;
    public static float z = 0f;
    public static int ind = 0;
    public static int idroom = 0;
    public bool helper = true;
    private static string request;
    public static string deftxt;
    private static string flc;


    void Start()
    {
        flchanger();
        Txtchng();
    }
    void Update()
    {

    }
    public void Refresher() 
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        helper = true;
    }
    public void Click()
    {
        switch (helper) {
            case true:
                fin();
                Roomchooser();
                if (idroom > 0)
                {
                    SceneManager.LoadScene(ind, LoadSceneMode.Additive);
                    Creator();
                    Txtchng();
                    flchanger();
                    helper = false;
                }
                else
                {
                    Txtchng();
                    flchanger();
                    helper = true;
                }
                break;
            default:
                helper = false;
                break;

        }
    }
    public void Cans()
    {
        ind = 0;
        idroom = 0;
        switch (helper)
        {
            case false:
                Destructor();
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                fin();
                Txtchng();
                flchanger();
                Roomchooser();
                helper = true;
                break;
            default:
                Txtchng();
                helper = true;
                break;
        }
    }
    public void find()
    {
        if (string.IsNullOrWhiteSpace(inText.text))
        {
            request = null;
        }
        else
        {
            request = inText.text;
        }
    }
    public void fincaller()
    {
        fin();
    }
    void fin() 
    { 
        if (request == null)
        {
            idroom = 0;
        }
        else
        {
            idroom = int.Parse(request);
        }
    }
    void Roomchooser()
    {
        switch (idroom)
        {
            case 1:
                x = 578.2719f;
                y = 4.683387f;
                z = 251.9308f;
                ind = 0;
                break;
            case 2:
                x = 543.82f;
                y = 4.683387f;
                z = 251.97f;
                ind = 0;
                break;
            case 3:
                x = 578.04f;
                y = 4.683387f;
                z = 227.11f;
                ind = 0;
                break;
            case 4:
                x = 541.47f;
                y = 4.683387f;
                z = 226.86f;
                ind = 0;
                break;
            case 5:
                x = -2087.4f;
                y = 4.683389f;
                z = 200.7f;
                ind = 1;
                break;
            case 6:
                x = -2109.9f;
                y = 4.683389f;
                z = 200.7f;
                ind = 1;
                break;
            case 7:
                x = -2079.65f;
                y = 4.683389f;
                z = 226.28f;
                ind = 1;
                break;
            case 8:
                x = -2116.8f;
                y = 4.683389f;
                z = 225.8f;
                ind = 1;
                break;
            default:
                idroom = 0;
                ind = 0;
                break;
        }
    }
    void Creator()
    {
        _obj = Instantiate(Cube, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        _obj.SetActive(true);
    }
    void Destructor()
    {
        Destroy(this._obj);
    }
    public void Txtupdt()
    {
        etz.text = null;
        Txtchng();
        etz.text = deftxt;
    }
    void flchanger()
    {
        int e = ind + 1;
        flc = e.ToString() + " этаж";
    }
    public void fldetector()
    {
        flchanger();
        flor.text = flc;
    }
    void Txtchng()
    {
        int e = ind + 1;
        if (idroom > 0)
        {
            deftxt = "Искомый кабинет находится на " + e.ToString() + " этаже";
        }
        else if (request == null) 
        {
            deftxt = "Введите номер комнаты";
        }
        else if (idroom == 0)
        {
            deftxt = "Искомой комнаты не существует!";
        }
    }
    public void StartScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }
    public void FiendScene()
    {
        if (ind != 0)
        {
            SceneManager.LoadScene(ind, LoadSceneMode.Additive);
        }
    }
    void toilet()
    {
        SceneManager.LoadScene(ind, LoadSceneMode.Additive);
        Creator();
        helper = false;
    }
    public void mtClick()
    {
        if (helper)
        {
            x = -2072.4f;
            y = 4.683389f;
            z = 201.36f;
            ind = 1;
            toilet();
        }
    }
    public void wtClick() 
    {
        if (helper) {
            x = -2126.851f;
            y = 4.683389f;
            z = 199.835f;
            ind = 1;
            toilet();
        }
    }
}
