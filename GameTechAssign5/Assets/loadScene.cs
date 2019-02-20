using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
  void Start(){

  }
  
  public void loadThisScene(string scenename){
    SceneManager.LoadScene(scenename);
  }
}
