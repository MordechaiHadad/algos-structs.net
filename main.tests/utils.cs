using System.Collections.Generic;

namespace main.tests;

public class Utils
{
    static public BinaryTree<int> tree = new BinaryTree<int>
    {
        value = 20,
        right = new BinaryTree<int>()
        {
            value = 50,
            right = new BinaryTree<int>()
            {
                value = 100,
                right = null,
                left = null,
            },
            left = new BinaryTree<int>()
            {
                value = 30,
                right = new BinaryTree<int>()
                {
                    value = 45,
                    right = null,
                    left = null,
                },
                left = new BinaryTree<int>()
                {
                    value = 29,
                    right = null,
                    left = null,
                }
            },
        },
        left = new BinaryTree<int>()
        {
            value = 10,
            right = new BinaryTree<int>()
            {
                value = 15,
                right = null,
                left = null,
            },
            left = new BinaryTree<int>()
            {
                value = 5,
                right = new BinaryTree<int>()
                {
                    value = 7,
                    right = null,
                    left = null,
                },
                left = null,
            }
        }
    };

    static public List<List<int>> matrix = new List<List<int>>(){
        new List<int>(){0, 3, 1,  0, 0, 0, 0}, // 0
        new List<int>(){0, 0, 0,  0, 1, 0, 0},
        new List<int>(){0, 0, 7,  0, 0, 0, 0},
        new List<int>(){0, 0, 0,  0, 0, 0, 0},
        new List<int>(){0, 0, 18, 0, 0, 0, 1},
        new List<int>(){0, 1, 0,  5, 0, 2, 0},
        new List<int>(){0, 0, 0,  1, 0, 0, 1}
    };
}
