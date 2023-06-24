using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableState
{
    public float[] xPositions;
    public float[] yPositions;
    public float[] zPositions;

    //I want to save other objects as well. Can I do that?
    public float[] otherObjectsHealth;
}
