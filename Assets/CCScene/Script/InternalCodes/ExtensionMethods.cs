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
}
