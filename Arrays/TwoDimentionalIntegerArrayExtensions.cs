using System;
using System.Collections.Generic;

namespace Algorithms.Arrays{
    public static class TwoDimentionalIntegerArrayExtensions{
        public static void PrintSpiral(this int[,] arr){
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            List<int> output = new List<int>();
            if(rows * cols  <= 0){return;}
            int beginRow = 0, endRow = rows - 1, beginCol = 0, endCol = cols - 1;
            while(beginRow <= endRow && beginCol <= endCol){
                for(int col = beginCol; col <= endCol; col++){output.Add(arr[beginRow, col]);}
                for(int row = beginRow + 1; row <= endRow; row++){output.Add(arr[row, endCol]);}
                if(beginRow < endRow && beginCol < endCol){
                    for(int col = endCol - 1; col > beginCol; col--){output.Add(arr[endRow, col]);}
                    for(int row = endRow; row > beginRow; row--){output.Add(arr[row, beginCol]);}
                }
                beginRow++;
                endRow--;
                beginCol++;
                endCol--;
            }
            output.ForEach(x=> Console.WriteLine(x));
        }

        public static void Rotate(this int[,] arr){
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for(int layer = 0; layer < rows/2; layer++){
                int first = layer;
                int last = rows - layer - 1;
                for(int i = first; i < last; i++){
                    int offset = i - layer;
                    int temp = arr[first, i];
                    arr[first, i] = arr[last - offset, first];
                    arr[last - offset, first] = arr[last, last - offset];
                    arr[last, last - offset] = arr[i, last];
                    arr[i, last] = temp;
                }
            }
        }

        public static int Search(this int[,] arr, int element){
            return -1;
        }

        public static int MeetingRoomsII(this int [,] arr){
            int roomsNeeded = 0;
            int length = arr.GetLength(0);
            if(length == 0){return roomsNeeded;}
            int[] startingTimes = new int[length];
            int[] endingTimes = new int[length];
            for(int i = 0; i < length; i++){
                startingTimes[i] = arr[i,0];
                endingTimes[i] = arr[i,1];
            }
            Array.Sort(startingTimes);
            Array.Sort(endingTimes);
            int startingPosition = 0, endingPosition = 0;
            while(startingPosition < length){
                if(startingTimes[startingPosition] >= endingTimes[endingPosition]){
                    endingPosition++;
                    roomsNeeded--;
                }
                startingPosition++;
                roomsNeeded++;
            }
            return roomsNeeded;
        }
    }
}