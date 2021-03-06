# Narato.ExecutionTimingMiddleware
This library contains middleware for timing requests

It will time the request processing time in an unintrusive way. It will add a response header with the timing in ms.

Getting started
==========
### 1. Add dependency in your project's csproj file

```xml
<PackageReference Include="Narato.ExecutionTimingMiddleware" Version="2.0.0" />
```

### 2. Configure Startup.cs
In the Configure method, add following line:
```C#
app.UseExecutionTiming();
```
This line has to be **above** `app.UseMvc();`


# Helping out

If you want to help out, please read [this wiki page](https://github.com/Narato/Narato.ExecutionTimingMiddleware/wiki/Helping-out)