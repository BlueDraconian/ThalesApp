namespace ThalesApp.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }

        public string? Employee_Name { get; set; }

        public int Employee_Anual_Salary { get; set; }

        private int _employee_Salary;

        public int Employee_Salary
        {
            get { return _employee_Salary; }
            set 
            {
                if (value > 0)
                {
                    _employee_Salary = value;
                }
                else 
                {
                    _employee_Salary = 0;
                }
                Employee_Anual_Salary = _employee_Salary * 12;
            
            }
        }

        public int Employee_Age { get; set; }

        public string? Profile_Image { get; set; }

    }

    public class Root 
    {
        public string? status { get; set; }
        public string? Message { get; set; }
    }

    public class PluralRoot: Root
    {
        public List<EmployeeModel> Data { get; set; }
        public PluralRoot() { Data = new List<EmployeeModel>(); }
    }

    public class SingleRoot : Root
    {
        public EmployeeModel Data { get; set; }
    }
}
