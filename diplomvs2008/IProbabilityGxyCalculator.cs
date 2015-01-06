using System;
using System.Collections;

namespace Diplom_Work_Compare_Results_Probabilities
{
    /// <summary>
    /// Ймовірносні характеристики результатів фунції, при зададаних детерміновах спотвореннях на вході.
    /// </summary>
    public struct Gprobabilites
    {
        public double G0;
        public double Gc;
        public double Gce; // E1
        public double Gee; // E2

        public double Sum()
        {
            return G0 + Gc + Gce + Gee;
        }
        public double SumCorrectionAndError()
        {
            return Gc + Gce + Gee;
        }
    }

    public interface IProbabilityGxyCalculator
    {
        Gprobabilites GetGprobabilitesResult(BitArray result);
        int OutputNumberOfDigits();
    }
}
