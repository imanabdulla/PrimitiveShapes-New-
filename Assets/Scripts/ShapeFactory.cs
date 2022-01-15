using UnityEngine;

public class ShapeFactory : Factory<Shape3D>
{
    public Mesh[] possibleMeshes;
    public Color[] possibleColors;
    public Shape3D.ColliderType[] possibleColliders;

    public void DisplayShape(Transform parent, Vector3 pos, Quaternion rot, Mesh shapeMesh, Color shapeColor, Shape3D.ColliderType shapeColliderType)
    {
        Shape3D shape = GetNewInstance() as Shape3D;

        shape.transform.parent = parent;
        shape.transform.localPosition = pos;
        shape.transform.localRotation = rot;
        shape.mesh = shapeMesh;
        shape.color = shapeColor;
        shape.colliderType = shapeColliderType;
    }

    public void DontDisplayShape(Transform shapeParent) => shapeParent.GetChild(0).gameObject.SetActive(false);
}
