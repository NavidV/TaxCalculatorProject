namespace DataService.APIProject.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccessfull { get; set; } = true;
        public object Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ErrorMessages { get; set; }
    }
}
