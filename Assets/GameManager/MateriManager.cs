using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MateriManager : MonoBehaviour
{
    public Materi[] materiArr;
    private static List<Materi> materiList;
    public static Materi currentMateri;
    private int indexMateri = 0;
    private int materiCount = 0;
    public static string currentArName;
    [SerializeField]
    private Text TitleText;
    [SerializeField]
    private Text SubText;
    [SerializeField]
    private Text MateriText;
    [SerializeField]
    private Button btNext;
    [SerializeField]
    private Button btPrev;


    void Start()
    {
        if (materiList == null || materiList.Count == 0)
        {
            materiList = materiArr.ToList<Materi>();
        }
        btPrev.interactable = false;
        SetCurrentMateri();
       
    }
    void SetCurrentMateri()
    {
        currentMateri = materiList[indexMateri];
        SubText.text = currentMateri.subJudul;
        MateriText.text = currentMateri.materi;
        currentArName = currentMateri.namaAr;
        materiCount = materiList.Count;
        Debug.Log("Count" + materiCount);
        
    }

    public void NextMateri()
    {
        btPrev.interactable = true;
        Debug.Log("Index Next Ke-" + indexMateri);
        indexMateri++;
        if (indexMateri < materiCount)
        {
            currentMateri = materiList[indexMateri];
            SubText.text = currentMateri.subJudul;
            MateriText.text = currentMateri.materi;
            currentArName = currentMateri.namaAr;
            if (indexMateri == materiCount - 1)
            {
                btNext.interactable = false;
            }
        }
        else if (indexMateri >= materiCount)
        {
            Debug.Log("Materi Mentok Ges");
        }
    }
    public void PrevMateri()
    {
        Debug.Log("Index Prev Ke-" + indexMateri);
        btNext.interactable = true;
        indexMateri--;
        if (indexMateri < materiCount)
        {
            currentMateri = materiList[indexMateri];
            SubText.text = currentMateri.subJudul;
            MateriText.text = currentMateri.materi;
            currentArName = currentMateri.namaAr;
            Debug.Log("Prev Materi Ke-" + indexMateri);
            if (indexMateri == 0)
            {
                btPrev.interactable = false;
            }
        }
        else if (indexMateri < 0)
        {
            Debug.Log("Materi Mentok Ges");
        }

    }

    public void OpenAR()
    {
        SceneManager.LoadScene(3);
    }
    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }
    void Back()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
                return;
            }

        }
    }
    void Update() {
        Back();
    }
}