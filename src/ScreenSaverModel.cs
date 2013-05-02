namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

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

            // TODO Default-Font --> dependant to operating system:
            //         Windows XP -> Arial
            //         Windows Vista --> Verdana? Lucida Console?
            //         Windows 7 --> Verdana? Lucida Console?

            this.Font = new System.Drawing.Font("Segoe UI", 22);
            //this.Font = new System.Drawing.Font("Lucida Console", 22);
            this.TextCollections = new List<TextCollection>();

            TextCollection red = new TextCollection(Color.Red);
            red.Items.Add("Don´t Repeat Yourself (DRY)\nJede Doppelung von Code oder auch nur Handgriffen leistet Inkonsistenzen und Fehlern Vorschub.");
            red.Items.Add("Keep it simple, stupid (KISS)\nWer mehr tut als das Einfachste, lässt den Kunden warten und macht die Lösung unnötig kompliziert.");
            red.Items.Add("Vorsicht vor Optimierungen!\nOptimierungen kosten immer viel Aufwand. Wer Vorsicht walten lässt, spart oft wertvolle Ressourcen für das, was dem Kunden wirklich nützt.");
            red.Items.Add("Favour Composition over Inheritance (FCoI)\nKomposition fördert die lose Kopplung und die Testbarkeit eines Systems und ist oft flexibler.");
            red.Items.Add("Die Pfadfinderregel beachten\nJede Beschäftigung mit einem Gegenstand macht ihn zumindest ein klein wenig besser.");
            red.Items.Add("Root Cause Analysis\nSymptome behandeln bringt vielleicht schnell eine Linderung – langfristig kostet es aber mehr Aufwand. Wer stattdessen unter die Oberfläche von Problemen schaut, arbeitet am Ende effizenter.");
            red.Items.Add("Ein Versionskontrollsystem einsetzen\nAngst vor Beschädigung eines \"running system\" lähmt die Softwareentwicklung. Mit einer Versionsverwaltung ist solche Angst unbegründet. Die Entwicklung kann schnell und mutig voranschreiten.");
            red.Items.Add("Einfache Refaktorisierungsmuster anwenden\nCode verbessern ist leichter, wenn man typische Verbesserungshandgriffe kennt. Ihre Anwendungsszenarien machen sensibel für Schwachpunkte im eigenen Code. Als anerkannte Muster stärken sie den Mut, sie anzuwenden.");
            red.Items.Add("Täglich reflektieren\nKeine Verbesserung, kein Fortschritt, kein Lernen ohne Reflexion. Aber nur, wenn Reflexion auch eingeplant wird, findet sie unter dem Druck des Tagesgeschäftes auch statt.");

            TextCollection orange = new TextCollection(Color.Orange);
            orange.Items.Add("Single Level of Abstraction (SLA)\nDie Einhaltung eines Abstraktionsniveaus fördert die Lesbarkeit.");
            orange.Items.Add("Single Responsibility Principle (SRP)\nFokus erleichtert das Verständnis. Eine Klasse mit genau einer Aufgabe ist verständlicher als ein Gemischtwarenladen.");
            orange.Items.Add("Separation of Concerns (SoC)\nWenn eine Codeeinheit keine klare Aufgabe hat ist es schwer sie zu verstehen, sie anzuwenden und sie ggf. zu korrigieren oder zu erweitern.");
            orange.Items.Add("Source Code Konventionen\nCode wird häufiger gelesen als geschrieben. Daher sind Konventionen wichtig, die ein schnelles Lesen und Erfassen des Codes unterstützen.");
            orange.Items.Add("Issue Tracking\nNur, was man aufschreibt, vergisst man nicht und kann man effektiv delegieren und verfolgen.");
            orange.Items.Add("Automatisierte Integrationstests\nIntegrationstests stellen sicher dass der Code tut was er soll. Diese wiederkehrende Tätigkeit nicht zu automatisieren wäre Zeitverschwendung.");
            orange.Items.Add("Lesen, Lesen, Lesen\nLesen bildet!");
            orange.Items.Add("Reviews\nVier Augen sehen mehr als zwei. Wenn der eine Entwickler dem anderen seinen Code erklärt, tauchen meist Details auf, die bislang nicht bedacht wurden.");

            TextCollection yellow = new TextCollection(Color.Yellow);
            yellow.Items.Add("Interface Segregation Principle (ISP)\nLeistungsbeschreibungen, die unabhängig von einer konkreten Erfüllung sind, machen unabhängig.");
            yellow.Items.Add("Dependency Inversion Principle\nPunktgenaues Testen setzt Isolation von Klassen voraus. Isolation entsteht, wenn Klassen keine Abhängigkeiten von Implementationen mehr enthalten – weder zur Laufzeit, noch zur Übersetzungszeit. Konkrete Abhängigkeiten sollten deshalb so spät wie möglich entschieden werden. Am besten zur Laufzeit.");
            yellow.Items.Add("Liskov Substitution Principle\nWer mit Erben zu tun hat, möchte keine Überraschungen erleben, wenn er mit Erblassern vertraut ist.");
            yellow.Items.Add("Principle of Least Astonishment\nWenn sich eine Komponente überraschenderweise anders verhält als erwartet, wird ihre Anwendung unnötig kompliziert und fehleranfällig.");
            yellow.Items.Add("Information Hiding Principle\nDurch das Verbergen von Details in einer Schnittstelle werden die Abhängigkeiten reduziert.");
            yellow.Items.Add("Automatisierte Unit Tests\nNur automatisierte Tests werden auch wirklich konsequent ausgeführt. Je punktgenauer sie Code testen, desto besser.");
            yellow.Items.Add("Mockups (Testattrappen)\nOhne Attrappen keine einfach kontrollierbaren Tests.");
            yellow.Items.Add("Code Coverage Analyse\nTraue nur Tests, von denen du weißt, dass sie auch wirklich das Testareal abdecken.");
            yellow.Items.Add("Teilnahme an Fachveranstaltungen\nAm besten lernen wir von anderen und in Gemeinschaft.");
            yellow.Items.Add("Komplexe Refaktorisierungen\nEs ist nicht möglich, Code direkt in der ultimativen Form zu schreiben.");

            TextCollection green = new TextCollection(Color.LightGreen);
            green.Items.Add("Open Closed Principle\nWeil das Risiko, durch neue Features ein bisher fehlerfreies System zu instabilisieren, so gering wie möglich gehalten werden sollte.");
            green.Items.Add("Tell, don´t ask\nHohe Kohäsion und lose Kopplung sind Tugenden. Öffentliche Zustandsdetails einer Klasse widersprechen dem.");
            green.Items.Add("Law of Demeter\nAbhängigkeiten von Objekten über mehrere Glieder einer Dienstleistungskette hinweg führen zu unschön enger Kopplung.");
            green.Items.Add("Continuous Integration\nAutomatisierung und Zentralisierung der Softwareproduktion machen produktiver und reduzieren das Risiko von Fehlern bei der Auslieferung.");
            green.Items.Add("Statische Codeanalyse (Metriken)\nVertrauen ist gut, Kontrolle ist besser - und je automatischer, desto leichter ist sie.");
            green.Items.Add("Inversion of Control Container\nNur, was nicht fest verdrahtet ist, kann leichter umkonfiguriert werden.");
            green.Items.Add("Erfahrung weitergeben\nWer sein Wissen weitergibt, hilft nicht nur anderen, sondern auch sich selbst.");
            green.Items.Add("Messen von Fehlern\nNur wer weiß, wie viele Fehler auftreten, kann sein Vorgehen so verändern, dass die Fehlerrate sinkt.");

            TextCollection blue = new TextCollection(Color.LightBlue);
            blue.Items.Add("Entwurf und Implementation überlappen nicht\nPlanungsunterlagen, die mit der Umsetzung nichts mehr gemein haben, schaden mehr, als dass sie nützen. Deshalb nicht die Planung aufgeben, sondern die Chance auf Inkonsistenz minimieren.");
            blue.Items.Add("Implementation spiegelt Entwurf\nUmsetzung, die von der Planung beliebig abweichen kann, führt direkt in die Unwartbarkeit. Umsetzung braucht daher einen durch die Planung vorgegebenen physischen Rahmen.");
            blue.Items.Add("You Ain´t Gonna Need It (YAGNI)\nDinge die niemand braucht, haben keinen Wert. Verschwende an sie also keine Zeit.");
            blue.Items.Add("Continuous Delivery\nAls Clean Code Developer möchte ich sicher sein, dass ein Setup das Produkt korrekt installiert. Wenn ich das erst beim Kunden herausfinde, ist es zu spät.");
            blue.Items.Add("Iterative Entwicklung\nWarum? Frei nach von Clausewitz: Kein Entwurf, keine Implementation überlebt den Kontakt mit dem Kunden. Softwareentwicklung tut daher gut daran, ihren Kurs korrigieren zu können.");
            blue.Items.Add("Komponentenorientierung\nSoftware braucht Black-Box-Bausteine, die sich parallel entwickeln und testen lassen. Das fördert Evolvierbarkeit, Produktivität und Korrektheit.");
            blue.Items.Add("Test first\nDer Kunde ist König und bestimmt die Form einer Dienstleistung. Service-Implementationen sind also nur passgenau, wenn sie durch einen Client getrieben werden.");

            this.TextCollections.Add(red);
            this.TextCollections.Add(orange);
            this.TextCollections.Add(yellow);
            this.TextCollections.Add(green);
            this.TextCollections.Add(blue);
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
