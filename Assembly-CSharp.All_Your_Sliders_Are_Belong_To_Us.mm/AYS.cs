using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using MonoMod;
using Mono.Cecil;

public class patch_GameSettings : GameSettings
{
    private extern void orig_Start();
    private void Start()
    {
        if(this.damageSliders != null)
        {
            foreach(var i in this.damageSliders)
            {
                Debug.Log(i.name + ".maxValue: " + i.maxValue.ToString());
                i.maxValue *= 100;
                InputField tmpInpt = i.transform.parent.GetComponentsInChildren<InputField>()[0];
                if (tmpInpt != null) {
                    Debug.Log("Text object val: " + tmpInpt.text);
                    tmpInpt.textComponent.fontSize = 18;
                    tmpInpt.characterLimit = 6;
                }
            }
        }
        orig_Start();
    }
}