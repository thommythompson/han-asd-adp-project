using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests;

public class TestMyGraph
{
    [Fact]
    void AddVerticesAndEdges()
    {
        IMyGraph<Pizza> myGraph = new MyGraph<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        myGraph.AddVertex(pizza1);
        myGraph.AddVertex(pizza2);
        myGraph.AddVertex(pizza3);
        
        myGraph.AddEdge(pizza1, pizza2, 5);
        myGraph.AddEdge(pizza2, pizza3, 10);
        myGraph.AddEdge(pizza3, pizza1, 15);
    }
    
    [Fact]
    void Neighbors()
    {
        IMyGraph<Pizza> myGraph = new MyGraph<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        myGraph.AddVertex(pizza1);
        myGraph.AddVertex(pizza2);
        myGraph.AddVertex(pizza3);
        
        myGraph.AddEdge(pizza1, pizza2, 5);
        myGraph.AddEdge(pizza2, pizza3, 10);
        myGraph.AddEdge(pizza3, pizza1, 15);

        Assert.Equal(new List<Pizza>{ pizza2 }, myGraph.Neighbors(pizza1));
        Assert.Equal(new List<Pizza>{ pizza3 }, myGraph.Neighbors(pizza2));
        Assert.Equal(new List<Pizza>{ pizza1 }, myGraph.Neighbors(pizza3));
    }
    
    [Fact]
    void Adjacent()
    {
        IMyGraph<Pizza> myGraph = new MyGraph<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        myGraph.AddVertex(pizza1);
        myGraph.AddVertex(pizza2);
        myGraph.AddVertex(pizza3);
        
        myGraph.AddEdge(pizza1, pizza2, 5);
        myGraph.AddEdge(pizza2, pizza3, 10);
        myGraph.AddEdge(pizza3, pizza1, 15);

        Assert.True(myGraph.AreAdjacent(pizza1, pizza2));
        Assert.True(myGraph.AreAdjacent(pizza2, pizza3));
        Assert.True(myGraph.AreAdjacent(pizza3, pizza1));
    }
    
    [Fact]
    void RemoveVertex()
    {
        IMyGraph<Pizza> myGraph = new MyGraph<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        myGraph.AddVertex(pizza1);
        myGraph.AddVertex(pizza2);
        myGraph.AddVertex(pizza3);
        
        myGraph.AddEdge(pizza1, pizza2, 5);
        myGraph.AddEdge(pizza2, pizza3, 10);
        myGraph.AddEdge(pizza3, pizza1, 15);

        myGraph.RemoveVertex(pizza1);
        myGraph.AddVertex(pizza1);
    }
    
    [Fact]
    void RemoveEdge()
    {
        IMyGraph<Pizza> myGraph = new MyGraph<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        myGraph.AddVertex(pizza1);
        myGraph.AddVertex(pizza2);
        myGraph.AddVertex(pizza3);
        
        myGraph.AddEdge(pizza1, pizza2, 5);
        myGraph.AddEdge(pizza2, pizza3, 10);
        myGraph.AddEdge(pizza3, pizza1, 15);

        myGraph.RemoveEdge(pizza1, pizza2);
        myGraph.AddEdge(pizza1, pizza2, 2);
    }
    
    [Fact]
    void AddExistingVertex()
    {
        IMyGraph<Pizza> myGraph = new MyGraph<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        myGraph.AddVertex(pizza1);
        myGraph.AddVertex(pizza2);
        myGraph.AddVertex(pizza3);
        
        myGraph.AddEdge(pizza1, pizza2, 5);
        myGraph.AddEdge(pizza2, pizza3, 10);
        myGraph.AddEdge(pizza3, pizza1, 15);

        Assert.Throws<Exception>(() => myGraph.AddVertex(pizza1));
    }
}