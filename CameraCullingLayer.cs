using System;
using UnityEditor;
using UnityEngine;

public class CameraCullingLayer : EditorWindow
{


    [MenuItem("SH Custom/change camera layer")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<CameraCullingLayer>();
        wnd.titleContent = new GUIContent("Custom set Camera Culling Layer");
        wnd.Show();
    }

    private GameObject camera;
    private LayerMask[] layers = new LayerMask[32];
    private float[] tem = new float[32];
    private Vector2 scrollPosition;
    private void OnGUI()
    {
        camera = Selection.activeTransform.gameObject;

        if (camera.GetComponent<Camera>())
        {
            EditorGUILayout.HelpBox("only float accepted", MessageType.Warning);
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Layer Effected  !",GUILayout.Width(100));
            EditorGUILayout.LabelField("Destence of culling");
            EditorGUILayout.EndHorizontal();
            for (int i = 0; i < 32; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Layer no : " + i, GUILayout.Width(100));
                try
                {
                    tem[i] = float.Parse(EditorGUILayout.TextField(tem[i].ToString(), GUILayout.Width(100)));
                }
                catch
                {
                    EditorGUILayout.HelpBox("only float accepted", MessageType.Warning);
                }
               
                EditorGUILayout.EndHorizontal();
            }


            if(GUILayout.Button("Change Culling Lyer", GUILayout.Width(200)))
            {
                camera.GetComponent<Camera>().layerCullDistances = tem;
            }

            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.HelpBox("Click on camera gameobject"   , MessageType.Warning);
        }

       
        
    }
   
}
