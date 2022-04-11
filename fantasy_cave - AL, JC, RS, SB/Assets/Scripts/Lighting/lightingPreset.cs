using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset 1", menuName = "Scriptables/Lighting Preset", order = 1)]
public class lightingPreset : ScriptableObject
{
    public Gradient AmbientColor, DirectionalColor, FogColor;
}