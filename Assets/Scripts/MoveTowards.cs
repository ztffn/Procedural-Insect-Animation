using UnityEngine;

// Vector3.MoveTowards example.

// A cube can be moved around the world. It is kept inside a 1 unit by 1 unit
// xz space. A small, long cylinder is created and positioned away from the center of
// the 1x1 unit. The cylinder is moved between two locations. Each time the cylinder is
// positioned the cube moves towards it. When the cube reaches the cylinder the cylinder
// is re-positioned to the other location. The cube then changes direction and moves
// towards the cylinder again.
//
// A floor object is created for you.
//
// To view this example, create a new 3d Project and create a Cube placed at
// the origin. Create Example.cs and change the script code to that shown below.
// Save the script and add to the Cube.
//
// Now run the example.

public class MoveTowards : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
public float turnrate = 1.0f;
  //  public Vector3 targetStart = new Vector3(0.8f, 0.0f, 0.8f);
    // The target (cylinder) position.
    public Transform target;

    void Awake()
    {

        // Create and position the cylinder. Reduce the size.
      //  var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
     //   cylinder.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);

        // Grab cylinder values and place on the target.
     //   target = cylinder.transform;
      //  target.transform.position = targetStart;

    }

    void Update()
    {
        // Move our position a step closer to the target.
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }
        Vector3 movementDirection = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z);
        movementDirection.Normalize();
     transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (movementDirection), Time.deltaTime * turnrate);
    }
}