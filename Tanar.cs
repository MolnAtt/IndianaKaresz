using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Karesz
{
    public partial class Form1 : Form
    {
        string betöltendő_pálya = "indiana.txt";

        Random r = new Random();

        void TANÁR_ROBOTJAI()
        {
            Betölt("indiana.txt");

            new Robot("Karesz", 0, 0, 0, 0, 0, 7 + r.Next(-2, 3), 14 + r.Next(-2, 3), 1);

            bool koponya_a_helyen_van = true;


            // BALTÁK


            Robot balta1 = new Robot("Első balta", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 13, 14 - r.Next(-1,4), r.Next(2) * 2);

            balta1.Feladat = delegate ()
            {
                Faltol_falig_ingazik(balta1, ref koponya_a_helyen_van);
                Kavicsra_parkol(balta1);
            };

            Robot balta2 = new Robot("Második balta", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 16, 14-r.Next(-3,2), r.Next(2) * 2);

            balta2.Feladat = delegate ()
            {
                Faltol_falig_ingazik(balta2, ref koponya_a_helyen_van);
                Kavicsra_parkol(balta2);
            };

            Robot balta3 = new Robot("Harmadik balta", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 19, 14 - r.Next(-4,1), 2);

            balta3.Feladat = delegate ()
            {
                Faltol_falig_ingazik(balta3, ref koponya_a_helyen_van);
                Kavicsra_parkol(balta3);
            };


            // KŐGOLYÓ

            Robot kőgolyó = new Robot("Kőgolyó", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 35, 14, 3);

            kőgolyó.Feladat = delegate ()
            {
                while (koponya_a_helyen_van)
                {
                    if (pálya.MiVanItt(new Vektor(33, 14)) != sárga)
                        koponya_a_helyen_van = false;
                    kőgolyó.Várj();
                }
                while (!kőgolyó.Ki_fog_lépni_a_pályáról())
                    kőgolyó.Lépj();
            };
        }

        private void Kavicsra_parkol(Robot balta)
		{
            while(!balta.Előtt_fal_van() && !balta.Alatt_van_kavics())
			{
                balta.Lépj();
				if (balta.Előtt_fal_van())
				{
                    balta.Fordulj(jobbra);
                    balta.Fordulj(jobbra);
                }
            }
		}

		private void Faltol_falig_ingazik(Robot balta, ref bool koponya_a_helyen_van)
		{
            while (koponya_a_helyen_van)
			{
                while (!balta.Előtt_fal_van())
                    balta.Lépj();
                balta.Fordulj(jobbra);
                balta.Fordulj(jobbra);
			}
        }
    }
}