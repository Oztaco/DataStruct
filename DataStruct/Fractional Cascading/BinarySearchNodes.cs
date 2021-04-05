using System;

namespace Fractional_Cascading {
    // C# program for using Binary Search to find location of a
    // fractional cascading node in a list by a given attribute
    public class BinarySearchNodes {
        private Utils u = new Utils();
        public int binarySearch(Node[] nodeArray, int searchValue, int attrCode) {
            /** Parameters:
                    nodeArray:      array of nodes ordered by the attribute associated
                                    with attrCode
                                                                    
                    searchValue:    the thing value for which we are searching

                    attrCode:       node[i].getAttr(attrCode) returns the attrubute by
                                    which nodeArray is ordered
            */
            if(nodeArray.Length == 0) 
                throw new Exception("Attempting binarySearch on empty array");
            return binarySearch(nodeArray, 0, nodeArray.Length-1, searchValue, attrCode);
        }

        private int binarySearch(Node[] nodeArray, int l, int r, int x, int attrCode) {
            if(r < 1 || l > r) {
                // Check if value is at 0th index
                if(nodeArray[r].getAttr(attrCode) == x) return r;
                String xNotInArrException =
                    "value: " + x + " cannot be found in node array during binary " + 
                    "search\n\tl-index: " + l +  "\tr-index: " + r + "\tx: " + x + "\n";      
                throw new Exception(xNotInArrException); // Base case
            }
            
            int m = l + (r - l) / 2;
            int valueAtMid = nodeArray[m].getAttr(attrCode);

            // Value located at midpoint of nodeArray
            if(x == valueAtMid) return m;

            // Value is less than element at mid, search left side
            else if(x < valueAtMid) return binarySearch(nodeArray, l, m-1, x, attrCode);

            // Value is greater than element at mid, search right side
            else return binarySearch(nodeArray, m+1, r, x, attrCode);
        }
    }
}
