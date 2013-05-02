namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// This class holds a collection of texts for the screen saver.
    /// </summary>
    internal class TextCollection
    {
        /// <summary>
        /// Constructor of the TextCollection.
        /// </summary>
        /// <param name="color">Every text in this collection gets displayed with this given color.</param>
        public TextCollection(Color color)
        {
            this.Color = color;
            this.Items = new List<string>();
        }

        /// <summary>
        /// Color to be used for the items of this TextCollection.
        /// </summary>
        internal Color Color
        {
            get;
            private set;
        }

        /// <summary>
        /// Texts to be displayed by the screen saver.
        /// </summary>
        internal List<string> Items
        {
            get;
            private set;
        }
    }
}
