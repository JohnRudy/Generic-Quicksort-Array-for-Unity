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


/// <summary>
/// This is the class for the items that the QSArray handles
/// You can switch the name from Item to your liking.
/// the class must contain all interface relevant values and CompareTo from IComparable
/// </summary>

using Quicksort;

public class ExampleItem : QSItem<ExampleItem> {
    //All Interfaces require that the same variables are present that are declared in the interface itself
    //See QSArray interface
    int qsItemIndex;
    public int QSIndex {
        get { return qsItemIndex; }
        set {
            if( !qsItemIndex.Equals(value) ) {
                qsItemIndex = value;
            }
        }
    }

    //Value to compare to in the item
    //this can be any value
    int exampleValue;
    public int SortedValue {
        get {
            return exampleValue;
        }
        set {
            if( !exampleValue.Equals(value) ) {
                exampleValue = value;
            }
        }
    }

    //We use this to compare two items together. 
    //Compare value 1 higher priority and -1 lower priority, 0 is the same
    //Adding more expections here can have more outcomes
    public int CompareTo ( ExampleItem itemToCompare ) {
        int compare = exampleValue.CompareTo(itemToCompare.exampleValue);
        return compare;
    }
}