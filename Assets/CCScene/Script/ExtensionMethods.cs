using UnityEngine;
public static class ExtensionMethods{
    public static void DestroyAllChildren(this Transform transform)
    {
        if (transform.childCount != 0)
        {
            for (int childNum = 0; childNum < transform.childCount; childNum++)
            {
                GameObject.Destroy(transform.GetChild(childNum).gameObject);
            }
        }
    }
    public static void DisableAllLayers(this Animator animator)
    {
        for(int numLayer = 1; numLayer < animator.layerCount; numLayer++)
        {
            animator.SetLayerWeight(numLayer, 0);
        }
    }
}
