using System;
using System.IO;
using Live2D.Cubism.Framework.Json;
using UnityEngine;
using Live2D.Cubism.Framework;

public class InitModel : MonoBehaviour {
    public string path;
    void Start(){
        //location of the model3.json file of the model 
        var model3Json = CubismModel3Json.LoadAtPath(path + ".model3.json", BuiltinLoadAssetAtPath);

        var model = model3Json.ToModel(); // get model json return cubims model
        model.gameObject.AddComponent<CubismAutoEyeBlinkInput>(); // add the blinking
    }
    
    public static object BuiltinLoadAssetAtPath(Type assetType, string absolutePath)
    {
        if (assetType == typeof(byte[]))
        {
            return File.ReadAllBytes(absolutePath);
        }
        else if (assetType == typeof(string))
        {
            return File.ReadAllText(absolutePath);
        }
        else if (assetType == typeof(Texture2D))
        {
            var texture = new Texture2D(1, 1);
            texture.LoadImage(File.ReadAllBytes(absolutePath));

            return texture;
        }

        throw new NotSupportedException();
    }
}