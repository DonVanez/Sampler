using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading;

//===========================================================
//                       ver 0.0
//===========================================================
//                      Attention!
// The following code is a vivid representative of bidlocode!
//
// All classes used for completing the first working version
// are consolidated in this file. It is swful!
//
// Speaking about the description of this code it can be said
// that it's main goal is to carry out the sampling algorithm
// designed for generating representative sample from aquired
// base. Data income type is a .csv file with numbers and
// strings (symbols could possibly be cyrillic). Header row
// included.
//
//                                         to be continued...
//
//                 Proceed on your own risk!
//============================================================

namespace SampleGenerator2017
{
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // This block defines a class with global variables
    // This solution is thought to be temporary ;)
    //=====================================================================
    //=====================================================================
    //=====================================================================
    internal static class GlobalVariables
    {
        public const int DefaultNumberOfBuckets = 3;
        public const int LowerBoundaryForNumberOfBuckets = 2;
        public const int UpperBoundaryForNumberOfBuckets = 12;
        public const int DefaultSampleSize = 20;

        public const string LogPath = @"log\log.log";
        public const string SampleFolderPath = @"output_samples\";
        public const string ResultFolderPath = @"output_results\";
    }
    
    //public delegate void VoidAssertionDelegate(string message); // The idea was to define an assertion via delegate. Didn't take off
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // This block defines main class Sampler.
    // Entry point of the programm is here
    //=====================================================================
    //=====================================================================
    //=====================================================================
    public class Sampler
    {
        public static void Main(string[] args)
        {
            BasicUtilities.LogStart(); // !!! Check for existence of log and output folders should be performed
            Console.WriteLine(DateTime.Now);
            
            /*Console.WriteLine("OK!");
            //Console.WriteLine(newEl.ToString());
            //AbstractBucketing<string> testBucket = new BasicStringBucketing(); 
            var testBucket = new BasicStringBucketing("test");
            testBucket.AddElement("string 1");
            testBucket.AddElement("string 2");
            testBucket.AddElement("string 1");
            testBucket.AddElement("string 1");
            testBucket.AddElement("string 5");
            testBucket.AddElement("string 3");
            testBucket.AddElement("string 0");
            testBucket.AddElement("string 0");
            testBucket.AddElement("string 3");
            testBucket.AddElement("string 2");
            testBucket.AbortCurrentBucketing();
            testBucket.PrintAll();
            testBucket.PrintCount();
            Console.WriteLine(testBucket.PushElement("string 0"));
            testBucket.PrintAll();
            Console.WriteLine(testBucket.PushElement("string 0"));
            testBucket.PrintAll();
            Console.WriteLine(testBucket.PushElement("string 0"));
            testBucket.PrintAll();
            testBucket.InitDataSetRandomly(1000, 12);
            testBucket.PrintAll();
            Console.WriteLine(testBucket.SimpleBucketing(5));
            testBucket.PrintAll();
            var testIntList = new List<int>();
            Console.WriteLine(testBucket.GetListOfBucketSizes(testIntList));
            foreach (var el in testIntList)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine(testBucket.DefaultBucketing());
            testBucket.PrintAll();
            testBucket.ClearDataSet();
            testBucket.PrintAll();
            Console.WriteLine("{0}", GlobalVariables.DefaultNumberOfBuckets);
            Console.WriteLine(""); // */
            
            //var testSet = new TestDataSetCl1();
            //testSet.DefineRandomly(100);
            //testSet.PrintAll();
            
            /*var testEl1 = new DataSetClassT1();
            testEl1.TestStringsLoad();
            testEl1.PrintHead();
            
            var testBucket2 = new BasicStringBucketing();
            testBucket2.InitBucketingFromSample("s1", testEl1);
            Console.WriteLine(testBucket2.DefaultBucketing());
            testBucket2.PrintHead();
            Console.WriteLine("");
            Console.WriteLine(StatTests.ChiSquaredTest(testEl1, testEl1, testBucket2));
            Console.WriteLine(StatTests.PSITest(testEl1, testEl1, testBucket2));
            Console.WriteLine("");
            
            var testEl2 = new DataSetClassT1(testEl1);
            Console.WriteLine("");
            testEl2.PrintHead();
            testEl2 = testEl1.SimpleSampleGenerator(250);
            testEl2.PrintHead();
            Console.WriteLine(StatTests.ChiSquaredTest(testEl2, testEl1, testBucket2));
            Console.WriteLine(StatTests.PSITest(testEl2, testEl1, testBucket2));
            
            using (var output = new StreamWriter(@"output.csv"))
            {
                output.WriteLine("Chi_squared_test;PSI_test");
            }

            for (var i = 0; i < 3000; i++)
            {
                //Console.WriteLine("");
                //testEl2.PrintHead();
                testEl2 = testEl1.SimpleSampleGenerator(250);
                //testEl2.PrintHead();
                //Console.WriteLine(StatTests.ChiSquaredTest(testEl2, testEl1, testBucket2));
                //Console.WriteLine(StatTests.PSITest(testEl2, testEl1, testBucket2));

                using (var output = new StreamWriter(@"output.csv", true))
                {
                    output.WriteLine("{0};{1}", StatTests.ChiSquaredTest(testEl2, testEl1, testBucket2), StatTests.PSITest(testEl2, testEl1, testBucket2));
                }
            }
            // */

            /*using (var log = new StreamWriter(@"log\log.txt", true))
            {
                log.WriteLine("{0} - first test of log", DateTime.Now);
            }
            
            using (var log = new StreamWriter(@"log\log.txt", true))
            {
                log.WriteLine("{0} - second test of log", DateTime.Now);
            } // */

            var testLoad = new DataSetClassT1();
            var typeList = new List<Type>
            {
                typeof(int), typeof(string), typeof(string), typeof(int),
                typeof(double), typeof(DateTime), typeof(int)
            };

            testLoad = FileReader.ReadFileIntoDataSet("Generated_portfolio_with_flag_t_1200.csv", typeList, ';');
            testLoad.PrintHead();
            TestingUtilities.NotSoDumbTest_4("test_12_", 1, testLoad);
            //var testCopy = new DataSetClassT1(testLoad, "Copy");
            //testCopy.PrintHead();
                
            Console.WriteLine("Major Tom! I'm ready to terminate!");

            //BasicUtilities.UniversalLogger();
            //BasicUtilities.UniversalLogger("New message!");
            //BasicUtilities.UniversalLogger("Logger test!", GlobalVariables.LogPath); // */

            //var testStrati = new PairStratificationT1();
            /*testStrati.PrintHead();
            testStrati.AddNewField("string_factor_1", typeof(string));
            testStrati.AddNewField("dt_factor_1", typeof(DateTime));
            testStrati.PrintHead();
            //testStrati.GetStratumByKey(new FlexiblePair(testLoad.GetAtomByIndex("string_factor_1", 0), testLoad.GetAtomByIndex("dt_factor_1", 0)));
            testStrati.PrintHead();
            testStrati.FillFromDataSet(testLoad, "Safe");
            testStrati.PrintHead();
            testStrati.PrintAll();

            var testBucket3 = new BasicStringBucketing();
            testBucket3.InitBucketingFromSample("string_factor_1", testLoad);
            testBucket3.SimpleBucketing(5);
            testStrati.ConformWithBucketing(testBucket3);
            testStrati.PrintAll();

            var testBucket4 = new BasicDateTimeBucketing();
            testBucket4.InitBucketingFromSample("dt_factor_1", testLoad);
            testBucket4.SimpleBucketing(4);
            testStrati.ConformWithBucketing(testBucket4);
            testStrati.PrintAll();

            var sample = testLoad.SampleGenFromStratification(100, testStrati);
            sample.PrintAll(); // */




            Console.ReadKey();
            BasicUtilities.LogEnd();
        }
    }
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // The following code defines abstract AbstractBucketing class
    // Because of different data types of the income parameter I decided 
    // to inherite real service classes from this for int, double, string
    // and datetime datatypes. Everything else can be implemented later.
    //=====================================================================
    //=====================================================================
    //=====================================================================

    public interface IBucketing { // !!! Now this solution is a crooked nail. Should be rewritten or at least revised and fulfilled!
        int GetBucketNumberByElement(object element);
        string GetFieldName();
        Type GetFieldType();
        int GetCount();
        int GetNumberOfBuckets();
        //bool GetListOfBucketSizes(List<int> inputList);
        int GetWeightByElement(object inElement);
        bool InitBucketingFromSample(string fieldName, DataSetClassT1 sample);
        bool SimpleBucketing(int numberOfBuckets);
    }


    
    public abstract class AbstractBucketing<TParamType> : IBucketing
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of fields definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        protected IDictionary<TParamType, PairOfIntegers> DataSet;
        protected int Count;
        protected int NumberOfBuckets;
        protected List<int> BucketSizesList;
        protected bool Checked;
        protected string FieldName;
        protected Type FieldType;

