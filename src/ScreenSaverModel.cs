namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// This class represents the model of the Model-View-Presenter.
    /// </summary>
    internal class ScreenSaverModel
    {
        /// <summary>
        /// Constructor of the ScreenSaverModel class. Loads the configuration from the Windows registry
        /// and the texts from the installation directory.
        /// </summary>
        public ScreenSaverModel()
        {
            this.Interval = 8000;
            this.Font = new System.Drawing.Font("Verdana", 22);
            this.TextCollections = new List<TextCollection>();
        }

        /// <summary>
        /// Interval in milliseconds of changing texts.
        /// </summary>
        internal int Interval
        {
            get;
            private set;
        }

        /// <summary>
        /// Font to be used for displaying the texts.
        /// </summary>
        internal Font Font
        {
            get;
            private set;
        }

        /// <summary>
        /// A list of all (enabled) TextCollections.
        /// </summary>
        internal List<TextCollection> TextCollections
        {
            get;
            private set;
        }
    }
}
