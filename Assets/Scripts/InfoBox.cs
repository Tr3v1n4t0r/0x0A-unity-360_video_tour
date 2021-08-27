using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Script that enables the easy toggling of an info box.</summary>
public class InfoBox : MonoBehaviour
{
    ///<summary>Shows and hides the passed info box.</summary>
    public void ToggleActive(GameObject infoBox) {
        infoBox.SetActive(!infoBox.activeSelf);
    }
}
