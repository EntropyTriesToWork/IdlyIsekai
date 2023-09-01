using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName ="Settings")]
public class SettingsSO : ScriptableObject
{
    public int musicVolume;
    public int sfxVolume;
}
