using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class XMLManager : MonoBehaviour
{
    [Serializable]
    public class Shape
    {
        public string Name;
        public Color Color;
    }

    [Serializable]
    public class ShapeDatabase
    {
        [XmlArray("Shapes")]
        public List<Shape> shapes;
    }

    public ShapeDatabase shapeDB;

    #region Singlton
    public static XMLManager xMLManager;
    void Awake() => xMLManager = this;
    #endregion

    void Start() => Load();

    public void Save()
    {
        //create new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ShapeDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/PrimitiveShape.xml", FileMode.Create);

        //serialize data to xml file
        serializer.Serialize(stream, shapeDB);

        //close stream
        stream.Close();
    }

    public void Load()
    {
        //open xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ShapeDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/PrimitiveShape.xml", FileMode.Open);

        //deserialize data from xml file to ShapeDataBase object
        shapeDB = serializer.Deserialize(stream) as ShapeDatabase;

        //close stream
        stream.Close();
    }
}
