using System;

namespace Floyd_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 3, 1, 2, 1 };

            var slowRunner = array[0];
            var fastRunner = array[0];

            //assume a sorted array for better understanding
            //assume each number represent a node with a values that redirekt to n+1
            //if there is a duplicate (wich dont redirekt to n+1) the represented node pattern begins with a line and end with a cycle

            //example:
            //            3 <- 5 
            //            ↓    ↑ 
            //  1 -> 2 -> 3 -> 4

            // first finding cycle, get opposite node of cycle beginning
            // 2 pointer represents two runner running the nodes down, one is faster than the other
            // if there is a cycle, the runners will meet at some time
            // if not cycle the runners will never meet
            
            while (true)
            {
                slowRunner = array[slowRunner];
                fastRunner = array[array[fastRunner]];
                if (slowRunner == fastRunner)
                    break;
            }

            // finding duplicate node aka connecting node from line of nodes to cycle
            // the runners always meets opposite of connected node, cause he is twice as fast
            // to find connected node (duplicate) we let circleRunner start at slowRunner position
            // than newRunner start at beginning of line
            // throu magic we know that the left nodes from position of slowRunner to connected node,
            // is the rest of line nodes divide by circle nodes
            // so if both run on same speed they will meet at connecting node

            int newRunner = array[0];
            int circleRunner = slowRunner;
            while (newRunner != circleRunner)
            {
                newRunner = array[newRunner];
                circleRunner = array[circleRunner];
            }
            Console.WriteLine(newRunner);
        }
    }
}
