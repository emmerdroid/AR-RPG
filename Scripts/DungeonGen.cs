using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }

    public Vector2 size;
    public int startPoint = 0;
    public GameObject[] rooms;
    public Vector2 offset;


    List<Cell> layout;//layout

    // Start is called before the first frame update
    void Start()
    {
        LayoutGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LevelGenerator()
{
    for (int i = 0; i < size.x; i++)
    {
        for (int j = 0; j < size.y; j++)
        {
            Cell currentCell = layout[Mathf.FloorToInt(i + j * size.x)];
            if (currentCell.visited)
            {
                // Randomly selects a room from the array
                int randomIndex = Random.Range(0, rooms.Length);
                GameObject selectedRoom = rooms[randomIndex];
                
                var newRoom = Instantiate(selectedRoom, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                newRoom.updateRoom(currentCell.status);
            }
        }
    }
}


    void LayoutGenerator()
    {
        layout = new List<Cell>();
        
        for (int i=0; i<size.x; i++)
        {
            for (int j=0; j<size.y; j++)
            {
                layout.Add(new Cell());
            }
        }

        int currentCell = startPoint;
        Stack<int> path = new Stack<int>();
        int k = 0; 

        while (k<500)
        {
            k++;
            layout[currentCell].visited = true;

            if(currentCell == layout.Count-1)
            {
                break;
            }

            List<int> neighbors = CheckingNeighbors(currentCell);

            if(neighbors.Count ==0)
            {
                if(path.Count ==0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);
                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if (newCell > currentCell)
                {
                    if(newCell - 1 == currentCell)//means the cell is on the east
                    {
                        layout[currentCell].status[2] = true;//cell is on the east
                        currentCell = newCell;
                        layout[currentCell].status[3] = true;//this open the door on the west side
                    }
                    else
                    {
                        layout[currentCell].status[1] = true;//if the cell is on the south 
                        currentCell = newCell;
                        layout[currentCell].status[0] = true;//the door is open for north
                    }
                }
                else
                {
                     if(newCell + 1 == currentCell)//if the cell is on the west
                    {
                        layout[currentCell].status[3] = true;//cell on the west
                        currentCell = newCell;
                        layout[currentCell].status[2] = true;//opens the door on the east
                    }
                    else
                    {
                        layout[currentCell].status[0] = true;//cell on the north
                        currentCell = newCell;
                        layout[currentCell].status[1] = true;//door opens on the south
                    }
                }
            }

        }
        LevelGenerator();
    }

    List<int> CheckingNeighbors(int cell)//this checks the sides of each cell(room)
    {
        List<int> neighbors = new List<int>();
        //this checks the north side wall/if not been visted then it passes a room in the north direction
        if (cell - size.x >= 0 && !layout[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }
        //checking the south side wall
        if (cell + size.x < layout.Count && !layout[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }
        //checking the east side wall
        if ((cell + 1) % size.x != 0 && !layout[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }
        //checking the west side wall
        if (cell % size.x != 0 && !layout[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }

}
