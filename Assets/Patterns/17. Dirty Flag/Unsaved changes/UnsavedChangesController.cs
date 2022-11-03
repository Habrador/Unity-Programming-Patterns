using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsavedChangesController : MonoBehaviour
{
    public Transform cubeGO;    

    //This is the Dirty Flag
    private bool isSaved = true;

    private readonly float cubeSpeed = 5f;



    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cubeGO.Translate(cubeSpeed * Time.deltaTime * Vector3.forward);

            isSaved = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cubeGO.Translate(cubeSpeed * Time.deltaTime * -Vector3.forward);

            isSaved = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cubeGO.Translate(cubeSpeed * Time.deltaTime * -Vector3.right);

            isSaved = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cubeGO.Translate(cubeSpeed * Time.deltaTime * Vector3.right);

            isSaved = false;
        }
    }



    private void OnGUI()
    {    
        if (GUILayout.Button("Save"))
        {
            Debug.Log("Game was saved");

            isSaved = true;
        }

        if (!isSaved)
        {
            GUILayout.Box("Warning you have unsaved changes");
        }
    }
}
