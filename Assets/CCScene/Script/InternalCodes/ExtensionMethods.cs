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
    public static Vector3 ZeroY(this Vector3 vector3)
    {
        return new Vector3(vector3.x, 0, vector3.z);
    }
}
