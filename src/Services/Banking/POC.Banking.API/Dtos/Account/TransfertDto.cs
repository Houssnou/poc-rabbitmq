namespace POC.Banking.API.Dtos.Account
{
    public class TransfertDto
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount  { get; set; }
    }
}
