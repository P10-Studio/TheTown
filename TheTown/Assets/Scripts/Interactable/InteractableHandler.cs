using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class InteractableHandler : MonoBehaviour
{
    [SerializeField] private Material outline;
    [SerializeField] private MeshRenderer meshRenderer;

    private Material[] originalMaterials;
    private Material[] outlineMaterials;

    private bool IsOutlineEnabled { get; set; } = false;
    
    private void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        
        originalMaterials = meshRenderer.materials;
        
        outlineMaterials = new Material[originalMaterials.Length + 1];
        Array.Copy(originalMaterials, outlineMaterials, originalMaterials.Length);
        outlineMaterials[^1] = outline;
        
        Debug.Log(originalMaterials.ToList().Select(x => x.name));
        Debug.Log(outlineMaterials.ToList().Select(x => x.name));
    }
    
    private void ShowOutline()
    {
        if (IsOutlineEnabled || originalMaterials.Length <= 0) return;

        meshRenderer.materials = outlineMaterials;
        IsOutlineEnabled = true;
    }
    
    private void HideOutline()
    {
        if (!IsOutlineEnabled) return;
        
        meshRenderer.materials = originalMaterials;
        IsOutlineEnabled = false;
    }
    
    private void OnMouseEnter()
    {
        ShowOutline();
    }
    
    private void OnMouseExit()
    {        
        HideOutline();
    }
    
    private void OnMouseDown()
    {
        Debug.Log("Interactable clicked: " + gameObject.name);
    }
}
