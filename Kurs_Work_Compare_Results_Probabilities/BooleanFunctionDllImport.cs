using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections;

namespace Diplom_Work_Compare_Results_Probabilities.TruthTable
{
    static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);


        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
    class BooleanFunctionDllImport : BooleanFuntionWithInputDistortion, IDisposable
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int BoolFunction(int numberToMultiply);
        private IntPtr _pDll;
        private BoolFunction _improtedFunction;
        // Track whether Dispose has been called.
        private bool disposed = false;
        public BooleanFunctionDllImport(int inputNumberOfDigits, int outputNumberOfDigits, string dllObjectPath,
            string methodName = "BoolFunction")
            : base(inputNumberOfDigits, outputNumberOfDigits)
        {
            _pDll = NativeMethods.LoadLibrary(dllObjectPath);//@"C:\Users\User\Documents\Visual Studio 2012\Projects\lab5CS\Debug\dllexport.dll");
            // error handling here
            if (_pDll == IntPtr.Zero)
            {
                throw new Exception("DllImport Error! Cann't Load Library!");
            }
            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(_pDll, methodName);
            // error handling here
            if (pAddressOfFunctionToCall == IntPtr.Zero)
            {
                throw new Exception("DllImport Error! Cann't get method address!");
            }

            _improtedFunction = (BoolFunction)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall,
                                                                                    typeof(BoolFunction));
        }

        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            int argument = Convert.ToInt32(index);
            int[] res = new int[1];
            res[0] = _improtedFunction(argument);
            var tempRes = new BitArray(res);
            var result = new BitArray(OutputNumberOfDigits, false);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = tempRes[i];
            }
            return result;
        }
        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");
            int[] array = new int[1];
            operand.CopyTo(array, 0);
            int[] res = new int[1];
            res[0] = _improtedFunction(array[0]);
            var tempRes = new BitArray(res);
            var result = new BitArray(OutputNumberOfDigits, false);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = tempRes[i];
            }
            return result;
        }
        public int GetResult(int operand)
        {
            return _improtedFunction(operand);
        }

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if(disposing)
                {
                    // Dispose managed resources.
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                bool result = NativeMethods.FreeLibrary(_pDll);
                // Note disposing has been done.
                disposed = true;

            }
        }

        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~BooleanFunctionDllImport()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

    }
}