        public IDictionary<TParamType, PairOfIntegers> GetDataSet
        {
            get { return DataSet; }
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of fields definition block
        // Start of accessors definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int GetCount()
        {
            return Count;
        }

        public int GetNumberOfBuckets()
        {
            return NumberOfBuckets;
        }

        public bool GetListOfBucketSizes(List<int> inputList)
        {
            if (inputList == null)
            {
                Console.WriteLine("InputList is a null reference!"); // !!! Should be replaced by log or assertion!
                return false;
            }
            
            inputList.Clear();
            inputList.AddRange(BucketSizesList.Select(el => el));
            return true;
        }

        public bool IsChecked()
        {
            return Checked;
        }

        public string GetFieldName()
        {
            return FieldName;
        }

        public Type GetFieldType()
        {
            return FieldType;
        }

        public NameTypePair GetFieldNameTypePair()
        {
            return new NameTypePair(FieldName, FieldType);
        }

        public int GetBucketNumberByElement(object element)
        {
            if (element is TParamType) {
                return DataSet[(TParamType)element].Bucket;
            }
            return -1;
        }
        
        public int GetWeightByElement(object inElement)
        {
            if (inElement is TParamType) {
                return DataSet[(TParamType)inElement].Weight;
            }
            return -1;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of fields definition block
        // Start of accessors definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public virtual void InitDataSetRandomly(int size, int numberOfClasses)
        {    
            if (numberOfClasses <= 0)
            {
                Console.WriteLine("NumberOfClasses parameter is nonpositive!");
                return;
            }
            
            Console.WriteLine("Not Implemented yet!"); // Should be changed for assertion or raise an exception
        }

        public virtual void AddElement(TParamType element) // !!!! does not change List of sizes. Needs revision
        {
            if (DataSet.Keys.Contains(element))
            {
                DataSet[element].IncrementWeight();
                //Console.WriteLine("Debug " + DataSet[element].weight.GetType()); // Debug feature
                Count++;
            }
            else
            {
                var internalPairVariable = new PairOfIntegers();
                DataSet.Add(element, internalPairVariable);
                Count++;
            }
        }

        public virtual bool PushElement(TParamType element) // !!!! does not change List of sizes. Needs revision
        {
            PairOfIntegers tmp;
            
            if (DataSet.TryGetValue(element, out tmp))
            {
                if (tmp.Weight == 1)
                {
                    DataSet.Remove(element);
                    Count -= 1;
                    return false;
                }
                
                DataSet[element].DecrementWeight();
                Count -= 1;
                return true;
            }
            
            return false;
        }

        public virtual void ClearDataSet()
        {
            DataSet.Clear();
            Count = 0;
            NumberOfBuckets = 0;
            BucketSizesList.Clear();
        }
        
        public virtual bool AbortCurrentBucketing()
        {
            try
            {
                foreach (var value in DataSet.Values)
                {
                    value.Bucket = 0;
                }
                NumberOfBuckets = 1;
                BucketSizesList.Clear();
                BucketSizesList.Add(Count);
            }
            catch // !!! needs implementation
            {
                Console.WriteLine("Exception caught while aborting bucketing!"); // !!! Should be replaced by log or assertion!
                return false;
            }
            return true;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data manipulation methods definition block
        // Start of data import methods definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public bool InitBucketingFromSample(string fieldName, DataSetClassT1 sample)
        {
            if (!sample.GetNamesTypeSet.Keys.Contains(fieldName)) return false; // Should contain log or assertion
            if (sample.GetNamesTypeSet[fieldName] != typeof(TParamType)) return false; // Should contain log or Assertion

            foreach (var el in sample.GetDataSet[fieldName])
            {
                if (el.GetType() == typeof(TParamType)) AddElement((TParamType)el);
                else
                {
                    Console.WriteLine("While initiating bucketing from sample type incompatibility occured! Particulary:");
                    Console.WriteLine("Target type - {0}", typeof(TParamType));
                    Console.WriteLine("Insert type - {0}", el.GetType()); // !!! Should be replaced with log or assertion
                    return false;
                }
            }

            FieldName = fieldName;
            //FieldType = typeof(TParamType); // By default it should be so
            Checked = false;
            //NumberOfBuckets = 0; // By default it should be so
            
            return true;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data import methods definition block
        // Start of data output methods definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void PrintAll()
        {
            PrintHead();
            
            Console.WriteLine("");
            Console.WriteLine("DataSet contains the following elements:");
            foreach (var i in DataSet.Keys)
            {
                try
                {
                    Console.Write("{0} : ", i);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                DataSet[i].PrintAll();
                Console.WriteLine();
            }
        }
        
        public void PrintHead()
        {
            Console.WriteLine("Bucketing under consideration has the following properties:");
            Console.WriteLine("FieldName = " + FieldName);
            Console.WriteLine("FieldType = " + typeof(TParamType));
            Console.WriteLine("Count = " + Count);
            Console.WriteLine("NumberOfBuckets = " + NumberOfBuckets);
            
            Console.Write("List of bucket sizes: ");
            foreach (var i in BucketSizesList)
            {
                try
                {
                    Console.Write("{0}, ", i);
                }
                catch
                {
                    Console.WriteLine("Exception occured while printing BucketSizesList"); // !!! Should be replaced by log or assertion!
                }
            }
        }

        public void PrintCount()
        {
            Console.WriteLine(DataSet.Count);
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data output methods definition block
        // Start of Gost 5812-82 block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /*public virtual bool SimpleBucketing(int numberOfBuckets)
        {
            if (numberOfBuckets <= 0)
            {
                Console.WriteLine("Parameter numberOfBuckets is nonpositive!"); // !!! Needs transformation to log or assertion
                return false;
            }
            
            Console.WriteLine("Not implemented!"); // !!! Needs transformation to log or assertion
            return false;
        } // */
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of Gost 5812-82 block
        // Start of algorithm defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public virtual bool SimpleBucketing(int numberOfBuckets)
        {
            //--------------------------------------------------------
            // Start of checking block
            //--------------------------------------------------------
            if (numberOfBuckets <= 0)
            {
                Console.WriteLine(
                    "Passed in number of buckets is nonpositive!"); // !!! Should be replaced by log or assertion!
                return false;
            }

            if (DataSet.Count < numberOfBuckets)
            {
                Console.WriteLine(
                    "Dictionary does not contain so many elements!"); // !!! Should be replaced by log or assertion!
                return false;
            }
            //--------------------------------------------------------
            // End of checking block
            // Start of initialization and preparation block
            //--------------------------------------------------------
            double weightOfCurrentBucket = 0;
            double cumulativeLeftWeight = Count; // May be i'll use you later, buddy =)
            var expectedWeightOfBucket = cumulativeLeftWeight / numberOfBuckets;
            var currentBucket = -1;
            var numberOfUnhandled = DataSet.Count;

            AbortCurrentBucketing();
            
            BucketSizesList.Clear();
            for (var i = 0; i < numberOfBuckets; i++)
            {
                BucketSizesList.Add(0);
            }
            //----------------------------------------------------------
            // End of initialization and preparation block
            // Start of logical block
            //----------------------------------------------------------
            foreach (var i in DataSet)
            {
                if (currentBucket == -1)
                {
                    currentBucket = 0;
                    weightOfCurrentBucket = i.Value.Weight;
                }
                else if (currentBucket == numberOfBuckets - 1)
                {
                    weightOfCurrentBucket += i.Value.Weight;
                }
                else if (numberOfUnhandled == numberOfBuckets - currentBucket)
                {
                    currentBucket++;
                    weightOfCurrentBucket = i.Value.Weight;
                }
                else if (Math.Abs(weightOfCurrentBucket - expectedWeightOfBucket + i.Value.Weight) <
                         Math.Abs(weightOfCurrentBucket - expectedWeightOfBucket))
                {
                    weightOfCurrentBucket += i.Value.Weight;
                }
                else
                {
                    currentBucket++;
                    weightOfCurrentBucket = i.Value.Weight;

                    if (numberOfBuckets == currentBucket)
                        Console.WriteLine("currentBucket is equal to numberOfBuckets!");
                    else expectedWeightOfBucket = cumulativeLeftWeight / (numberOfBuckets - currentBucket);

                }

                if (currentBucket >= BucketSizesList.Count)
                {
                    Console.WriteLine("Too many buckets created!"); // !!! should be replaced with log or assertion
                    return false;
                }
                
                i.Value.Bucket = currentBucket;
                BucketSizesList[currentBucket] += i.Value.Weight;
                cumulativeLeftWeight -= i.Value.Weight;
                numberOfUnhandled--;
            }

            NumberOfBuckets = numberOfBuckets;
            return true;
            //-------------------------------------------------------------------------
            // End of logical block
            //-------------------------------------------------------------------------
        }
        
        public virtual bool DefaultBucketing()
        {
            return SimpleBucketing(GlobalVariables.DefaultNumberOfBuckets);
        } // */

        public virtual bool ShrinkBucketDown(int numberOfBucket)
        {
            Console.WriteLine("Needs implementation!"); // !!!
            return false;
        }

        public virtual bool ShrinkBucketUp(int numberOfBucket)
        {
            Console.WriteLine("Needs implementation!"); // !!!
            return false;
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of bucketing algorithm defining block
        // Start of checking and debuging methods defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public virtual bool CheckBasicBucketLogic() // Yes, I am ashamed
        {
            var result = true; // this variable wil be returned by the method.
                               // If false - the Bucketing is trivial, incorrect
                               // or mistake was found and corrected
            
            if (DataSet.Count == 0) // !!! should be rewritten to return at this point!
            {
                result = false;
                Count = 0;
                Console.WriteLine("Dataset is empty!"); // !!! Should be replaced by log or assertion
            }

            if (string.IsNullOrEmpty(FieldName))
            {
                result = false;
                Console.WriteLine("FieldName is empty "); // !!! Should be replaced by log or assertion
            }

            if (FieldType != typeof(TParamType))
            {
                result = false;
                FieldType = typeof(TParamType);
                Console.WriteLine("FieldType used to be incorrect"); // !!! Should be replaced by log or assertion
            }
            
            var sizesOfBucketsListSize = BucketSizesList.Count;
            //var minValue = 0;
            var maxValue = sizesOfBucketsListSize - 1;
            var positiveShift = 0;
            var negativeShift = 0;
            var temp = 0;
            var sizesCheckList = new List<int>();
            sizesCheckList.AddRange(BucketSizesList.Select(el => 0));

            foreach (var pair in DataSet.Values)
            {
                if (pair.Bucket > maxValue + positiveShift)
                {
                    result = false;
                    positiveShift += pair.Bucket - positiveShift - maxValue;
                    Console.WriteLine("PositiveShift incremented!"); // !!! Should be replaced by log or assertion
                }
                else if (pair.Bucket < - negativeShift)
                {
                    result = false;
                    negativeShift -= pair.Bucket + negativeShift;
                    Console.WriteLine("NegativeShift incremented!"); // !!! Should be replaced by log or assertion
                }
            }
            
            sizesCheckList.InsertRange(0, Enumerable.Range(0, negativeShift).Select(el => 0));
            sizesCheckList.AddRange(Enumerable.Range(0, positiveShift).Select(el => 0));

            //temp = 0; // written previously
            foreach (var pair in DataSet.Values)
            {
                sizesCheckList[pair.Bucket + negativeShift] += pair.Weight;
                temp += pair.Weight;
                if (pair.Weight > 0) continue;
                result = false;
                Console.WriteLine("Nonpositive weight detected!"); // !!! Should be replaced by log or assertion
            }
            
            if (temp != Count)
            {
                result = false;
                Console.WriteLine("Sum of bucket weights is not equal to Count field!"); // !!! Should be replaced by log or assertion
            }

            foreach (var el in sizesCheckList)
            {
                if (el > 0) continue;
                
                sizesCheckList.Remove(sizesCheckList.IndexOf(el));
                result = false;
                Console.WriteLine("Bucket {0} has a nonpositive total weight!", sizesCheckList.IndexOf(el) - negativeShift); // !!! Should be replaced by log or assertion
            }

            if (NumberOfBuckets != sizesCheckList.Count)
            {
                result = false;
                Console.WriteLine("NumberOfBuckets field is filled incorrectly!"); // !!! Should be replaced by log or assertion
            }
            
            return result;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of checking and debuging methods defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
    
    

//=========================================================================
// The following block of code must be a shame of its author and an eyeache
// to any programmer reading through it. I promise to rewrite it and make
// it more elegant. Someday...
//=========================================================================
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining basic bucketing class for string input.
    //=====================================================================
    //=====================================================================
    //=====================================================================
    
    public class BasicStringBucketing : AbstractBucketing<string>
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors and destructor defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public BasicStringBucketing()
        {
            DataSet = new SortedDictionary<string, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = "Undefined";
            FieldType = typeof(string);
        }
        
        public BasicStringBucketing(string passedFieldName)
        {
            DataSet = new SortedDictionary<string, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = passedFieldName;
            FieldType = typeof(string);
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors and destructor defining block
        // Start of data manipulation methods block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public override void InitDataSetRandomly(int size, int numberOfClasses)
        {
            if (size <= 0 || numberOfClasses <= 0)
            {
                Console.WriteLine("Value of size and/or numberOfClasses is nonpositive!"); // Should be replaced by log or assertion!
                return;
            }
            
            var tempRand = new Random();
            
            ClearDataSet();

            for (var i = 0; i < size; i++)
            {
                AddElement(tempRand.Next(numberOfClasses).ToString());
            }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data manipulation methods defining block
        // Start of data check methods defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining basic bucketing class for integer input.
    //=====================================================================
    //=====================================================================
    //=====================================================================
    
    public class BasicIntBucketing : AbstractBucketing<int>
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors and destructor defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public BasicIntBucketing()
        {
            DataSet = new SortedDictionary<int, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = "Undefined";
            FieldType = typeof(int);
        }
        
        public BasicIntBucketing(string passedFieldName)
        {
            DataSet = new SortedDictionary<int, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = passedFieldName;
            FieldType = typeof(int);
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors and destructor defining block
        // Start of data manipulation methods block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public override void InitDataSetRandomly(int size, int numberOfClasses)
        {
            if (size <= 0 || numberOfClasses <= 0)
            {
                Console.WriteLine("Value of size and/or numberOfClasses is nonpositive!"); // Should be replaced by log or assertion!
                return;
            }
            
            var tempRand = new Random();
            
            ClearDataSet();

            for (var i = 0; i < size; i++)
            {
                AddElement(tempRand.Next(numberOfClasses));
            }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data manipulation methods defining block
        // Start of data check methods defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining basic bucketing class for double input.
    //=====================================================================
    //=====================================================================
    //=====================================================================
    
    public class BasicDoubleBucketing : AbstractBucketing<double>
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors and destructor defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public BasicDoubleBucketing()
        {
            DataSet = new SortedDictionary<double, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = "Undefined";
            FieldType = typeof(double);
        }
        
        public BasicDoubleBucketing(string passedFieldName)
        {
            DataSet = new SortedDictionary<double, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = passedFieldName;
            FieldType = typeof(double);
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors and destructor defining block
        // Start of data manipulation methods block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public override void InitDataSetRandomly(int size, int numberOfClasses)
        {
            if (size <= 0 || numberOfClasses <= 0)
            {
                Console.WriteLine("Value of size and/or numberOfClasses is nonpositive!"); // Should be replaced by log or assertion!
                return;
            }
            
            var tempRand = new Random();
            
            ClearDataSet();

            for (var i = 0; i < size; i++)
            {
                AddElement(tempRand.Next(numberOfClasses));
            }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data manipulation methods defining block
        // Start of data check methods defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining basic bucketing class for double input.
    //=====================================================================
    //=====================================================================
    //=====================================================================
    
    public class BasicDateTimeBucketing : AbstractBucketing<DateTime>
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors and destructor defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public BasicDateTimeBucketing()
        {
            DataSet = new SortedDictionary<DateTime, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = "Undefined";
            FieldType = typeof(DateTime);
        }
        
        public BasicDateTimeBucketing(string passedFieldName)
        {
            DataSet = new SortedDictionary<DateTime, PairOfIntegers>();
            Count = 0;
            NumberOfBuckets = 1;
            BucketSizesList = new List<int>(0);
            Checked = false;
            FieldName = passedFieldName;
            FieldType = typeof(DateTime);
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors and destructor defining block
        // Start of data manipulation methods block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public override void InitDataSetRandomly(int size, int numberOfClasses)
        {
            if (size <= 0 || numberOfClasses <= 0)
            {
                Console.WriteLine("Value of size and/or numberOfClasses is nonpositive!"); // Should be replaced by log or assertion!
                return;
            }
            
            var tempRand = new Random();
            
            ClearDataSet();

            for (var i = 0; i < size; i++)
            {
                AddElement(DateTime.Today.AddDays(tempRand.Next(numberOfClasses)));
            }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of data manipulation methods defining block
        // Start of data check methods defining block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining stratification
    //=====================================================================
    //=====================================================================
    //=====================================================================

    
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining a .csv parser
    //=====================================================================
    //=====================================================================
    //=====================================================================

    public class FileReader
    {
        public static DataSetClassT1 ReadFileIntoDataSet(string fileName, List<Type> typeList, char separator)
        {
            var result = new DataSetClassT1();
            
            using (var inputStream = new StreamReader(fileName))
            {
                var headerString = inputStream.ReadLine();
                if (string.IsNullOrEmpty(headerString))
                {
                    using (var log = new StreamWriter(GlobalVariables.LogPath, true))
                    {
                        log.WriteLine(DateTime.Now + " - StreamReader defined with path to file equal" +
                                      " to {0} is a null pointer or a file under consideration is empty!", fileName);
                    }

                    return result;
                }

                var header = headerString.Split(separator);

                if (header.Length != typeList.Count)
                {
                    using (var log = new StreamWriter(GlobalVariables.LogPath, true))
                    {
                        log.WriteLine(DateTime.Now + " - StreamReader defined with path to file equal to " +
                                      "{0} has a header incompatible with passed list of types:", fileName);
                        log.WriteLine("header size = {0}, type list size = {1}", header.Length, typeList.Count);
                        
                        log.Write("Header: ");
                        for (var i = 0; i < header.Length; i++)
                        {
                            log.Write("{0}" + (i == header.Length - 1 ? "" : ", "), header[i]);
                        }
                        
                        log.Write("TypeList: ");
                        for (var i = 0; i < typeList.Count; i++)
                        {
                            log.Write("{0}" + (i == typeList.Count - 1 ? "" : ", "), typeList[i]);
                        }
                    }

                    return result;
                }
                
                // !!! Should include header check

                for (var i = 0; i < header.Length; i++)
                {
                    result.AddNewField(header[i], typeList[i]);
                }

                if (inputStream.EndOfStream)
                {
                    using (var log = new StreamWriter(GlobalVariables.LogPath, true))
                    {
                        log.WriteLine(DateTime.Now + " - File located at {0} contains nothing but a header!", fileName);
                    }

                    return result;
                }
                
                while (!inputStream.EndOfStream)
                {
                    result.LoadData(inputStream.ReadLine(), separator);
                }
            }
            
            return result;
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // First test classes created to check functionality
    //=====================================================================
    //=====================================================================
    //=====================================================================
    
    public class DataSetClassT1
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of fields and properties definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        protected IDictionary<string, IList> DataSet;
        protected int Size;
        protected Dictionary<string, Type> NamesTypesDict;

        public IDictionary<string, IList> GetDataSet
        {
            get { return DataSet; }
        }
        
        public Dictionary<string, Type> GetNamesTypeSet
        {
            get { return NamesTypesDict; }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of fields and properties definition block
        // Start of constructors and destructor definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public DataSetClassT1()
        {
            DataSet = new Dictionary<string, IList>();
            Size = 0;
            NamesTypesDict = new Dictionary<string, Type>();
        }

        public DataSetClassT1(DataSetClassT1 inPattern, string inMode = "Default")
        {
            DataSet = new Dictionary<string, IList>();
            Size = 0;
            NamesTypesDict = new Dictionary<string, Type>();

            foreach (var el in inPattern.NamesTypesDict)
            {
                _AddNewField(el.Key, el.Value);
            }

            if (inMode.Contains("Copy")) {
                Size = inPattern.GetSize();

                foreach (var el in NamesTypesDict) {
                    for (var index = 0; index < Size; index++) {
                        AddElementOneField(el.Key, inPattern.GetAtomByIndex(el.Key, index));
                    }
                }
            }
        }

        public Type GetTypeByName(string inName) {
            return NamesTypesDict[inName];
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors and destructor definition block
        // Start of accessors definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public int GetSize()
        {
            return Size;
        }

        public object GetAtomByIndex(string fieldName, int index)
        {
            return DataSet[fieldName][index];
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of accessors definition block
        // Start of functions loading data definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void _AddNewField(string passedName, Type passedType)
        {
            if (NamesTypesDict.Keys.Contains(passedName))
            {
                Console.WriteLine("Duplicate field name!"); // !!! Should be replaced by log or assertion!
                return;
            }
            
            // Gost 5812-82 start
            if (passedType == typeof(int))
                DataSet.Add(passedName, new List<int>());
            else if (passedType == typeof(double))
                DataSet.Add(passedName, new List<double>());
            else if (passedType == typeof(string))
                DataSet.Add(passedName, new List<string>());
            else if (passedType == typeof(DateTime))
                DataSet.Add(passedName, new List<DateTime>());
            else if (passedType == typeof(long))
                DataSet.Add(passedName, new List<long>());
            else if (passedType == typeof(bool))
                DataSet.Add(passedName, new List<bool>());
            else if (passedType == typeof(char))
                DataSet.Add(passedName, new List<char>());
            else
            {
                Console.WriteLine("Unhadled type passed in passedType!"); // !!! Should be replaced by log or assertion!
                return;
            }
            // Gost 5812-82 end
            
            NamesTypesDict.Add(passedName, passedType);
        }
        // private version of AddNewField()
        
        public virtual bool AddNewField(string passedName, Type passedType)
        {
            if (NamesTypesDict.Keys.Contains(passedName))
            {
                Console.WriteLine("Duplicate field name!"); // !!! Should be replaced by log or assertion!
                return false;
            }
            
            // Gost 5812-82 start
            if (passedType == typeof(int))
                DataSet.Add(passedName, new List<int>());
            else if (passedType == typeof(double))
                DataSet.Add(passedName, new List<double>());
            else if (passedType == typeof(string))
                DataSet.Add(passedName, new List<string>());
            else if (passedType == typeof(DateTime))
                DataSet.Add(passedName, new List<DateTime>());
            else if (passedType == typeof(long))
                DataSet.Add(passedName, new List<long>());
            else if (passedType == typeof(bool))
                DataSet.Add(passedName, new List<bool>());
            else if (passedType == typeof(char))
                DataSet.Add(passedName, new List<char>());
            else
            {
                Console.WriteLine("Unhadled type passed in passedType!"); // !!! Should be replaced by log or assertion!
                return false;
            }
            // Gost 5812-82 end
            
            NamesTypesDict.Add(passedName, passedType);
                        
            return true;
        }

        protected virtual bool AddElementOneField<T>(string passedName, T element)
        {
            if (!DataSet.Keys.Contains(passedName)) return false;
            if (NamesTypesDict[passedName] != element.GetType()) return false;
            // */ // This is Gost 5812-82
            // Console.WriteLine("Undefined Name/Type pair! Passed in: passedName - {0}, element - {1} with type {2}", passedName, element, typeof(T)); // !!! Needs to be changed to log or assertion
            // !!! Need to add log or assertion in case of exception
            
            DataSet[passedName].Add(element);
            return true;
        }
        
        protected virtual bool AddNewEntity(Dictionary<string, object> inputDict)
        {
            foreach (var el in DataSet)
            {
                if (inputDict.Keys.Contains(el.Key))
                {
                    if (inputDict[el.Key].GetType() == NamesTypesDict[el.Key])
                    {
                        el.Value.Add(inputDict[el.Key]);
                    }
                }
                // Gost 5812-82 start !!!
                // The idea is to add some default element but i'm too busy now to write it properly. Sorry ;)
                // From the first glance i'd say, that i need to iterate through the set of built-in value types
                // and add a default for each of them. For any reference type i'd append the null pointer.
                try
                {
                    if (NamesTypesDict[el.Key] == typeof(int))
                        el.Value.Add(-1234);
                    else if (NamesTypesDict[el.Key] == typeof(double))
                        el.Value.Add(-1234);
                    else if (NamesTypesDict[el.Key] == typeof(string))
                        el.Value.Add("");
                    else if (NamesTypesDict[el.Key] == typeof(DateTime))
                        el.Value.Add(DateTime.Now.AddYears(999));
                    else if (NamesTypesDict[el.Key] == typeof(bool))
                        el.Value.Add(false);
                    else if (NamesTypesDict[el.Key] == typeof(long))
                        el.Value.Add(-1234);
                    else if (NamesTypesDict[el.Key] == typeof(char))
                        el.Value.Add(' ');
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }
                // Gost 5812-82 end
            }
            Size += 1;
            return true;
        }



        public virtual void RemoveEntityByIndex(int inIndex) {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.RemoveEntityByIndex() method failed because " +
            //    "it's not implemented yet.", GlobalVariables.LogPath);
            //return;

            if (inIndex >= Size) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.RemoveEntityByIndex() method failed because " +
                    "inIndex exceeds DataSet size.", GlobalVariables.LogPath);
                return;
            }

            foreach (var i in DataSet) {
                i.Value.RemoveAt(inIndex);
            }
        }

        public virtual void AppendSet(DataSetClassT1 inputSet)
        {
            if (!IsCompatibleWith(inputSet)) return; // !!! Should contain log or assertion
            
            foreach (var el in NamesTypesDict)
            {
                foreach (var entity in inputSet.DataSet[el.Key]) DataSet[el.Key].Add(entity);
            }

            Size += inputSet.Size;
        }
        
        public virtual bool LoadData(string data, char separator)
        {
            var result = true;
            var input = data.Split(separator);
            var keySet = DataSet.Keys.ToArray();

            if (input.Length != keySet.Length)
            {
                using (var log = new StreamWriter(GlobalVariables.LogPath, true))
                {
                    log.WriteLine(DateTime.Now + " - LoadData method of DataSetClassT1 class failed" +
                                  " because of input.Length != DataSet.Keys.Count");
                }

                return false;
            }

            for (var i = 0; i < input.Length; i++)
            {
                try
                {
                    DataSet[keySet[i]].Add(Convert.ChangeType(input[i], NamesTypesDict[keySet[i]]));
                }
                catch (Exception e)
                {
                    using (var log = new StreamWriter(GlobalVariables.LogPath, true))
                    {
                        log.WriteLine(DateTime.Now +  " - LoadData method of DataSetClassT1 class failed" +
                                      " because of incorrect type conversion or appending data to list. " +
                                      "Invalid value: {0}, field: {1}, target type: {2}. Exception messa" +
                                      "ge: {3}", input[i], keySet[i], NamesTypesDict[keySet[i]], e.Message);
                    }
                    
                    DataSet[keySet[i]].Add(BasicUtilities.DefaultValue(NamesTypesDict[keySet[i]]));
                    result = false;
                }
            }

            Size += 1;
            
            return result;
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of functions loading data definition block
        // Start of functions extracting data definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public virtual DataSetClassT1 ExtractElementByIndex(int index)
        {
            if (index > Size - 1)
            {
                Console.WriteLine("Requested element number exceeds the size of DataSet!"); // !!! Should be replaced with log
                return null;
            }
            
            var result = new DataSetClassT1(this);
            foreach (var el in NamesTypesDict)
            {
                result.AddElementOneField(el.Key, DataSet[el.Key][index]);
            }
            result.Size = 1;
            
            return result;
        }
        
        public virtual DataSetClassT1 ExtractSetByIndices(List<int> indices)
        {
            if (indices.Max() > Size - 1 || indices.Min() < 0)
            {
                Console.WriteLine("At least one index in the set passed into function is incompatible with current DataSet!");
                    // !!! Should be replaced with log or assertion
                return null;
            }
            
            var result = new DataSetClassT1(this);
            foreach (var el in NamesTypesDict)
            {
                foreach (var index in indices)
                {
                    result.AddElementOneField(el.Key, DataSet[el.Key][index]);
                }
            }

            result.Size = indices.Count;
            
            return result;
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of functions extracting data definition block
        // Start of the output utilities block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public virtual void PrintAll()
        {
            this.PrintHead();

            foreach (var element in DataSet)
            {
                Console.Write("Field name: {0}; Type of field: {1}\nContent: ", element.Key, NamesTypesDict[element.Key]);
                foreach (var i in element.Value)
                {
                    Console.Write((i is string ? i : i.ToString()) + ", ");
                }
                Console.WriteLine();
            }
        }

        public virtual void PrintHead()
        {
            foreach (var element in DataSet)
            {
                Console.WriteLine("Field name: {0}; Type of field: {1}", element.Key, NamesTypesDict[element.Key]);
                Console.WriteLine("Size of inserted data {0}", element.Value.Count);
            }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of the output utilities block
        // Start of sample generators block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public DataSetClassT1 SimpleSampleGenerator(int size) {
            if (size > Size) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.SimpleSampleGenerator() method failed because " +
                        "the size of requested sample is greater than size of population!", GlobalVariables.LogPath);
                return null;
            }
            
            //Console.WriteLine("Checkpoint 1. Passed size value is appropriate.");

            var result = new DataSetClassT1(this);
            var localGenRandom = new Random();
            var pickedIndices = new List<int>();
            
            var leftIndices = new List<int>();
            leftIndices.AddRange(Enumerable.Range(0, Size));
            
            //Console.WriteLine("Checkpoint 2. Local variables defined successfully.");

            if (size < Size / 2)
            {
                for (var i = 0; i < size; i++)
                {
                    var tmp = localGenRandom.Next(leftIndices.Count);
                    pickedIndices.Add(leftIndices[tmp]);
                    leftIndices.RemoveAt(tmp);
                }
                //Console.WriteLine("Checkpoint 3. Indices picked.");
                /*Console.WriteLine("Indices List:");
                foreach (var el in pickedIndices)
                {
                    Console.Write(el + ", ");
                }
                Console.ReadKey(); // */
                result.AppendSet(ExtractSetByIndices(pickedIndices));
                //Console.WriteLine("Checkpoint 4. Subsmple extracted successfully.");
            }
            else
            {
                for (var i = 0; i < Size - size; i++)
                {
                    var tmp = localGenRandom.Next(leftIndices.Count);
                    pickedIndices.Add(leftIndices[tmp]);
                    leftIndices.RemoveAt(tmp);
                }
                //Console.WriteLine("Checkpoint 3. Indices picked.");
                result.AppendSet(ExtractSetByIndices(leftIndices));
                //Console.WriteLine("Checkpoint 4. Subsmple extracted successfully.");
            }
            
            return result;
        }



        public DataSetClassT1 SampleGenFromStratification(int inputSize, IStratification inputStratification) {
            if (inputSize > Size) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.SampleGenFromStratification() method failed because " +
                        "the size of requested sample is greater than size of population!", GlobalVariables.LogPath);
                return null;
            }
            
            var result = new DataSetClassT1(this);
            var localGenRandom = new Random();
            var pickedIndices = new List<int>();
            
            var StrataSizeList = new List<int>();
            var StrataHashTable = new Dictionary<int, List<int>>();
            //Console.WriteLine("Checkpoint 2 reached!");
            foreach (var i in Enumerable.Range(0, Size)) {
                var key = inputStratification.GenKeyFromData(new IndexDataT1Pair(i, this));
                //Console.WriteLine("Checkpoint 2.1 reached!");
                var stratum = inputStratification.GetStratumByKey(key);
                //Console.WriteLine("Checkpoint 2.2 reached!");

                if (stratum >= StrataSizeList.Count) {
                    foreach (var j in Enumerable.Range(StrataSizeList.Count, stratum + 1)) {
                        StrataSizeList.Add(0);
                        StrataHashTable.Add(j, new List<int>());
                    }
                }
                //Console.WriteLine("Checkpoint 2.3 reached!");

                StrataSizeList[stratum] += 1;
                //Console.WriteLine("Checkpoint 2.4 reached!");
                StrataHashTable[stratum].Add(i);
                //Console.WriteLine("Checkpoint 2.5 reached!");
            }
            //Console.WriteLine("Checkpoint 3 reached!");

            int count = 0;
            int cumulativeProceededWeight = 0;
            foreach (var i in StrataHashTable) {
                cumulativeProceededWeight += i.Value.Count;
                var lim = Math.Round(inputSize*(double)cumulativeProceededWeight/Size);

                while (count < lim) {
                    var nextRandom = localGenRandom.Next(i.Value.Count);
                    pickedIndices.Add(i.Value[nextRandom]);
                    i.Value.RemoveAt(nextRandom);
                    count += 1;
                }
            }
            //Console.WriteLine("Checkpoint 4 reached!");

            result.AppendSet(ExtractSetByIndices(pickedIndices));
            
            //Console.WriteLine("Checkpoint 5 reached!");
            return result;
        }



        public DataSetClassT1 ModifySampleInRelationTo(DataSetClassT1 inPopulation, IBucketing[] inBucketsArray, IList inIndices = null) {
            Console.WriteLine("Entering ModifySampleInRelationTo(), defining service variables.");
            //var sampleIndices = inIndices == null ? new List<int>() : inIndices;
            var sampleIndices = new List<int>();
            var outRes = new DataSetClassT1(this, "Copy");

            Console.WriteLine("-> " + sampleIndices.Count);
            outRes.PrintAll();
            outRes = outRes.AugmentSampleInRelationTo(inPopulation, inBucketsArray, sampleIndices);
            Console.WriteLine("-> " + sampleIndices.Count);
            outRes.PrintAll();
            outRes = outRes.ShrinkSampleInRelationTo(inPopulation, inBucketsArray, sampleIndices);
            Console.WriteLine("-> " + sampleIndices.Count);

            Console.WriteLine("Quiting ModifySampleInRelationTo()");
            return outRes;

            /*BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.ModifySampleInRelationTo() method failed because " +
                "it is not implemented.", GlobalVariables.LogPath);
            return null; // */
        }



        public DataSetClassT1 AugmentSampleInRelationTo(DataSetClassT1 inPopulation, IBucketing[] inBucketsArray, IList inIndices = null) {
            //Console.WriteLine("Entering AugmentSampleInRelationTo(), defining service variables.");
            double bestPar = Double.MaxValue;
            var SampleCopy = new DataSetClassT1(this, "Copy"); // !!! This copy may be dropped but it makes me feel safer
            var outRes = new DataSetClassT1();
            var IndicesBlackList = new List<int>();

            //Console.WriteLine("Filling IndicesBlackList.");
            if (inIndices != null && inIndices.Count == SampleCopy.GetSize()) { // !!! may cause a problem if a null pointer
                foreach (var i in inIndices) IndicesBlackList.Add((int)i);
            }
            else IndicesBlackList = inPopulation.GenerateIndicesOfSample(SampleCopy);

            //Console.WriteLine("Augmenting sample.");
            IndicesBlackList.Add(-1); // Why? 0_o
            Console.WriteLine(IndicesBlackList.Count);
            foreach (var i in Enumerable.Range(0, inPopulation.GetSize())) {
                if (IndicesBlackList.Contains(i)) continue;

                double tmpPar = 0;
                var tmpSample = new DataSetClassT1(SampleCopy, "Copy"); // It can be replaced with DataSetClassT1(this, "Copy")
                //tmpSample.RemoveEntityByIndex(i);
                tmpSample.AppendSet(inPopulation.ExtractElementByIndex(i));

                foreach (var b in inBucketsArray) {
                    //Type tmpType = b.GetFieldType();
                    tmpPar += StatTests.ChiSquaredTest(tmpSample, inPopulation, b); // !!! Depends on the metric. Should be refactored
                }

                if (tmpPar < bestPar) {
                    outRes = tmpSample;
                    bestPar = tmpPar;
                    Console.WriteLine(IndicesBlackList.Count);
                    IndicesBlackList.RemoveAt(IndicesBlackList.Count - 1); // <- The answer on 'Why?' question here. We delete the last element
                    Console.WriteLine(IndicesBlackList.Count);
                    IndicesBlackList.Add(i);
                    Console.WriteLine(IndicesBlackList.Count);
                }
            }

            if (inIndices != null) {
                inIndices.Clear();
                foreach (var i in IndicesBlackList) inIndices.Add(i);
            }

            Console.WriteLine(IndicesBlackList.Count);
            Console.WriteLine(inIndices.Count);
            Console.ReadKey();

            //Console.WriteLine("Quitinging AugmentSampleInRelationTo().");
            return outRes;

            //BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.AugmentSampleInRelationTo() method failed because " +
            //    "it is not implemented.", GlobalVariables.LogPath);
            //return null;
        }



        public DataSetClassT1 ShrinkSampleInRelationTo(DataSetClassT1 inPopulation, IBucketing[] inBucketsArray, IList inIndices = null) {
            Console.WriteLine("Entering ShrinkSampleInRelationTo(), defining service variables.");
            this.PrintAll();
            Console.WriteLine(this.GetSize());
            Console.WriteLine("");
            double bestPar = Double.MaxValue;
            int indexForRemoval = -1;
            var IndicesBlackList = new List<int>();
            var SampleCopy = new DataSetClassT1(this, "Copy"); // !!! This copy may be dropped but it makes me feel safer
            Console.WriteLine("------------------------------------");
            SampleCopy.PrintAll();
            Console.WriteLine("------------------------------------");
            BasicUtilities.PrintList(inIndices);
            Console.WriteLine("------------------------------------");
            var outRes = new DataSetClassT1();
            //Console.WriteLine("Entering ShrinkSampleInRelationTo() checkpoint 1.");
            if (inIndices != null && inIndices.Count == SampleCopy.GetSize()) { // !!! may cause a problem if a null pointer
                foreach (var i in inIndices) {
                    IndicesBlackList.Add((int)i);
                    Console.WriteLine("Pushed element: {0} or {1}", i, (int)i);
                }
            }
            else IndicesBlackList = inPopulation.GenerateIndicesOfSample(SampleCopy);
            //BasicUtilities.PrintList(IndicesBlackList); // Currently empty list
            //BasicUtilities.PrintList(inIndices); // Currently null pointer
            Console.WriteLine("Entering ShrinkSampleInRelationTo() checkpoint 2.");
            Console.WriteLine("------------------------------------");
            SampleCopy.PrintAll();
            Console.WriteLine("------------------------------------");
            BasicUtilities.PrintList(IndicesBlackList);
            Console.WriteLine("------------------------------------");
            foreach (var i in Enumerable.Range(0, SampleCopy.GetSize())) {
                double tmpPar = 0;
                var tmpSample = new DataSetClassT1(SampleCopy, "Copy");
                tmpSample.RemoveEntityByIndex(i);

                foreach (var b in inBucketsArray) {
                    //Type tmpType = b.GetFieldType();
                    tmpPar += StatTests.ChiSquaredTest(tmpSample, inPopulation, b); // !!! Depends on the metric. Should be refactored
                }

                if (tmpPar < bestPar) {
                    outRes = tmpSample;
                    bestPar = tmpPar;
                    indexForRemoval = i;
                }
            }
            Console.WriteLine("Entering ShrinkSampleInRelationTo() checkpoint 3.");
            Console.WriteLine("IndicesBlackList.Count = {0}", IndicesBlackList.Count);
            Console.WriteLine("this.GetSize() = {0}", this.GetSize());
            Console.WriteLine("indexForRemoval = {0}", indexForRemoval);
            if (indexForRemoval >= 0 && indexForRemoval < SampleCopy.GetSize()) IndicesBlackList.RemoveAt(indexForRemoval);

            if (inIndices != null) {
                inIndices.Clear();
                foreach (var i in IndicesBlackList) inIndices.Add(i);
            }

            //Console.WriteLine("Quiting ShrinkSampleInRelationTo().");
            return outRes;

            //BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.ShrinkSampleInRelationTo() method failed because " +
            //    "it is not implemented.", GlobalVariables.LogPath);
            //return null; // !!! Not implemented!
        }



        public List<int> GenerateIndicesOfSample(DataSetClassT1 inSample) {
            var outRes = new List<int>();
            var IndicesWhiteList = new List<int>();
            IndicesWhiteList.AddRange(Enumerable.Range(0, inSample.GetSize())); // May be it would be better to call getter here instead of this.Size

            for (int i = 0; i < this.GetSize(); i++) {
                var WhiteListCopy = new List<int>();
                WhiteListCopy.AddRange(IndicesWhiteList);
                foreach (var j in WhiteListCopy) {
                    foreach (var name in NamesTypesDict.Keys) {
                        if (!this.GetAtomByIndex(name, i).Equals(inSample.GetAtomByIndex(name, j))) { // !!! == does not work here!
                            //Console.WriteLine("Goto executed on step {0}: name = {1}, atom of population = {2}, atom of sample = {3}",
                            //    i, name, this.GetAtomByIndex(name, i), inSample.GetAtomByIndex(name, j));
                            /*using (var log = new StreamWriter("help_log.txt", true))
                            {
                                log.WriteLine("Goto executed on step {0}: name = {1}, atom of population = {2}, atom of sample = {3}",
                                    i, name, this.GetAtomByIndex(name, i), inSample.GetAtomByIndex(name, j));
                            } // */
                            goto EndOfLoop;
                        }
                    }

                    IndicesWhiteList.Remove(j);
                    outRes.Add(i);
                    //Console.WriteLine("OK!");
                    break;
                    EndOfLoop: continue;
                }

                if (IndicesWhiteList.Count == 0) break;
            }

            return outRes;
        }


        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of sample generators block
        // Start of testing and debuging features block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public bool IsEmpty()
        {
            return DataSet.Count == 0;
        }

        public bool ContainsFields(List<string> inputFieldNames)
        {
            foreach (var i in inputFieldNames)
            {
                if (!NamesTypesDict.ContainsKey(i)) return false;
            }

            return true;
        }

        public bool IncludesFields(List<string> inputFieldNames, List<Type> inputFieldTypes) // Should be enriched with debug mode
        {
            if (inputFieldNames.Count != inputFieldTypes.Count)
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.IncludesFields() method failed because " +
                    "inputFieldNames and inputFieldTypes lists have inconsistent sizes. Return value - false.", GlobalVariables.LogPath);
                return false;
            }

            if (!ContainsFields(inputFieldNames))
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.IncludesFields() method failed because " +
                    "inputFieldNames list does not pertain to list of field names of inputSet. Return value - false.", GlobalVariables.LogPath);
                return false;
            }

            foreach (var i in Enumerable.Range(0, inputFieldNames.Count))
            {
                if (NamesTypesDict.ContainsKey(inputFieldNames[i]))
                {
                    if (inputFieldTypes[i] != NamesTypesDict[inputFieldNames[i]])
                    {
                        BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.IncludesFields() method failed because " +
                            "inputFieldTypes, inputFieldNames and this.NamesTypesDict are not conform", GlobalVariables.LogPath);
                        return false;
                    }
                }
                else
                {
                    BasicUtilities.UniversalLogger("SampleGenerator2017.DataSetClassT1.IncludesFields() method failed because " +
                        "this.NamesTypesDict does not contain a key \"" + inputFieldNames[i] + "\".", GlobalVariables.LogPath);
                    return false;
                }
            }

            return true;
        }

        public bool IsCompatibleWith(DataSetClassT1 toCompare)
        {
            foreach (var el in NamesTypesDict)
            {
                if (!toCompare.NamesTypesDict.ContainsKey(el.Key)) return false; // !!! Should have a log or an assertion
                if (toCompare.NamesTypesDict[el.Key] != NamesTypesDict[el.Key]) return false;
            }

            return true;
        }
        
        public void TestStringsLoad()
        {
            Size = 10000;
            
            AddNewField("s1", typeof(string));
            AddNewField("s2", typeof(string));

            var myRand = new Random();

            for (var i = 0; i < Size; i++)
            {
                var s1 = "string" + myRand.Next(100);
                var s2 = myRand.NextDouble().ToString();
                
                AddElementOneField("s1", s1);
                AddElementOneField("s2", s2);
            }
        }

        public void OutputSampleT1(string marker)
        {
            var size = 0;
            var successNumber = 0;
            
            using (var output = new StreamWriter(GlobalVariables.SampleFolderPath + "Sample_"
                                                 + marker + ".csv"))
            {
                foreach (var el in NamesTypesDict.Keys) output.Write(el + ";");
                output.WriteLine("");
                for (var i = 0; i < Size; i++)
                {
                    foreach (var el in NamesTypesDict.Keys) output.Write(DataSet[el][i] + ";");
                    output.WriteLine("");
                    size += 1;
                    if ((int)DataSet["target_flag"][i] == 1) successNumber += 1;
                }
            }

            using (var output = new StreamWriter(GlobalVariables.ResultFolderPath + "Result.csv", true))
            {
                output.WriteLine("{0};{1};{2};{3}", marker, size, successNumber,
                    size == 0 ? 0 : (double)successNumber / size);
            }
        }

        public void OutputSampleT1_2(string marker, List<double> inChiSqResults)
        {
            var size = 0;
            var successNumber = 0;
            
            using (var output = new StreamWriter(GlobalVariables.SampleFolderPath + "Sample_"
                                                 + marker + ".csv"))
            {
                foreach (var el in NamesTypesDict.Keys) output.Write(el + ";");
                output.WriteLine("");
                for (var i = 0; i < Size; i++)
                {
                    foreach (var el in NamesTypesDict.Keys) output.Write(DataSet[el][i] + ";");
                    output.WriteLine("");
                    size += 1;
                    if ((int)DataSet["target_flag"][i] == 1) successNumber += 1;
                }
            }

            using (var output = new StreamWriter(GlobalVariables.ResultFolderPath + "Result_ext_1.csv", true))
            {
                output.Write("{0};{1};{2};{3};", marker, size, successNumber,
                    size == 0 ? 0 : (double)successNumber / size);
                for (int i = 0; i < inChiSqResults.Count-1; i++) {
                    output.Write("{0};", inChiSqResults[i]);
                }
                output.WriteLine("{0}", inChiSqResults[inChiSqResults.Count-1]);
            }
        }
    }
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Block defining statistical tests
    //=====================================================================
    //=====================================================================
    //=====================================================================

    public abstract class StatTests
    {
        public static bool CheckArguments(DataSetClassT1 sample, DataSetClassT1 fullPopulation,
            IBucketing bucketing)
        {
            if (sample == null || fullPopulation == null || bucketing == null)
            { // !!! Should be replaced with a log or assertion
                Console.WriteLine("Some of the arguments is assigned a null pointer!");
                Console.WriteLine("Sample is " + (sample == null ? "assigned a null pointer" : "present"));
                Console.WriteLine("DataSet is " + (fullPopulation == null ? "assigned a null pointer" : "present"));
                Console.WriteLine("Bucketing is " + (bucketing == null ? "assigned a null pointer" : "present"));
                return false;
            }
            if (sample.IsEmpty() || fullPopulation.IsEmpty() || bucketing.GetNumberOfBuckets() == 1)
                // This if statement could be inverted but it would make the code harder to read 
            { // !!! Should be replaced with a log or assertion
                Console.WriteLine("Some of the arguments is trivial!");
                Console.WriteLine("Sample is " + (sample.IsEmpty() ? "empty" : "normal"));
                Console.WriteLine("DataSet is " + (fullPopulation.IsEmpty() ? "empty" : "normal"));
                Console.WriteLine("Bucketing is " + (bucketing.GetNumberOfBuckets() == 1 ? "trivial" : "normal"));
                return false;
            }
            
            return true;
        }
        
        public static double ChiSquaredTest(DataSetClassT1 sample, DataSetClassT1 fullPopulation, IBucketing bucketing)
        {
            //-------------------------------------------------------------
            // Start of check block
            //-------------------------------------------------------------
            
            if (!CheckArguments(sample, fullPopulation, bucketing))
            {
                Console.WriteLine("Check not passed! Function evaluation terminated!"); // !!! should be replaced with log or assertion
                return -1;
            }
            
            //-------------------------------------------------------------
            // Start of data preparation block
            //-------------------------------------------------------------
            
            double result = 0;
            var n1 = sample.GetSize();
            var n2 = fullPopulation.GetSize();
            //Console.WriteLine("n1 = {0}, n2 = {1}", n1, n2);
            var sampleFrequencyArray = new List<int>();
            sampleFrequencyArray.AddRange(Enumerable.Range(0, bucketing.GetNumberOfBuckets()).Select(el => 0));
            var fullPopulationFrequencyArray = new List<int>();
            fullPopulationFrequencyArray.AddRange(Enumerable.Range(0, bucketing.GetNumberOfBuckets()).Select(el => 0));
            // !!! Here should be a check that everything is all right! E.g. that no bucket number is more than total quantity of buckets.
            
            foreach (var el in sample.GetDataSet[bucketing.GetFieldName()])
            {
                try
                {
                    sampleFrequencyArray[bucketing.GetBucketNumberByElement(el)] += 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // !!! Should be replaced with log or assertion
                }
            }
            foreach (var el in fullPopulation.GetDataSet[bucketing.GetFieldName()])
            {
                try
                {
                    fullPopulationFrequencyArray[bucketing.GetBucketNumberByElement(el)] += 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // !!! Should be replaced with log or assertion
                }
            }
            
            //-------------------------------------------------------------
            // Start of logic block
            //-------------------------------------------------------------
            
            foreach (var i in Enumerable.Range(0, bucketing.GetNumberOfBuckets()))
            {
                //Console.WriteLine("sampleFrequencyArray[i] = {0}, fullPopulationFrequencyArray[i] = {1}", sampleFrequencyArray[i], fullPopulationFrequencyArray[i]);
                //Console.WriteLine("{0}", (double)sampleFrequencyArray[i] / n1 - (double)fullPopulationFrequencyArray[i] / n2);
                //Console.WriteLine("{0}", sampleFrequencyArray[i] + fullPopulationFrequencyArray[i]);
                result += ((double)sampleFrequencyArray[i] / n1 - (double)fullPopulationFrequencyArray[i] / n2)
                        * ((double)sampleFrequencyArray[i] / n1 - (double)fullPopulationFrequencyArray[i] / n2)
                        / (sampleFrequencyArray[i] + fullPopulationFrequencyArray[i]);
            }
            result *= n1 * n2;
            
            return result;
        }

        public static double PSITest(DataSetClassT1 sample, DataSetClassT1 fullPopulation, IBucketing bucketing)
        {
            /*if (!CheckArguments(sample, fullPopulation, bucketing))
            {
                Console.WriteLine("Check not passed! Function evaluation terminated!"); // !!! should be replaced with log or assertion
                return -1;
            } // */
            
            //-------------------------------------------------------------
            // Start of data preparation block
            //-------------------------------------------------------------
            
            double result = 0;
            var n1 = sample.GetSize();
            var n2 = fullPopulation.GetSize();
            var sampleFrequencyArray = new List<int>();
            sampleFrequencyArray.AddRange(Enumerable.Range(0, bucketing.GetNumberOfBuckets()).Select(el => 0));
            var fullPopulationFrequencyArray = new List<int>();
            fullPopulationFrequencyArray.AddRange(Enumerable.Range(0, bucketing.GetNumberOfBuckets()).Select(el => 0));
            // !!! Here should be a check that everything is all right! E.g. that no bucket number is more than total quantity of buckets.
            
            foreach (var el in sample.GetDataSet[bucketing.GetFieldName()])
            {
                try
                {
                    sampleFrequencyArray[bucketing.GetBucketNumberByElement(el)] += bucketing.GetWeightByElement(el);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // !!! Should be replaced with log or assertion
                }
            }
            foreach (var el in fullPopulation.GetDataSet[bucketing.GetFieldName()])
            {
                try
                {
                    fullPopulationFrequencyArray[bucketing.GetBucketNumberByElement(el)] += bucketing.GetWeightByElement(el);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // !!! Should be replaced with log or assertion
                }
            }
            
            //-------------------------------------------------------------
            // Start of logic block
            //-------------------------------------------------------------
            
            foreach (var i in Enumerable.Range(0, bucketing.GetNumberOfBuckets()))
            {
                double temp = 12345;
                try
                {
                    temp = ((double)sampleFrequencyArray[i] / n1 - (double)fullPopulationFrequencyArray[i] / n2)
                              * Math.Log((double)sampleFrequencyArray[i] * n2 / fullPopulationFrequencyArray[i] / n1);
                    // !!! possible zero devision should be handled
                }
                catch (Exception e)
                {
                    BasicUtilities.UniversalLogger("PSITest caught an exception while assigning value to temp variable. " + 
                        "Iteration number = " + i + ", sampleFrequencyArray[i] = " + sampleFrequencyArray[i] + 
                        ", fullPopulationFrequencyArray[i] = " + fullPopulationFrequencyArray[i] + 
                        ", n1 = " + n1 + ", n2 = " + n2 + ". Exception message - " + e.Message, GlobalVariables.LogPath);
                    //throw;
                }

                result += temp;
            }

            return result;
        }
    }
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Utility data structures and service classes
    // Elo! Diz iz India-style utility code ;)
    //=====================================================================
    //=====================================================================
    //=====================================================================



    interface IDataContainer {
        void Clear(); // Clears out the container
        void Push(object inElement); // Pushes an object into the container
        object Pull(object inKey); // Pulls out an element by key without removing it
        object Pop(object inKey); // Pulls out an element by key and then removes it
        void Remove(object inKey); // Removes an element by key
        object IndexOf(object inElement); // Returns a key of an element
    }
    
    public class DataContainerT1 : IDataContainer {
        // This data class is designed to maintain data exchange between methods
        public readonly List<object> Data; // This field should contain the data
        public readonly List<string> Remarks; // This field is utility and should be optional. By my idea it should contain data description and remarks.
        


        public DataContainerT1() {
            // Default constructor
            Data = new List<object>();
            Remarks = new List<string>();
        }

        public DataContainerT1(List<object> inData, List<string> inRemarks = null) {
            // Implied constructor-composer
            Data = new List<object>();
            Remarks = new List<string>();

            int inRemarksSize = inRemarks == null ? 0 : inRemarks.Count;
            foreach (var i in Enumerable.Range(0, inData.Count)) {
                Data.Add(inData[i]);
                Remarks.Add(i < inRemarksSize ? inRemarks[i] : "");
            }
        }


            
        public virtual void Clear() {
            // Method clearing all fields in the container
            Data.Clear();
            Remarks.Clear();
        }


            
        public virtual void Push(object inElement) {
            // Method pushing an element inside the container
            Data.Add(inElement);
            Remarks.Add("");
        }

        public virtual void Push(object inElement, string inRemark) {
            Data.Add(inElement);
            Remarks.Add(inRemark);
        }


            
        public virtual object Pull(object inKey) {
            if (inKey.GetType() == typeof(int)) return _PullByIndex((int)inKey);
            else if (inKey.GetType() == typeof(string)) return _PullByRemark((string)inKey);
            else if (inKey.GetType() == typeof(Type)) return _PullByElementType((Type)inKey);
            else return null;
        }
            
        protected virtual object _PullByIndex(int inIndex) {
            //if (inIndex >= Data.Count) return null; // More safety = greater price
            return Data[inIndex];
        }
            
        protected virtual object _PullByRemark(string inRemark) {
            object outRes = null;
                
            foreach (var i in Remarks) {
                if (i == inRemark) {
                    if (outRes == null) outRes = _PullByIndex(Remarks.IndexOf(i));
                    else {
                        // Console.WriteLine("DataContainerT1._PullByRemark() method got an ambiguous inRemark parameter."); // Should be replaced with log and\or assertion
                        return null;
                    }
                }
            }
                
            return outRes;
        }
            
        protected virtual object _PullByElementType(Type inType) {
            object outRes = null;
                
            foreach (var i in Data) {
                if (i.GetType() == inType) {
                    if (outRes == null) outRes = i;
                    else {
                        // Console.WriteLine("DataContainerT1._PullByElementType() method got an ambiguous inType parameter."); // Should be replaced with log and\or assertion
                        return null;
                    }
                }
            }
                
            return outRes;
        }


            
        public virtual object Pop(object inKey) {
            var outRes = Pull(inKey);
            if (outRes != null) Remove(inKey);
            return outRes;
        }


            
        public virtual void Remove(object inKey) {
            if (inKey.GetType() == typeof(int)) _RemoveByIndex((int)inKey);
            else if (inKey.GetType() == typeof(string)) _RemoveByRemark((string)inKey);
            else if (inKey.GetType() == typeof(Type)) _RemoveByElementType((Type)inKey);
            else BasicUtilities.UniversalLogger("SampleGenerator2017.DataContainerT1.Remove() method failed because " +
                "of inconsistent key passed in as a parameter.", GlobalVariables.LogPath);
        }
            
        protected virtual void _RemoveByIndex(int inIndex) {
            //if (inIndex >= Data.Count) return null; // More safety = greater price
            Data.RemoveAt(inIndex);
            Remarks.RemoveAt(inIndex);
        }
            
        protected virtual void _RemoveByRemark(string inRemark) {
            int removalIndex = -1;
                
            foreach (var i in Remarks) {
                if (i == inRemark) {
                    if (removalIndex == -1) removalIndex = Remarks.IndexOf(i);
                    else {
                        BasicUtilities.UniversalLogger("SampleGenerator2017.DataContainerT1._RemoveByRemark() method failed because " +
                            "the remark parameter passed in is ambiguous and corresponds to two or more elements in Data List.", GlobalVariables.LogPath);
                        return;
                    }
                }
            }
                
            if (removalIndex > -1) _RemoveByIndex(removalIndex);
        }
            
        protected virtual void _RemoveByElementType(Type inType) {
            int removalIndex = -1;
                
            foreach (var i in Data) {
                if (i.GetType() == inType) {
                    if (removalIndex == -1) removalIndex = Data.IndexOf(i);
                    else {
                        // Console.WriteLine("DataContainerT1._PullByRemark() method got an ambiguous inRemark parameter."); // Should be replaced with log and\or assertion
                        return;
                    }
                }
            }
                
            if (removalIndex > -1) _RemoveByIndex(removalIndex);
        }



        public virtual void RemoveMany(object inKey) {
            if (inKey.GetType() == typeof(List<int>)) {
                foreach (var i in (inKey as List<int>).OrderByDescending(x => x)) _RemoveByIndex(i);
            }
            else if (inKey.GetType() == typeof(string)) _RemoveManyByRemark((string)inKey);
            else if (inKey.GetType() == typeof(List<string>)) {
                foreach (var i in inKey as List<string>) _RemoveManyByRemark(i);
            }
            else if (inKey.GetType() == typeof(Type)) _RemoveManyByElementType((Type)inKey);
            else if (inKey.GetType() == typeof(List<Type>)) {
                foreach (var i in inKey as List<Type>) _RemoveManyByElementType(i);
            }
            else BasicUtilities.UniversalLogger("SampleGenerator2017.DataContainerT1.RemoveMany() method failed because " +
                "of inconsistent key passed in as a parameter.", GlobalVariables.LogPath);
        }

        protected virtual void _RemoveManyByRemark(string inRemark) {
            var removalIndices = new List<int>();
            foreach (var i in Enumerable.Range(0, Remarks.Count).OrderByDescending(x => x)) {
                if (Remarks[i] == inRemark) removalIndices.Add(i);
            }

            foreach (var i in removalIndices) {
                _RemoveByIndex(i);
            }
        }
            
        protected virtual void _RemoveManyByElementType(Type inType) {
            var removalIndices = new List<int>();
            foreach (var i in Enumerable.Range(0, Data.Count).OrderByDescending(x => x)) {
                if (Data[i].GetType() == inType) removalIndices.Add(i);
            }

            foreach (var i in removalIndices) {
                _RemoveByIndex(i);
            }
        }


            
        public virtual object IndexOf(object inElement) {
            return Data.IndexOf(inElement);
        }


            
        public override string ToString() {
            // Not implemented!
            return base.ToString();
        }
    }



    public struct FlexiblePair
    {
        public object First;
        public object Second;

        public FlexiblePair(object inputFirst, object inputSecond = null)
        {
            First = inputFirst;
            Second = inputSecond;
        }

        public bool IsEqualTo(FlexiblePair toCompare)
        {
            return this.First.Equals(toCompare.First) && this.Second.Equals(toCompare.Second);
        }

        public override string ToString() {
            return "(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public object GetAtomByIndex(int input) {
            if (input == 0)      return First;
            else if (input == 1) return Second;
            else                 return null;
        }

        public static FlexiblePair ConvertTo(object inputObject) {
            if (inputObject is FlexiblePair) return (FlexiblePair)inputObject;
            else return new FlexiblePair();
        } // !!! Gost 5812-82
    }



    public struct FlexibleTriplet
    {
        public object First;
        public object Second;
        public object Third;

        public FlexibleTriplet(object inputFirst, object inputSecond = null, object inputThird = null) {
            First = inputFirst;
            Second = inputSecond;
            Third = inputThird;
        }

        public bool IsEqualTo(FlexibleTriplet toCompare) {
            return this.First.Equals(toCompare.First) && this.Second.Equals(toCompare.Second) && this.Third.Equals(toCompare.Third);
        }

        public override string ToString() {
            return "(" + First.ToString() + ", " + Second.ToString() + ", " + Third.ToString() + ")";
        }

        public object GetAtomByIndex(int input) {
            if (input == 0)      return First;
            else if (input == 1) return Second;
            else if (input == 2) return Third;
            else                 return null;
        }

        public static FlexibleTriplet ConvertTo(object inputObject) {
            if (inputObject is FlexibleTriplet) return (FlexibleTriplet)inputObject;
            else return new FlexibleTriplet();
        } // !!! Gost 5812-82
    }



    public struct FlexibleQuartet
    {
        public object First;
        public object Second;
        public object Third;
        public object Forth;

        public FlexibleQuartet(object inputFirst, object inputSecond = null, object inputThird = null, object inputForth = null)
        {
            First = inputFirst;
            Second = inputSecond;
            Third = inputThird;
            Forth = inputForth;
        }

        public bool IsEqualTo(FlexibleQuartet toCompare)
        {
            return this.First.Equals(toCompare.First) && this.Second.Equals(toCompare.Second)
            && this.Third.Equals(toCompare.Third) && this.Forth.Equals(toCompare.Forth);
        }

        public override string ToString() {
            return "(" + First.ToString() + ", " + Second.ToString() + ", " + Third.ToString() + ", " + Forth.ToString() + ")";
        }

        public object GetAtomByIndex(int input) {
            if (input == 0)      return First;
            else if (input == 1) return Second;
            else if (input == 2) return Third;
            else if (input == 3) return Forth;
            else                 return null;
        }

        public static FlexibleQuartet ConvertTo(object inputObject) {
            if (inputObject is FlexibleQuartet) return (FlexibleQuartet)inputObject;
            else return new FlexibleQuartet();
        } // !!! Gost 5812-82
    }


    
    public class PairOfIntegers
    {
        public int Weight { get; set; } // !!! Should leave only getter
        public int Bucket { get; set; } // !!! Should leave only getter

        public PairOfIntegers()
        {
            Weight = 1;
            Bucket = 0;
            //Console.WriteLine("Pair created"); // debug feature. Should be replaced by log or assertion!
        }

        public PairOfIntegers(int w, int b)
        {
            Weight = w;
            Bucket = b;
        }// */

        public void IncrementWeight()
        {
            Weight++;
            //Console.WriteLine("Weight in pair incremented"); // debug feature
        }

        public void DecrementWeight()
        {
            Weight--;
        }
            
        public void ResetBucket()
        {
            Bucket = 0;
        }

        public void PrintAll()
        {
            Console.Write("({0}, {1})", Weight, Bucket);
        }
    }



    public class NameTypePair : IEquatable<NameTypePair>
    {
        public readonly string Name;
        public readonly Type DataType;

        public NameTypePair(string passedName, Type passedType)
        {
            Name = passedName;
            DataType = passedType;
        }

        public bool Equals(NameTypePair pair)
        {
            return Name == pair.Name && DataType == pair.DataType;
        }
    }


    
    public class NameObjectPair : IEquatable<NameObjectPair>
    {
        public readonly string Name;
        public readonly object Value;

        public NameObjectPair(string passedName, object passedValue)
        {
            Name = passedName;
            Value = passedValue;
        }

        public bool Equals(NameObjectPair pair)
        {
            return Name == pair.Name && Value == pair.Value;
        }
    }



    public class IndexDataT1Pair {
        public readonly int Index;
        public readonly DataSetClassT1 Data;

        public IndexDataT1Pair(int inputIndex, DataSetClassT1 inputData) {
            Index = inputIndex;
            Data = inputData;
        }
    }



    public class BasicUtilities
    {
        public static object DefaultValue(Type T)
        {
            if (T == typeof(int)) return -1234;
            if (T == typeof(double)) return -(double)1234;
            if (T == typeof(string)) return "\0";
            if (T == typeof(DateTime)) return DateTime.Now.AddYears(999);
            if (T == typeof(bool)) return false;
            if (T == typeof(long)) return -(long)1234;
            if (T == typeof(char)) return '\0';
            
            return null;
        }

        public static void PrintList(IList inputList)
        {
            if (inputList == null) Console.Write("Null pointer was passed as inputList");
            else if (inputList.Count == 0) Console.Write("Empty list was passed as inputList");
            else foreach (var i in inputList) Console.Write(i.ToString() + ", ");

            Console.WriteLine("");
        }

        public static bool IsFirstSublistOfSecond(IList inputFirst, IList inputSecond, string mode = "Default")
        {
            bool result = true;
            if (mode.Contains("Unique")) {
                foreach (var i in inputFirst) {
                    if (!inputSecond.Contains(i)) {
                        result = false;
                        break;
                    }
                }
            }
            else {
                //var copyOfFirst = new typeof(inputFirst.GetType())(); // OMG! What a trash!
                var copyOfSecond = new List<object>();
                CopyFirstListIntoSecond(inputSecond, copyOfSecond, "Ignore type");

                foreach (var i in inputFirst) {
                    if (!copyOfSecond.Contains(i)) {
                        result = false;
                        break;
                    }

                    copyOfSecond.Remove(i);
                }
            }
            return result;
        }

        public static void CopyFirstListIntoSecond(IList inputFirst, IList inputSecond, string mode = "Default") {
            if (inputFirst.GetType() != inputSecond.GetType()) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.BasicUtilities.CopyFirstListIntoSecond method failed"
                    + " because inputFirst.GetType() and inputSecond.GetType() are not equal!", GlobalVariables.LogPath);
                if (!mode.Contains("ignore type")) return;
            }

            if (!mode.Contains("Append")) inputSecond.Clear();

            if (!mode.Contains("Ignore type")) {
                try {
                    foreach (var i in inputFirst) {
                        inputSecond.Add(i);
                    }
                }
                catch(Exception e) {
                    BasicUtilities.UniversalLogger("SampleGenerator2017.BasicUtilities.CopyFirstListIntoSecond method failed"
                        + " while appending elements to inputSecond list in \"ignore type\" mode. An exception was caught " +
                        "with the following message: " + e.Message, GlobalVariables.LogPath);
                }
            }
            else {
                foreach (var i in inputFirst) {
                    inputSecond.Add(i);
                }
            }
        }

        public static void LogStart()
        {
            using (var log = new StreamWriter(GlobalVariables.LogPath, true))
            {
                log.WriteLine(DateTime.Now + " - Sampler.exe launched!");
            }
        }
        
        public static void LogEnd()
        {
            using (var log = new StreamWriter(GlobalVariables.LogPath, true))
            {
                log.WriteLine(DateTime.Now + " - Sampler.exe reached its endpoint successfully!");
            }
        }

        public static void UniversalLogger(string message = "No message specified!", string path = "log.log")
        {
            using (var log = new StreamWriter(path, true))
            {
                log.WriteLine(DateTime.Now + " - " + message);
            }
        }
    }
    
    
    
    //=====================================================================
    //=====================================================================
    //=====================================================================
    // Testing utilities
    //=====================================================================
    //=====================================================================
    //=====================================================================

    public class TestingUtilities
    {
        public static void DumbTest(string markerBase, int numberOfTests, DataSetClassT1 dataSet)
        {
            foreach (var i in Enumerable.Range(0, numberOfTests))
            {
                var marker = markerBase;
                if (i < 10) marker = marker + "00" + i;
                else if (i < 100) marker = marker + "0" + i;
                else        marker = marker + i;

                dataSet.SimpleSampleGenerator(GlobalVariables.DefaultSampleSize).OutputSampleT1(marker);
            }
        }
        
        public static void NotSoDumbTest(string markerBase, int numberOfTests, DataSetClassT1 dataSet)
        {
            var s1Bucketing = new BasicStringBucketing();
            s1Bucketing.InitBucketingFromSample("string_factor_1", dataSet);
            s1Bucketing.SimpleBucketing(5);
            var s2Bucketing = new BasicStringBucketing();
            s2Bucketing.InitBucketingFromSample("string_factor_2", dataSet);
            s2Bucketing.SimpleBucketing(4);
            var i1Bucketing = new BasicIntBucketing();
            i1Bucketing.InitBucketingFromSample("int_factor_1", dataSet);
            i1Bucketing.SimpleBucketing(4);
            var d1Bucketing = new BasicDoubleBucketing();
            d1Bucketing.InitBucketingFromSample("double_factor_1", dataSet);
            d1Bucketing.SimpleBucketing(4);
            var dtBucketing = new BasicDateTimeBucketing();
            dtBucketing.InitBucketingFromSample("dt_factor_1", dataSet);
            dtBucketing.SimpleBucketing(5);

            foreach (var i in Enumerable.Range(0, numberOfTests))
            {
                var marker = markerBase;
                if (i < 10) marker = marker + "00" + i;
                else if (i < 100) marker = marker + "0" + i;
                else        marker = marker + i;

                if (i % 25 == 0) Console.WriteLine("{0} loops already proceeded. {1}% of work is done!", i, (double)i/numberOfTests*100);
                
                var output = new DataSetClassT1();
                double bestPar = 0;
                
                output = dataSet.SimpleSampleGenerator(GlobalVariables.DefaultSampleSize);
                /*bestPar = StatTests.ChiSquaredTest(output, dataSet, s1Bucketing) *
                          StatTests.PSITest(output, dataSet, s1Bucketing) +
                          StatTests.ChiSquaredTest(output, dataSet, s2Bucketing) *
                          StatTests.PSITest(output, dataSet, s2Bucketing) +
                          StatTests.ChiSquaredTest(output, dataSet, i1Bucketing) *
                          StatTests.PSITest(output, dataSet, i1Bucketing) +
                          StatTests.ChiSquaredTest(output, dataSet, d1Bucketing) *
                          StatTests.PSITest(output, dataSet, d1Bucketing) +
                          StatTests.ChiSquaredTest(output, dataSet, dtBucketing) *
                          StatTests.PSITest(output, dataSet, dtBucketing); // */

                bestPar = StatTests.ChiSquaredTest(output, dataSet, s1Bucketing)
                          //* StatTests.PSITest(output, dataSet, s1Bucketing)
                          + StatTests.ChiSquaredTest(output, dataSet, s2Bucketing)
                          //* StatTests.PSITest(output, dataSet, s2Bucketing)
                          + StatTests.ChiSquaredTest(output, dataSet, i1Bucketing)
                          //* StatTests.PSITest(output, dataSet, i1Bucketing)
                          + StatTests.ChiSquaredTest(output, dataSet, d1Bucketing)
                          //* StatTests.PSITest(output, dataSet, d1Bucketing)
                          + StatTests.ChiSquaredTest(output, dataSet, dtBucketing);
                          //* StatTests.PSITest(output, dataSet, dtBucketing);

                /*Console.WriteLine("New iteration cycle launched!");
                Console.WriteLine("New data_quality:");
                Console.WriteLine("s1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, s1Bucketing),
                    StatTests.PSITest(output, dataSet, s1Bucketing));
                Console.WriteLine("s2_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, s2Bucketing),
                    StatTests.PSITest(output, dataSet, s2Bucketing));
                Console.WriteLine("i1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, i1Bucketing),
                    StatTests.PSITest(output, dataSet, i1Bucketing));
                Console.WriteLine("d1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, d1Bucketing),
                    StatTests.PSITest(output, dataSet, d1Bucketing));
                Console.WriteLine("dt_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, dtBucketing),
                    StatTests.PSITest(output, dataSet, dtBucketing)); // */

                foreach (var c in Enumerable.Range(0, 100))
                {
                    //var tmp = new DataSetClassT1();
                    var tmp = dataSet.SimpleSampleGenerator(GlobalVariables.DefaultSampleSize);
                    
                    /*double tmpPar = StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing) *
                                    StatTests.PSITest(tmp, dataSet, s1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing) *
                                    StatTests.PSITest(tmp, dataSet, s2Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing) *
                                    StatTests.PSITest(tmp, dataSet, i1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing) *
                                    StatTests.PSITest(tmp, dataSet, d1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing) *
                                    StatTests.PSITest(tmp, dataSet, dtBucketing); // */

                    double tmpPar = StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing);

                    if (tmpPar < bestPar)
                    {
                        bestPar = tmpPar;
                        output = tmp;
                        /*Console.WriteLine("Switch performed at step {0}!", c);
                        Console.WriteLine("New data_quality:");
                        Console.WriteLine("s1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, s1Bucketing),
                            StatTests.PSITest(output, dataSet, s1Bucketing));
                        Console.WriteLine("s2_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, s2Bucketing),
                            StatTests.PSITest(output, dataSet, s2Bucketing));
                        Console.WriteLine("i1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, i1Bucketing),
                            StatTests.PSITest(output, dataSet, i1Bucketing));
                        Console.WriteLine("d1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, d1Bucketing),
                            StatTests.PSITest(output, dataSet, d1Bucketing));
                        Console.WriteLine("dt_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, dtBucketing),
                            StatTests.PSITest(output, dataSet, dtBucketing)); // */
                    }
                }

                output.OutputSampleT1(marker);
                /*Console.WriteLine("The result data quality:");
                Console.WriteLine("s1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, s1Bucketing),
                    StatTests.PSITest(output, dataSet, s1Bucketing));
                Console.WriteLine("s2_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, s2Bucketing),
                    StatTests.PSITest(output, dataSet, s2Bucketing));
                Console.WriteLine("i1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, i1Bucketing),
                    StatTests.PSITest(output, dataSet, i1Bucketing));
                Console.WriteLine("d1_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, d1Bucketing),
                    StatTests.PSITest(output, dataSet, d1Bucketing));
                Console.WriteLine("dt_repres = ({0}, {1})", StatTests.ChiSquaredTest(output, dataSet, dtBucketing),
                    StatTests.PSITest(output, dataSet, dtBucketing));
                Console.ReadKey(); // */
                
            }
        }



        public static void NotSoDumbTest_2(string markerBase, int numberOfTests, DataSetClassT1 dataSet)
        {
            var s1Bucketing = new BasicStringBucketing();
            s1Bucketing.InitBucketingFromSample("string_factor_1", dataSet);
            s1Bucketing.SimpleBucketing(5);
            var s2Bucketing = new BasicStringBucketing();
            s2Bucketing.InitBucketingFromSample("string_factor_2", dataSet);
            s2Bucketing.SimpleBucketing(4);
            var i1Bucketing = new BasicIntBucketing();
            i1Bucketing.InitBucketingFromSample("int_factor_1", dataSet);
            i1Bucketing.SimpleBucketing(4);
            var d1Bucketing = new BasicDoubleBucketing();
            d1Bucketing.InitBucketingFromSample("double_factor_1", dataSet);
            d1Bucketing.SimpleBucketing(4);
            var dtBucketing = new BasicDateTimeBucketing();
            dtBucketing.InitBucketingFromSample("dt_factor_1", dataSet);
            dtBucketing.SimpleBucketing(5);

            var testStrati = new PairStratificationT1();
            /*testStrati.AddNewField("string_factor_1", typeof(string));
            testStrati.AddNewField("dt_factor_1", typeof(DateTime));
            testStrati.PrintHead();
            //testStrati.GetStratumByKey(new FlexiblePair(testLoad.GetAtomByIndex("string_factor_1", 0), testLoad.GetAtomByIndex("dt_factor_1", 0)));
            testStrati.PrintHead();
            testStrati.FillFromDataSet(testLoad, "Safe");
            testStrati.PrintHead();
            testStrati.PrintAll(); // */

            var inFieldNames = new List<string>{"string_factor_1", "dt_factor_1"};
            foreach (var i in inFieldNames) {
                testStrati.AddNewField(i, dataSet.GetTypeByName(i));
            }
            testStrati.FillFromDataSet(dataSet, "Safe");
            testStrati.ConformWithBucketing(s1Bucketing);
            testStrati.ConformWithBucketing(dtBucketing);
            testStrati.PrintAll();

            foreach (var i in Enumerable.Range(0, numberOfTests))
            {
                var marker = markerBase;
                if (i < 10) marker = marker + "00" + i;
                else if (i < 100) marker = marker + "0" + i;
                else        marker = marker + i;

                if (i % 10 == 0) Console.WriteLine("{0} loops already proceeded. {1}% of work is done!", i, (double)i/numberOfTests*100);
                
                var output = new DataSetClassT1();
                double bestPar = 0;
                
                output = dataSet.SampleGenFromStratification(GlobalVariables.DefaultSampleSize, testStrati);

                bestPar = StatTests.ChiSquaredTest(output, dataSet, s1Bucketing)
                        + StatTests.ChiSquaredTest(output, dataSet, s2Bucketing)
                        + StatTests.ChiSquaredTest(output, dataSet, i1Bucketing)
                        + StatTests.ChiSquaredTest(output, dataSet, d1Bucketing)
                        + StatTests.ChiSquaredTest(output, dataSet, dtBucketing);

                foreach (var c in Enumerable.Range(0, 100))
                {
                    var tmp = dataSet.SampleGenFromStratification(GlobalVariables.DefaultSampleSize, testStrati);

                    double tmpPar = StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing) +
                                    StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing);

                    if (tmpPar < bestPar)
                    {
                        bestPar = tmpPar;
                        output = tmp;
                    }

                    /*tmp.PrintHead();
                    Console.WriteLine("Chi_sq test vector is equal to: ("
                             + StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing));
                    Console.ReadKey(); // */
                }

                output.OutputSampleT1(marker);

                output.PrintHead();
                Console.WriteLine("Chi_sq test vector is equal to: ("
                         + StatTests.ChiSquaredTest(output, dataSet, s1Bucketing) +
                    ", " + StatTests.ChiSquaredTest(output, dataSet, s2Bucketing) +
                    ", " + StatTests.ChiSquaredTest(output, dataSet, i1Bucketing) +
                    ", " + StatTests.ChiSquaredTest(output, dataSet, d1Bucketing) +
                    ", " + StatTests.ChiSquaredTest(output, dataSet, dtBucketing));
                //Console.ReadKey();
            }
        }



        public static void NotSoDumbTest_3(string markerBase, int numberOfTests, DataSetClassT1 dataSet)
        {
            var s1Bucketing = new BasicStringBucketing();
            s1Bucketing.InitBucketingFromSample("string_factor_1", dataSet);
            s1Bucketing.SimpleBucketing(5);
            var s2Bucketing = new BasicStringBucketing();
            s2Bucketing.InitBucketingFromSample("string_factor_2", dataSet);
            s2Bucketing.SimpleBucketing(4);
            var i1Bucketing = new BasicIntBucketing();
            i1Bucketing.InitBucketingFromSample("int_factor_1", dataSet);
            i1Bucketing.SimpleBucketing(4);
            var d1Bucketing = new BasicDoubleBucketing();
            d1Bucketing.InitBucketingFromSample("double_factor_1", dataSet);
            d1Bucketing.SimpleBucketing(4);
            var dtBucketing = new BasicDateTimeBucketing();
            dtBucketing.InitBucketingFromSample("dt_factor_1", dataSet);
            dtBucketing.SimpleBucketing(5);

            var testStrati = new PairStratificationT1();

            var inFieldNames = new List<string>{"string_factor_1", "dt_factor_1"};
            foreach (var i in inFieldNames) {
                testStrati.AddNewField(i, dataSet.GetTypeByName(i));
            }
            testStrati.FillFromDataSet(dataSet, "Safe");
            testStrati.ConformWithBucketing(s1Bucketing);
            testStrati.ConformWithBucketing(dtBucketing);
            testStrati.PrintAll();

            var ChiSqBestRes = new List<double>();

            foreach (var i in Enumerable.Range(0, numberOfTests))
            {
                ChiSqBestRes.Clear();
                var marker = markerBase;
                if (i < 10) marker = marker + "00" + i;
                else if (i < 100) marker = marker + "0" + i;
                else        marker = marker + i;

                if (i % 10 == 0) Console.WriteLine("{0} loops already proceeded. {1}% of work is done!", i, (double)i/numberOfTests*100);
                
                var output = new DataSetClassT1();
                double bestPar = 0;
                
                output = dataSet.SampleGenFromStratification(GlobalVariables.DefaultSampleSize, testStrati);
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, s1Bucketing));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, s2Bucketing));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, i1Bucketing));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, d1Bucketing));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, dtBucketing));

                bestPar = ChiSqBestRes[0] + ChiSqBestRes[1] + ChiSqBestRes[2] + ChiSqBestRes[3] + ChiSqBestRes[4];

                foreach (var c in Enumerable.Range(0, 100))
                {
                    var tmp = dataSet.SampleGenFromStratification(GlobalVariables.DefaultSampleSize, testStrati);

                    var ChiSqResults = new List<double>();
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing));

                    double tmpPar = ChiSqResults[0] + ChiSqResults[1] + ChiSqResults[2] + ChiSqResults[3] + ChiSqResults[4];

                    if (tmpPar < bestPar)
                    {
                        bestPar = tmpPar;
                        output = tmp;
                        ChiSqBestRes = ChiSqResults;
                    }

                    /*tmp.PrintHead();
                    Console.WriteLine("Chi_sq test vector is equal to: ("
                             + StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing));
                    Console.ReadKey(); // */
                }

                output.OutputSampleT1_2(marker, ChiSqBestRes);

                output.PrintHead();
                Console.WriteLine("Chi_sq test vector is equal to: ("
                         + ChiSqBestRes[0] +
                    ", " + ChiSqBestRes[1] +
                    ", " + ChiSqBestRes[2] +
                    ", " + ChiSqBestRes[3] +
                    ", " + ChiSqBestRes[4]);
                //Console.ReadKey();
            }
        }



        public static void NotSoDumbTest_4(string markerBase, int numberOfTests, DataSetClassT1 dataSet)
        {
            IBucketing[] bucketingArray = new IBucketing[5];
            bucketingArray[0] = new BasicStringBucketing();
            bucketingArray[0].InitBucketingFromSample("string_factor_1", dataSet);
            bucketingArray[0].SimpleBucketing(5);
            bucketingArray[1] = new BasicStringBucketing();
            bucketingArray[1].InitBucketingFromSample("string_factor_2", dataSet);
            bucketingArray[1].SimpleBucketing(4);
            bucketingArray[2] = new BasicIntBucketing();
            bucketingArray[2].InitBucketingFromSample("int_factor_1", dataSet);
            bucketingArray[2].SimpleBucketing(4);
            bucketingArray[3] = new BasicDoubleBucketing();
            bucketingArray[3].InitBucketingFromSample("double_factor_1", dataSet);
            bucketingArray[3].SimpleBucketing(4);
            bucketingArray[4] = new BasicDateTimeBucketing();
            bucketingArray[4].InitBucketingFromSample("dt_factor_1", dataSet);
            bucketingArray[4].SimpleBucketing(4);

            var testStrati = new PairStratificationT1();

            var inFieldNames = new List<string>{"string_factor_1", "dt_factor_1"};
            foreach (var i in inFieldNames) {
                testStrati.AddNewField(i, dataSet.GetTypeByName(i));
            }
            testStrati.FillFromDataSet(dataSet, "Safe");
            testStrati.ConformWithBucketing(bucketingArray[0]);
            testStrati.ConformWithBucketing(bucketingArray[4]);
            testStrati.PrintAll();

            var ChiSqBestRes = new List<double>();

            foreach (var i in Enumerable.Range(0, numberOfTests))
            {
                ChiSqBestRes.Clear();
                var marker = markerBase;
                if (i < 10) marker = marker + "00" + i;
                else if (i < 100) marker = marker + "0" + i;
                else        marker = marker + i;

                if (i % 10 == 0) Console.WriteLine("{0} loops already proceeded. {1}% of work is done!", i, (double)i/numberOfTests*100);
                
                var output = new DataSetClassT1();
                double bestPar = 0;
                
                output = dataSet.SampleGenFromStratification(GlobalVariables.DefaultSampleSize, testStrati);
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[0]));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[1]));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[2]));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[3]));
                ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[4]));

                bestPar = ChiSqBestRes[0] + ChiSqBestRes[1] + ChiSqBestRes[2] + ChiSqBestRes[3] + ChiSqBestRes[4];

                foreach (var c in Enumerable.Range(0, 100))
                {
                    var tmp = dataSet.SampleGenFromStratification(GlobalVariables.DefaultSampleSize, testStrati);

                    var ChiSqResults = new List<double>();
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, bucketingArray[0]));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, bucketingArray[1]));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, bucketingArray[2]));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, bucketingArray[3]));
                    ChiSqResults.Add(StatTests.ChiSquaredTest(tmp, dataSet, bucketingArray[4]));

                    double tmpPar = ChiSqResults[0] + ChiSqResults[1] + ChiSqResults[2] + ChiSqResults[3] + ChiSqResults[4];

                    if (tmpPar < bestPar)
                    {
                        bestPar = tmpPar;
                        output = tmp;
                        ChiSqBestRes = ChiSqResults;
                    }

                    /*tmp.PrintHead();
                    Console.WriteLine("Chi_sq test vector is equal to: ("
                             + StatTests.ChiSquaredTest(tmp, dataSet, s1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, s2Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, i1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, d1Bucketing) +
                        ", " + StatTests.ChiSquaredTest(tmp, dataSet, dtBucketing));
                    Console.ReadKey(); // */
                }

                output.PrintHead();
                Console.WriteLine("Chi_sq test vector is equal to: ("
                         + ChiSqBestRes[0] +
                    ", " + ChiSqBestRes[1] +
                    ", " + ChiSqBestRes[2] +
                    ", " + ChiSqBestRes[3] +
                    ", " + ChiSqBestRes[4] + ")");
                Console.WriteLine("");

                var tmpSample = new DataSetClassT1(output, "Copy");
                var IndicesBlackList = new List<int>();
                BasicUtilities.PrintList(dataSet.GenerateIndicesOfSample(tmpSample));
                tmpSample.PrintHead();
                Console.WriteLine(IndicesBlackList.Count);
                //BasicUtilities.PrintList(IndicesBlackList);
                tmpSample = tmpSample.ModifySampleInRelationTo(dataSet, bucketingArray, IndicesBlackList);
                tmpSample.PrintHead();
                Console.WriteLine(IndicesBlackList.Count);
                //BasicUtilities.PrintList(IndicesBlackList);
                tmpSample = tmpSample.ModifySampleInRelationTo(dataSet, bucketingArray, IndicesBlackList);
                tmpSample.PrintHead();
                Console.WriteLine(IndicesBlackList.Count);
                //BasicUtilities.PrintList(IndicesBlackList);

                /*for (int j = 0; j < 1000; j++) {
                    Console.WriteLine("Entered determined part of sample generation algorithm");
                    output = output.ModifySampleInRelationTo(dataSet, bucketingArray, IndicesBlackList);

                    ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[0]));
                    ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[1]));
                    ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[2]));
                    ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[3]));
                    ChiSqBestRes.Add(StatTests.ChiSquaredTest(output, dataSet, bucketingArray[4]));

                    output.PrintHead();
                    Console.WriteLine("Chi_sq test vector is equal to: ("
                             + ChiSqBestRes[0] +
                        ", " + ChiSqBestRes[1] +
                        ", " + ChiSqBestRes[2] +
                        ", " + ChiSqBestRes[3] +
                        ", " + ChiSqBestRes[4]);
                    BasicUtilities.PrintList(IndicesBlackList);
                    Console.WriteLine("");
                    if(Console.ReadLine() == "quit") break;
                } // */

                output.OutputSampleT1_2(marker, ChiSqBestRes);

                output.PrintHead();
                Console.WriteLine("Chi_sq test vector is equal to: ("
                         + ChiSqBestRes[0] +
                    ", " + ChiSqBestRes[1] +
                    ", " + ChiSqBestRes[2] +
                    ", " + ChiSqBestRes[3] +
                    ", " + ChiSqBestRes[4]);
                //Console.ReadKey();
            }
        }
    }
    
    
    
    //=====================================================================
    // Quick-sort implementation
    //=====================================================================
    // !!! To be implemented
    //=====================================================================































    public interface IStratification
    {
        int GetStratumByKey(object inputKey);
        object GenKeyFromData(object Data);
        void AbortStratification();
        void PushEntity(object inputEntity);
        void PullEntity(object inputEntity);
        void RemoveEntity(object inputEntity);
        bool IsFiltrationOf(IStratification toCompare);
        bool IsHomogeneousTo(IStratification toCompare);
        //bool IsEqualTo(IStratification toCompare); // replaced with IEquatable.Equals()
        void PrintHead();
        void PrintAll();
        string ToString();
    }





    public abstract class AbstractStratificationT1 : IStratification, IEquatable<AbstractStratificationT1>
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of fields and properties definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        public List<string> FieldNames; // !!! Should be readonly
        public List<Type> FieldTypes;
        public Dictionary<object, PairOfIntegers> Stratification; // A Key must be of a value type or inherite IEquatable<object>
        public List<int> StrataSizeList;
        protected int QuantityOfStrata;
        protected int QuantityOfElements;
        protected bool Checked;



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of fields and properties definition block
        // Start of getters\setters definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        public bool IsChecked()
        {
            return Checked;
        }

        public int GetQuantityOfStrata()
        {
            return QuantityOfStrata;
        }

        public int GetQuantityOfElements()
        {
            return QuantityOfElements;
        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of getters\setters definition block
        // Start of interface methods implementation block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        public virtual int GetStratumByKey(object inputKey)
        {
            if (Stratification.ContainsKey(inputKey)) return Stratification[inputKey].Bucket; // !!! PairOfIntegers should be changed
            
            //var inputType = inputKey.GetType();
            if (inputKey is IEquatable<object>)
            {
                foreach (var i in Stratification.Keys)
                {
                    if (inputKey.Equals(i)) return Stratification[i].Bucket;
                }
            }

            BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.GetStratumByKey() method failed"
                + " because key equal to the input was not found!", GlobalVariables.LogPath);
            return 0;
        }

        public virtual object GenKeyFromData(object Data) {
            BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.GenKeyFromData() method not implemented!", GlobalVariables.LogPath);
            return null;
        }

        public virtual void AbortStratification()
        {
            foreach (var i in Stratification)
            {
                i.Value.Bucket = 0;
            }

            QuantityOfStrata = 1;
            StrataSizeList.Clear();

            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.AbortStratification() method not implemented!", GlobalVariables.LogPath);
        }

        public virtual void PushEntity(object inputEntity)
        {
            if (Stratification.ContainsKey(inputEntity))
            {
                Stratification[inputEntity].Weight += 1;
                QuantityOfElements += 1;
                return;
            } // !!! PairOfIntegers should be changed

            if (inputEntity is IEquatable<object>)
            {
                foreach (var i in Stratification.Keys)
                {
                    if (inputEntity.Equals(i))
                    {
                        Stratification[i].Weight += 1;
                        QuantityOfElements += 1;
                        return;
                    }
                }
            }

            Stratification.Add(inputEntity, new PairOfIntegers(1, 0));
            QuantityOfElements += 1;

            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.AddEntity() method not implemented!", GlobalVariables.LogPath);
        }

        public virtual void PullEntity(object inputEntity)
        {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.RemoveEntity() method not implemented!", GlobalVariables.LogPath);

            if (Stratification.ContainsKey(inputEntity))
            {
                if (Stratification[inputEntity].Weight == 1) Stratification.Remove(inputEntity);
                else Stratification[inputEntity].Weight -= 1;
            }
            else if (inputEntity is IEquatable<object>)
            {
                foreach (var i in Stratification.Keys)
                {
                    if (inputEntity.Equals(i))
                    {
                        if (Stratification[i].Weight == 1) Stratification.Remove(i);
                        else Stratification[i].Weight -= 1;
                    }
                }
            }
            else
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.PullEntity() method failed "
                    + "because no element was found having passed key.", GlobalVariables.LogPath);
                return;
            }

            QuantityOfElements -= 1;
        }

        public virtual void RemoveEntity(object inputEntity)
        {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.RemoveEntity() method not implemented!", GlobalVariables.LogPath);

            if (Stratification.ContainsKey(inputEntity))
            {
                QuantityOfElements -= Stratification[inputEntity].Weight;
                Stratification.Remove(inputEntity);
            }
            else if (inputEntity is IEquatable<object>)
            {
                foreach (var i in Stratification.Keys)
                {
                    if (inputEntity.Equals(i))
                    {
                        QuantityOfElements -= Stratification[inputEntity].Weight;
                        Stratification.Remove(i);
                    }
                }
            }
            else
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.RemoveEntity() method failed "
                    + "because no element was found having passed key.", GlobalVariables.LogPath);
                return;
            }
        }

        public virtual bool IsFiltrationOf(IStratification toCompare)
        // true if every field in this belongs to toCompare. In other words: '<='
        {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.IsFiltrationOf() method not implemented!", GlobalVariables.LogPath);
            //return false;
            if (!(toCompare is AbstractStratificationT1))
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.IsFiltrationOf() method "
                    + "encountered type inconsistency - toCompare element is not an entity of AbstractStratificationT1.",
                    GlobalVariables.LogPath);
                return false;
            }

            var localCopyOfInput = toCompare as AbstractStratificationT1;
            if (localCopyOfInput == null) return false; // !!! Should be enriched with log

            bool result = true;
            for (var i = 0; i < FieldNames.Count; i++)
            {
                if (localCopyOfInput.FieldNames.Contains(this.FieldNames[i]))
                {
                    int tmp = localCopyOfInput.FieldNames.IndexOf(this.FieldNames[i]);
                    if (localCopyOfInput.FieldTypes[tmp] != this.FieldTypes[i])
                    {
                        result = false;
                        BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.IsFiltrationOf() method "
                            + "encountered type inconsistency. FieldName = " + this.FieldNames[i] + ", this.FieldType = "
                            + this.FieldTypes[i] + ", toCompare.FieldType = " + localCopyOfInput.FieldTypes[tmp] , GlobalVariables.LogPath);
                    }
                }
                else
                {
                    result = false;
                    //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.IsFiltrationOf() method "
                    //    + "encountered FieldList incostistency.", GlobalVariables.LogPath);
                }
            }

            return result;
        }

        public virtual bool IsHomogeneousTo(IStratification toCompare)
        {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.IsHomogeneousTo() method not implemented!", GlobalVariables.LogPath);
            return this.IsFiltrationOf(toCompare) && toCompare.IsFiltrationOf(this);
        }

        public virtual void PrintHead()
        {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.PrintHead() method not implemented!", GlobalVariables.LogPath);

            Console.WriteLine("");
            Console.WriteLine("Stratification under consideration has the following properties:");
            Console.WriteLine("Checked = " + Checked);
            Console.WriteLine("QuantityOfStrata = " + QuantityOfStrata);
            Console.WriteLine("QuantityOfElements = " + QuantityOfElements);
            Console.WriteLine("FieldName list contains:");
            BasicUtilities.PrintList(FieldNames);
            Console.WriteLine("FieldType list contains:");
            BasicUtilities.PrintList(FieldTypes);
            Console.WriteLine("StrataSizeList list contains:");
            BasicUtilities.PrintList(StrataSizeList);
            Console.WriteLine("");
        }

        public virtual void PrintAll()
        {
            //BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.PrintHead() method not implemented!", GlobalVariables.LogPath);

            PrintHead();

            Console.WriteLine("Stratification dictionary contains the following element set:");
            foreach (var i in Stratification) Console.WriteLine("Key: " + i.Key.ToString() + ", Weight: " + 
                i.Value.Weight + ", Strtum: " + i.Value.Bucket);

            Console.WriteLine("");
        }

        public override string ToString() // !!! Is not implemented!
        {
            BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.Tostring() method not implemented!", GlobalVariables.LogPath);
            return "SampleGenerator2017.AbstractStratification object";
        }

        public virtual bool Equals(AbstractStratificationT1 toCompare) // !!! Is not implemented!
        {
            BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.Equals() method not implemented!", GlobalVariables.LogPath);
            return false;
        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of interface methods implementation block
        // Start of data manipulation methods definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        protected virtual bool UniteTwoStrata() // !!! Is not implemented!
        {
            BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.UniteTwoStrata() method not implemented!", GlobalVariables.LogPath);
            return true;
        }

        protected virtual void _AddNewField(string fieldName, Type fieldType)
        {
            if (string.IsNullOrEmpty(fieldName) || fieldType == null)
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification._AddNewField method failed because " +
                    "fieldName and/or fieldType is empty or null. fieldName = " + fieldName +
                    ", fieldType = " + fieldType + ".", GlobalVariables.LogPath);
                return;
            }

            if (FieldNames.Contains(fieldName))
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification._AddNewField method failed because " +
                    "fieldName \"" + fieldName + "\" is already present in FieldNames list.", GlobalVariables.LogPath);
                return;
            }

            FieldNames.Add(fieldName);
            FieldTypes.Add(fieldType);
            Checked = false;
        }

        /*protected virtual void _AddElementToField(string fieldName, object inputValue)
        {
            Stratification[fieldName].Add(inputValue);
        } // */ // WTF?! Maybe I was drunk when wrote this ;)

        public virtual bool AddEntityFromSetByIndex(DataSetClassT1 inputSet, int inputIndex, string mode = "Safe")
        // !!! Is not implemented! Particularly, logical block is ommited but some checks implemented, so this pattern can be used in derived class.
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (inputIndex >= inputSet.GetSize()) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratificationT1.AddEntityFromSetByIndex method failed because " +
                    "inputIndex is greater than Size of inputSet or equals it.", GlobalVariables.LogPath);
                return true;
            }

            if (mode.Contains("Safe")) {
                if ( ! inputSet.IncludesFields(FieldNames, FieldTypes)) {
                    BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratificationT1.AddEntityFromSetByIndex method failed because " +
                        "stratification FieldNames and FieldTypes lists are inconsistent with inputSet.", GlobalVariables.LogPath);
                    return true;
                }
            }

            /*foreach (var i in FieldNames)
            {
                //_AddElementToField(i, inputSet.GetAtomByIndex(i, index));
                Console.WriteLine("Bad luck, bro! ;)");
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratificationT1.AddEntityFromSetByIndex method is not implemented", 
                    GlobalVariables.LogPath);
                return true;
            } // */ // Ahaha! WTF?!

            //QuantityOfElements += 1;
            return false;
        }

        public virtual bool FillFromDataSet(DataSetClassT1 inputSet, string mode = "Safe")
        // !!! Is not implemented! Particularly, logical block is ommited but some checks implemented, so this pattern can be used in derived class.
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (inputSet == null)
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratificationT1.FillFromDataSet() method failed because " +
                    "inputSet is assigned a null pointer.", GlobalVariables.LogPath);
                return true;
            }

            if (inputSet.GetSize() == 0)
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratificationT1.FillFromDataSet() method failed because " +
                    "inputSet has Size equal to 0 and therefore is to be empty.", GlobalVariables.LogPath);
                return true;
            }

            if (!inputSet.IncludesFields(FieldNames, FieldTypes))
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.FillFromDataSet() method failed because " +
                    "inputSet.IncludesFields returned \"false\" with the passed parameters.", GlobalVariables.LogPath);
                if (mode == "Safe") return true;
            }

            return false;
        }

        public virtual bool ConformWithBucketing(IBucketing bucketing)
        // !!! Is not implemented! Particularly, logical block is ommited but some checks implemented, so this pattern can be used in derived class.
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (bucketing == null)
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.ConformWithBucketing() method failed because input " +
                    "bucketing variable is assigned a null pointer.", GlobalVariables.LogPath);
                return true;
            }

            if (bucketing.GetNumberOfBuckets() <= 1)
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.ConformWithBucketing() method failed because input " +
                    "bucketing is trivial (GetNumberOfBuckets() method returns 1 or less).", GlobalVariables.LogPath);
                return true;
            }

            if (!FieldNames.Contains(bucketing.GetFieldName()))
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.ConformWithBucketing() method failed because " +
                    "FieldNames list does not contain bucketing FieldName. Bucketing FieldName = \"" + bucketing.GetFieldName() + "\"", 
                    GlobalVariables.LogPath); // printing out the list of field names could be added here
                return true;
            }

            if (FieldTypes[FieldNames.IndexOf(bucketing.GetFieldName())] != bucketing.GetFieldType())
            {
                BasicUtilities.UniversalLogger("SampleGenerator2017.AbstractStratification.ConformWithBucketing() method failed because " +
                    "bucketing FieldType does not match the corresponding element in FieldTypes set.", GlobalVariables.LogPath);
                return true;
            }

            return false;
        }
    }



    public class PairStratificationT1 : AbstractStratificationT1
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors\destructors definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public PairStratificationT1() {
            FieldNames = new List<string>();
            FieldTypes = new List<Type>();
            Stratification = new Dictionary<object, PairOfIntegers>();
            StrataSizeList = new List<int>();
            QuantityOfStrata = 1;
            QuantityOfElements = 0;
            Checked = false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors\destructors definition block
        // Start of override block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected override void _AddNewField(string fieldName, Type fieldType) {
            if (FieldNames.Count < 2) base._AddNewField(fieldName, fieldType);
            else {
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1._AddNewField() method failed because " +
                    "two fields are already present in the stratification.", GlobalVariables.LogPath);
            }
        }

        public override object GenKeyFromData(object inputData) {
            if (inputData is IndexDataT1Pair) {
                IndexDataT1Pair tmp = inputData as IndexDataT1Pair;
                return new FlexiblePair(
                    tmp.Data.GetAtomByIndex(FieldNames[0], tmp.Index), 
                    tmp.Data.GetAtomByIndex(FieldNames[1], tmp.Index));
                // !!! Very unsafe! Should be revised and enriched with some sort of safety gear
            }
            else {
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.GenKeyFromData() method failed because " +
                    "inputData is not an object of a comprehensible type.", GlobalVariables.LogPath);
                return null; // !!! Probably will cause exception because FlexiblePair/Triplet/Quartet are value types. At least I think they must be
            }
        }

        public override void PushEntity(object inputEntity) {
            if (!(inputEntity is FlexiblePair)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.PushEntity() method failed because " +
                    "inputEntity is not an object of FlexiblePair type.", GlobalVariables.LogPath);
                return;
            }
            base.PushEntity(inputEntity);
        }

        public override void PullEntity(object inputEntity) {
            if (!(inputEntity is FlexiblePair)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.PullEntity() method failed because " +
                    "inputEntity is not an object of FlexiblePair type.", GlobalVariables.LogPath);
                return;
            }
            base.PullEntity(inputEntity);
        }

        public override void RemoveEntity(object inputEntity) {
            if (!(inputEntity is FlexiblePair)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.RemoveEntity() method failed because " +
                    "inputEntity is not an object of FlexiblePair type.", GlobalVariables.LogPath);
                return;
            }
            base.RemoveEntity(inputEntity);
        }

        public override bool AddEntityFromSetByIndex(DataSetClassT1 inputSet, int inputIndex, string mode = "Safe")
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (base.AddEntityFromSetByIndex(inputSet, inputIndex, mode)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.AddEntityFromSetByIndex() method failed because " +
                    "inputEntity is not an object of FlexiblePair type.", GlobalVariables.LogPath);
                return true;
            }

            PushEntity(new FlexiblePair(inputSet.GetAtomByIndex(FieldNames[0], inputIndex), inputSet.GetAtomByIndex(FieldNames[1], inputIndex)));
            return false;
        }

        public override bool FillFromDataSet(DataSetClassT1 inputSet, string mode = "Safe")
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (base.FillFromDataSet(inputSet, mode)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.FillFromDataSet() method failed because " +
                    "inputEntity is not an object of FlexiblePair type.", GlobalVariables.LogPath);
                return true;
            }

            foreach (var i in Enumerable.Range(0, inputSet.GetSize())) {
                AddEntityFromSetByIndex(inputSet, i, "Unsafe");
            }
            return false;
        }

        public override bool ConformWithBucketing(IBucketing inputBucketing) {
            if (base.ConformWithBucketing(inputBucketing)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.PairStratificationT1.ConformWithBucketing() method failed because " +
                    "basic check was not passed.", GlobalVariables.LogPath);
                return true;
            }

            int index = FieldNames.IndexOf(inputBucketing.GetFieldName()); // !!! may be -1 if element could not be found in the list

            foreach (var i in Stratification) {
                //FlexiblePair tmp = (FlexiblePair)i.Key;// as FlexiblePair?; // Gost 5812-82
                //FlexiblePair tmp2 = tmp == null ? new FlexiblePair() : tmp;
                var tmp = FlexiblePair.ConvertTo(i.Key).GetAtomByIndex(index);

                i.Value.Bucket = i.Value.Bucket * inputBucketing.GetNumberOfBuckets() +
                    inputBucketing.GetBucketNumberByElement(tmp);
            } // */ // F***g not nullable types! This shit makes me really unhappy! X(

            return false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of override block
        // Start of local methods definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddNewField(string fieldName, Type fieldType) {
            _AddNewField(fieldName, fieldType);
        } // */ // !!! Testing feature! Should be removed!
    }



    public class TripletStratificationT1 : AbstractStratificationT1
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors\destructors definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public TripletStratificationT1() {
            FieldNames = new List<string>();
            FieldTypes = new List<Type>();
            Stratification = new Dictionary<object, PairOfIntegers>();
            StrataSizeList = new List<int>();
            QuantityOfStrata = 1;
            QuantityOfElements = 0;
            Checked = false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors\destructors definition block
        // Start of override block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected override void _AddNewField(string fieldName, Type fieldType) {
            if (FieldNames.Count < 3) base._AddNewField(fieldName, fieldType);
            else {
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1._AddNewField() method failed because " +
                    "two fields are already present in the stratification.", GlobalVariables.LogPath);
            }
        }

        public override object GenKeyFromData(object inputData) {
            if (inputData is IndexDataT1Pair) {
                IndexDataT1Pair tmp = inputData as IndexDataT1Pair;
                return new FlexibleTriplet(
                    tmp.Data.GetAtomByIndex(FieldNames[0], tmp.Index), 
                    tmp.Data.GetAtomByIndex(FieldNames[1], tmp.Index),
                    tmp.Data.GetAtomByIndex(FieldNames[2], tmp.Index));
                // !!! Very unsafe! Should be revised and enriched with some sort of safety gear
            }
            else {
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.GenKeyFromData() method failed because " +
                    "inputData is not an object of a comprehensible type.", GlobalVariables.LogPath);
                return null; // !!! Probably will cause exception because FlexiblePair/Triplet/Quartet are value types. At least I think they must be
            }
        }

        public override void PushEntity(object inputEntity) {
            if (!(inputEntity is FlexibleTriplet)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.PushEntity() method failed because " +
                    "inputEntity is not an object of FlexibleTriplet type.", GlobalVariables.LogPath);
                return;
            }
            base.PushEntity(inputEntity);
        }

        public override void PullEntity(object inputEntity) {
            if (!(inputEntity is FlexibleTriplet)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.PullEntity() method failed because " +
                    "inputEntity is not an object of FlexibleTriplet type.", GlobalVariables.LogPath);
                return;
            }
            base.PullEntity(inputEntity);
        }

        public override void RemoveEntity(object inputEntity) {
            if (!(inputEntity is FlexibleTriplet)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.RemoveEntity() method failed because " +
                    "inputEntity is not an object of FlexibleTriplet type.", GlobalVariables.LogPath);
                return;
            }
            base.RemoveEntity(inputEntity);
        }

        public override bool AddEntityFromSetByIndex(DataSetClassT1 inputSet, int inputIndex, string mode = "Safe")
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (base.AddEntityFromSetByIndex(inputSet, inputIndex, mode)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.AddEntityFromSetByIndex() method failed because " +
                    "basic check inhereted from parent class returned 'true'.", GlobalVariables.LogPath);
                return true;
            }

            PushEntity(
                new FlexibleTriplet(
                    inputSet.GetAtomByIndex(FieldNames[0], inputIndex),
                    inputSet.GetAtomByIndex(FieldNames[1], inputIndex),
                    inputSet.GetAtomByIndex(FieldNames[2], inputIndex)
                )
            );
            return false;
        }

        public override bool FillFromDataSet(DataSetClassT1 inputSet, string mode = "Safe")
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (base.FillFromDataSet(inputSet, mode)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.FillFromDataSet() method failed because " +
                    "basic check inhereted from parent class returned 'true'.", GlobalVariables.LogPath);
                return true;
            }

            foreach (var i in Enumerable.Range(0, inputSet.GetSize())) {
                AddEntityFromSetByIndex(inputSet, i, "Unsafe");
            }
            return false;
        }

        public override bool ConformWithBucketing(IBucketing inputBucketing) {
            if (base.ConformWithBucketing(inputBucketing)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.TripletStratificationT1.ConformWithBucketing() method failed because " +
                    "basic check was not passed.", GlobalVariables.LogPath);
                return true;
            }

            int index = FieldNames.IndexOf(inputBucketing.GetFieldName()); // !!! may be -1 if element could not be found in the list

            foreach (var i in Stratification) {
                //FlexiblePair tmp = (FlexiblePair)i.Key;// as FlexiblePair?; // Gost 5812-82
                //FlexiblePair tmp2 = tmp == null ? new FlexiblePair() : tmp;
                var tmp = FlexibleTriplet.ConvertTo(i.Key).GetAtomByIndex(index);

                i.Value.Bucket = i.Value.Bucket * inputBucketing.GetNumberOfBuckets() +
                    inputBucketing.GetBucketNumberByElement(tmp);
            } // */ // F***g not nullable types! This shit makes me really unhappy! X(

            return false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of override block
        // Start of local methods definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddNewField(string fieldName, Type fieldType) {
            _AddNewField(fieldName, fieldType);
        } // */ // !!! Testing feature! Should be removed!
    }



    public class QuartetStratificationT1 : AbstractStratificationT1
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Start of constructors\destructors definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public QuartetStratificationT1() {
            FieldNames = new List<string>();
            FieldTypes = new List<Type>();
            Stratification = new Dictionary<object, PairOfIntegers>();
            StrataSizeList = new List<int>();
            QuantityOfStrata = 1;
            QuantityOfElements = 0;
            Checked = false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of constructors\destructors definition block
        // Start of override block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected override void _AddNewField(string fieldName, Type fieldType) {
            if (FieldNames.Count < 4) base._AddNewField(fieldName, fieldType);
            else {
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1._AddNewField() method failed because " +
                    "two fields are already present in the stratification.", GlobalVariables.LogPath);
            }
        }

        public override object GenKeyFromData(object inputData) {
            if (inputData is IndexDataT1Pair) {
                IndexDataT1Pair tmp = inputData as IndexDataT1Pair;
                return new FlexibleQuartet(
                    tmp.Data.GetAtomByIndex(FieldNames[0], tmp.Index), 
                    tmp.Data.GetAtomByIndex(FieldNames[1], tmp.Index),
                    tmp.Data.GetAtomByIndex(FieldNames[2], tmp.Index),
                    tmp.Data.GetAtomByIndex(FieldNames[3], tmp.Index));
                // !!! Very unsafe! Should be revised and enriched with some sort of safety gear
            }
            else {
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.GenKeyFromData() method failed because " +
                    "inputData is not an object of a comprehensible type.", GlobalVariables.LogPath);
                return null; // !!! Probably will cause exception because FlexiblePair/Quartet/Quartet are value types. At least I think they must be
            }
        }

        public override void PushEntity(object inputEntity) {
            if (!(inputEntity is FlexibleQuartet)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.PushEntity() method failed because " +
                    "inputEntity is not an object of FlexibleQuartet type.", GlobalVariables.LogPath);
                return;
            }
            base.PushEntity(inputEntity);
        }

        public override void PullEntity(object inputEntity) {
            if (!(inputEntity is FlexibleQuartet)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.PullEntity() method failed because " +
                    "inputEntity is not an object of FlexibleQuartet type.", GlobalVariables.LogPath);
                return;
            }
            base.PullEntity(inputEntity);
        }

        public override void RemoveEntity(object inputEntity) {
            if (!(inputEntity is FlexibleQuartet)){
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.RemoveEntity() method failed because " +
                    "inputEntity is not an object of FlexibleQuartet type.", GlobalVariables.LogPath);
                return;
            }
            base.RemoveEntity(inputEntity);
        }

        public override bool AddEntityFromSetByIndex(DataSetClassT1 inputSet, int inputIndex, string mode = "Safe")
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (base.AddEntityFromSetByIndex(inputSet, inputIndex, mode)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.AddEntityFromSetByIndex() method failed because " +
                    "basic check inhereted from parent class returned 'true'.", GlobalVariables.LogPath);
                return true;
            }

            PushEntity(
                new FlexibleQuartet(
                    inputSet.GetAtomByIndex(FieldNames[0], inputIndex),
                    inputSet.GetAtomByIndex(FieldNames[1], inputIndex),
                    inputSet.GetAtomByIndex(FieldNames[2], inputIndex),
                    inputSet.GetAtomByIndex(FieldNames[3], inputIndex)
                )
            );
            return false;
        }

        public override bool FillFromDataSet(DataSetClassT1 inputSet, string mode = "Safe")
        // return type turned to bool. The idea is to return 'true' if some error occured. This can be (and probably should be) replaced with exception raise
        {
            if (base.FillFromDataSet(inputSet, mode)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.FillFromDataSet() method failed because " +
                    "basic check inhereted from parent class returned 'true'.", GlobalVariables.LogPath);
                return true;
            }

            foreach (var i in Enumerable.Range(0, inputSet.GetSize())) {
                AddEntityFromSetByIndex(inputSet, i, "Unsafe");
            }
            return false;
        }

        public override bool ConformWithBucketing(IBucketing inputBucketing) {
            if (base.ConformWithBucketing(inputBucketing)) {
                BasicUtilities.UniversalLogger("SampleGenerator2017.QuartetStratificationT1.ConformWithBucketing() method failed because " +
                    "basic check was not passed.", GlobalVariables.LogPath);
                return true;
            }

            int index = FieldNames.IndexOf(inputBucketing.GetFieldName()); // !!! may be -1 if element could not be found in the list

            foreach (var i in Stratification) {
                //FlexiblePair tmp = (FlexiblePair)i.Key;// as FlexiblePair?; // Gost 5812-82
                //FlexiblePair tmp2 = tmp == null ? new FlexiblePair() : tmp;
                var tmp = FlexibleQuartet.ConvertTo(i.Key).GetAtomByIndex(index);

                i.Value.Bucket = i.Value.Bucket * inputBucketing.GetNumberOfBuckets() +
                    inputBucketing.GetBucketNumberByElement(tmp);
            } // */ // F***g not nullable types! This shit makes me really unhappy! X(

            return false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // End of override block
        // Start of local methods definition block
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddNewField(string fieldName, Type fieldType) {
            _AddNewField(fieldName, fieldType);
        } // */ // !!! Testing feature! Should be removed!
    }
}