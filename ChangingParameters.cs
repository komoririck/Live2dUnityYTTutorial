using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingParameters : MonoBehaviour{
    CubismModel live2dModel;
    CubismParameter parameter;

    void Awake(){                                   //in case you don't know, you can add the script after the init or instantiate, it'll also work "AddComponent<ChangingParameters>();"
        live2dModel = this.FindCubismModel(); // get the model on the object with this script
        parameter = live2dModel.Parameters.FindById("ParamMouthOpenY"); // finding parameters 
    }

    public void LateUpdate() {
        parameter.Value = 1f;
        live2dModel.Parameters[0].Value = 1f;
    }
}
