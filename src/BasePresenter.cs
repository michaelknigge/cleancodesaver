namespace MK.CleanCodeSaver.Core
{
    using System;

    /// <summary>
    /// This is the base class of all our presenters.
    /// </summary> 
    /// <typeparam name="T">The type of the view.</typeparam>
    internal abstract class BasePresenter<T>
    {
        /// <summary>
        /// Constructor of the BasePresenter. Just takes the view of the Model-View-Presenter.
        /// </summary>
        /// <param name="view">The view of the Model-View-Presenter.</param>
        public BasePresenter(T view)
        {
           this.View = view;
        }

        /// <summary>
        /// The view of the Model-View-Presenter.
        /// </summary>
        internal T View
        {
            get;
            private set;
        }
    }
}
