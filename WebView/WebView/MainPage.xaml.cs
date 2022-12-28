namespace WebView;

public partial class MainPage : ContentPage
{

    string currentUrl = "";
    public MainPage()
    {
        InitializeComponent();

        var current = Connectivity.NetworkAccess;

        if (current != NetworkAccess.Internet)
        {
            DisplayAlert("", "No Internet Connection", "Ok");
            return;
        }

        wbview.Source = "https://syndi365.info/";
    }

    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        busyIndi.IsVisible = true;
    }

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        currentUrl = e.Url;
        busyIndi.IsVisible = false;
    }

    protected override bool OnBackButtonPressed()
    {

        if (wbview.CanGoBack)
        {
            wbview.GoBack();
            return true;
        }

        else
        {

            if (currentUrl.Contains("https://syndi365.info/"))
            {
                Dispatcher.Dispatch(async () => {
                    bool a = await DisplayAlert("", "Exit?", "Ok", "Cancel");
                    if (a)
                    {
                        System.Environment.Exit(0);
                    }

                });
                return true;
            }
            else
            {
                wbview.Source = "https://syndi365.info/";
                return true;
            }

        }


    }


}

