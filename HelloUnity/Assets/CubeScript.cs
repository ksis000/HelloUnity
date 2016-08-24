using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

    public Vector3 spinSpeed = new Vector3 (0,-1,0);
    public Vector3 spinAxis = new Vector3(0, 1, 0);
    public float rotateSpeed = -.5f;
    
	// Use this for initialization
	void Start () {

        spinSpeed = new Vector3(0, .25f,0);
    }

    public void setSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(spinSpeed);
        this.transform.RotateAround(Vector3.zero, spinAxis, rotateSpeed);       

    }
}
