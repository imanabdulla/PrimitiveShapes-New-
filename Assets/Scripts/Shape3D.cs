using UnityEngine;

public class Shape3D : MonoBehaviour
{
    public Mesh mesh;
    public Color color;
    public enum ColliderType { CapsuleCollider, SphereCollider, BoxCollider }
    public ColliderType colliderType;

    [SerializeField]
    float rotationSpeed = 10;
    Vector2 mousePos;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material.color = color;

        switch (colliderType)
        {
            case ColliderType.CapsuleCollider:
                gameObject.AddComponent<CapsuleCollider>();
                break;
            case ColliderType.SphereCollider:
                gameObject.AddComponent<SphereCollider>();
                break;
            case ColliderType.BoxCollider:
                gameObject.AddComponent<BoxCollider>();
                break;
        }
    }

    void OnMouseDrag() => Rotate();

    void Rotate()
    {
        mousePos.x += Input.GetAxis("Mouse X");
        mousePos.y += Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(rotationSpeed * new Vector3(-mousePos.y, mousePos.x, 0));
    }
}
