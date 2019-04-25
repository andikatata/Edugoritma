using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomeManager : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    private bool isShow;
    public void SelectMenu() {
        if (isShow) {
            Debug.Log("out");
            animator.SetTrigger("FadeOut");
            isShow = false;   
        }else if (!isShow) {
            Debug.Log("in");
            animator.SetTrigger("FadeIn");
            isShow = true;
            Debug.Log("Finish"+this.animator.GetCurrentAnimatorStateInfo(0).IsName("FadeIn"));
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("FadeIn"))
            {
                animator.SetTrigger("ToMain");
            }
            
        }
    }
  
    public void SelectPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectARModul()
    {
        SceneManager.LoadScene(4);
    }

    public void SelectClose()
    {
        animator.SetTrigger("FadeIn");
        isShow = true;
    }

    public void ToMateri() {
        SceneManager.LoadScene(2);
    }

    void Start() {
        Debug.Log("start");
        isShow = true;
    }

    void Exit()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                return;
            }

        }
    }
    void Update() {
        Exit();
    }
    
}
