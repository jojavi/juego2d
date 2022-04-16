using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicMenu : MonoBehaviour
{
   
 
    public void loadlevel(){

        Debug.Log("Ingresa a nivel juego");

       // int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);

        
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("salio del juego");
    }
        
    
}
