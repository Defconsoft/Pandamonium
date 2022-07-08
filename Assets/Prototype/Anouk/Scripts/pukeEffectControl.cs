using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pukeEffectControl : MonoBehaviour
{
    
    public GameObject go;
    public SkinnedMeshRenderer[] skinnedMeshRenderers = new SkinnedMeshRenderer[6];
    private Material[] dinoMaterials = new Material[6];
    private float transitionFactor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        go.SetActive(false);

        if (skinnedMeshRenderers != null)
        {
            for(int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                Material[] temp = skinnedMeshRenderers[i].materials;
                dinoMaterials[i] = temp[0];
                dinoMaterials[i].SetFloat("_texTransitionFactor", 0f);
            }
        }
    }

    public void StartPukeEffect()
    {
        go.SetActive(true);
    }

    public void StopPukeEffect()
    {
        go.SetActive(false);
        StartCoroutine(TransitionTexturesBack());
    }

    public void StartTransitionToRotten()
    {
        StartCoroutine(TransitionTextures());
    }

    IEnumerator TransitionTextures()
    {
        transitionFactor = dinoMaterials[0].GetFloat("_texTransitionFactor");
        Debug.Log(transitionFactor);
        while(transitionFactor < 1f)
        {
            transitionFactor += 0.1f;
            foreach(Material mat in dinoMaterials)
            {
                mat.SetFloat("_texTransitionFactor", transitionFactor);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator TransitionTexturesBack()
    {
        transitionFactor = dinoMaterials[0].GetFloat("_texTransitionFactor");
        Debug.Log(transitionFactor);
        while(transitionFactor > 0f)
        {
            transitionFactor -= 0.1f;
            foreach(Material mat in dinoMaterials)
            {
                mat.SetFloat("_texTransitionFactor", transitionFactor);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
