using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ARManager : MonoBehaviour {
    private string arName;
    public Models[] modelsArr;
    private static List<Models> modelsList;
    // public Models currentModels;
    // public GameObject modelObject;
    [SerializeField]
    public GameObject Object1;
    [SerializeField]
    public GameObject Object2;
    [SerializeField]
    public GameObject Object3;
    private int count;

    // Use this for initialization
    void Start () {
        arName = MateriManager.currentArName;
        //if (modelsList == null || modelsList.Count == 0)
        //{
        //    modelsList = modelsArr.ToList<Models>();
        //}
        //Debug.Log("Start" + arName);
        //setCurrentModel();
        setARModel(arName);
	}
    void setCurrentModel() {
        count = modelsList.Count;
        Debug.Log(count + " Objek");
        modelsList = modelsArr.ToList<Models>();
        int cnt = modelsList.Count;
        Debug.Log(cnt + " Count Objek");
        for (int i = 0; i < count; i++) {
            Models currentModels = modelsList[i];
            string modelName = currentModels.namaAR;
            Debug.Log(modelName);
            GameObject modelObject = currentModels.ObjectAR;
            Debug.Log(modelObject);
            if (modelName.Equals(arName))
            {
                modelObject.SetActive(true);
                Debug.Log(modelName + "Active");
            }
            else {
                Debug.Log(modelName + "Not Active");
                modelObject.SetActive(false);
            }
        }
    }
    void setARModel(string arname) {
        switch (arName) {
            case "bubble_sort":
                Debug.Log("BUBBLE_ACTIVE");
                Object1.SetActive(true);
                Object2.SetActive(false);
                Object3.SetActive(false);
                break;
            case "selection_sort":
                Debug.Log("SELECTION_ACTIVE");
                Object1.SetActive(false);
                Object2.SetActive(true);
                Object3.SetActive(false);
                break;
            case "insertion_sort":
                Debug.Log("INSERTION_ACTIVE");
                Object1.SetActive(false);
                Object2.SetActive(false);
                Object3.SetActive(true);
                break;
            default:
                Debug.Log("OBJECT_NOTFOUND");
                Object1.SetActive(false);
                Object2.SetActive(false);
                Object3.SetActive(false);
                break;
        }
    }
    void Back() {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(2);
                return;
            }

        }
    }
    public void onBack() {
        SceneManager.LoadScene(2);
     
    }


	// Update is called once per frame
	void Update () {
        Back();
	}
 
}
