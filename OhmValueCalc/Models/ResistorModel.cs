using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmValueCalc.Models
{
    public class ResistorModel
    {

        /*
         * 
        None	–	–	–	–	±20	M	–
        Pink	PK	3015	–	×10−3[3]	×0.001	–	–
        Silver	SR	–	–	    ×10−2	×0.01	±10	K	–
        Gold	GD	–	–	    ×10−1	×0.1	±5	J	–
        Black	BK	9005	0	×100	×1	–	250	U
        Brown	BN	8003	1	×101	×10	±1	F	100	S
        Red	RD	3000	2	×102	×100	±2	G	50	R
        Orange	OG	2003	3	×103	×1000	±0.05[3]	W	15	P
        Yellow	YE	1021	4	×104	×10000	±0.02[3][nb 1][5]	P	25	Q
        Green	GN	6018	5	×105	×100000	±0.5	D	20	Z[nb 2]
        Blue	BU	5015	6	×106	×1000000	±0.25	C	10	Z[nb 2]
        Violet	VT	4005	7	×107	×10000000	±0.1	B	5	M
        Grey	GY	7000	8	×108	×100000000	±0.01[3][nb 3][nb 1][5]	L (A)	1	K
        White	WH	1013	9	×109	×1000000000	         * 
         * 
         */

        public string bandAColor { get; set; }
        public string bandBColor { get; set; }
        public string bandCColor { get; set; }
        public string bandDColor { get; set; }


        public static string CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            //Int32 intOhms = 0;
            double dblOhms = 0;
            string ohmString = "ohms";

            // for testing, just use numbers 0 to 9
            // for production, use CSS color name strings

            try
            {
                double tens = 10 * GetSigFigureFromColor(bandAColor);
                double ones = 1 * GetSigFigureFromColor(bandBColor);
                double mult = GetMultiplierFromColor(bandCColor);

                dblOhms = (tens + ones) * mult;
                //intOhms = (Int32)dblOhms;

                if (dblOhms == 1) ohmString = "ohm";

            } 
            catch(Exception ex)
            {

            }

            return dblOhms.ToString("#,###,###,###,##0.######") + " " + ohmString;
        }

        public static double GetSigFigureFromColor(string colorName)
        {
            double result = 0;

            if (colorName == "black") result = 0;
            if (colorName == "brown") result = 1;
            if (colorName == "red") result = 2;
            if (colorName == "orange") result = 3;
            if (colorName == "yellow") result = 4;
            if (colorName == "green") result = 5;
            if (colorName == "blue") result = 6;
            if (colorName == "violet") result = 7;
            if (colorName == "gray") result = 8;
            if (colorName == "white") result = 9;

            return result;
        }

        public static double GetMultiplierFromColor(string colorName)
        {
            float result = 0;

            if (colorName == "pink") result = 0.001f;
            if (colorName == "silver") result = 0.01f;
            if (colorName == "gold") result = 0.1f;

            if (colorName == "black") result  = 1f;
            if (colorName == "brown") result  = 10f;
            if (colorName == "red") result    = 100f;
            if (colorName == "orange") result = 1000f;
            if (colorName == "yellow") result = 10000f;
            if (colorName == "green") result  = 100000f;
            if (colorName == "blue") result   = 1000000f;
            if (colorName == "violet") result = 10000000f;
            if (colorName == "gray") result   = 100000000f;
            if (colorName == "white") result  = 1000000000f;

            return result;
        }

        public static string CalculateToleranceValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {

            float result = 20;

            if (bandDColor == "none") result = 20f;

            if (bandDColor == "silver") result = 10f;
            if (bandDColor == "gold") result = 5f;

            if (bandDColor == "brown") result = 1f;
            if (bandDColor == "red") result = 2f;
            if (bandDColor == "orange") result = 0.05f;
            if (bandDColor == "yellow") result = 0.2f;
            if (bandDColor == "green") result = 0.5f;
            if (bandDColor == "blue") result = 0.25f;
            if (bandDColor == "violet") result = 0.1f;
            if (bandDColor == "gray") result = 0.01f;

            return result.ToString() + "% tolerance";
        }

    }

}
 