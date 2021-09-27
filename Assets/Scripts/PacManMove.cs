using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PacManMove : MonoBehaviour
{
  
    public GameObject pacman;
    
    private PacTweener tweener;
    
    private Vector3 endposition;
   
    private int moveindex;



    public Dictionary<int, pacman_move> move_dic;

    // Start is called before the first frame update
    void Start()
    {

        move_dic = new Dictionary<int, pacman_move>();
        move_dic.Add(0, new pacman_move(new Vector3(1, -1, 0), 1, new Vector3(0, 0, -90)));
        move_dic.Add(1, new pacman_move(new Vector3(6, -1, 0), 2, new Vector3(0, 0, 0)));
        move_dic.Add(2, new pacman_move(new Vector3(6, -5, 0), 3, new Vector3(180, 0, -90)));
        move_dic.Add(3, new pacman_move(new Vector3(1, -5, 0), 0, new Vector3(0, 0, 0)));

        endposition = move_dic[0].TargetPosition;

        moveindex = 0;
       
        tweener = GetComponent<PacTweener>();
      
        pacman.GetComponent<Animator>();
         
        tweener.AddTween(pacman.transform, endposition, endposition, 2f);

    }

    // Update is called once per frame
    void Update()
    {
         
        if (pacman.transform.position == endposition)
        {
            endposition = move_dic[moveindex].TargetPosition;
            pacman.transform.localRotation = Quaternion.Euler(0, 0, move_dic[moveindex].Rotation.z);
            moveindex = move_dic[moveindex].Moveindex;
            tweener.AddTween(pacman.transform, pacman.transform.position, endposition, 2f);

        }
    }

}


public class pacman_move
{
    private Vector3 targetposition;
    private int moveindex;
    private Vector3 rotation;

    public pacman_move(Vector3 targetposition, int moveindex, Vector3 rotation)
    {
        TargetPosition = targetposition;
        Moveindex = moveindex;
        Rotation = rotation;
    }

    public Vector3 TargetPosition { get => targetposition; set => targetposition = value; }
    public int Moveindex { get => moveindex; set => moveindex = value; }
    public Vector3 Rotation { get => rotation; set => rotation = value; }
}

