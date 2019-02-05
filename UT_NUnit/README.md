# NUnit

- 2019/02/05

```powershell
> mkdir UT_NUnit
> cd UT_NUnit
> dotnet new sln
> mkdir PrimeService
> cd PrimeService
> dotnet new classlib
> Rename-Item .\Class1.cs PrimeService.cs
# Coding PrimeService.cs

> cd ..
> dotnet sln add PrimeService/PrimeService.csproj
# 將裏頭的 classlib 專案, 加入至 PrimeService 主專案之中

> mkdir PrimeService.Tests
> cd PrimeService.Tests
> dotnet new nunit
# 建立測試用專案 NUnit

> dotnet add reference ../PrimeService/PrimeService.csproj
# 在 PrimeService.Test/PrimeService.Tests.csproj 新增參考(專門用來測試 /PrimeService/PrimeService.csproj)

> Rename-Item UnitTest1.cs PrimeService_IsPrimeShould.cs
# Coding PrimeService_IsPrimeShould.cs
# [TestFixture] : 包含單元測試的類別
# [Test]: 測試方法

> cd ..
> dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
# 將測試用專案, 新增至 /UT_Nunit.sln

> dotnet test
# 測試必然失敗, 開始 Coding, 好讓測試可以成功
# 開始 Coding /PrimeService/PrimeService.cs

> 
```