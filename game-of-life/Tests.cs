using NUnit.Framework;
using System;

namespace game_of_life
{
    public class Tests
    {
        Program app = new Program();

        //     [Test]
        //     void LiveCellWithFewerThan2LiveNeighboursDie() {
        //         Boolean result = app.GetLiveStatus(new int[] {0,0,0,0} ); 
        //         Assert.AreEqual(0, result, "Expected to be dead when all neighbours are dead");
        //    }

        [Test]
        public void Example_2()
        {
            int[,] mat = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 1, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0 },
               {0, 0, 0, 0, 0, 1, 0, 0 },
           };
            // true -> live ; false -> dead
            //    int result =  app.UnderPopulation(mat,3,3, 1,1);
            //    Assert.AreEqual(2, result);

            int[,] output = app.GetNewGen(mat, 4, 8);

            int[,] result = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0 },
               {0, 0, 0, 1, 1, 1, 0, 0 },
               {0, 0, 0, 0, 1, 0, 0, 0 },
            };

            Assert.AreEqual(result, output);
        }


        [Test]
        public void Example_1()
        {
            int[,] mat = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0 },
               {0, 1, 1, 1, 1, 1, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0 },
           };
            // true -> live ; false -> dead
            //    int result =  app.UnderPopulation(mat,3,3, 1,1);
            //    Assert.AreEqual(2, result);

            int[,] output = app.GetNewGen(mat, 5, 8);

            int[,] result = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 1, 0, 0 },
               {0, 0, 1, 0, 0, 1, 0, 0 },
               {0, 0, 1, 1, 1, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0 },
            };

            Assert.AreEqual(result, output);
        }

        // ..........
        // ...**.....
        // ....*.....
        // ..........
        // ..........
        // geekforgeeks.org
        [Test]
        public void TestCaseGeeksForGeeks()
        {
            int[,] mat = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
           };
            // true -> live ; false -> dead
            //    int result =  app.UnderPopulation(mat,3,3, 1,1);
            //    Assert.AreEqual(2, result);

            int[,] output = app.GetNewGen(mat);

            int[,] result = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            Assert.AreEqual(result, output);
        }



        //    [Test] 
        //    public void FiveLiveNeighbours() {
        //        int[][] mat = new int[][] {
        //            new int[]{ 0,1,0 },
        //            new int[]{ 1,1,0 },
        //            new int[]{ 1,1,1 },
        //        };
        //        // true -> live ; false -> dead
        //        int result =  app.GetLiveNeighbourCount(mat,3,3, 1,1);
        //        Assert.AreEqual(5, result);
        //    }

        //    [Test]
        public void BorderCell()
        {
            int[,] mat = new int[,] {
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 1, 1, 0, 0, 0 },
               {0, 1, 1, 1, 1, 1, 1, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0 },
               {0, 0, 0, 0, 0, 0, 0, 0 },
           };
            // true -> live ; false -> dead
            int result = app.GetLiveNeighbourCount(mat, 5, 8, 3, 2);
            Assert.AreEqual(3, result);

            result = app.GetLiveNeighbourCount(mat, 5, 8, 2, 0);
            Assert.AreEqual(1, result);
        }
    }
}