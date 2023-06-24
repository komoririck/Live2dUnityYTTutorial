using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingParametersTwo : MonoBehaviour{
    CubismModel model;

    void Awake()
    {
        model = this.FindCubismModel();
    }

    void LateUpdate()
    {
        model.Parameters[0].Value = 30;
        model.Parameters.FindById("ParamMouthOpenY").Value = 1;

        CubismParameter head = model.Parameters[1];
        head.Value = -30;

        for (int i = 0; i < model.Parameters.Length; i++)
        {
            if (model.Parameters[i].DefaultValue == 0)
            {
                if (model.Parameters[i].MaximumValue == 30)
                {
                    model.Parameters[i].Value = model.Parameters[i].MaximumValue;
                }
                else
                {
                    model.Parameters[i].Value = model.Parameters[i].MinimumValue;
                }
            }

        }

    }
}
