using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Proj5_byYakupY
{
    static class Constants
    {
        /* Denna class innehåller statiska variabler som t.ex.
        /* fönsterstorlek som behövs i projektet men inte riktigt
         * hör till SuperClassen eller liknande.
         */

        // Skapa listorna för spelet.
        // Lista för byggnader
        public static List<Building> BuildingList = new List<Building>();
        // Lista för fiender
        public static List<Enemy> EnemyList = new List<Enemy>();
        // Övriga listor
        public static List<Texture2D> TextureList = new List<Texture2D>();
        public static List<Explosion> ExplosionList = new List<Explosion>();
      
        // Backgroundlayern sätts efter screenWidth och screenHeight

        // Värden som anger spelfönstrets storlek
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 960;

        // Storleken på torn & fiender (ja, dessa är olika)
        public static int TowerSize = 45;
        public static int EnemySize = 30;

        // Credits för spelaren & hp på Construction Yard
        public static int Credits;
        public static int cYardHp;
        public static int BountyCounter = 2;
        public static int WaveKilled;

        // Övrigt
        public static int siloCounter = 0;

    }
}
