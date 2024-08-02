using System;
using System.Windows.Forms;

namespace GoatForms
{
    /// <summary>
    /// A specialized <see cref="UserControl"/> for creating a web browser control with a simple user interface.
    /// </summary>
    /// <remarks>
    /// This control provides a basic web browser with navigation and refresh functionalities,
    /// including a back button, forward button, refresh button, and an address bar.
    /// </remarks>
    public class WebBrowserControl : UserControl
    {
        private WebBrowser webBrowser;
        private TextBox addressBar;
        private Button backButton;
        private Button forwardButton;
        private Button refreshButton;
        private Button goButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserControl"/> class.
        /// </summary>
        /// <remarks>
        /// Sets up the components of the control, including the web browser, address bar,
        /// and navigation buttons. Configures event handlers for the buttons to perform
        /// web browsing actions such as navigating back, forward, refreshing, and going to a URL.
        /// </remarks>
        public WebBrowserControl()
        {
            InitializeComponents();
        }

        /// <summary>
        /// Initializes the components of the <see cref="WebBrowserControl"/>.
        /// </summary>
        /// <remarks>
        /// Configures the layout of the web browser, address bar, and navigation buttons
        /// within the control. Sets up event handlers for button clicks to interact with
        /// the web browser.
        /// </remarks>
        private void InitializeComponents()
        {
            webBrowser = new WebBrowser { Dock = DockStyle.Fill };
            addressBar = new TextBox { Dock = DockStyle.Top, Width = 300 };
            backButton = new Button { Text = "Back" };
            forwardButton = new Button { Text = "Forward" };
            refreshButton = new Button { Text = "Refresh" };
            goButton = new Button { Text = "Go" };

            backButton.Click += (s, e) => webBrowser.GoBack();
            forwardButton.Click += (s, e) => webBrowser.GoForward();
            refreshButton.Click += (s, e) => webBrowser.Refresh();
            goButton.Click += (s, e) => webBrowser.Navigate(addressBar.Text);

            FlowLayoutPanel panel = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };
            panel.Controls.Add(backButton);
            panel.Controls.Add(forwardButton);
            panel.Controls.Add(refreshButton);
            panel.Controls.Add(addressBar);
            panel.Controls.Add(goButton);

            Controls.Add(webBrowser);
            Controls.Add(panel);
        }

        /// <summary>
        /// Navigates the web browser to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        /// <remarks>
        /// Sets the address bar text to the specified URL and navigates the web browser to it.
        /// </remarks>
        public void Navigate(string url)
        {
            webBrowser.Navigate(url);
            addressBar.Text = url;
        }
    }
}
