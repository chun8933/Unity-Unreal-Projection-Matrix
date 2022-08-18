using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unreal;

public class TestMatrix : MonoBehaviour
{
    public Camera view;

    // Debug use 
    // For chking value in runtime only
    public Matrix4x4 UnityMatrix;

    // Start is called before the first frame update
    void Start()
    {
        // Get Unity current cam matrix
        UnityMatrix = view.projectionMatrix;

        // Code as same as Unreal
        FMinimalViewInfo info;
        view.GetViewPoint(out info);

        // To implement FMinimalViewInfo function only
        FMatrix CalculatedUnrealMatrix = info.calculate_projection_matrix();
        Debug.Log(info.ToString());
        Debug.Log(CalculatedUnrealMatrix.ToString());

        Debug.Log("---------------------");
        // Usually use the below method to get the matrix
        FMatrix ConvertedUnrealMatrix = info.covert_from_projection_matrix();
        Debug.Log(ConvertedUnrealMatrix.ToString());
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug use
        // Apply modification in runtime
        view.projectionMatrix = UnityMatrix;
    }
}
