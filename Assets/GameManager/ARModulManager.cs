using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ARModulManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
    public void onBack()
    {
        SceneManager.LoadScene(0);

    }
    // Update is called once per frame
    void Update () {
        Back();
	}
}
