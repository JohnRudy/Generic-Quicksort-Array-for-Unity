///<summary>
///Copyright 2021 Jussi Mattila a.k.a John Rudy Permission is hereby granted, free of charge, to any person 
///obtaining a copy of this software and associated documentation files (the "Software"), to deal in the 
///Software without restriction, including without limitation the rights to use, copy, modify, merge, 
///publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
///Software is furnished to do so, subject to the following conditions: The above copyright notice and this 
///permission notice shall be included in all copies or substantial portions of the Software. 
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
/// BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
/// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE 
/// USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </summary>


using System;
using System.Linq;
//QSArray is a array of items that use the quicksort method to sort the items based on their values to always 
//have a lowest or highest value at index 0.
//To use QS array you just need to set the array in your class with QSArray<ExampleItem> items;
//Items must inherit the QSItem interface to work.
//Must use Quicksort namespace

namespace Quicksort {
    public class QSArray<T> where T : QSItem<T> {
        //Items array
        T [ ] items;
        //Needed for array setting and other functions
        int currentItemCount = 0;

        //Constructor for the array
        public QSArray ( int maxSize ) {
            items = new T [ maxSize ];
        }


        ///---------------------------------------------------------///
        /// Basic functionality for the array                       ///
        /// for adding, removing, getting the current count and     ///
        /// does the array contain item and returning an item       ///
        ///---------------------------------------------------------///


        public T RemoveFirst () {
            T item = items [ 0 ];
            Remove(item);
            return item;
        }

        public T RemoveLast () {
            T item = items [ currentItemCount - 1 ];
            Remove(item);
            return item;
        }

        public void Remove ( T item ) {
            //LinQ to the rescue for removing an item from an array!
            items = items.Where(e => e.CompareTo(item) != 0).ToArray();
            currentItemCount--;
        }

        public void Add ( T item ) {
            item.QSIndex = currentItemCount;
            items [ currentItemCount ] = item;
            currentItemCount++;
        }

        public int Count {
            get {
                return currentItemCount;
            }
        }

        public bool Contains ( T item ) {
            return Equals(items [ item.QSIndex ], item);
        }

        public void Swap ( T itemA, T itemB ) {
            int indexA = itemA.QSIndex;
            int indexB = itemB.QSIndex;

            T temp = items [ indexA ];

            items [ indexA ] = itemB;
            itemB.QSIndex = indexA;

            items [ indexB ] = temp;
            temp.QSIndex = indexB;
        }

        public void Sort () {
            QuickSort(0, currentItemCount - 1);
        }

        public T ItemAtIndex ( int index ) {
            return items [ index ];
        }


        ///---------------------------------------------------------------///
        /// Quicksort methods, these are called within the QSArray class  ///
        ///---------------------------------------------------------------///


        private void QuickSort ( int left, int right ) {
            //Left    Pivot       Right
            //v         v          v
            //[][][][][][][][][][][]
            if( left >= right ) { return; }

            T pivot = items [ ( left + right ) / 2 ];
            int index = Partition(left, right, pivot);

            //Recursively call the method again in two sections until all values are sorted
            //   Pivot
            //Left   Right 
            //v    v    v          
            //[][][][][][][][][][][]
            QuickSort(left, index - 1);
            QuickSort(index, right);
        }

        private int Partition ( int left, int right, T pivot ) {
            while( left <= right ) {

                // Left  Pivot  Right
                //   v++ -> v <- --v
                //[][][][][][][][][][][]

                while( items [ left ].SortedValue < pivot.SortedValue ) {
                    left++;
                }

                while( items [ right ].SortedValue > pivot.SortedValue ) {
                    right--;
                }

                if( left <= right ) {
                    Swap(items [ left ], items [ right ]);
                    left++;
                    right--;
                }
            }

            //Left is our new pivot once we hit the end. 
            return left;
        }
    }



    //Interface to access itemIndex. All items must inherit this interface and variables 
    public interface QSItem<T> : IComparable<T> {
        int QSIndex {
            get;
            set;
        }

        int SortedValue {
            get;
            set;
        }
    }

}