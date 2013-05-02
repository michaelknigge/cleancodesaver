namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Drawing;

    /// <summary>
    /// This interface defines the view for the screen saver.
    /// </summary>
    internal interface IScreenSaverView
    {
        /// <summary>
        /// Starts the timer. 
        /// </summary>
        /// <param name="interval">Interval of timer in msec.</param>
        void StartTimer(int interval);

        /// <summary>
        /// Sets the font to be used for displaying the rules.
        /// </summary>
        /// <param name="font">The font to be used for the text on the screen.</param>
        void SetFont(Font font);

        /// <summary>
        /// Updates the position, color and text of the currently shown text.
        /// </summary>
        /// <param name="color">The color of the text.</param>
        /// <param name="text">The text to be shown.</param>
        void UpdateText(Color color, string text);
    }
}
