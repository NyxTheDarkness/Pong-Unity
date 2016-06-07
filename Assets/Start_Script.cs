using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Start_Script : MonoBehaviour {

	public void LoadScene()
	{
		Debug.Log("Loading Main Scene");
		SceneManager.LoadScene("main_scene", LoadSceneMode.Single);
	}
}
