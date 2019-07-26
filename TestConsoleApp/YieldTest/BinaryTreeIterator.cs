using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.YieldTest
{
  public class Node<T>
  {
    public T Value;
    public Node<T> Left, Right;
    public Node<T> Parent;

    public Node(T value)
    {
      Value = value;
    }

    public Node(T value, Node<T> left, Node<T> right)
    {
      Value = value;
      Left = left;
      Right = right;

      left.Parent = right.Parent = this;
    }

    public IEnumerable<T> PreOrder
    {
      get
      {
        foreach (var node in PreOrderExecute(this))
          yield return node.Value;
      }
    }

    private IEnumerable<Node<T>> PreOrderExecute(Node<T> current)
    {
      yield return current;
      if (current.Left != null)
        foreach (var leftNode in PreOrderExecute(current.Left))
          yield return leftNode;
      if (current.Right != null)
        foreach (var rightNode in PreOrderExecute(current.Right))
          yield return rightNode;
    }
  }

  public static class BinaryTreeIterator
  {
    public static void Execute()
    {
      var node = new Node<char>('a',
        new Node<char>('b',
          new Node<char>('c'),
          new Node<char>('d')),
        new Node<char>('e'));

      Console.WriteLine(new string(node.PreOrder.ToArray()));
    }
  }
}
