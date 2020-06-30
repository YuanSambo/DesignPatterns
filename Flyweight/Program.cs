using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class TreeType
    {
        public int height;
        public int width;
        
        public TreeType(int height , int width)
        {
            this.height = height;
            this.width = width;
        }

        public override string ToString()
        {
           return $"Height : {height},Width :{width}";
        }
    }

    public class Tree
    {
        private Tuple<int,int> Position;
        public TreeType TreeType;
        public Tree(Tuple<int,int> position , TreeType treeType)
        {
            Position = position;
            TreeType = treeType;
        }

        public override string ToString()
        {
            return $"Tree planted : {Position},{TreeType}";
        }
    }

    public class FlyWeightFactory
    {
        List<TreeType> _treeTypes = new List<TreeType>();

        public TreeType GetTreeType(int height,int width)
        {
            var treeType = _treeTypes.Find(type => type.height == height && type.width == width);
            if (treeType != null)
            {
                return treeType;
            }
            
            var newTreeType = new TreeType(height,width);
            _treeTypes.Add(newTreeType);
            return newTreeType;
        }
    }

    public class Forest
    {
        FlyWeightFactory _factory = new FlyWeightFactory();

        public void PlantTree(Tuple<int,int> position,int height, int width)
        {
            var treeType = _factory.GetTreeType(height, width);
            var tree = new Tree(position,treeType);
            Console.WriteLine(tree);
        }
    }
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest();
            forest.PlantTree(new Tuple<int,int>(2,3),10,10);
        }
    }
}