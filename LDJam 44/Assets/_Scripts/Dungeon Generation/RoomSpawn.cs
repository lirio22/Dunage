using UnityEngine;

public class RoomSpawn : MonoBehaviour {

    public DungeonContentSpawner contentSpawner;

    public GameObject[] rooms;

    public string corner1Tag;    
    public GameObject corner1;
    private bool spawnCorner1;

    public string corner2Tag;
    public GameObject corner2;
    private bool spawnCorner2;

    private void Awake()
    {
        contentSpawner = GameObject.FindGameObjectWithTag("DungeonController").GetComponent<DungeonContentSpawner>();
    }

    private void Start()
    {
        Invoke("InstantiateRoom", 0.1f);
    }

    private void InstantiateRoom()
    {
        if(spawnCorner1)
        {
            GameObject newRoom = Instantiate(corner1, transform.position, Quaternion.identity);
            contentSpawner.Rooms.Add(newRoom);
            Destroy(gameObject);
        }
        else if(spawnCorner2)
        {
            GameObject newRoom = Instantiate(corner2, transform.position, Quaternion.identity);
            contentSpawner.Rooms.Add(newRoom);
            Destroy(gameObject);
        }
        else
        {
            GameObject newRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
            contentSpawner.Rooms.Add(newRoom);
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Center")
        {
            Destroy(gameObject);
        }

        if(other.tag == corner1Tag)
        {
            spawnCorner1 = true;
        }

        if (other.tag == corner2Tag)
        {
            spawnCorner2 = true;
        }
    }
}
