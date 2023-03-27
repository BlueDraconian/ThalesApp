
using Newtonsoft.Json;
using ThalesApp.Models;

namespace ThalesApp.DataAccess.Employee
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public async Task<List<EmployeeModel>> Get(int id)
        {
            HttpResponseMessage response;
            PluralRoot finalResponse = new PluralRoot();
            using (var client = new HttpClient()) 
            {
                if (id <= 0)
                {
                    response = await client.GetAsync("http://dummy.restapiexample.com/api/v1/employees/");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        finalResponse = JsonConvert.DeserializeObject<PluralRoot>(result);

                    }
                }
                else 
                {
                    response = await client.GetAsync("http://dummy.restapiexample.com/api/v1/employee/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        SingleRoot singleResponseBody = JsonConvert.DeserializeObject<SingleRoot>(result);
                        finalResponse.status = singleResponseBody.status;
                        finalResponse.Message = singleResponseBody.Message;
                        if (singleResponseBody.Data != null)
                        {
                            finalResponse.Data.Add(singleResponseBody.Data);
                        }

                    }
                }
                return finalResponse.Data;
            }
        }
    }
}
