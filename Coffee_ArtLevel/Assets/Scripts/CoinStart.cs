using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinStart : MonoBehaviour {

    int credits;
    Text creditDisplay;

	// Use this for initialization
	void Start () {
        
	
	}

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            credits++;
            creditDisplay = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
            creditDisplay.text = credits.ToString(); ;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && credits >= 1)
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(1);
        }

    }
}
