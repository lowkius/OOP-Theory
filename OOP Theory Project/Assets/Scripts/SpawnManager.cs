using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Sphere;
    public GameObject Cylinder;

    public Vector3 m_ShapeScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 ShapeScale //ENCAPSULATION
    {
        get { return m_ShapeScale; }
        private set
        {
            if (value.x > 1.0f || value.y > 1.0f || value.z > 1.0f)
            {
                Debug.LogError("Error. Shape scale X,Y,Z values cannot be greater than 1.0f");
                m_ShapeScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else
            {
                m_ShapeScale = value;
            }
        }
    }

    private GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.Find("SpawnManager/SpawnPoint");
    }

    //Spawn Cube Method //ABSTRACTION
    public void SpawnCube(int size)
    {
        GameObject cubeObject = (GameObject)Instantiate(Cube, SpawnPoint.transform.position, Cube.transform.rotation);

        ScaleShape(cubeObject, size); //ABSTRACTION
    }

    //Spawn Cylinder Method //ABSTRACTION
    public void SpawnCylinder(int size)
    {
        GameObject cylinderObject = (GameObject)Instantiate(Cylinder, SpawnPoint.transform.position, Cylinder.transform.rotation);

        ScaleShape(cylinderObject, size); //ABSTRACTION
    }

    //Spawn Sphere Method //ABSTRACTION
    public void SpawnSphere(int size)
    {
        GameObject sphereObject = (GameObject)Instantiate(Sphere, SpawnPoint.transform.position, Sphere.transform.rotation);

        ScaleShape(sphereObject, size); //ABSTRACTION
    }

    //Scale Shape Method
    private void ScaleShape(GameObject shapeObject, int size) //ABSTRACTION
    {
        float scaleSize;

        scaleSize = Sphere.GetComponent<Shapes>().GetShapeScale(size);
        ShapeScale = new Vector3(scaleSize, scaleSize, scaleSize);
        shapeObject.transform.localScale += new Vector3(scaleSize, scaleSize, scaleSize);
        shapeObject.GetComponent<Shapes>().SetShapeSize(size);
    }
}
