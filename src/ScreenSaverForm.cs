namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Microsoft.Win32;

    /// <summary>
    /// This is the screensaver.
    /// </summary> 
    internal partial class ScreenSaverForm : Form, IScreenSaverView
    {
        /// <summary>
        /// The presenter of this form.
        /// </summary>
        private ScreenSaverPresenter presenter;

        /// <summary>
        /// The current mouse location.
        /// </summary>
        private Point mouseLocation;

        /// <summary>
        /// true if and only the screensaver was started in preview mode.
        /// </summary>
        private bool previewMode = false;

        /// <summary>
        /// A generator for random numbers.
        /// </summary>
        private Random rand = new Random();

        /// <summary>
        /// Default constructor the the ScreenSaverForm.
        /// </summary>
        public ScreenSaverForm()
        {
            this.InitializeComponent();
            this.presenter = new ScreenSaverPresenter(this);
            Cursor.Hide();
        }

        /// <summary>
        /// Constructor the the ScreenSaverForm that is used for running the screensaver in full screen mode.
        /// </summary>
        /// <param name="bounds">Specifies the size of the form (full screen).</param>
        public ScreenSaverForm(Rectangle bounds)
            : this()
        {
            this.Bounds = bounds;
        }

        /// <summary>
        /// Constructor the the ScreenSaverForm that is used for running the screensaver in preview mode.
        /// </summary>
        /// <param name="previewWindow">Parent window handle.</param>
        public ScreenSaverForm(IntPtr previewWindow)
            : this()
        {
            // Set the preview window as the parent of this window
            NativeMethods.SetParent(this.Handle, previewWindow);

            // Make this a child window so it will close when the parent dialog closes
            NativeMethods.SetWindowLong(this.Handle, (int) GWL.STYLE, new IntPtr(NativeMethods.GetWindowLong(this.Handle, (int) GWL.STYLE) | (int) WindowStyles.WS_CHILD));

            // Place our window inside the parent
            Rectangle parentRect;
            NativeMethods.GetClientRect(previewWindow, out parentRect);
            Size = parentRect.Size;
            Location = new Point(0, 0);

            this.previewMode = true;
        }

        /// <summary>
        /// Starts the timer. 
        /// </summary>
        /// <param name="interval">Interval of timer in msec.</param>
        public void StartTimer(int interval)
        {
            this.moveTimer.Interval = interval;
            this.moveTimer.Tick += new EventHandler(this.OnTimerTick);
            this.moveTimer.Start();
        }

        /// <summary>
        /// Sets the font to be used for displaying the rules.
        /// </summary>
        /// <param name="font">The font to be used for the displayed texts.</param>
        public void SetFont(Font font)
        {
            this.textLabel.Font = font;
        }

        /// <summary>
        /// Updates the position, color and text of the currently shown text.
        /// </summary>
        /// <param name="color">The color to be used for the text.</param>
        /// <param name="text">The text to be displayed.</param>
        public void UpdateText(Color color, string text)
        {
            this.textLabel.ForeColor = color;
            this.textLabel.Text = text;
            this.textLabel.Left = this.rand.Next(Math.Max(1, this.Bounds.Width - this.textLabel.Width));
            this.textLabel.Top = this.rand.Next(Math.Max(1, this.Bounds.Height - this.textLabel.Height));
        }

        /// <summary>
        /// Load the configuration and intitializes the screensaver.
        /// </summary>
        /// <param name="sender">Sender of this event.</param>
        /// <param name="e">Arguments of thie event.</param>
        private void OnLoad(object sender, EventArgs e)
        {
            this.presenter.OnLoad();
        }

        /// <summary>
        /// Moves the text to a new location.
        /// </summary>
        /// <param name="sender">Sender of this event.</param>
        /// <param name="e">Arguments of thie event.</param>
        private void OnTimerTick(object sender, System.EventArgs e)
        {
            this.presenter.OnTimerTick();
        }

        /// <summary>
        /// Gets the current mouse position. If the position was changed by more than 5 pixels (horizontally
        /// or vertically) the screensaver ends.
        /// </summary>
        /// <param name="sender">Sender of this event.</param>
        /// <param name="e">Arguments of thie event.</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!this.previewMode)
            {
                if (!this.mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance
                    if (Math.Abs(this.mouseLocation.X - e.X) > 5 ||
                        Math.Abs(this.mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }

                // Update current mouse location
                this.mouseLocation = e.Location;
            }
        }

        /// <summary>
        /// Ends the screensaver.
        /// </summary>
        /// <param name="sender">Sender of this event.</param>
        /// <param name="e">Arguments of thie event.</param>
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.previewMode)
                Application.Exit();
        }

        /// <summary>
        /// Ends the screensaver.
        /// </summary>
        /// <param name="sender">Sender of this event.</param>
        /// <param name="e">Arguments of thie event.</param>
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (!this.previewMode)
                Application.Exit();
        }
    }
}
