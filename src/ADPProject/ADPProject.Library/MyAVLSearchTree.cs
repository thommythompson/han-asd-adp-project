namespace ADPProject.Library;

public class MyAVLSearchTree<T> : IMyAVLSearchTree<T> where T : IComparable<T>
{
    private AVLTreeNode<T> root;

    private int Height(AVLTreeNode<T> node)
    {
        return node == null ? 0 : node.height;
    }

    private int Max(int a, int b) => a > b ? a : b;

    private int GetBalance(AVLTreeNode<T> node)
    {
        return node == null ? 0 : Height(node.left) - Height(node.right);
    }

    private AVLTreeNode<T> RightRotate(AVLTreeNode<T> y)
    {
        AVLTreeNode<T> x = y.left;
        AVLTreeNode<T> rightSubtree = x.right;

        x.right = y;
        y.left = rightSubtree;

        UpdateHeights(y, x);

        return x;
    }

    private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> x)
    {
        AVLTreeNode<T> y = x.right;
        AVLTreeNode<T> leftSubtree = y.left;

        y.left = x;
        x.right = leftSubtree;

        UpdateHeights(x, y);

        return y;
    }

    private void UpdateHeights(AVLTreeNode<T> parent, AVLTreeNode<T> child)
    {
        int parentHeight = (parent != null) ? Max(Height(parent.left), Height(parent.right)) + 1 : 0;
        int childHeight = (child != null) ? Max(Height(child.left), Height(child.right)) + 1 : 0;

        if (parent != null)
            parent.height = parentHeight;

        if (child != null)
            child.height = childHeight;
    }

    public void Insert(T value)
    {
        root = InsertRecursive(root, value);
    }

    private AVLTreeNode<T> InsertRecursive(AVLTreeNode<T> node, T value)
    {
        if (node == null)
            return new AVLTreeNode<T>(value);

        int comparisonResult = value.CompareTo(node.value);

        if (comparisonResult < 0)
            node.left = InsertRecursive(node.left, value);
        else if (comparisonResult > 0)
            node.right = InsertRecursive(node.right, value);
        else
            return node;

        UpdateHeights(node, node.left);
        UpdateHeights(node, node.right);

        return Balance(node, value);
    }


    private AVLTreeNode<T> Balance(AVLTreeNode<T> node, T value)
    {
        int balance = GetBalance(node);

        if (balance > 1 && value.CompareTo(node.left.value) < 0)
            return RightRotate(node);

        if (balance < -1 && value.CompareTo(node.right.value) > 0)
            return LeftRotate(node);

        if (balance > 1 && value.CompareTo(node.left.value) > 0)
        {
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }

        if (balance < -1 && value.CompareTo(node.right.value) < 0)
        {
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }

        return node;
    }

    public void Remove(T value)
    {
        root = RemoveRecursive(root, value);
    }

    private AVLTreeNode<T> RemoveRecursive(AVLTreeNode<T> node, T value)
    {
        if (node == null)
            return null;

        int comparisonResult = value.CompareTo(node.value);

        if (comparisonResult < 0)
        {
            node.left = RemoveRecursive(node.left, value);
        }
        else if (comparisonResult > 0)
        {
            node.right = RemoveRecursive(node.right, value);
        }
        else
        {
            if (node.left == null)
                return node.right;

            if (node.right == null)
                return node.left;

            node.value = MinValueNode(node.right).value;
            node.right = RemoveRecursive(node.right, node.value);
        }

        UpdateHeights(node, node.left);
        UpdateHeights(node, node.right);

        return Balance(node, value);
    }

    private AVLTreeNode<T> MinValueNode(AVLTreeNode<T> node)
    {
        AVLTreeNode<T> current = node;

        while (current.left != null)
            current = current.left;

        return current;
    }

    public bool Find(T value)
    {
        return FindRecursive(root, value);
    }

    private bool FindRecursive(AVLTreeNode<T> node, T value)
    {
        if (node == null)
            return false;

        if (value.CompareTo(node.value) == 0)
            return true;

        if (value.CompareTo(node.value) < 0)
            return FindRecursive(node.left, value);
        else
            return FindRecursive(node.right, value);
    }

    public T FindMin()
    {
        if (root == null)
            throw new InvalidOperationException("The tree is empty.");

        AVLTreeNode<T> current = root;
        while (current.left != null)
        {
            current = current.left;
        }

        return current.value;
    }

    public T FindMax()
    {
        if (root == null)
            throw new InvalidOperationException("The tree is empty.");

        AVLTreeNode<T> current = root;
        while (current.right != null)
        {
            current = current.right;
        }

        return current.value;
    }

    public List<T> PreOrder()
    {
        List<T> result = new List<T>();
        PreOrderTraversal(root, result);
        return result;
    }

    private void PreOrderTraversal(AVLTreeNode<T> node, List<T> result)
    {
        if (node != null)
        {
            result.Add(node.value);
            PreOrderTraversal(node.left, result);
            PreOrderTraversal(node.right, result);
        }
    }

    public List<T> PostOrder()
    {
        List<T> result = new List<T>();
        PostOrderTraversal(root, result);
        return result;
    }

    private void PostOrderTraversal(AVLTreeNode<T> node, List<T> result)
    {
        if (node != null)
        {
            PostOrderTraversal(node.left, result);
            PostOrderTraversal(node.right, result);
            result.Add(node.value);
        }
    }

    public List<T> InOrder()
    {
        List<T> result = new List<T>();
        InOrderTraversal(root, result);
        return result;
    }

    private void InOrderTraversal(AVLTreeNode<T> node, List<T> result)
    {
        if (node != null)
        {
            InOrderTraversal(node.left, result);
            result.Add(node.value);
            InOrderTraversal(node.right, result);
        }
    }

    public void ConvertFromArray(T[] array)
    {
        foreach (var value in array)
        {
            Insert(value);
        }
    }
}

public class AVLTreeNode<T> where T : IComparable<T>
{
    public T value;
    public int height;
    public AVLTreeNode<T> left;
    public AVLTreeNode<T> right;

    public AVLTreeNode(T val)
    {
        value = val;
        height = 1;
    }
}