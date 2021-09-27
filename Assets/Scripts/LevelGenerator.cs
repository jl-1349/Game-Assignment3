using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum rotate_type
{
    leftup,

    rightup,

    leftdown,

    rightdown,

}


public class LevelGenerator : MonoBehaviour
{

    private GameObject wallSide;

    public GameObject corner;
    
    public GameObject crossroad;
    
    public GameObject longline;
    
    public GameObject twocorners;
    
    public GameObject twoline;
    
    public GameObject normalpel;
    
    public GameObject powerpel;
    
    public List<GameObject> listwall;

     
    public float levelmap_width;
    
    public float levelmap_height;


    int[,] levelMap =
       {
            { 1,2,2,2,2,2,2,2,2,2,2,2,2,7},
            { 2,5,5,5,5,5,5,5,5,5,5,5,5,4},
            { 2,5,3,4,4,3,5,3,4,4,4,3,5,4},
            { 2,6,4,0,0,4,5,4,0,0,0,4,5,4},
            { 2,5,3,4,4,3,5,3,4,4,4,3,5,3},
            { 2,5,5,5,5,5,5,5,5,5,5,5,5,5},
            { 2,5,3,4,4,3,5,3,3,5,3,4,4,4},
            { 2,5,3,4,4,3,5,4,4,5,3,4,4,3},
            { 2,5,5,5,5,5,5,4,4,5,5,5,5,4},
            { 1,2,2,2,2,1,5,4,3,4,4,3,0,4},
            { 0,0,0,0,0,2,5,4,3,4,4,3,0,3},
            { 0,0,0,0,0,2,5,4,4,0,0,0,0,0},
            { 0,0,0,0,0,2,5,4,4,0,3,4,4,0},
            { 2,2,2,2,2,1,5,3,3,0,4,0,0,0},
            { 0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };


    int[,] rotateMap =
      {
        { 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 3, 3, 3, 0, 0, 3, 3, 3, 3, 0, 0 },
        { 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0 },
        { 0, 0, 1, 1, 1, 2, 0, 1, 1, 1, 1, 2, 0, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 3, 3, 3, 0, 0, 3, 0, 0, 3, 3, 3 },
        { 0, 0, 1, 1, 1, 2, 0, 0, 2, 0, 1, 1, 1, 3 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 3, 0, 0, 1, 3, 3, 3, 0, 0 },
        { 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 1, 2, 0, 1 },
        { 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 3, 3, 0 },
        { 1, 1, 1, 1, 1, 2, 0, 1, 2, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0 },
        };


    private void Awake()
    {

        levelmap_width = levelMap.GetLength(0);

        levelmap_height = levelMap.GetLength(1);



        listwall = new List<GameObject>();

        listwall.Add(null);
        
        listwall.Add(twocorners);
        
        listwall.Add(twoline);
        
        listwall.Add(corner);
        
        listwall.Add(longline);
        
        listwall.Add(normalpel);
        
        listwall.Add(powerpel);
        
        listwall.Add(crossroad);


    }
    // Start is called before the first frame update
    void Start()
    {
        var Grid = GameObject.Find("wallGrid");
        Destroy(Grid);

        LevelGenerate(0, 0);
        LevelGenerate(-27, 0);
        LevelGenerate(0f, -27);
        LevelGenerate(-27f, -27);

    }

    // Update is called once per frame
    private void LevelGenerate(float column, float row)
    {

        for (int x = 0; x < levelmap_width; x++)
        {
            for (int y = 0; y < levelmap_height; y++)
            {

                
                if (levelMap[x, y] == 0)
                {

                }
               
                else
                {
                    
                    wallSide = (GameObject)Instantiate(listwall[levelMap[x, y]], transform);


                    if (column == 0 && row == 0)
                    {

                        wallSide.transform.position = new Vector3((column + y) * 1, (row + x) * -1);
                        rotate(wallSide, rotateMap[x, y], rotate_type.leftup);

                    }
                    else if (column == -27 && row == 0)
                    {

                        wallSide.transform.position = new Vector3((column + y) * -1, (row + x) * -1);
                        rotate(wallSide, rotateMap[x, y], rotate_type.rightup);

                    }
                    else if (column == 0 && row == -27)
                    {

                        wallSide.transform.position = new Vector3((column + y) * 1, (row + x) * 1);
                        rotate(wallSide, rotateMap[x, y], rotate_type.leftdown);

                    }
                    else if (column == -27 && row == -27)
                    {
                        wallSide.transform.position = new Vector3((column + y) * -1, (row + x) * 1);
                        rotate(wallSide, rotateMap[x, y], rotate_type.rightdown);

                    }



                }

            }
        }

    }


    private void rotate(GameObject wallSide, int index, rotate_type t)
    {

        switch (t)
        {
            case rotate_type.leftup:

                switch (index)
                {
                    
                    case 1:
                        wallSide.transform.Rotate(0f, 0f, 90f);
                        break;
                    case 2:
                        wallSide.transform.Rotate(0f, 0f, 180f);
                        break;
                    case 3:
                        wallSide.transform.Rotate(0f, 0f, 270f);
                        break;
                    case 0:
                        wallSide.transform.Rotate(0f, 0f, 0f);
                        break;

                }


                break;

            case rotate_type.rightup:

                switch (index)
                {
                    case 1:
                        wallSide.transform.Rotate(0f, 180f, 90f);
                        break;
                    case 2:
                        wallSide.transform.Rotate(0f, 180f, 180f);
                        break;
                    case 3:
                        wallSide.transform.Rotate(0f, 180f, 270f);
                        break;
                    case 0:
                        wallSide.transform.Rotate(0f, 180f, 0f);
                        break;

                }


                break;

            case rotate_type.leftdown:

                switch (index)
                {
                    case 1:
                        wallSide.transform.Rotate(180f, 0f, 90f);
                        break;
                    case 2:
                        wallSide.transform.Rotate(180f, 0f, 180f);
                        break;
                    case 3:
                        wallSide.transform.Rotate(180f, 0f, 270f);
                        break;
                    case 0:
                        wallSide.transform.Rotate(180f, 0f, 0f);
                        break;

                }

                break;

            case rotate_type.rightdown:

                switch (index)
                {
                    case 1:
                        wallSide.transform.Rotate(180f, 180f, 90f);
                        break;
                    case 2:
                        wallSide.transform.Rotate(180f, 180f, 180f);
                        break;
                    case 3:
                        wallSide.transform.Rotate(180f, 180f, 270f);
                        break;
                    case 0:
                        wallSide.transform.Rotate(180f, 180f, 0f);
                        break;

                }

                break;


        }

    }

}
