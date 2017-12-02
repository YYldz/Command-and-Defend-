using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Proj5_byYakupY
{
    /*
     * Denna manager innehåller alla texturer för spelet.
     * De skapas som en property så att de kan användas i
     * hela projektet.
     */
    static class TextureManager
    {
        // Byggnader
        public static Texture2D PillBoxTexture { get; private set; }
        public static Texture2D ObeliskTexture { get; private set; }
        public static Texture2D SiloTexture { get; private set; }

        // Fiender
        public static Texture2D Soldier { get; private set; }
        public static Texture2D Commando { get; private set; }

        // Övrigt
        public static Texture2D Background { get; private set; }
        public static Texture2D RtBackground { get; private set; }
        public static Texture2D HealthBar { get; private set; }

        public static Texture2D ObeliskButton { get; private set; }
        public static Texture2D PillboxButton { get; private set; }
        public static Texture2D SiloButton { get; private set; }
        public static Texture2D MenuButtonOne { get; private set; }
        public static Texture2D MenuButtonTwo { get; private set; }

        public static Texture2D Dot { get; private set; }

        // Upgrades
        public static Texture2D PillboxUpOne { get; private set; }
        public static Texture2D PillboxUpTwo { get; private set; }

        public static Texture2D ToolTipPillbox { get; private set; }
        public static Texture2D ToolTipObelisk { get; private set; }
        public static Texture2D ToolTipSilo { get; private set; }
        public static Texture2D ToolTipUpgradeOne { get; private set; }
        public static Texture2D ToolTipUpgradeTwo { get; private set; }

        public static Texture2D Button { get; private set; }

        public static Texture2D MenuBackground { get; private set; }
        public static void LoadContent(ContentManager content)
        {
            // Byggnader
            PillBoxTexture = content.Load<Texture2D>(@"Buildings/pillbox");
            ObeliskTexture = content.Load<Texture2D>(@"Buildings/obelisk");
            SiloTexture = content.Load<Texture2D>(@"Buildings/silo");

            // Fiender
            Soldier = content.Load<Texture2D>(@"Enemies/gdi");
            Commando = content.Load<Texture2D>(@"Enemies/gdi2");

            // Övrigt
            Background = content.Load<Texture2D>(@"Misc/background");
            RtBackground = content.Load<Texture2D>(@"Misc/rt");
            MenuBackground = content.Load<Texture2D>(@"Misc/splash");
            HealthBar = content.Load<Texture2D>(@"Misc/hpbar");
            ObeliskButton = content.Load<Texture2D>(@"Buildings/obeliskIcon");
            PillboxButton = content.Load<Texture2D>(@"Buildings/pboxIcon");
            SiloButton = content.Load<Texture2D>(@"Buildings/siloIcon");
            PillboxUpOne = content.Load<Texture2D>(@"Buildings/pboxSpdIcon");
            PillboxUpTwo = content.Load<Texture2D>(@"Buildings/pboxDMGIcon");
            ToolTipPillbox = content.Load<Texture2D>(@"Misc/Price1");
            ToolTipObelisk = content.Load<Texture2D>(@"Misc/Price2");
            ToolTipSilo = content.Load<Texture2D>(@"Misc/Price3");
            ToolTipUpgradeOne = content.Load<Texture2D>(@"Misc/Price4");
            ToolTipUpgradeTwo = content.Load<Texture2D>(@"Misc/Price5");

            MenuButtonOne = content.Load<Texture2D>(@"Misc/splashbutton");
            MenuButtonTwo = content.Load<Texture2D>(@"Misc/splashbutton2");
            Constants.TextureList.Add(content.Load<Texture2D>(@"Misc/particle1"));
            //Constants.textureList.Add(content.Load<Texture2D>(@"Misc/particle2"));
            Constants.TextureList.Add(content.Load<Texture2D>(@"Misc/particle3"));

            Dot = content.Load<Texture2D>(@"Misc/whitePixel");

            Button = content.Load<Texture2D>(@"Misc/trans");

        }
    }
}
