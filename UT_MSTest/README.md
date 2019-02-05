# MSTest

- 2019/02/05
- dotnet 2.2.103

```powershell
> mkdir UT_MSTest
> cd UT_MSTest
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
> dotnet new mstest
# 建立測試用專案 MSTest

> dotnet add reference ../PrimeService/PrimeService.csproj
# 在 PrimeService.Test/PrimeService.Tests.csproj 新增參考(專門用來測試 /PrimeService/PrimeService.csproj)

> Rename-Item UnitTest1.cs PrimeService_IsPrimeShould.cs
# Coding PrimeService_IsPrimeShould.cs
# [TestClass] : 包含單元測試的類別
# [TestMethod]: 測試方法

> cd ..
> dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
# 將測試用專案, 新增至 /UT_MSTest.sln

# 在 / 底下執行測試
> dotnet test
# 測試必然失敗, 開始 Coding, 好讓測試可以成功
# 開始 Coding /PrimeService/PrimeService.cs
```