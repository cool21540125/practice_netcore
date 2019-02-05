# dotnet CLI

- 2019/02/06
- [Using cli](https://docs.microsoft.com/zh-tw/dotnet/core/tutorials/using-with-xplat-cli)

```powershell
# change sdk
> dotnet --list-sdks
1.0.0-preview2-1-003177 [C:\Program Files\dotnet\sdk]
2.1.503 [C:\Program Files\dotnet\sdk]
2.2.103 [C:\Program Files\dotnet\sdk]

> dotnet new globaljson
# Change version in global.json -> 2.1.503

> dotnet --version
2.1.503
```

## dotnet new console

會建立 `PROJECT_NAME.csproj` 及 `Program.cs`(Entry point)

> Starting with .NET Core 2.0 SDK, you don't have to run `dotnet restore` because it's run implicitly by all commands that require a restore to occur, such as `dotnet new`, `dotnet build` and `dotnet run`.

> If you're using a .NET Core 1.x version of the SDK, you'll have to call `dotnet restore` yourself after calling `dotnet new`.

## Compile

by using `dotnet build`, it will compile your code(without running it), and it will produce `DLL file`. After that, just type `dotnet bin\Debug\netcoreapp2.1\PROJ.dll` to run it.



