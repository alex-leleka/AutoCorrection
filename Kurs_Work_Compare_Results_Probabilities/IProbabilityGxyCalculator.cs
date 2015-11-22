using System;
using System.Collections;
using System.Diagnostics;

namespace Diplom_Work_Compare_Results_Probabilities
{
    /// <summary>
    /// Ймовірносні характеристики результатів фунції, при зададаних детермінованих спотвореннях на вході.
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

    public struct G4Probability
    {
        /// <summary>
        /// Probabilities of bit value G[real value][expected value].
        /// </summary>
        public double[][] G;

        public G4Probability(Gprobabilites[] p)
        {
            Debug.Assert(p.Length == 2);
            const int resultsCount = 2;//p.Length;
            G = new double[resultsCount][];
            for (int i = 0; i < resultsCount; i++)
            {
                G[i] = new double[resultsCount];
            }

            G[0][0] = 1 - p[0].Gee;
            G[1][0] = p[0].Gee;
            G[1][1] = 1 - p[1].Gee;
            G[0][1] = p[1].Gee;
        }
    }

    public struct BitGprobabilities
    {
        public double[] G0;
        public double[] Gc;
        public double[] Ge;
        public BitGprobabilities(double g00,double gc0,double ge0,double g01, double gc1,double ge1)
        {
            Gc = new double[2];
            Ge = new double[2];
            G0 = new double[2];

            Gc[0] = gc0;
            Gc[1] = gc1;
            Ge[0] = ge0;
            Ge[1] = ge1;
            G0[0] = g00;
            G0[1] = g01;
        }
        public BitGprobabilities(Gprobabilites p0, Gprobabilites p1)
        {
            Gc = new double[2];
            Ge = new double[2];
            G0 = new double[2];

            Gc[0] = p0.Gc + p0.Gce;
            Gc[1] = p1.Gc + p1.Gce;
            Ge[0] = p0.Gee;
            Ge[1] = p1.Gee;
            G0[0] = p0.G0;
            G0[1] = p1.G0;
        }
    }

    public interface IProbabilityGxyCalculator
    {
        Gprobabilites GetGprobabilitesResult(BitArray result);
        int OutputNumberOfDigits();
    }
}
