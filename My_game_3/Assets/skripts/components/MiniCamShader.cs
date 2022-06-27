using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamShader : MonoBehaviour
{
    public Shader _reflShader;
    private Camera _camera; 
   
    void Awake()
    {
        _reflShader = Shader.Find("Unlit/Texture");
        _camera = GetComponent<Camera>();

        if (_reflShader)
        {
            _camera.SetReplacementShader(_reflShader, "RenderType"); 
        }
    }

    void OnDisable()
    {
        _camera.ResetReplacementShader();  
    }
}
