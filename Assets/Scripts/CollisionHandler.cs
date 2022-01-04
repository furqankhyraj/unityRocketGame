using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("LaunchPad");
                break;
            case "Finish":
                Debug.Log("Finished");
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                Debug.Log("Blew up");
                break;

        }
    }
}
