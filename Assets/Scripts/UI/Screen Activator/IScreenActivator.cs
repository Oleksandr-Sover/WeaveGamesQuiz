
namespace UI
{
    public interface IScreenActivator
    {
        void TurnOnHomeScreen();
        void TurnOnGameScreen();
        void TurnOnResultCongratsScreen();
        void TurnOnResultFailedScreen();
    }
}