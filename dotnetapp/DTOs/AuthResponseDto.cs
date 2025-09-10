namespace dotnetapp.DTOs
{
    public class AuthResponseDto
    {
        public bool Success { get; set; }      // Added Success flag
        public string Message { get; set; }    // Added optional message
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserDto User { get; set; }
    }
}
