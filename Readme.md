# Dynamic Consume
## Purpose



This package was prepared to eliminate the code confusion experienced when consuming the API in a .Net Core application.


## Installation

You can add the package to your project via the Nuget package manager or cli

```sh
dotnet add package DynamicConsume --version 1.0.1
```

## Usage

After installing the package, you must first register for the service in the Program.cs file.

```sh
builder.Services.AddDynamicConsume();
```
Afterwards, you can use it in the controller you will use by requesting it from the DI container.
Example Usage:

```CSharp
 public class HomeController : Controller
    {

        private readonly Consume<WeatherDto> _consume;

        public HomeController(Consume<WeatherDto> consume)
        {
            _consume = consume;

        }
         public async Task<IActionResult> GetConsume()
        {
            var values = await _consume.GetListAsync("https://localhost:44367/WeatherForecast");
            var result = values;
            return View(values);
        }
    }
}
```
Example Usage 2:
```CSharp
 public class HomeController : Controller
    {

        private readonly Consume _consume1;

        public HomeController(Consume consume1)
        {
            _consume1 = consume1;
        }

        public async Task<IActionResult> GetString()
        {
            var values = await _consume1.GetStringAsync("https://localhost:44367/api/Values/GetString");
            var result = values;
            return View(values);
        }
    }
}
```
## Development

## License


