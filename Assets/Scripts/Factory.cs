using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] T prefab;

    protected T GetNewInstance()
    {
        return Instantiate(prefab);
    }
}
