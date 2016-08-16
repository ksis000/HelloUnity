using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
    
    public Vector3 spinSpeed = Vector3.zero;
    public Vector3 spinAxis = new Vector3(0, 1, 0);
    public float rotateSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        //setSize(2.0f);
        //this.transform.position = new Vector3(0, 5, 3);
        spinSpeed = new Vector3(Random.value, Random.value, Random.value);
        spinAxis.x = (Random.value - Random.value) * .1f;
	
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
