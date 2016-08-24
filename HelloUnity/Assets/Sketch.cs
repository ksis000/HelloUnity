using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour
{
    public TextMesh nText = new TextMesh();
    public GameObject myPrefab;
    public string _WebsiteURL = "http://ksis000lab2.azurewebsites.net/tables/product?zumo-api-version=2.0.0";

    void Start()
    {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
        int totalCubes = 8;
        int totalDistance = 10;
        int i = 0;
        int j = 0;
        
        

        //for (int i = 0; i < totalCubes; i++)
        //{
            /*float perc = i / (float)totalCubes;

            float x = perc * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeScript>().setSize(1.0f - perc);
            newCube.GetComponent<CubeScript>().rotateSpeed = perc;*/
        //}


        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + product.ProductName);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            /*float perc = i / (float)totalCubes;

            float x = perc * totalDistance;*/
            float perc = 0.0f;
            float x = -5.0f;
            float y = 5.0f;
            float z = 0.0f;
            Color colour = Color.white;

            

            if (product.Manufacturer == "Abbas")
            {
                perc = j / (float)totalCubes;
                x = perc * totalDistance;
                x = x - 4;
                y = 8.0f - (float)(j*.35);
                colour = Color.green;
                j++;
            } else if (product.Manufacturer == "Fama")
            {
                perc = i / (float)totalCubes;
                x = perc * totalDistance;
                x = x - 4;
                y = 5.0f -(float)(i*.35);
                colour = Color.yellow;
                i++;
            }

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            //newCube.GetComponent<CubeScript>().setSize(1.0f - perc);
            newCube.GetComponent<CubeScript>().setSize(.5f);
            //newCube.GetComponent<CubeScript>().rotateSpeed = perc;
            newCube.GetComponent<CubeScript>().rotateSpeed = -.25f;
            newCube.GetComponentInChildren<TextMesh>().text = product.ProductName;
            //newCube.GetComponentInChildren<TextMesh>().transform.localPosition = new Vector3(x, y-3, z);
            newCube.GetComponent<Renderer>().material.color = colour;

           

            //i++;

            //----------------------
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
