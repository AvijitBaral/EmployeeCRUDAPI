namespace EmployeeCRUDAPI.Model
{
    public class ResponseModel<T>
    {
        public T ? Result { get; set; }
        public int ? Statuscode { get; set; } = 200;
        public string ? StatusMessage { get; set; }
    }
}
