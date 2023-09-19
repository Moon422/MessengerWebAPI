namespace MessengerWebAPI.ViewModels
{
    public class LoginResponseViewModel
    {
        public string JwtToken { get; set; }
        public ShowUserViewModel User { get; set; }
    }
}
