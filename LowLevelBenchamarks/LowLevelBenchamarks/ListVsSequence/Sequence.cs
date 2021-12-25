using System;

namespace LowLevelBenchamarks.ListVsSequence
{
    //public class Sequence<T>
    //{
    //    private const int DefaultCapacity = 4;
    //    private const int DefaultBuckets = 4;

    //    private int count;
    //    private T[][] buckets = Array.Empty<T[]>();
    //    private int bucketCount;
    //    private T[] tailArray = Array.Empty<T>();
    //    private int tailCount;

    //    public int Count => count;

    //    public void Add(T item)
    //    {
    //        if (tailCount < tailArray.Length)
    //        {
    //            tailArray[tailCount++] = item;
    //            count++;
    //            return;
    //        }
    //        if(bucketCount < buckets.Length)
    //        {
    //            if (tailCount > 0)
    //            {
    //                tailArray = new T[tailArray.Length * 2];
    //                tailArray[0] = item;
    //                tailCount = 1;
    //                buckets[bucketCount++] = tailArray;
    //                return;

    //            }
    //            tailArray = new T[DefaultCapacity];
    //            tailArray[0] = item;
    //            tailCount = 1;
    //            buckets[bucketCount++] = tailArray;
    //            return;
    //        }
    //        // grow bucket...
    //        if (bucketCount>0)
    //        {
    //            Array.Resize(ref buckets, buckets.Length * 2);
    //        } else
    //        {
    //            buckets = new T[DefaultBuckets][];
    //        }
    //        if (tailCount > 0)
    //        {
    //            tailArray = new T[tailArray.Length * 2];
    //            tailArray[0] = item;
    //            tailCount = 1;
    //            count++;
    //            buckets[bucketCount++] = tailArray;
    //            return;
    //        }
    //        tailArray = new T[DefaultCapacity];
    //        buckets[bucketCount++] = tailArray;
    //        tailArray[0] = item;
    //        tailCount = 1;
    //        count++;
    //    }


    // }
}
