AgileCoding.Extentions.Loggers NuGet Package
============================================

The AgileCoding.Extentions.Loggers package provides extension methods to enhance logger behavior. These extension methods add convenience and make it easy to write logs of various types.

Features
--------

This package offers extension methods for the ILogger interface from the AgileCoding.Library.Interfaces package:

1.  WriteVerbose - Write verbose log entries.
2.  WriteInformation - Write informational log entries.
3.  WriteWarning - Write warning log entries, optionally with an associated Exception.
4.  WriteError - Write error log entries, optionally with an associated Exception.
5.  WriteCritical - Write critical log entries, optionally with an associated Exception.
6.  IsEnabled - Check if the logger is enabled for a given event type.

How to Use
----------

To use these extension methods in your project, first install the package. Then, create an instance of a class that implements the ILogger interface, and call the extension methods on it.

Here's an example of how you might use the WriteInformation method:

```csharp
using AgileCoding.Library.Interfaces.Logging;
using AgileCoding.Extentions.Loggers;

public class MyClass
{
    private ILogger _logger;

    public MyClass(ILogger logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        // Some code...

        _logger.WriteInformation(0, "Did something");

        // More code...
    }
}
```

Installation
------------

You can install this NuGet package through the following ways:

-   Package Manager: "PM> Install-Package AgileCoding.Extentions.Loggers -Version 2.0.5"
-   .NET CLI: "dotnet add package AgileCoding.Extentions.Loggers --version 2.0.5"

Requirements
------------

.NET 6.0 or later

Contribute
----------

This is an open source project. We encourage you to contribute to it by submitting issues, or directly contributing code.

License
-------

This project is licensed under the terms of the MIT license.

Contact
-------

For questions or any other feedback, please open an issue in the GitHub repository.