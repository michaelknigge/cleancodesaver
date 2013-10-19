namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// This is the presenter of the screen saver.
    /// </summary>
    internal class ScreenSaverPresenter : BasePresenter<IScreenSaverView>
    {
        /// <summary>
        /// The ScreenSaverModel contains the configuration and the texts to be displayed be the screen saver.
        /// </summary>
        private ScreenSaverModel model;

        /// <summary>
        /// A generator for random numbers, used to pick a randim TextCollection.
        /// </summary>
        private Random randomForTextCollection = new Random();

        /// <summary>
        /// A generator for random numbers, used to pick a random text with a TextCollection.
        /// </summary>
        private Random randomForText = new Random();

        /// <summary>
        /// Constructor the the ScreenSaverPresenter.
        /// </summary>
        /// <param name="view">The view of the Model-View-Presenter.</param>
        public ScreenSaverPresenter(IScreenSaverView view)
            : base(view)
        {
            this.model = ScreenSaverModelFactory.Create();
        }

        /// <summary>
        /// OnLoad has to be called from the view when the form was loaded.
        /// </summary>
        internal void OnLoad()
        {
            this.View.SetFont(this.model.Font);
            this.UpdateTextOnScreen();
            this.View.StartTimer(this.model.Interval);
        }

        /// <summary>
        /// OnTimeTick has to be called from the view every time the timer has elasped.
        /// </summary>
        internal void OnTimerTick()
        {
            this.UpdateTextOnScreen();
        }

        /// <summary>
        /// Updates the displayed text.
        /// </summary>
        private void UpdateTextOnScreen()
        {
            int collectionIndex = this.randomForTextCollection.Next(Math.Max(0, this.model.TextCollections.Count));
            TextCollection collection = this.model.TextCollections[collectionIndex];

            int textIndex = this.randomForText.Next(Math.Max(0, collection.Items.Count));
            this.View.UpdateText(collection.Color, collection.Items[textIndex]);
        }
    }
}
