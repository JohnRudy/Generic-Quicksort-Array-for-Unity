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

//This is an example program on how to initialize the QSArray.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quicksort;

public class Program : MonoBehaviour
{
    //Our new qs array
    QSArray<ExampleItem> items;

    int itemAmount = 10;

    private void Start () {
        //Initializing the QSarray with the maxsize we want
        items = new QSArray<ExampleItem>(itemAmount);

        for (int i = 0 ; i < itemAmount ; i++ ) {
            int rng = Random.Range(0, 10);
            ExampleItem newItem = new ExampleItem();
            newItem.SortedValue = rng;
            items.Add(newItem);
            print(newItem.QSIndex + " Index " + newItem.SortedValue + " value");
        }

        items.Sort();
        print("Sorted!");


        for( int i = 0 ; i < items.Count ; i++ ) {
            ExampleItem itemToSee = items.ItemAtIndex(i);
            print(itemToSee.QSIndex + " Index " + itemToSee.SortedValue + " value");
        }
}
}
