namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// This static class creates the ScreenSaverModel.
    /// </summary>
    internal static class ScreenSaverModelFactory
    {
        /// <summary>
        /// Creates the ScreenSaverModel. The text collections are created from a XML configuration file.
        /// </summary>
        /// <returns>A ready to use ScreenSaverModel.</returns>
        public static ScreenSaverModel Create()
        {
            ScreenSaverModel model = new ScreenSaverModel();
            List<TextCollection> collections = model.TextCollections;

            XmlDocument doc = new XmlDocument();

            try 
            {
                doc.Load(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CleanCodeSaver.xml"));

                foreach (XmlNode textCollection in doc.SelectNodes("/configuration/textCollection"))
                {
                    string colorAttr = textCollection.Attributes["color"].Value;
                    Color color = System.Drawing.ColorTranslator.FromHtml(colorAttr);
                    TextCollection collection = new TextCollection(color);

                    foreach (XmlNode entry in textCollection.SelectNodes("entry"))
                        collection.Items.Add(entry.Attributes["caption"].Value + "\n\n" + entry.Attributes["text"].Value);

                    collections.Add(collection);
                }
            }
            catch (System.Exception e)
            {
                collections.Clear();
                TextCollection errorCollection = new TextCollection(Color.Red);
                errorCollection.Items.Add("--- ERROR ---\n\n" + e.Message);
                collections.Add(errorCollection);
            }

            return model;
        }
    }
}
