<h1 align="center">StockportGovUK.AspNetCore.Middleware.ExceptionHandling</h1>

<div align="center">
  :boom: :fishing_pole_and_fish: :white_check_mark:
</div>
<div align="center">
  <strong>Hold up, let's sort this out!</strong>
</div>
<div align="center">
  Middleware to handle exceptions at the top of an application; logging the error and returning a useful message to the consumer
</div>

<br />

<div align="center">
  <img alt="Application version" src="https://img.shields.io/badge/version-1.0.0-brightgreen.svg?style=flat-square" />
  <img alt="Open Issues" src="https://img.shields.io/github/issues/smbc-digital/StockportGovUK.AspNetCore.Middleware.ExceptionHandling?style=flat-square" />
  <img alt="Stars" src="https://img.shields.io/github/stars/smbc-digital/StockportGovUK.AspNetCore.Middleware.ExceptionHandling?style=flat-square" />
  <img alt="Stability for application" src="https://img.shields.io/badge/stability-experimental-orange.svg?style=flat-square" />
</div>

<div align="center">
  <h3>
    External Links
    <a href="https://github.com/smbc-digital/StockportGovUK.AspNetCore.Middleware.ExceptionHandling">
      GitHub
    </a>
    <span> | </span>
    <a href="https://www.nuget.org/packages/StockportGovUK.AspNetCore.Middleware.ExceptionHandling/">
      NuGet
    </a>
  </h3>
</div>

<div align="center">
  <sub>Built with ❤︎ by
  <a href="https://www.stockport.gov.uk">Stockport Council</a> and
  <a href="">
    contributors
  </a>
</div>

## Table of Contents
- [Features](#features)
- [Example](#example)
- [Philosophy](#philosophy)
- [Installation](#installation)
- [Configuration](#configuration)

## Features
- __Common approach:__ abstracts complication of adding exception handling to an application
- __Logging:__ uses the default logger configured by the application to store information about the exception
- __Error codes:__ returns standard error codes to the consumer, allowing them to handle the error how they see fit

## Example
```c#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...

    app.UseMiddleware<ExceptionHandling>();
    
    ...
}
```

## Philosophy
To ensure all of our applications are handling exceptions and won't return an exception to a consumer we wanted a common way to let exceptions bubble to the top of an application and log the outcome. This package adds a global try catch to an application, if an exception is thrown the message within is set to the configured logging solution and an appropriate error is sent to the consumer

## Installation
```bash
$ dotnet add package StockportGovUK.AspNetCore.Middleware.ExceptionHandling
```

## Configuration
When registering which exception handling middleware needed there are a few options:

| Type | Response | Example |
| --- | --- | --- |
| ExceptionHandling | Return status code 500 | `app.UseMiddleware<ExceptionHandling>();` |
| AppExceptionHandling | Redirect to "/error" | `app.UseMiddleware<AppExceptionHandling>();` |
| ApiExceptionHandling | Return status code 500 | `app.UseMiddleware<ApiExceptionHandling>();` |

## License
[MIT](https://tldrlegal.com/license/mit-license)
