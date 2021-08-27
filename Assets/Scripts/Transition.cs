using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Script to control transition states.</summary>
public class Transition : MonoBehaviour
{
    // Duration of transition.
    public float duration;
    // Length of pause between fade out and fade in.
    public float pause;

    // GameObject variables referencing the different rooms.
    public GameObject living;
    public GameObject cube;
    public GameObject cantina;
    public GameObject mezz;

    // Variables to track transition state.
    private GameObject currObj;
    private GameObject transObj;
    private float expo;
    private float pauseLeft;
    private bool transing = false;

    ///<summary>Runs upon scene load. Sets variables to their initial value.</summary>
    void Start() {
        currObj = living;
        transObj = currObj;
        pauseLeft = pause;
    }

    ///<summary>Runs every frame. Handles transitioning between rooms.</summary>
    void Update() {
        if (transing) {
            expo = RenderSettings.skybox.GetFloat("_Exposure");

            // Lowers exposure until completely dark, then switches videos and raises exposure back.
            if (currObj != transObj) {
                if ( expo > Time.deltaTime / duration) {
                    RenderSettings.skybox.SetFloat("_Exposure", expo - Time.deltaTime / duration);
                    expo = expo - Time.deltaTime / duration;
                } else {
                    RenderSettings.skybox.SetFloat("_Exposure", 0f);

                    currObj.SetActive(false);
                    transObj.SetActive(true);

                    if (pauseLeft > 0f) {
                        pauseLeft -= Time.deltaTime;
                    } else {
                        currObj = transObj;
                        pauseLeft = pause;
                    }
                }
            } else {
                if (1f - expo > Time.deltaTime / duration) {
                    RenderSettings.skybox.SetFloat("_Exposure", expo + Time.deltaTime / duration);
                } else {
                    RenderSettings.skybox.SetFloat("_Exposure",  1f);

                    foreach (Transform child in currObj.transform) {
                        child.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    
    ///<summary>Sets up to transition to the Cube scene.</summary>
    public void ToCube() {
        transObj = cube;
        transing = true;

        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
    
    ///<summary>Sets up to transition to the Living Room scene.</summary>
    public void ToLiving() {
        transObj = living;
        transing = true;

        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
    
    ///<summary>Sets up to transition to the Cantina scene.</summary>
    public void ToCantina() {
        transObj = cantina;
        transing = true;

        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
    
    ///<summary>Sets up to transition to the Mezzanine scene.</summary>
    public void ToMezz() {
        transObj = mezz;
        transing = true;

        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
}