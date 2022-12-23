using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views.InputMethods;
using Android.Views;
using static Android.Views.ViewTreeObserver;
using AView = Android.Views.View;

namespace ScrollNFocus;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity, IOnGlobalFocusChangeListener
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        ViewTreeObserver observer = Window.DecorView.ViewTreeObserver;

        observer.AddOnGlobalFocusChangeListener(this);
        //observer.AddOnScrollChangedListener(this);
    }

    void FocusChanged(object sender, GlobalFocusChangeEventArgs e)
    {

        if (e.NewFocus is null && e.OldFocus is not null)
        {
            InputMethodManager imm = InputMethodManager.FromContext(this);

            IBinder wt = e.OldFocus.WindowToken;

            if (imm is null || wt is null)
                return;

            imm.HideSoftInputFromWindow(wt, HideSoftInputFlags.None);
        }
    }

    public override bool OnTouchEvent(MotionEvent e)
    {
        if (CurrentFocus is not null)
            CurrentFocus.ClearFocus();

        return base.OnTouchEvent(e);
    }

    void IOnGlobalFocusChangeListener.OnGlobalFocusChanged(AView oldFocus, AView newFocus)
    {
        if (newFocus is null && oldFocus is not null)
        {
            InputMethodManager imm = InputMethodManager.FromContext(this);

            IBinder wt = oldFocus.WindowToken;

            if (imm is null || wt is null)
                return;

            imm.HideSoftInputFromWindow(wt, HideSoftInputFlags.None);
        }
    }
}
