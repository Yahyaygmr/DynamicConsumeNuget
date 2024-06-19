# Dynamic Consume
## Purpose



This package was prepared to eliminate the code confusion experienced when consuming the API in a .Net Core application.


## Installation

You can add the package to your project via the Nuget package manager or cli

```sh
dotnet add package DynamicConsume --version 2.0.1
```

## Usage

After installing the package, you must first register for the service in the Program.cs file.

```sh
builder.Services.AddDynamicConsume("api url");
```
Afterwards, you can use it in the controller you will use by requesting it from the DI container.

## The methods and parameters

Generic class methods

```CSharp

Task<List<T>> GetListAsync(string endpoint)
Task<T> GetByIdAsync(string endpoint, int id)
Task<List<T>> GetListByIdAsync(string endpoint, int id)
Task<int> PostAsync(string endpoint, object modelClass)
Task<int> PutAsync(string endpoint, object modelClass)
Task<int> DeleteAsync(string endpoint, int id)

```
Non generic class methods
```CSharp
Task<string> GetStringAsync(string endpoint)
Task<int> GetIntAsync(string endpoint)
```
Example Usage:

```CSharp

public class MyDataModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class MyService
{
    private readonly Consume<MyDataModel> _consume;

    public MyService(Consume<MyDataModel> consume)
    {
        _consume = consume;
    }

    public async Task<List<MyDataModel>> GetAllData()
    {
        return await _consume.GetListAsync("/data");
    }

    public async Task<MyDataModel> GetDataById(int id)
    {
        return await _consume.GetByIdAsync("/data", id);
    }

    public async Task<int> CreateData(MyDataModel model)
    {
        return await _consume.PostAsync("/data", model);
    }

    public async Task<int> UpdateData(MyDataModel model)
    {
        return await _consume.PutAsync("/data", model);
    }

    public async Task<int> DeleteData(int id)
    {
        return await _consume.DeleteAsync("/data", id);
    }
}

```


## License

This project is licensed under the MIT License. See the LICENSE file for more information.


