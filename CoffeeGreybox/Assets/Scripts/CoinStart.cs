using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoinStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(0);
        }
	
	}
}
