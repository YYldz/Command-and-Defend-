using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Proj5_byYakupY
{
    /*
     * Här laddar jag in menytexturer och annan media
     * som ljud och video.
     */
    static class MediaHandler
    {
        public static SpriteFont myFont;

        public static Song Aoi { get; private set; }

        public static SoundEffect mGun { get; private set; }
        public static SoundEffect ObeliskBeamSound { get; private set; }
        public static SoundEffect sGun { get; private set; }
        public static SoundEffect Sell { get; private set; }
        public static SoundEffect Click { get; private set; }
        public static SoundEffect Build { get; private set; }
        public static SoundEffect ErrorSnd { get; private set; }
        public static SoundEffect CreditPlus { get; private set; }
        public static SoundEffect Cancel { get; private set; }

        public static void LoadContent(ContentManager content)
        {
            myFont = content.Load<SpriteFont>(@"Misc/font");
            Aoi = content.Load<Song>(@"Media/aoi");
            mGun = content.Load<SoundEffect>(@"Media/chaingn1");
            ObeliskBeamSound = content.Load<SoundEffect>(@"Media/obelray1");
            sGun = content.Load<SoundEffect>(@"Media/silencer");
            Sell = content.Load<SoundEffect>(@"Media/cashturn");
            Click = content.Load<SoundEffect>(@"Media/clicky1");
            Build = content.Load<SoundEffect>(@"Media/place2");
            ErrorSnd = content.Load<SoundEffect>(@"Media/scold8");
            CreditPlus = content.Load<SoundEffect>(@"Media/credup1");
            Cancel = content.Load<SoundEffect>(@"Media/emblem");
        }
    }
}
