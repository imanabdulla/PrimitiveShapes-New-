using UnityEngine;
using UnityEngine.UI;

public class ShapeDisplay : MonoBehaviour
{
    /// <summary>
    /// reference of used Factory 
    /// </summary>
    public ShapeFactory shapeFactory;
    public Dropdown shapeDropDown, colorDropDown;

    /// <summary>
    /// when user click on Display Button 
    /// </summary>
    public void OnDisplayBtnClick()
    {
        //destroy current instantiated shape if exsists
        if (shapeFactory.gameObject.transform.GetChild(shapeDropDown.value).childCount > 0)
            shapeFactory.DontDisplayShape(shapeFactory.gameObject.transform.GetChild(shapeDropDown.value));

        //configure new shape properties
        var mesh = shapeFactory.possibleMeshes[shapeDropDown.value];
        var color = shapeFactory.possibleColors[colorDropDown.value];
        var colliderType = shapeFactory.possibleColliders[shapeDropDown.value];

        //instantiate new shape 
        shapeFactory.DisplayShape(shapeFactory.gameObject.transform.GetChild(shapeDropDown.value), Vector3.zero, Quaternion.identity,mesh, color, colliderType);

        //store new data in shape database
        StoreNewShapeToDatabase(color);
    }

    void StoreNewShapeToDatabase(Color color) => XMLManager.xMLManager.shapeDB.shapes[shapeDropDown.value].Color = color;

    public void DisplayShapeFromLoadedDatabase()
    {
        for (int i = 0; i < XMLManager.xMLManager.shapeDB.shapes.Count; i++)
        {
            var mesh = shapeFactory.possibleMeshes[i];
            var color = XMLManager.xMLManager.shapeDB.shapes[i].Color;
            var colliderType = shapeFactory.possibleColliders[i];

            shapeFactory.DisplayShape(shapeFactory.gameObject.transform.GetChild(i), Vector3.zero, Quaternion.identity, mesh, color, colliderType);
        }
    }
}

