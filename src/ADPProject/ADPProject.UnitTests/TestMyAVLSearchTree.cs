namespace ADPProject.Tests;

public class TestMyAVLSearchTree
{
    [Fact]
    public void Insert()
    {
        var avl = new MyAVLSearchTree<int>();
        
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);
        avl.Insert(4);
        avl.Insert(5);
        avl.Insert(6);
        avl.Insert(7);
        avl.Insert(8);
        avl.Insert(9);
        avl.Insert(10);
        
        Assert.Equal(10, avl.PreOrder().Count);
    }
    
    [Fact]
    public void PreOrder()
    {
        var avl = new MyAVLSearchTree<int>();
        
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);
        avl.Insert(4);
        avl.Insert(5);
        avl.Insert(6);
        avl.Insert(7);
        avl.Insert(8);
        avl.Insert(9);
        avl.Insert(10);

        var preorder = avl.PreOrder();
        var expected = new List<int> { 4,2,1,3,8,6,5,7,9,10};
        Assert.Equal(expected, preorder);
    }
    
    [Fact]
    public void PostOrder()
    {
        var avl = new MyAVLSearchTree<int>();
        
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);
        avl.Insert(4);
        avl.Insert(5);
        avl.Insert(6);
        avl.Insert(7);
        avl.Insert(8);
        avl.Insert(9);
        avl.Insert(10);

        var preorder = avl.PostOrder();
        var expected = new List<int> { 1,3,2,5,7,6,10,9,8,4 };
        Assert.Equal(expected, preorder);
    }
    
    [Fact]
    public void InOrder()
    {
        var avl = new MyAVLSearchTree<int>();
        
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);
        avl.Insert(4);
        avl.Insert(5);
        avl.Insert(6);
        avl.Insert(7);
        avl.Insert(8);
        avl.Insert(9);
        avl.Insert(10);

        var preorder = avl.InOrder();
        var expected = new List<int> { 1,2,3,4,5,6,7,8,9,10 };
        Assert.Equal(expected, preorder);
    }
    
    [Fact]
    public void FindMin()
    {
        var avl = new MyAVLSearchTree<int>();
        
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);
        avl.Insert(4);
        avl.Insert(5);
        avl.Insert(6);
        avl.Insert(7);
        avl.Insert(8);
        avl.Insert(9);
        avl.Insert(10);
        
        Assert.Equal(1, avl.FindMin());
    }
    
    [Fact]
    public void FindMax()
    {
        var avl = new MyAVLSearchTree<int>();
        
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);
        avl.Insert(4);
        avl.Insert(5);
        avl.Insert(6);
        avl.Insert(7);
        avl.Insert(8);
        avl.Insert(9);
        avl.Insert(10);

        Assert.Equal(10, avl.FindMax());
    }
}